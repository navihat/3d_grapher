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

        // S3-06: tách đường cong thành các đoạn liền.
        private const float YMax = 10f;

        private static Vector2Int[] Segments(string expression, float a, float b, int sampleCount,
            out Vector3[] positions, out bool truncated, int maxSegments = 8)
        {
            var function = Compile(expression);
            var samples = new Vector2[sampleCount];
            CurveGeometry.Sample(function, a, b, samples);
            positions = new Vector3[2 * sampleCount];
            var segments = new Vector2Int[maxSegments];

            var count = CurveGeometry.FillCurveSegments(function, samples, YMax, 0.02f, positions, segments,
                out truncated);

            System.Array.Resize(ref segments, count);
            return segments;
        }

        [Test]
        public void FillCurveSegments_ContinuousFunction_OneSegmentOnPaperPlane()
        {
            var segments = Segments("sqrt(x)", 0f, 4f, 5, out var positions, out var truncated);

            Assert.AreEqual(1, segments.Length);
            Assert.AreEqual(new Vector2Int(0, 5), segments[0]);
            Assert.AreEqual(new Vector3(4f, 0.02f, 2f), positions[4], "(x, y) nằm ở (x, lift, y)");
            Assert.IsFalse(truncated);
        }

        [Test]
        public void FillCurveSegments_SteepButContinuous_NotCut()
        {
            // x³ trên [0; 2]: mẫu 0; 0,125; 1; 3,375; 8, dốc dần nhưng liên tục
            var segments = Segments("x³", 0f, 2f, 5, out _, out _);

            Assert.AreEqual(1, segments.Length);
        }

        [Test]
        public void FillCurveSegments_SkipsPointsOutsideDomain()
        {
            var segments = Segments("sqrt(x)", -2f, 2f, 5, out var positions, out _);

            Assert.AreEqual(1, segments.Length);
            Assert.AreEqual(new Vector2Int(0, 3), segments[0], "x = -2, -1 ngoài tập xác định");
            Assert.AreEqual(0f, positions[0].x, Tolerance);
        }

        [Test]
        public void FillCurveSegments_HoleInsideRange_SplitsIntoTwo()
        {
            // x/x không xác định tại x = 0 (mẫu thứ 3 trong 5 mẫu trên [-2; 2])
            var segments = Segments("x/x", -2f, 2f, 5, out _, out _);

            Assert.AreEqual(2, segments.Length);
            Assert.AreEqual(new Vector2Int(0, 2), segments[0]);
            Assert.AreEqual(new Vector2Int(2, 2), segments[1]);
        }

        [Test]
        public void FillCurveSegments_ReciprocalAcrossZero_SplitsWithoutVerticalLine()
        {
            // 200 mẫu trên [-1; 1] không trúng x = 0, nên chỉ có thể cắt nhờ phát hiện bước nhảy
            var segments = Segments("1/x", -1f, 1f, 200, out var positions, out _);

            Assert.AreEqual(2, segments.Length);
            var leftEnd = positions[segments[0].x + segments[0].y - 1];
            var rightStart = positions[segments[1].x];
            Assert.AreEqual(-YMax, leftEnd.z, Tolerance, "Nhánh trái dừng đúng tại y = -yMax");
            Assert.AreEqual(YMax, rightStart.z, Tolerance, "Nhánh phải bắt đầu đúng tại y = yMax");
            Assert.AreEqual(-0.1f, leftEnd.x, 1e-3f);
            Assert.AreEqual(0.1f, rightStart.x, 1e-3f);
        }

        [Test]
        public void FillCurveSegments_TanAcrossAsymptote_SplitsIntoTwo()
        {
            var segments = Segments("tan x", 0f, 3f, 200, out var positions, out _);

            Assert.AreEqual(2, segments.Length);
            Assert.AreEqual(YMax, positions[segments[0].x + segments[0].y - 1].z, Tolerance);
            Assert.AreEqual(-YMax, positions[segments[1].x].z, Tolerance);
        }

        [Test]
        public void FillCurveSegments_JumpBetweenSamplesInsideRange_Cut()
        {
            // tan 1,5 ≈ 14,1 và tan 1,65 ≈ -12,6 đều trong dải |y| ≤ 20 nhưng nằm hai bên tiệm cận π/2:
            // |Δy| > yMax nên kiểm tra trung điểm, tan 1,575 ≈ -237 nằm ngoài [-12,6; 14,1] → cắt
            var function = Compile("tan x");
            var samples = new[] { new Vector2(1.5f, Mathf.Tan(1.5f)), new Vector2(1.65f, Mathf.Tan(1.65f)) };
            var positions = new Vector3[4];
            var segments = new Vector2Int[2];

            var count = CurveGeometry.FillCurveSegments(function, samples, 20f, 0f, positions, segments, out _);

            Assert.AreEqual(0, count, "Hai mẫu bị tách thành hai đoạn 1 điểm, cả hai bị bỏ");
        }

        [Test]
        public void FillCurveSegments_AllPointsAboveYMax_NoSegment()
        {
            var segments = Segments("x + 20", 0f, 4f, 5, out _, out _);

            Assert.AreEqual(0, segments.Length);
        }

        [Test]
        public void FillCurveSegments_ExitsYMax_EndsExactlyAtEdge()
        {
            // 2x trên [0; 8]: mẫu 0, 2, 4, 6, 8 → y = 0, 4, 8, 12, 16; vượt yMax = 10 tại x = 5
            var segments = Segments("2x", 0f, 8f, 5, out var positions, out _);

            Assert.AreEqual(1, segments.Length);
            Assert.AreEqual(new Vector2Int(0, 4), segments[0]);
            Assert.AreEqual(new Vector3(5f, 0.02f, 10f), positions[3]);
        }

        [Test]
        public void FillCurveSegments_MoreSegmentsThanCapacity_Truncated()
        {
            // tan x trên [0; 10] có 3 tiệm cận (π/2, 3π/2, 5π/2) → 4 đoạn, chỉ giữ 2
            var segments = Segments("tan x", 0f, 10f, 400, out _, out var truncated, maxSegments: 2);

            Assert.AreEqual(2, segments.Length);
            Assert.IsTrue(truncated);
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
