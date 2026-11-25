# Project overview

> Bản nháp 08/11/2026 — nhóm review và chốt.

## Mục tiêu

Học sinh lớp 12 quét phiếu bài tập bằng điện thoại, thấy đồ thị y = f(x) và khối tròn xoay quanh Ox nổi đúng trên hệ trục in sẵn (hướng 10/11, chờ giảng viên xác nhận), rồi làm bài theo chu trình Dự đoán – Quan sát – Giải thích. Chi tiết đề bài, lý thuyết học tập và kế hoạch: `Docs/planning/`.

## Kiến trúc

```
            ┌──────────┐
            │   Core   │  interface chung
            └────┬─────┘
         ┌───────┴───────┐
   ┌─────▼─────┐   ┌─────▼─────┐
   │ Tracking  │   │ Graphing  │   không tham chiếu lẫn nhau
   │   Duy     │   │   Thái    │
   └─────┬─────┘   └─────┬─────┘
         └───────┬───────┘
          ┌──────▼───────┐
          │ Exercises/UI │  gọi cả hai qua interface
          │     Hùng     │
          └──────────────┘
```

Mỗi module có một assembly definition (`Grapher.Core`, `Grapher.Tracking`, `Grapher.Graphing`, `Grapher.Exercises`, `Grapher.UI`).

## Interface giữa các module (đã chốt 25/11)

| Interface | Ai cung cấp | Ai dùng | Ý nghĩa |
| --- | --- | --- | --- |
| `ITargetOrigin` (`Core/ITargetOrigin.cs`) | Tracking | Exercises | Transform gốc O trùng hệ trục in, kèm trạng thái tracking và target ID |
| `IGraphRenderer` (`Core/IGraphRenderer.cs`) | Graphing | Exercises | Vẽ y = f(x) trên [a, b] dưới GraphRoot, đổi cận/hệ số không tạo mesh mới, bật/tắt lớp đường cong/miền/khối; trả lỗi tiếng Việt |

Exercises chỉ tham chiếu `Grapher.Core`, không gọi thẳng Tracking hay Graphing; UI tham chiếu Core và Exercises.

Đồ thị là con của gốc tọa độ (`ImageTarget → GraphRoot → Surface`), nên đi theo phiếu giấy mà Graphing không cần biết gì về Vuforia.

## Luồng chạy

1. Camera chụp khung hình → Vuforia nhận ra phiếu → cập nhật vị trí ImageTarget.
2. Exercises đọc dữ liệu bài (ScriptableObject: target ID, hàm mặc định, câu hỏi, đáp án).
3. Graphing biên dịch biểu thức một lần, sinh đường cong, miền tô và lưới khối tròn xoay; kéo thanh trượt chỉ cập nhật vị trí đỉnh.
4. Exercises chạy POE: dự đoán → hiện đồ thị → hỏi → chấm, ghi log JSON cục bộ.

## Scene

- `Scenes/Main.unity` — scene build APK, chỉ một người sửa (xem `gitflow.md`).
- `Scenes/Sandbox/<Tên>.unity` — mỗi người một scene thử nghiệm riêng.
