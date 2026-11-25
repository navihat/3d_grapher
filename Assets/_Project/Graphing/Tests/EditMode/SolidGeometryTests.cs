using NUnit.Framework;
using UnityEngine;

namespace Grapher.Graphing.Tests
{
    // S2-10: lưới khối tròn xoay quanh Ox.
    public class SolidGeometryTests
    {
        private const float Tolerance = 1e-4f;
        private const int Segments = 8;

        private static void Build(Vector2[] samples, float sweepRadians, out Vector3[] vertices, out int[] triangles)
        {
            vertices = new Vector3[SolidGeometry.VertexCount(samples.Length, Segments)];
            triangles = new int[SolidGeometry.TriangleIndexCount(samples.Length, Segments)];
            SolidGeometry.Fill(samples, Segments, sweepRadians, vertices, triangles);
        }

        private static Vector2[] SampleOf(string expression, float a, float b, int count)
        {
            Assert.IsTrue(CompiledFunction.TryCompile(expression, out var function, out var error), error);
            var samples = new Vector2[count];
            CurveGeometry.Sample(function, a, b, samples);
            return samples;
        }

        [Test]
        public void Fill_SqrtOnZeroToFour_EveryRingVertexAtRadiusSqrtX()
        {
            var samples = SampleOf("sqrt(x)", 0f, 4f, 5);
            Build(samples, 2 * Mathf.PI, out var vertices, out _);

            for (var i = 0; i < samples.Length; i++)
            {
                for (var j = 0; j <= Segments; j++)
                {
                    var v = vertices[i * (Segments + 1) + j];
                    Assert.AreEqual(samples[i].x, v.x, Tolerance);
                    Assert.AreEqual(Mathf.Sqrt(i), new Vector2(v.y, v.z).magnitude, Tolerance);
                }
            }
        }

        [Test]
        public void Fill_AngleZeroLiesOnCurveOnPaper()
        {
            var samples = new[] { new Vector2(1f, 2f), new Vector2(2f, 3f) };
            Build(samples, 2 * Mathf.PI, out var vertices, out _);

            Assert.AreEqual(new Vector3(1f, 0f, 2f), vertices[0]);
            Assert.AreEqual(new Vector3(2f, 0f, 3f), vertices[Segments + 1]);
        }

        [Test]
        public void Fill_HalfSweep_StaysAbovePaper()
        {
            var samples = SampleOf("sin(x)", 0f, Mathf.PI, 10);
            Build(samples, Mathf.PI, out var vertices, out _);

            foreach (var v in vertices)
            {
                Assert.That(v.y, Is.GreaterThanOrEqualTo(-Tolerance));
            }
        }

        [Test]
        public void Fill_NegativeValue_UsesAbsoluteRadius()
        {
            var samples = new[] { new Vector2(0f, -2f), new Vector2(1f, -2f) };
            Build(samples, 2 * Mathf.PI, out var vertices, out _);

            Assert.AreEqual(2f, new Vector2(vertices[3].y, vertices[3].z).magnitude, Tolerance);
        }

        [Test]
        public void Fill_AllTrianglesIndexValidVertices()
        {
            var samples = SampleOf("sqrt(x)", 0f, 4f, 20);
            Build(samples, 2 * Mathf.PI, out var vertices, out var triangles);

            Assert.AreEqual(0, triangles.Length % 3);
            foreach (var index in triangles)
            {
                Assert.That(index, Is.InRange(0, vertices.Length - 1));
            }
        }

        [Test]
        public void Fill_SideNormalPointsAwayFromAxis()
        {
            var samples = new[] { new Vector2(0f, 1f), new Vector2(1f, 1f) };
            Build(samples, 2 * Mathf.PI, out var vertices, out var triangles);

            var a = vertices[triangles[0]];
            var normal = Vector3.Cross(vertices[triangles[1]] - a, vertices[triangles[2]] - a);
            var outward = new Vector3(0f, a.y, a.z);

            Assert.Greater(Vector3.Dot(normal, outward), 0f);
        }

        [Test]
        public void Fill_SampleOutsideDomain_DropsAdjacentSideTriangles()
        {
            var samples = new[] { new Vector2(0f, float.NaN), new Vector2(1f, 1f), new Vector2(2f, 1f) };
            Build(samples, 2 * Mathf.PI, out var vertices, out var triangles);

            for (var t = 0; t < Segments * 6; t++)
            {
                Assert.AreEqual(0, triangles[t], "Dải giữa mẫu NaN và mẫu kế tiếp phải bị bỏ");
            }
            Assert.AreNotEqual(triangles[Segments * 6], triangles[Segments * 6 + 1], "Dải hợp lệ vẫn còn");
            foreach (var v in vertices)
            {
                Assert.IsFalse(float.IsNaN(v.y) || float.IsNaN(v.z), "Không đỉnh nào là NaN");
            }
        }
    }
}
