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
        /// Tách đường cong thành các đoạn liền để vẽ mỗi đoạn bằng một LineRenderer.
        /// Cắt tại mẫu NaN/∞, tại bước nhảy (tiệm cận đứng của 1/x, tan x) và bỏ phần |y| &gt; yMax;
        /// chỗ đường cong ra/vào dải |y| ≤ yMax được nội suy thêm một điểm đúng tại y = ±yMax.
        /// Ghi vị trí liên tiếp vào positions (cần ít nhất 2 × samples.Length phần tử), mỗi đoạn là
        /// (chỉ số đầu, số điểm) trong segments. Đoạn dưới 2 điểm bị bỏ; quá segments.Length đoạn thì
        /// bỏ phần còn lại và truncated = true. Trả về số đoạn.
        /// </summary>
        public static int FillCurveSegments(CompiledFunction function, Vector2[] samples, float yMax, float lift,
            Vector3[] positions, Vector2Int[] segments, out bool truncated)
        {
            truncated = false;
            var count = 0;
            var segmentCount = 0;
            var start = -1; // chỉ số đầu của đoạn đang mở trong positions; -1 = không có đoạn mở

            for (var i = 0; i < samples.Length; i++)
            {
                var sample = samples[i];
                var inside = IsFinite(sample.y) && Mathf.Abs(sample.y) <= yMax;
                var connected = i > 0 && IsConnected(function, samples[i - 1], sample, yMax);

                if (inside)
                {
                    if (start >= 0 && !connected)
                    {
                        CloseSegment(ref start, ref count, segments, ref segmentCount);
                    }
                    if (start < 0)
                    {
                        if (segmentCount == segments.Length)
                        {
                            truncated = true;
                            return segmentCount;
                        }
                        start = count;
                        if (connected)
                        {
                            // Đi vào dải |y| ≤ yMax từ mẫu trước nằm ngoài
                            positions[count++] = EdgePoint(samples[i - 1], sample, yMax, lift);
                        }
                    }
                    positions[count++] = new Vector3(sample.x, lift, sample.y);
                }
                else if (start >= 0)
                {
                    if (connected)
                    {
                        // Ra khỏi dải |y| ≤ yMax
                        positions[count++] = EdgePoint(sample, samples[i - 1], yMax, lift);
                    }
                    CloseSegment(ref start, ref count, segments, ref segmentCount);
                }
            }

            if (start >= 0)
            {
                CloseSegment(ref start, ref count, segments, ref segmentCount);
            }
            return segmentCount;
        }

        // Hai mẫu liền nhau nối được khi cả hai hữu hạn và không có bước nhảy giữa chúng. Bước nhảy lớn (> yMax)
        // được kiểm tra bằng trung điểm: hàm liên tục, đơn điệu trên khoảng nhỏ cho f(trung điểm) nằm giữa hai giá trị;
        // qua tiệm cận đứng thì f(trung điểm) vọt ra ngoài hoặc không xác định.
        private static bool IsConnected(CompiledFunction function, Vector2 previous, Vector2 current, float yMax)
        {
            if (!IsFinite(previous.y) || !IsFinite(current.y))
            {
                return false;
            }
            if (Mathf.Abs(current.y - previous.y) <= yMax)
            {
                return true;
            }

            var middle = function.Evaluate((previous.x + current.x) * 0.5);
            return !double.IsNaN(middle) && !double.IsInfinity(middle)
                   && middle >= Mathf.Min(previous.y, current.y) && middle <= Mathf.Max(previous.y, current.y);
        }

        // Điểm trên đoạn nối outside – inside có y = ±yMax (cùng dấu với outside).
        private static Vector3 EdgePoint(Vector2 outside, Vector2 inside, float yMax, float lift)
        {
            var edgeY = Mathf.Sign(outside.y) * yMax;
            var t = (edgeY - inside.y) / (outside.y - inside.y);
            return new Vector3(Mathf.Lerp(inside.x, outside.x, t), lift, edgeY);
        }

        private static void CloseSegment(ref int start, ref int count, Vector2Int[] segments, ref int segmentCount)
        {
            if (count - start >= 2)
            {
                segments[segmentCount++] = new Vector2Int(start, count - start);
            }
            else
            {
                count = start;
            }
            start = -1;
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
