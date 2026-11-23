using UnityEngine;

namespace Grapher.Core
{
    /// <summary>
    /// Cung cấp thông tin gốc tọa độ và trạng thái tracking của một marker.
    /// Module Graphing và Exercises sử dụng interface này để định vị đồ thị mà không phụ thuộc trực tiếp vào Vuforia.
    /// </summary>
    public interface ITargetOrigin
    {
        /// <summary>
        /// Mã định danh của target (ví dụ: "worksheet_lesson13_01").
        /// </summary>
        string TargetId { get; }

        /// <summary>
        /// Transform gốc O (0,0,0) đã được căn chỉnh trùng khớp với hệ trục in trên giấy.
        /// </summary>
        Transform OriginTransform { get; }

        /// <summary>
        /// True nếu marker đang được camera theo dõi trực tiếp hoặc qua Extended Tracking.
        /// </summary>
        bool IsTracked { get; }
    }
}
