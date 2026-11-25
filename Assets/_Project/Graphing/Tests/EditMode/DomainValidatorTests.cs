using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Grapher.Graphing.Tests
{
    // S3-05: kiểm tra miền trước khi vẽ — f xác định trên [a, b]; với khối tròn xoay còn cần f(x) ≥ 0.
    // Lỗi trả thông báo tiếng Việt; số viết kiểu Việt Nam (dấu phẩy thập phân), cận viết [a; b] như SGK.
    public class DomainValidatorTests
    {
        private static CompiledFunction Compile(string input, params string[] parameterNames)
        {
            Assert.IsTrue(CompiledFunction.TryCompile(input, out var function, out var error, parameterNames), error);
            return function;
        }

        private static IEnumerable<TestCaseData> ValidSolidCases()
        {
            // Bộ bài POE (learning_design.md), phần B và các hàm trong sprint
            yield return new TestCaseData("2x - x²", 0.0, 2.0).SetName("Bài 3: 2x - x² trên [0; 2]");
            yield return new TestCaseData("√(4 - x²)", -2.0, 2.0).SetName("Bài 4: √(4 - x²) trên [-2; 2], bằng 0 ở hai cận");
            yield return new TestCaseData("sqrt(x)", 0.0, 4.0).SetName("sqrt(x) trên [0; 4], bằng 0 tại a");
            yield return new TestCaseData("sin x", 0.0, Math.PI).SetName("sin x trên [0; π]");
            yield return new TestCaseData("x³", 0.0, 2.0).SetName("x³ trên [0; 2]");
            yield return new TestCaseData("(x - 1)²", 0.0, 2.0).SetName("(x - 1)² chạm Ox tại x = 1");
            // sin(π) tính bằng double cho -1,2e-16: sai số làm tròn không được tính là giá trị âm
            yield return new TestCaseData("-sin x", Math.PI, 2 * Math.PI).SetName("-sin x trên [π; 2π], sai số làm tròn tại π");
            yield return new TestCaseData("ln x", 1.0, Math.E).SetName("ln x trên [1; e]");
            yield return new TestCaseData("1/x", 1.0, 3.0).SetName("1/x trên [1; 3]");
            yield return new TestCaseData("e^x", -1.0, 1.0).SetName("e^x trên [-1; 1]");
        }

        [TestCaseSource(nameof(ValidSolidCases))]
        public void Validate_SolidFunctionDefinedAndNonNegative_ReturnsNull(string input, double a, double b)
        {
            Assert.IsNull(DomainValidator.Validate(Compile(input), a, b, requireNonNegative: true));
        }

        [Test]
        public void Validate_AreaWithSignChange_AllowsNegativeValues()
        {
            // Bài 2: diện tích một chu kỳ sin x, f đổi dấu tại π nhưng vẫn hợp lệ khi chỉ tô miền
            Assert.IsNull(DomainValidator.Validate(Compile("sin x"), 0, 2 * Math.PI, requireNonNegative: false));
        }

        [Test]
        public void Validate_AreaFunctionUndefined_StillReturnsError()
        {
            var error = DomainValidator.Validate(Compile("sqrt(x)"), -1, 4, requireNonNegative: false);

            Assert.AreEqual("Hàm số không xác định tại x = -1 thuộc đoạn [-1; 4].", error);
        }

        private static IEnumerable<TestCaseData> UndefinedCases()
        {
            // Điểm lỗi đầu tiên (quét từ a) nằm đúng tại a nên thông báo không phụ thuộc số mẫu
            yield return new TestCaseData("sqrt(x)", -1.0, 4.0,
                "Hàm số không xác định tại x = -1 thuộc đoạn [-1; 4].").SetName("Căn số âm");
            yield return new TestCaseData("1/x", 0.0, 1.0,
                "Hàm số không xác định tại x = 0 thuộc đoạn [0; 1].").SetName("Chia cho 0 (vô cực)");
            yield return new TestCaseData("ln x", 0.0, 2.0,
                "Hàm số không xác định tại x = 0 thuộc đoạn [0; 2].").SetName("ln 0 (âm vô cực)");
            yield return new TestCaseData("√(4 - x²)", -3.0, 2.0,
                "Hàm số không xác định tại x = -3 thuộc đoạn [-3; 2].").SetName("Cận vượt ra ngoài tập xác định");
            yield return new TestCaseData("sqrt(x)", -0.5, 4.0,
                "Hàm số không xác định tại x = -0,5 thuộc đoạn [-0,5; 4].").SetName("Số thập phân viết dấu phẩy");
        }

        [TestCaseSource(nameof(UndefinedCases))]
        public void Validate_FunctionUndefinedOnRange_ReturnsVietnameseError(string input, double a, double b,
            string expected)
        {
            Assert.AreEqual(expected, DomainValidator.Validate(Compile(input), a, b, requireNonNegative: true));
        }

        [Test]
        public void Validate_UndefinedInsideRange_ReportsPointInsideRange()
        {
            // sqrt(1 - x) không xác định khi x > 1; điểm báo lỗi phải nằm trong (1; 2]
            var error = DomainValidator.Validate(Compile("sqrt(1 - x)"), 0, 2, requireNonNegative: true);

            StringAssert.StartsWith("Hàm số không xác định tại x = 1", error);
            StringAssert.EndsWith(" thuộc đoạn [0; 2].", error);
        }

        private static IEnumerable<TestCaseData> NegativeCases()
        {
            yield return new TestCaseData("x - 1", 0.0, 2.0,
                "Hàm số nhận giá trị âm tại x = 0 thuộc đoạn [0; 2]. Khối tròn xoay cần f(x) ≥ 0 trên cả đoạn.")
                .SetName("Âm tại cận a");
            yield return new TestCaseData("x³", -1.0, 2.0,
                "Hàm số nhận giá trị âm tại x = -1 thuộc đoạn [-1; 2]. Khối tròn xoay cần f(x) ≥ 0 trên cả đoạn.")
                .SetName("x³ với cận âm");
            yield return new TestCaseData("-x²", 0.5, 1.0,
                "Hàm số nhận giá trị âm tại x = 0,5 thuộc đoạn [0,5; 1]. Khối tròn xoay cần f(x) ≥ 0 trên cả đoạn.")
                .SetName("Dấu âm trước luỹ thừa: -x²");
        }

        [TestCaseSource(nameof(NegativeCases))]
        public void Validate_SolidFunctionNegative_ReturnsVietnameseError(string input, double a, double b,
            string expected)
        {
            Assert.AreEqual(expected, DomainValidator.Validate(Compile(input), a, b, requireNonNegative: true));
        }

        [Test]
        public void Validate_SolidSignChangeInsideRange_ReturnsNegativeError()
        {
            // sin x trên [0; 2π]: hợp lệ cho diện tích (Bài 2) nhưng không dựng khối được
            var error = DomainValidator.Validate(Compile("sin x"), 0, 2 * Math.PI, requireNonNegative: true);

            StringAssert.StartsWith("Hàm số nhận giá trị âm tại x = 3", error);
            StringAssert.EndsWith("Khối tròn xoay cần f(x) ≥ 0 trên cả đoạn.", error);
        }

        [Test]
        public void Validate_AsymptoteInsideRange_ReturnsError()
        {
            // tan x có tiệm cận đứng tại π/2 ∈ [0; 2]; lấy mẫu có thể không trúng π/2 nhưng phải báo lỗi
            Assert.IsNotNull(DomainValidator.Validate(Compile("tan x"), 0, 2, requireNonNegative: true));
        }

        [Test]
        public void Validate_NegativeCoefficient_ReturnsNegativeError()
        {
            var function = Compile("k*sqrt(x)", "k");
            Assert.IsNull(DomainValidator.Validate(function, 1, 4, requireNonNegative: true), "k = 1 mặc định");

            function.SetParameter("k", -1);

            StringAssert.StartsWith("Hàm số nhận giá trị âm tại x = 1 ",
                DomainValidator.Validate(function, 1, 4, requireNonNegative: true));
        }

        [TestCase(2.0, 2.0)]
        [TestCase(4.0, 0.0)]
        public void Validate_LowerBoundNotLessThanUpper_ReturnsError(double a, double b)
        {
            Assert.AreEqual("Cận dưới a phải nhỏ hơn cận trên b.",
                DomainValidator.Validate(Compile("sqrt(x)"), a, b, requireNonNegative: true));
        }
    }
}
