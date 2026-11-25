using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Grapher.Core;
using Unity.Collections;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Grapher.Graphing
{
    /// <summary>
    /// Vẽ y = f(x) trên [a, b] dưới GraphRoot: đường cong (LineRenderer), miền giữa đồ thị và Ox (Mesh)
    /// và khối tròn xoay quanh Ox (Mesh).
    /// 1 đơn vị đồ thị = 1 đơn vị local của GraphRoot; phiếu giấy là mặt phẳng XZ.
    /// Hệ số (ví dụ k trong k*sqrt(x)) phải được khai báo bằng SetParameter trước khi gọi Draw.
    /// Đường cong bị cắt tại điểm gián đoạn: mỗi đoạn liền vẽ bằng một LineRenderer, các bản sao của _curve
    /// được tạo sẵn trong Awake; đổi hệ số hoặc cận chỉ ghi lại vị trí đỉnh, không tạo mesh hay object mới.
    /// </summary>
    public class GraphRenderer : MonoBehaviour, IGraphRenderer
    {
        private const int MaxCurveSegments = 8;

        [Header("Thành phần")]
        [SerializeField] private LineRenderer _curve;
        [SerializeField] private MeshFilter _area;
        [SerializeField] private MeshFilter _solid;

        [Header("Lấy mẫu")]
        [Tooltip("Số điểm lấy mẫu trên [a, b]")]
        [SerializeField] private int _sampleCount = 200;

        [Header("Khối tròn xoay")]
        [Tooltip("Số đoạn chia mỗi vòng quanh Ox")]
        [SerializeField] private int _solidSegments = 48;

        [Tooltip("360 = khối đầy đủ (nửa dưới nằm dưới mặt giấy); 180 = chỉ nửa nổi trên giấy")]
        [SerializeField] private float _solidSweepDegrees = 360f;

        [Tooltip("Độ nâng khỏi mặt giấy (đơn vị đồ thị) để không bị nhấp nháy với giấy")]
        [SerializeField] private float _areaLift = 0.01f;
        [SerializeField] private float _curveLift = 0.02f;

        [Tooltip("Chỉ vẽ phần đường cong có |y| không vượt quá giá trị này (đơn vị đồ thị = cm); miền và khối không đổi")]
        [SerializeField] private float _curveYMax = 10f;

        [Header("Vẽ thử khi chạy (để trống thì không vẽ)")]
        [SerializeField] private string _initialExpression = "sqrt(x)";
        [SerializeField] private float _initialA = 0f;
        [SerializeField] private float _initialB = 4f;

        private readonly Dictionary<string, float> _parameters = new Dictionary<string, float>();
        private CompiledFunction _function;
        private float _a;
        private float _b;

        private Vector2[] _samples;
        private LineRenderer[] _curves;
        private Vector3[] _curvePositions;
        private NativeArray<Vector3> _curveNative;
        private Vector2Int[] _curveSegments;
        private bool _warnedTruncated;
        private Vector3[] _areaVertices;
        private Mesh _areaMesh;

        private Vector3[] _solidVertices;
        private int[] _solidTriangles;
        private Mesh _solidMesh;

        private readonly Stopwatch _stopwatch = new Stopwatch();

        /// <summary>Thời gian lấy mẫu f(x) (NCalc) lần dựng gần nhất, mili giây.</summary>
        public double LastSampleMilliseconds { get; private set; }

        /// <summary>Tổng thời gian dựng lại đường cong, miền và khối lần gần nhất, mili giây.</summary>
        public double LastRebuildMilliseconds { get; private set; }

        private void Awake()
        {
            _samples = new Vector2[_sampleCount];
            _curvePositions = new Vector3[_sampleCount * 2];
            _curveNative = new NativeArray<Vector3>(_curvePositions.Length, Allocator.Persistent);
            _curveSegments = new Vector2Int[MaxCurveSegments];
            _curve.useWorldSpace = false;
            _curves = new LineRenderer[MaxCurveSegments];
            _curves[0] = _curve;
            for (var k = 1; k < _curves.Length; k++)
            {
                _curves[k] = CloneCurve(k);
            }
            _areaVertices = new Vector3[_sampleCount * 2];

            var normals = new Vector3[_areaVertices.Length];
            for (var i = 0; i < normals.Length; i++)
            {
                normals[i] = Vector3.up;
            }

            _areaMesh = new Mesh { name = "GraphArea" };
            _areaMesh.MarkDynamic();
            _areaMesh.vertices = _areaVertices;
            _areaMesh.normals = normals;
            _areaMesh.triangles = CurveGeometry.CreateAreaTriangles(_sampleCount);
            _area.sharedMesh = _areaMesh;

            _solidVertices = new Vector3[SolidGeometry.VertexCount(_sampleCount, _solidSegments)];
            _solidTriangles = new int[SolidGeometry.TriangleIndexCount(_sampleCount, _solidSegments)];
            _solidMesh = new Mesh { name = "GraphSolid" };
            if (_solidVertices.Length > ushort.MaxValue)
            {
                _solidMesh.indexFormat = UnityEngine.Rendering.IndexFormat.UInt32;
            }
            _solidMesh.MarkDynamic();
            _solid.sharedMesh = _solidMesh;

            Clear();
        }

        private void Start()
        {
            if (string.IsNullOrEmpty(_initialExpression))
            {
                return;
            }

            var error = Draw(_initialExpression, _initialA, _initialB, transform.parent);
            if (error != null)
            {
                Debug.LogWarning(error, this);
                return;
            }

            Debug.Log($"[GraphRenderer] {_initialExpression}: dựng lại {LastRebuildMilliseconds:F2} ms " +
                      $"(lấy mẫu {LastSampleMilliseconds:F2} ms), {_sampleCount} mẫu × {_solidSegments} đoạn, " +
                      $"{_solidVertices.Length} đỉnh khối", this);
        }

        private void OnDestroy()
        {
            Destroy(_areaMesh);
            Destroy(_solidMesh);
            for (var k = 1; k < _curves.Length; k++)
            {
                if (_curves[k] != null)
                {
                    Destroy(_curves[k].gameObject);
                }
            }
            if (_curveNative.IsCreated)
            {
                _curveNative.Dispose();
            }
        }

        // Bản sao chỉ có LineRenderer (không Instantiate cả GameObject của _curve, vì nó có thể mang GraphRenderer).
        private LineRenderer CloneCurve(int index)
        {
            var source = _curve.transform;
            var clone = new GameObject(_curve.name + " " + index);
            clone.layer = _curve.gameObject.layer;
            clone.transform.SetParent(source.parent, false);
            clone.transform.SetLocalPositionAndRotation(source.localPosition, source.localRotation);
            clone.transform.localScale = source.localScale;

            var line = clone.AddComponent<LineRenderer>();
            line.sharedMaterials = _curve.sharedMaterials;
            line.widthCurve = _curve.widthCurve;
            line.widthMultiplier = _curve.widthMultiplier;
            line.colorGradient = _curve.colorGradient;
            line.numCornerVertices = _curve.numCornerVertices;
            line.numCapVertices = _curve.numCapVertices;
            line.alignment = _curve.alignment;
            line.textureMode = _curve.textureMode;
            line.shadowCastingMode = _curve.shadowCastingMode;
            line.receiveShadows = _curve.receiveShadows;
            line.sortingLayerID = _curve.sortingLayerID;
            line.sortingOrder = _curve.sortingOrder;
            line.useWorldSpace = false;
            line.loop = false;
            line.enabled = _curve.enabled;
            return line;
        }

        public string Draw(string expression, float a, float b, Transform parent)
        {
            if (!CompiledFunction.TryCompile(expression, out var function, out var error, _parameters.Keys.ToArray()))
            {
                return error;
            }

            foreach (var parameter in _parameters)
            {
                function.SetParameter(parameter.Key, parameter.Value);
            }

            _function = function;
            _warnedTruncated = false;
            if (parent != null && transform.parent != parent)
            {
                transform.SetParent(parent, false);
            }
            return UpdateRange(a, b);
        }

        public string UpdateRange(float a, float b)
        {
            if (_function == null)
            {
                return "Chưa có hàm số để vẽ.";
            }
            if (!(a < b))
            {
                return "Cận dưới a phải nhỏ hơn cận trên b.";
            }

            _a = a;
            _b = b;
            Rebuild();
            return null;
        }

        public void SetParameter(string name, float value)
        {
            _parameters[name] = value;
            if (_function == null)
            {
                return;
            }

            _function.SetParameter(name, value);
            Rebuild();
        }

        public void SetLayerVisible(GraphLayer layer, bool visible)
        {
            switch (layer)
            {
                case GraphLayer.Curve:
                    foreach (var curve in _curves)
                    {
                        curve.enabled = visible;
                    }
                    break;
                case GraphLayer.Area:
                    _area.GetComponent<MeshRenderer>().enabled = visible;
                    break;
                case GraphLayer.Solid:
                    _solid.GetComponent<MeshRenderer>().enabled = visible;
                    break;
            }
        }

        public void Clear()
        {
            _function = null;
            foreach (var curve in _curves)
            {
                curve.positionCount = 0;
            }
            for (var i = 0; i < _areaVertices.Length; i++)
            {
                _areaVertices[i] = Vector3.zero;
            }
            _areaMesh.vertices = _areaVertices;
            _areaMesh.RecalculateBounds();

            Array.Clear(_solidVertices, 0, _solidVertices.Length);
            Array.Clear(_solidTriangles, 0, _solidTriangles.Length);
            _solidMesh.vertices = _solidVertices;
            _solidMesh.triangles = _solidTriangles;
            _solidMesh.RecalculateBounds();
        }

        private void Rebuild()
        {
            _stopwatch.Restart();
            CurveGeometry.Sample(_function, _a, _b, _samples);
            LastSampleMilliseconds = _stopwatch.Elapsed.TotalMilliseconds;

            var segmentCount = CurveGeometry.FillCurveSegments(_function, _samples, _curveYMax, _curveLift,
                _curvePositions, _curveSegments, out var truncated);
            var used = segmentCount > 0 ? _curveSegments[segmentCount - 1].x + _curveSegments[segmentCount - 1].y : 0;
            NativeArray<Vector3>.Copy(_curvePositions, _curveNative, used);
            for (var k = 0; k < _curves.Length; k++)
            {
                if (k < segmentCount)
                {
                    var segment = _curveSegments[k];
                    _curves[k].positionCount = segment.y;
                    _curves[k].SetPositions(_curveNative.GetSubArray(segment.x, segment.y));
                }
                else
                {
                    _curves[k].positionCount = 0;
                }
            }
            if (truncated && !_warnedTruncated)
            {
                _warnedTruncated = true;
                Debug.LogWarning($"[GraphRenderer] Đường cong có hơn {MaxCurveSegments} đoạn, chỉ vẽ {MaxCurveSegments} đoạn đầu.", this);
            }

            CurveGeometry.FillAreaVertices(_samples, _areaVertices, _areaLift);
            _areaMesh.vertices = _areaVertices;
            _areaMesh.RecalculateBounds();

            SolidGeometry.Fill(_samples, _solidSegments, _solidSweepDegrees * Mathf.Deg2Rad,
                _solidVertices, _solidTriangles);
            _solidMesh.vertices = _solidVertices;
            _solidMesh.triangles = _solidTriangles;
            _solidMesh.RecalculateNormals();
            _solidMesh.RecalculateBounds();

            LastRebuildMilliseconds = _stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}
