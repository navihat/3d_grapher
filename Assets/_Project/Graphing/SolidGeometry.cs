using UnityEngine;

namespace Grapher.Graphing
{
    /// <summary>
    /// Lưới khối tròn xoay quanh Ox: mặt bên quét bán kính |f(x)| quanh trục Ox, cộng hai nắp tròn ở x = a và x = b.
    /// Quy ước toạ độ giống CurveGeometry: Ox là trục X của GraphRoot nằm trên mặt giấy (Y = 0), góc 0 nằm trên giấy
    /// phía +Z (trùng đường cong), góc tăng thì vòng lên +Y.
    /// Số đỉnh và số chỉ số tam giác cố định theo (số mẫu, số đoạn) để cập nhật không cấp phát bộ nhớ.
    /// </summary>
    public static class SolidGeometry
    {
        // Bố cục đỉnh: [vòng 0 .. vòng n-1] mỗi vòng (segments + 1) đỉnh (đỉnh cuối trùng đỉnh đầu, để làm đường nối),
        // sau đó nắp trái (tâm + vòng), nắp phải (tâm + vòng). Nắp có đỉnh riêng để pháp tuyến phẳng.

        public static int VertexCount(int sampleCount, int segments)
        {
            return sampleCount * (segments + 1) + 2 * (segments + 2);
        }

        public static int TriangleIndexCount(int sampleCount, int segments)
        {
            return (sampleCount - 1) * segments * 6 + 2 * segments * 3;
        }

        /// <summary>
        /// Ghi đỉnh và chỉ số tam giác. Dải giữa hai mẫu có mẫu NaN/∞ bị bỏ (tam giác suy biến 0, 0, 0).
        /// </summary>
        public static void Fill(Vector2[] samples, int segments, float sweepRadians, Vector3[] vertices, int[] triangles)
        {
            var ringSize = segments + 1;
            var sampleCount = samples.Length;

            for (var i = 0; i < sampleCount; i++)
            {
                WriteRing(vertices, i * ringSize, samples[i], segments, sweepRadians);
            }

            var t = 0;
            for (var i = 0; i < sampleCount - 1; i++)
            {
                var valid = IsFinite(samples[i].y) && IsFinite(samples[i + 1].y);
                for (var j = 0; j < segments; j++)
                {
                    var a = i * ringSize + j;
                    var b = a + ringSize;
                    t = valid ? WriteQuad(triangles, t, a, b, a + 1, b + 1) : WriteDegenerate(triangles, t, 6);
                }
            }

            var leftCenter = sampleCount * ringSize;
            var rightCenter = leftCenter + ringSize + 1;
            t = WriteCap(vertices, triangles, t, leftCenter, samples[0], segments, sweepRadians, false);
            WriteCap(vertices, triangles, t, rightCenter, samples[sampleCount - 1], segments, sweepRadians, true);
        }

        private static void WriteRing(Vector3[] vertices, int start, Vector2 sample, int segments, float sweepRadians)
        {
            var radius = IsFinite(sample.y) ? Mathf.Abs(sample.y) : 0f;
            for (var j = 0; j <= segments; j++)
            {
                var angle = sweepRadians * j / segments;
                vertices[start + j] = new Vector3(sample.x, radius * Mathf.Sin(angle), radius * Mathf.Cos(angle));
            }
        }

        // Pháp tuyến hướng ra ngoài: Unity lấy pháp tuyến = Cross(b - a, c - a).
        private static int WriteQuad(int[] triangles, int t, int a, int nextSample, int nextAngle, int both)
        {
            triangles[t] = a;
            triangles[t + 1] = nextSample;
            triangles[t + 2] = nextAngle;
            triangles[t + 3] = nextSample;
            triangles[t + 4] = both;
            triangles[t + 5] = nextAngle;
            return t + 6;
        }

        private static int WriteCap(Vector3[] vertices, int[] triangles, int t, int center, Vector2 sample,
            int segments, float sweepRadians, bool facesPositiveX)
        {
            vertices[center] = new Vector3(sample.x, 0f, 0f);
            WriteRing(vertices, center + 1, sample, segments, sweepRadians);

            if (!IsFinite(sample.y))
            {
                return WriteDegenerate(triangles, t, segments * 3);
            }

            for (var j = 0; j < segments; j++)
            {
                var current = center + 1 + j;
                triangles[t] = center;
                triangles[t + 1] = facesPositiveX ? current + 1 : current;
                triangles[t + 2] = facesPositiveX ? current : current + 1;
                t += 3;
            }
            return t;
        }

        private static int WriteDegenerate(int[] triangles, int t, int count)
        {
            for (var k = 0; k < count; k++)
            {
                triangles[t + k] = 0;
            }
            return t + count;
        }

        private static bool IsFinite(float value)
        {
            return !float.IsNaN(value) && !float.IsInfinity(value);
        }
    }
}
