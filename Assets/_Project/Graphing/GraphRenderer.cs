using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Grapher.Core;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Grapher.Graphing
{
    /// <summary>
    /// Vẽ y = f(x) trên [a, b] dưới GraphRoot: đường cong (LineRenderer), miền giữa đồ thị và Ox (Mesh)
    /// và khối tròn xoay quanh Ox (Mesh).
    /// 1 đơn vị đồ thị = 1 đơn vị local của GraphRoot; phiếu giấy là mặt phẳng XZ.
    /// Hệ số (ví dụ k trong k*sqrt(x)) phải được khai báo bằng SetParameter trước khi gọi Draw.
    /// </summary>
    public class GraphRenderer : MonoBehaviour, IGraphRenderer
    {
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

        [Header("Vẽ thử khi chạy (để trống thì không vẽ)")]
        [SerializeField] private string _initialExpression = "sqrt(x)";
        [SerializeField] private float _initialA = 0f;
        [SerializeField] private float _initialB = 4f;

        private readonly Dictionary<string, float> _parameters = new Dictionary<string, float>();
        private CompiledFunction _function;
        private float _a;
        private float _b;

        private Vector2[] _samples;
        private Vector3[] _curvePositions;
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
            _curvePositions = new Vector3[_sampleCount];
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

            _curve.useWorldSpace = false;
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
                    _curve.enabled = visible;
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
            _curve.positionCount = 0;
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

            var count = CurveGeometry.FillCurvePositions(_samples, _curvePositions, _curveLift);
            _curve.positionCount = count;
            _curve.SetPositions(_curvePositions);

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
