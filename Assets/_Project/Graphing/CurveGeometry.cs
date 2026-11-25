using UnityEngine;

namespace Grapher.Graphing
{
    /// <summary>
    /// Tính toán hình học thuần (không cần scene): lấy mẫu y = f(x) và dựng lưới miền giữa đồ thị và Ox.
    /// Quy ước toạ độ: phiếu giấy nằm trên mặt phẳng XZ của GraphRoot, điểm (x, y) của đồ thị nằm ở (x, lift, y).
    /// Mọi mảng do nơi gọi cấp sẵn để đổi cận/hệ số không cấp phát bộ nhớ mới.
    /// </summary>
    public static class CurveGeometry
    {
        /// <summary>
        /// Lấy mẫu đều samples.Length điểm trên [a, b]. y có thể là NaN/∞ ở điểm ngoài tập xác định.
        /// </summary>
        public static void Sample(CompiledFunction function, float a, float b, Vector2[] samples)
        {
            var last = samples.Length - 1;
            for (var i = 0; i <= last; i++)
            {
                var x = a + (b - a) * i / last;
                samples[i] = new Vector2(x, (float)function.Evaluate(x));
            }
        }

        /// <summary>
        /// Chép các điểm hữu hạn thành vị trí cho LineRenderer, bỏ điểm NaN/∞. Trả về số điểm đã chép.
        /// </summary>
        public static int FillCurvePositions(Vector2[] samples, Vector3[] positions, float lift)
        {
            var count = 0;
            foreach (var sample in samples)
            {
                if (IsFinite(sample.y))
                {
                    positions[count++] = new Vector3(sample.x, lift, sample.y);
                }
            }
            return count;
        }

        /// <summary>
        /// Chỉ số tam giác của dải miền tô, chỉ phụ thuộc số mẫu nên tạo một lần.
        /// Đỉnh 2i nằm trên Ox, đỉnh 2i + 1 nằm trên đồ thị tại mẫu thứ i.
        /// </summary>
        public static int[] CreateAreaTriangles(int sampleCount)
        {
            var triangles = new int[(sampleCount - 1) * 6];
            for (var i = 0; i < sampleCount - 1; i++)
            {
                var axis = 2 * i;
                var curve = axis + 1;
                var nextAxis = axis + 2;
                var nextCurve = axis + 3;
                var t = i * 6;
                triangles[t] = axis;
                triangles[t + 1] = curve;
                triangles[t + 2] = nextCurve;
                triangles[t + 3] = axis;
                triangles[t + 4] = nextCurve;
                triangles[t + 5] = nextAxis;
            }
            return triangles;
        }

        /// <summary>
        /// Đỉnh của dải miền tô (2 đỉnh mỗi mẫu). Mẫu NaN/∞ dồn đỉnh đồ thị về Ox nên dải chỗ đó bị bỏ trống.
        /// </summary>
        public static void FillAreaVertices(Vector2[] samples, Vector3[] vertices, float lift)
        {
            for (var i = 0; i < samples.Length; i++)
            {
                var x = samples[i].x;
                var y = IsFinite(samples[i].y) ? samples[i].y : 0f;
                vertices[2 * i] = new Vector3(x, lift, 0f);
                vertices[2 * i + 1] = new Vector3(x, lift, y);
            }
        }

        private static bool IsFinite(float value)
        {
            return !float.IsNaN(value) && !float.IsInfinity(value);
        }
    }
}
