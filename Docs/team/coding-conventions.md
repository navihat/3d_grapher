# Coding conventions

> Bản nháp 08/11/2026 — nhóm review và chốt.

## Ngôn ngữ

- Tên class, biến, hàm, commit message: tiếng Anh.
- Comment và tài liệu: tiếng Việt hoặc tiếng Anh đều được.
- Chuỗi hiển thị cho người dùng (lỗi cú pháp, câu hỏi, gợi ý): tiếng Việt.

## Đặt tên

| Loại | Quy ước | Ví dụ |
| --- | --- | --- |
| Class, struct, enum, method, property | PascalCase | `SurfaceGraph`, `Rebuild()` |
| Interface | `I` + PascalCase | `IGraphRenderer` |
| Field private | `_camelCase` | `_resolution` |
| Field hiện trong Inspector | `[SerializeField] private` | `[SerializeField] private int _resolution = 80;` |
| Biến cục bộ, tham số | camelCase | `vertexCount` |
| Hằng số | PascalCase | `MaxResolution` |

- Một class public mỗi file, tên file trùng tên class.
- Namespace theo module: `Grapher.Core`, `Grapher.Tracking`, `Grapher.Graphing`, `Grapher.Exercises`, `Grapher.UI`.

## Unity

- Không dùng field `public` chỉ để hiện trong Inspector; dùng `[SerializeField] private`.
- Không gọi `Find*`, `GetComponent` trong `Update`; lấy một lần ở `Awake`.
- Tránh cấp phát bộ nhớ trong `Update` (new mảng, LINQ, nối chuỗi) — gây giật khi chạy trên điện thoại.
- Dữ liệu bài tập để trong ScriptableObject, không viết cứng trong code.

## Test

- Logic không phụ thuộc Unity (parser, chấm điểm) phải có test EditMode trong `<Module>/Tests/EditMode/`.
- Parser: bộ 30–50 biểu thức kiểu giáo khoa (`2x`, `sin x`, `x^2`, `-2^2 = -4`), thêm test mỗi khi sửa lỗi.
