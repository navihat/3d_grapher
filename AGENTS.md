# AGENTS.md — 3D Function Grapher on Paper (Đề tài 2615)

App AR trên Android: quét phiếu bài tập in, vẽ đồ thị hàm số 2D/3D nổi trên trang giấy, kèm bài tập có hướng dẫn theo chu trình Dự đoán – Quan sát – Giải thích (POE). Nhóm 3 người, 8 tuần (02/11 – 27/12/2026).

## Stack

- Unity 6000.6.4f1, URP, C#; Vuforia Engine (image target); NCalc (parser biểu thức)
- Code viết trong VS Code; scene, prefab, build làm trong Unity Editor
- Asset Serialization = Force Text: `.unity`, `.prefab`, `.asset`, `.meta` là YAML đọc được

## Cấu trúc

```
Assets/_Project/   code và asset của nhóm, chia theo module (xem bảng dưới)
Assets/Plugins/    thư viện ngoài (NCalc.dll)
Worksheets/        phiếu bài tập = marker: source/, targets/ (PNG lên Vuforia), print/ (PDF)
Docs/team/         quy ước nhóm — đọc trước khi làm việc
Docs/decisions/    quyết định đã thống nhất với nhóm/giảng viên — DECISIONS.md là bản tóm tắt
Docs/planning/     đề tài, phân tích, kế hoạch 8 tuần
```

| Module (`Assets/_Project/`) | Phụ trách | Nội dung |
| --- | --- | --- |
| `Core/` | cả nhóm | interface chung giữa các module |
| `Tracking/` | Duy | Vuforia, gốc tọa độ theo target, extended tracking |
| `Graphing/` | Thái | parser, đường cong 2D, mặt 3D, shader |
| `Exercises/`, `UI/` | Hùng | luồng POE, chấm điểm, bàn phím toán, thanh trượt |

Chiều phụ thuộc (asmdef): `Core ← Tracking, Graphing ← Exercises, UI`. Không thêm tham chiếu ngược chiều.

## Quy tắc bắt buộc

1. **Được đọc, không được sửa** `.unity`, `.prefab`, `.meta`, `ProjectSettings/*`, `Packages/packages-lock.json`. Cần thay đổi scene/prefab thì mô tả các bước để người làm trong Unity Editor.
2. **File mới** (`.cs`, `.asmdef`...) được tạo; Unity tự sinh `.meta`. **Di chuyển / đổi tên / xoá** file trong `Assets/` phải xử lý cả file `.meta` đi kèm (dùng `git mv` cho cả hai), nếu không scene sẽ báo "Missing Script".
3. Không tạo thư mục rỗng trong `Assets/`.
4. Không đụng `Library/`, `Temp/`, `Logs/`, `UserSettings/` (Unity tự sinh, không commit).
5. Code đặt đúng module và namespace `Grapher.<Module>`; xem `Docs/team/coding-conventions.md`.
6. Không đưa dữ liệu cá nhân của học sinh vào repo.
7. Thông báo lỗi hiển thị cho người dùng viết bằng tiếng Việt.

## Đọc file Unity để hỗ trợ dev

- Tìm GameObject đang dùng một script: lấy `guid` trong `X.cs.meta`, rồi `grep` guid đó trong `Assets/**/*.unity` và `*.prefab`.
- Xem giá trị field `[SerializeField]` đã lưu: tìm block `MonoBehaviour` có `m_Script: {guid: ...}` trong scene/prefab.
- Tham chiếu dạng `{fileID: 0}` ở field bắt buộc thường là chưa gán trong Inspector.

## Lệnh

Chạy test EditMode không cần mở Editor (đóng Unity Editor trước):

```bash
~/Unity/Hub/Editor/6000.6.4f1/Editor/Unity -batchmode -nographics -projectPath . \
  -runTests -testPlatform EditMode -testResults Logs/test-results.xml
```

## Tài liệu chi tiết

- `Docs/team/project-overview.md` — kiến trúc, luồng chạy, interface giữa các module
- `Docs/team/coding-conventions.md` — quy ước code C#
- `Docs/team/gitflow.md` — nhánh, commit, PR, review
- `Docs/team/unity-workflow.md` — cách làm việc với Unity (GUID, scene, prefab)
- `Docs/team/team-contract.md` — cam kết nhóm
- `Docs/decisions/DECISIONS.md` — quyết định đã chốt; ưu tiên hơn tài liệu planning khi mâu thuẫn
