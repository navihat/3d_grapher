using System;
using System.Globalization;
using NCalc;

namespace Grapher.Graphing
{
    /// <summary>
    /// Hàm y = f(x) đã biên dịch từ biểu thức kiểu sách giáo khoa. Biên dịch một lần, gọi Evaluate nhiều lần.
    /// </summary>
    public sealed class CompiledFunction
    {
        private readonly Expression _expression;

        private CompiledFunction(string source, string nCalcText, Expression expression)
        {
            Source = source;
            NCalcText = nCalcText;
            _expression = expression;
        }

        /// <summary>Biểu thức gốc người dùng nhập.</summary>
        public string Source { get; }

        /// <summary>Biểu thức sau tiền xử lý, dạng NCalc (để debug).</summary>
        public string NCalcText { get; }

        /// <summary>
        /// Biên dịch biểu thức. Trả về false và thông báo lỗi tiếng Việt nếu sai cú pháp.
        /// parameterNames là các hệ số được phép dùng (ví dụ "k" trong "k*sqrt(x)"), mặc định bằng 1.
        /// </summary>
        public static bool TryCompile(string input, out CompiledFunction function, out string error,
            params string[] parameterNames)
        {
            function = null;
            string nCalcText;
            try
            {
                nCalcText = ExpressionPreprocessor.ToNCalc(input, parameterNames);
            }
            catch (FormatException ex)
            {
                error = ex.Message;
                return false;
            }

            var expression = new Expression(nCalcText);
            if (expression.HasErrors())
            {
                error = "Biểu thức không hợp lệ.";
                return false;
            }

            foreach (var name in parameterNames)
            {
                expression.Parameters[name.ToLowerInvariant()] = 1.0;
            }

            function = new CompiledFunction(input, nCalcText, expression);
            error = null;
            return true;
        }

        /// <summary>Đổi giá trị một hệ số đã khai báo khi biên dịch.</summary>
        public void SetParameter(string name, double value)
        {
            _expression.Parameters[name.ToLowerInvariant()] = value;
        }

        /// <summary>
        /// Tính f(x). Ngoài tập xác định trả về NaN hoặc vô cực (ví dụ sqrt(-1), 1/0); nơi gọi tự bỏ các điểm đó.
        /// </summary>
        public double Evaluate(double x)
        {
            _expression.Parameters[ExpressionPreprocessor.Variable] = x;
            return Convert.ToDouble(_expression.Evaluate(), CultureInfo.InvariantCulture);
        }
    }
}
