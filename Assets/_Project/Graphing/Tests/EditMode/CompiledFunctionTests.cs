using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Grapher.Graphing.Tests
{
    // S2-09: biểu thức kiểu sách giáo khoa → giá trị đúng; lỗi cú pháp → thông báo tiếng Việt.
    public class CompiledFunctionTests
    {
        private const double Tolerance = 1e-9;

        private static IEnumerable<TestCaseData> ValueCases()
        {
            // Nhân ngầm, luỹ thừa, dấu âm
            yield return new TestCaseData("2x", 3.0, 6.0);
            yield return new TestCaseData("-2^2", 0.0, -4.0);
            yield return new TestCaseData("-x^2", 3.0, -9.0);
            yield return new TestCaseData("(-2)^2", 0.0, 4.0);
            yield return new TestCaseData("x²", 3.0, 9.0);
            yield return new TestCaseData("2x²", 3.0, 18.0);
            yield return new TestCaseData("-2²", 0.0, -4.0);
            yield return new TestCaseData("x³ - 3x", 2.0, 2.0);
            yield return new TestCaseData("2^3^2", 0.0, 512.0);
            yield return new TestCaseData("x^-1", 4.0, 0.25);
            yield return new TestCaseData("x^(1/2)", 9.0, 3.0);
            yield return new TestCaseData("1/2x", 4.0, 2.0);
            yield return new TestCaseData("(x+1)(x-1)", 3.0, 8.0);
            yield return new TestCaseData("x(x+1)", 2.0, 6.0);
            yield return new TestCaseData("1 + 2 * 3 - 4 / 2", 0.0, 5.0);

            // Hàm lượng giác, viết có và không có ngoặc
            yield return new TestCaseData("sin x", 1.0, Math.Sin(1));
            yield return new TestCaseData("sinx", 1.0, Math.Sin(1));
            yield return new TestCaseData("sin 2x", 1.0, Math.Sin(2));
            yield return new TestCaseData("sin x cos x", 1.0, Math.Sin(1) * Math.Cos(1));
            yield return new TestCaseData("sin x + 1", 1.0, Math.Sin(1) + 1);
            yield return new TestCaseData("2sin x", 1.0, 2 * Math.Sin(1));
            yield return new TestCaseData("sin²x", 1.0, Math.Sin(1) * Math.Sin(1));
            yield return new TestCaseData("sin(x)^2", 1.0, Math.Sin(1) * Math.Sin(1));
            yield return new TestCaseData("SIN(X)", 1.0, Math.Sin(1));
            yield return new TestCaseData("tg x", 1.0, Math.Tan(1));
            yield return new TestCaseData("cot x", 1.0, 1 / Math.Tan(1));

            // Căn, trị tuyệt đối, log, mũ, hằng số
            yield return new TestCaseData("sqrt(x)", 4.0, 2.0);
            yield return new TestCaseData("√x", 9.0, 3.0);
            yield return new TestCaseData("√(x+7)", 9.0, 4.0);
            yield return new TestCaseData("3√x", 4.0, 6.0);
            yield return new TestCaseData("|x - 3|", 1.0, 2.0);
            yield return new TestCaseData("2|x|", -2.0, 4.0);
            yield return new TestCaseData("ln x", Math.E, 1.0);
            yield return new TestCaseData("log 100", 0.0, 2.0);
            yield return new TestCaseData("e^x", 1.0, Math.E);
            yield return new TestCaseData("2πx", 1.0, 2 * Math.PI);
            yield return new TestCaseData("pi", 0.0, Math.PI);

            // Cách viết kiểu Việt Nam / ký tự Unicode
            yield return new TestCaseData("0,5x", 4.0, 2.0);
            yield return new TestCaseData("3 − 2x", 1.0, 1.0);
            yield return new TestCaseData("2 × x ÷ 4", 2.0, 1.0);

            // S3-05: các hàm trong bộ bài POE (learning_design.md)
            yield return new TestCaseData("x³", 1.5, 3.375);
            yield return new TestCaseData("sin x", Math.PI / 2, 1.0);
            yield return new TestCaseData("2x - x²", 0.5, 0.75);
            yield return new TestCaseData("√(4 - x²)", 1.0, Math.Sqrt(3));
        }

        [TestCaseSource(nameof(ValueCases))]
        public void Evaluate_TextbookExpression_ReturnsExpectedValue(string input, double x, double expected)
        {
            Assert.IsTrue(CompiledFunction.TryCompile(input, out var function, out var error), error);

            Assert.AreEqual(expected, function.Evaluate(x), Tolerance, function.NCalcText);
        }

        private static IEnumerable<TestCaseData> ErrorCases()
        {
            yield return new TestCaseData("", "Chưa nhập biểu thức.");
            yield return new TestCaseData("   ", "Chưa nhập biểu thức.");
            yield return new TestCaseData("2 *", "Thiếu số hoặc biến sau '*'.");
            yield return new TestCaseData("*x", "Thiếu số hoặc biến trước '*'.");
            yield return new TestCaseData("(x+1", "Thiếu dấu ngoặc đóng ')'.");
            yield return new TestCaseData("x+1)", "Thừa dấu ngoặc đóng ')'.");
            yield return new TestCaseData("()", "Thiếu số hoặc biến trước dấu ')'.");
            yield return new TestCaseData("|x", "Thiếu dấu '|' đóng giá trị tuyệt đối.");
            yield return new TestCaseData("sin", "Hàm sin thiếu đối số.");
            yield return new TestCaseData("x 2", "Thiếu phép toán trước số '2'.");
            yield return new TestCaseData("1.2.3", "Số không hợp lệ: '1.2.3'.");
            yield return new TestCaseData("2 $ x", "Ký tự không hợp lệ: '$'.");
            yield return new TestCaseData("y = x^2", "Không nhận ra 'y'. Chỉ dùng biến x và các hàm sin, cos, tan, cot, sqrt, ln, log, exp, abs.");
            yield return new TestCaseData("= x^2", "Chỉ nhập vế phải của hàm số, ví dụ x^2 + 1 thay vì y = x^2 + 1.");
        }

        [TestCaseSource(nameof(ErrorCases))]
        public void TryCompile_InvalidExpression_ReturnsVietnameseError(string input, string expectedError)
        {
            Assert.IsFalse(CompiledFunction.TryCompile(input, out var function, out var error));

            Assert.IsNull(function);
            Assert.AreEqual(expectedError, error);
        }

        [Test]
        public void SetParameter_DeclaredCoefficient_ChangesResult()
        {
            Assert.IsTrue(CompiledFunction.TryCompile("k*sqrt(x)", out var function, out var error, "k"), error);

            Assert.AreEqual(2.0, function.Evaluate(4), Tolerance, "Hệ số mặc định bằng 1");
            function.SetParameter("k", 3);
            Assert.AreEqual(6.0, function.Evaluate(4), Tolerance);
        }

        [Test]
        public void TryCompile_UndeclaredCoefficient_ReturnsError()
        {
            Assert.IsFalse(CompiledFunction.TryCompile("k*sqrt(x)", out _, out var error));

            StringAssert.StartsWith("Không nhận ra 'k'", error);
        }

        [Test]
        public void Evaluate_OutsideDomain_ReturnsNaNOrInfinity()
        {
            Assert.IsTrue(CompiledFunction.TryCompile("sqrt(x)", out var root, out _));
            Assert.IsTrue(CompiledFunction.TryCompile("1/x", out var reciprocal, out _));

            Assert.IsTrue(double.IsNaN(root.Evaluate(-1)));
            Assert.IsTrue(double.IsInfinity(reciprocal.Evaluate(0)));
        }
    }
}
