using UnityEngine;

namespace Grapher.Graphing
{
    /// <summary>
    /// Chỉ dùng trong scene Sandbox (S3-06): chọn hàm mẫu, kéo hệ số k và cận a, b bằng thanh trượt OnGUI
    /// (chạy được trên Android), hiện thời gian dựng lại để đo trên máy thật.
    /// Để trống Initial Expression của GraphRenderer để hai script không cùng vẽ lúc Start.
    /// </summary>
    public class GraphSandbox : MonoBehaviour
    {
        private const string Coefficient = "k";

        [SerializeField] private GraphRenderer _renderer;

        [Tooltip("Hàm mẫu, dùng hệ số k")]
        [SerializeField] private string[] _expressions = { "k*sqrt(x)", "k*(2x - x²)", "k*sin x", "k/x", "k*tan x" };

        [SerializeField] private float _k = 1f;
        [SerializeField] private float _a = 0f;
        [SerializeField] private float _b = 4f;

        private int _selected;
        private string _error;
        private double _maxRebuildMilliseconds;

        private void Start()
        {
            _renderer.SetParameter(Coefficient, _k);
            DrawSelected();
        }

        private void DrawSelected()
        {
            _maxRebuildMilliseconds = 0;
            _error = _renderer.Draw(_expressions[_selected], _a, _b, null);
            RecordTiming();
        }

        private void RecordTiming()
        {
            if (_error == null && _renderer.LastRebuildMilliseconds > _maxRebuildMilliseconds)
            {
                _maxRebuildMilliseconds = _renderer.LastRebuildMilliseconds;
            }
        }

        private void OnGUI()
        {
            var scale = Screen.dpi > 0 ? Screen.dpi / 160f : 1f;
            GUI.matrix = Matrix4x4.Scale(new Vector3(scale, scale, 1f));
            var width = Screen.width / scale - 20f;

            GUILayout.BeginArea(new Rect(10f, 10f, width, Screen.height / scale - 20f));

            var selected = GUILayout.SelectionGrid(_selected, _expressions, _expressions.Length);
            if (selected != _selected)
            {
                _selected = selected;
                DrawSelected();
            }

            var k = Slider("k", _k, -3f, 3f);
            var a = Slider("a", _a, -5f, 5f);
            var b = Slider("b", _b, -5f, 10f);

            if (!Mathf.Approximately(k, _k))
            {
                _k = k;
                _renderer.SetParameter(Coefficient, _k);
                RecordTiming();
            }
            if (!Mathf.Approximately(a, _a) || !Mathf.Approximately(b, _b))
            {
                _a = a;
                _b = b;
                _error = _renderer.UpdateRange(_a, _b);
                RecordTiming();
            }

            GUILayout.Label($"Dựng lại: {_renderer.LastRebuildMilliseconds:F2} ms " +
                            $"(lấy mẫu {_renderer.LastSampleMilliseconds:F2} ms), lớn nhất {_maxRebuildMilliseconds:F2} ms");
            if (_error != null)
            {
                GUILayout.Label(_error);
            }

            GUILayout.EndArea();
        }

        private static float Slider(string label, float value, float min, float max)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label($"{label} = {value:F2}", GUILayout.Width(90f));
            value = GUILayout.HorizontalSlider(value, min, max, GUILayout.ExpandWidth(true), GUILayout.Height(30f));
            GUILayout.EndHorizontal();
            return value;
        }
    }
}
