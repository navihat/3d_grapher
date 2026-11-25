using System.Globalization;

namespace Grapher.Graphing
{
    /// <summary>
    /// Kiểm tra y = f(x) trước khi vẽ: f xác định trên [a, b]; khi dựng khối tròn xoay còn cần f(x) ≥ 0.
    /// Kiểm tra bằng lấy mẫu đều, nên chỗ hỏng chỉ nằm trong một khoảng hẹp giữa hai mẫu có thể bị bỏ sót.
    /// </summary>
    public static class DomainValidator
    {
        private const int SampleCount = 401;

        // Sai số làm tròn, ví dụ -sin(π) = -1,2e-16, không tính là giá trị âm.
        private const double NegativeTolerance = 1e-9;

        /// <summary>
        /// Trả về null nếu hợp lệ, hoặc thông báo lỗi tiếng Việt chỉ ra điểm hỏng đầu tiên tính từ a.
        /// requireNonNegative = true khi cần dựng khối tròn xoay; false khi chỉ tô miền (f được đổi dấu).
        /// </summary>
        public static string Validate(CompiledFunction function, double a, double b, bool requireNonNegative)
        {
            if (!(a < b))
            {
                return "Cận dưới a phải nhỏ hơn cận trên b.";
            }

            var last = SampleCount - 1;
            for (var i = 0; i <= last; i++)
            {
                var x = a + (b - a) * i / last;
                var y = function.Evaluate(x);

                if (double.IsNaN(y) || double.IsInfinity(y))
                {
                    return $"Hàm số không xác định tại x = {Format(x)} thuộc đoạn [{Format(a)}; {Format(b)}].";
                }
                if (requireNonNegative && y < -NegativeTolerance)
                {
                    return $"Hàm số nhận giá trị âm tại x = {Format(x)} thuộc đoạn [{Format(a)}; {Format(b)}]. " +
                           "Khối tròn xoay cần f(x) ≥ 0 trên cả đoạn.";
                }
            }
            return null;
        }

        // Dấu phẩy thập phân kiểu Việt Nam. Không dùng CultureInfo("vi-VN") vì có thể thiếu trên Android IL2CPP.
        private static string Format(double value)
        {
            return value.ToString("0.##", CultureInfo.InvariantCulture).Replace('.', ',');
        }
    }
}
