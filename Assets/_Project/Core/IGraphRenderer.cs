using UnityEngine;

namespace Grapher.Core
{
    /// <summary>
    /// Vẽ đồ thị y = f(x), miền tô và khối tròn xoay quanh Ox.
    /// Module Exercises gọi qua interface này, không phụ thuộc trực tiếp vào Graphing.
    /// </summary>
    public interface IGraphRenderer
    {
        /// <summary>
        /// Vẽ y = f(x) trên [a, b], làm con của parent (thường là GraphRoot).
        /// Trả về null nếu thành công, hoặc thông báo lỗi tiếng Việt để hiện cho học sinh.
        /// </summary>
        string Draw(string expression, float a, float b, Transform parent);

        /// <summary>
        /// Đổi cận [a, b] của đồ thị đang vẽ, chỉ cập nhật đỉnh, không tạo mesh mới.
        /// Trả về null nếu thành công, hoặc thông báo lỗi tiếng Việt.
        /// </summary>
        string UpdateRange(float a, float b);

        /// <summary>
        /// Đổi giá trị một hệ số trong biểu thức, ví dụ "k" trong "k*sqrt(x)".
        /// </summary>
        void SetParameter(string name, float value);

        /// <summary>
        /// Bật/tắt từng lớp hình.
        /// </summary>
        void SetLayerVisible(GraphLayer layer, bool visible);

        /// <summary>
        /// Xoá toàn bộ hình đã vẽ.
        /// </summary>
        void Clear();
    }

    public enum GraphLayer
    {
        Curve,
        Area,
        Solid
    }
}
