using NUnit.Framework;
using UnityEngine;

namespace Grapher.Graphing.Tests
{
    // S2-11: lấy mẫu đồ thị và dựng lưới miền tô.
    public class CurveGeometryTests
    {
        private const float Tolerance = 1e-5f;

        private static CompiledFunction Compile(string expression)
        {
            Assert.IsTrue(CompiledFunction.TryCompile(expression, out var function, out var error), error);
            return function;
        }

        [Test]
        public void Sample_SqrtOnZeroToFour_SamplesEvenlyIncludingEndpoints()
        {
            var samples = new Vector2[5];

            CurveGeometry.Sample(Compile("sqrt(x)"), 0f, 4f, samples);

            for (var i = 0; i < 5; i++)
            {
                Assert.AreEqual(i, samples[i].x, Tolerance);
                Assert.AreEqual(Mathf.Sqrt(i), samples[i].y, Tolerance);
            }
        }

        [Test]
        public void FillCurvePositions_MapsGraphPointToPaperPlane()
        {
            var samples = new[] { new Vector2(2f, 3f) };
            var positions = new Vector3[1];

            var count = CurveGeometry.FillCurvePositions(samples, positions, 0.02f);

            Assert.AreEqual(1, count);
            Assert.AreEqual(new Vector3(2f, 0.02f, 3f), positions[0]);
        }

        [Test]
        public void FillCurvePositions_SkipsPointsOutsideDomain()
        {
            var samples = new Vector2[5];
            var positions = new Vector3[5];
            CurveGeometry.Sample(Compile("sqrt(x)"), -2f, 2f, samples);

            var count = CurveGeometry.FillCurvePositions(samples, positions, 0f);

            Assert.AreEqual(3, count, "x = -2, -1 ngoài tập xác định");
            Assert.AreEqual(0f, positions[0].x, Tolerance);
        }

        [Test]
        public void CreateAreaTriangles_IndicesCoverEveryStripWithinRange()
        {
            var triangles = CurveGeometry.CreateAreaTriangles(4);

            Assert.AreEqual(3 * 6, triangles.Length);
            foreach (var index in triangles)
            {
                Assert.That(index, Is.InRange(0, 4 * 2 - 1));
            }
        }

        [Test]
        public void FillAreaVertices_PairsAxisAndCurveVertices()
        {
            var samples = new[] { new Vector2(1f, 2f), new Vector2(2f, -1f) };
            var vertices = new Vector3[4];

            CurveGeometry.FillAreaVertices(samples, vertices, 0.01f);

            Assert.AreEqual(new Vector3(1f, 0.01f, 0f), vertices[0]);
            Assert.AreEqual(new Vector3(1f, 0.01f, 2f), vertices[1]);
            Assert.AreEqual(new Vector3(2f, 0.01f, 0f), vertices[2]);
            Assert.AreEqual(new Vector3(2f, 0.01f, -1f), vertices[3], "Phần dưới Ox vẫn được tô");
        }

        [Test]
        public void FillAreaVertices_PointOutsideDomain_CollapsesToAxis()
        {
            var samples = new[] { new Vector2(0f, float.NaN), new Vector2(1f, float.PositiveInfinity) };
            var vertices = new Vector3[4];

            CurveGeometry.FillAreaVertices(samples, vertices, 0f);

            Assert.AreEqual(0f, vertices[1].z);
            Assert.AreEqual(0f, vertices[3].z);
        }
    }
}
