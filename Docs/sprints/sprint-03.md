# Sprint 3 — 16/11 – 22/11/2026

**Mục tiêu sprint:** làm bù toàn bộ sprint 2 và làm việc của sprint 3 trong cùng một tuần (khối lượng gấp đôi, nhóm đã chấp nhận) — quét phiếu in v1 bằng điện thoại Android, đồ thị y = f(x) và khối tròn xoay quanh Ox nổi đúng trên hệ trục in, không biến mất khi tay che một góc phiếu; có mục tiêu học tập, lập luận lý thuyết học tập và bộ bài POE theo hướng thể tích khối tròn xoay.

**Gate 1 (dời từ 15/11 sang CN 22/11):** marker tracking ổn định. Đạt khi cả 4 điều sau đúng trên máy thật:

1. Marker v1 đạt 4–5 sao trên Vuforia Target Manager.
2. Nhận phiếu ở khoảng cách 20–40 cm, nghiêng tới 60°.
3. Gốc O và trục của đồ thị AR trùng hệ trục in (lệch không quá 2–3 mm khi nhìn thẳng).
4. Che tay một góc phiếu, đồ thị vẫn còn (Extended Tracking).

Trượt Gate 1 lần nữa → đổi thiết kế phiếu ngay đầu sprint 4; nếu vẫn kém, chuyển sang bản web dự phòng (MindAR.js).

Hiện trạng đầu sprint (16/11): sprint 2 chưa có việc nào xong; `main` chưa có Vuforia, NCalc, `Assets/_Project/`. Hướng bài học đổi sang thể tích khối tròn xoay ([biên bản 10/11](../decisions/2026-11-10_hop-nhom_the-tich-khoi-tron-xoay.md)), chờ giảng viên xác nhận. Việc được tách làm hai phần: phần A là việc của sprint 2 làm bù, giữ mã `S2-xx`; phần B là việc của sprint 3, mang mã `S3-xx`. Bỏ S2-12 (tô màu theo độ cao) vì hướng mới không cần.

## Phần A — Làm bù sprint 2 (mã S2)

### Duy — Tracking và marker

| # | Việc | Xong khi | Hạn | Issue | Trạng thái |
| --- | --- | --- | --- | --- | --- |
| S2-01 | Cài Vuforia Engine vào project, thêm license key Basic | Project mở được trên cả 3 máy, không lỗi compile; license key không nằm trong repo public | T2 16/11 | | ⬜ |
| S2-02 | Thiết kế phiếu marker v1 có hệ trục Oxy in sẵn (khung viền nhiều chi tiết, không lặp, tránh 8% viền ngoài) | Đạt 4–5 sao; PNG trong `Worksheets/targets/`, file gốc trong `Worksheets/source/` | T3 17/11 | | ⬜ |
| S2-03 | In thử trên A4 giấy mờ, đo tracking | Bảng kết quả: khoảng cách 20/40/60 cm × nghiêng 0/30/60° × che tay | T4 18/11 | | ⬜ |
| S2-04 | `GraphRoot`: gốc O trùng hệ trục in, nhập đúng chiều rộng thật của target (mét), 1 đơn vị = 1 cm | Một khối lập phương 1×1 cm đặt tại (1, 1) trùng ô (1, 1) trên phiếu | T5 19/11 | | ⬜ |
| S2-05 | Bật Extended Tracking (Device Pose Observer) | Che tay một góc phiếu, vật thể không biến mất | T5 19/11 | | ⬜ |
| S2-06 | Tạo `Scenes/Main.unity` và `Scenes/Sandbox/<Tên>.unity` cho 3 người; build APK có gọi NCalc | APK chạy trên 2 máy Android, ghi tên máy vào báo cáo tuần | T6 20/11 | | ⬜ |

### Thái — Vẽ đồ thị

| # | Việc | Xong khi | Hạn | Issue | Trạng thái |
| --- | --- | --- | --- | --- | --- |
| S2-19 | Tạo `Assets/_Project/` với 5 asmdef; chốt 2 interface trong `Core` (gốc tọa độ theo target, vẽ đồ thị) | Merge vào `main`; bảng interface trong `project-overview.md` cập nhật thành "đã chốt" | T2 16/11 | | ⬜ |
| S2-08 | Thêm `NCalc.dll` vào `Assets/Plugins/` | Gọi được NCalc từ assembly `Grapher.Graphing` | T2 16/11 | | ⬜ |
| S2-09 | Tiền xử lý biểu thức kiểu giáo khoa (`2x`, `sin x`, `x²`) + bộ 30 test EditMode | 30 test chạy xanh, có `-2^2 = -4`; lỗi cú pháp trả thông báo tiếng Việt | T3 17/11 | | ⬜ |
| S2-25 | Viết lập luận lý thuyết học tập (đa biểu diễn, học đa phương tiện, POE) theo hướng khối tròn xoay, mỗi lý thuyết gắn với tính năng cụ thể của app | Ghi vào `Docs/planning/learning-design.md`, có trích dẫn; Hùng review | T4 18/11 | | ⬜ |
| S2-11 | Đường cong y = f(x) bằng LineRenderer, tô miền giữa đồ thị và Ox | Vẽ `y = sqrt(x)` trên [0, 4] trùng hệ trục in, miền được tô | T4 18/11 | | ⬜ |
| S2-10 | Dựng khối tròn xoay quanh Ox từ y = f(x) ≥ 0 trên [a, b], bỏ tam giác có đỉnh NaN/∞ | Vẽ được khối của `sqrt(x)` trên [0, 4] và `sin(x)` trên [0, π]; đo thời gian sinh lưới trên máy thật | T6 20/11 | | ⬜ |
| S2-13 | Gắn đồ thị và khối làm con của `GraphRoot` (cùng Duy) | Đồ thị và khối tròn xoay nổi trên phiếu in, chạy trên Android | T7 21/11 | | ⬜ |
| S2-07 | Tạo GitHub Projects board, CODEOWNERS theo module | Issue sprint 3 có trên board | CN 22/11 | | ⬜ |

### Hùng — Bài tập và UI

| # | Việc | Xong khi | Hạn | Issue | Trạng thái |
| --- | --- | --- | --- | --- | --- |
| S2-14 | Viết mục tiêu học tập theo hướng khối tròn xoay | 3–5 mục tiêu đo được, gắn với Toán 12 Bài 13; ghi vào `Docs/planning/learning-design.md` | T3 17/11 | | ⬜ |
| S2-17 | Hoàn thiện FigJam phần Ideate | Link FigJam đưa vào báo cáo tuần 3 | T3 17/11 | | ⬜ |
| S2-15 | Chốt bộ hàm theo SGK Toán 12 Bài 13 + 3–4 bài POE (không dùng toàn hàm bậc nhất) | Danh sách hàm và cận [a, b], mỗi bài có câu dự đoán và câu hỏi giải thích; ghi vào `DECISIONS.md` | T4 18/11 | | ⬜ |
| S2-16 | Thiết kế UI trên Figma: chọn hàm và sửa hệ số, thanh trượt số đĩa n, ô nhập đáp số | Wireframe 4 màn hình: quét phiếu → xem đồ thị và miền → dự đoán và xem khối → lập tích phân, nộp đáp số | T6 20/11 | | ⬜ |
| S2-18 | Thu thập SUS bản tiếng Việt và mẫu pre/post test | File lưu trên Drive nhóm | CN 22/11 | | ⬜ |

### Nghiên cứu

| # | Việc | Người chính | Xong khi | Hạn | Trạng thái |
| --- | --- | --- | --- | --- | --- |
| S2-23 | Đọc lại 3 bài nghiên cứu, mỗi người 1 bài: Thái – Cheong et al. 2024; Hùng – Ahmad & Junaini 2020; Duy – tổng quan IJLTER | Mỗi người | Tóm tắt tối đa 1 trang/bài; ghi vào `Docs/planning/research-notes.md` | T4 18/11 | ⬜ |
| S2-24 | Phân tích lại 4 dự án: Duy – AR 3D Graphs; Thái – Math World, Catlike Coding; Hùng – GeoGebra 3D AR (kèm câu trả lời "khác GeoGebra 3D ở đâu") | Mỗi người | Mỗi dự án: làm được gì, còn thiếu gì, bài học cho module của mình; ghi vào `research-notes.md` | CN 22/11 | ⬜ |

### Cả nhóm

| # | Việc | Người chính | Xong khi | Hạn | Trạng thái |
| --- | --- | --- | --- | --- | --- |
| S2-21 | Review và chốt các file "bản nháp" trong `Docs/team/`, điền `team-contract.md` | Cả nhóm | Bỏ dòng "Bản nháp"; cả 3 người ký xác nhận | CN 22/11 | ⬜ |

## Phần B — Việc sprint 3 (mã S3)

Theo lộ trình sprint 3: parser + bộ test; đường cong, miền và khối tròn xoay hoàn chỉnh; khớp hệ trục AR với hệ trục in; cấu trúc dữ liệu bài tập. Các việc này nối tiếp bản prototype của phần A.

### Duy — Tracking và marker

| # | Việc | Xong khi | Hạn | Issue | Trạng thái |
| --- | --- | --- | --- | --- | --- |
| S3-04 | Khớp hệ trục AR với hệ trục in: đo độ lệch tại gốc O và 4 điểm trên hai trục, ở 3 góc nhìn; chỉnh `GraphRoot` | Bảng đo, lệch không quá 2–3 mm khi nhìn thẳng (sau S2-04) | T7 21/11 | | ⬜ |

### Thái — Vẽ đồ thị

| # | Việc | Xong khi | Hạn | Issue | Trạng thái |
| --- | --- | --- | --- | --- | --- |
| S3-05 | Mở rộng bộ test parser lên 50 biểu thức; kiểm tra miền: f xác định và f(x) ≥ 0 trên [a, b] | 50 test chạy xanh; hàm không hợp lệ trên [a, b] trả thông báo tiếng Việt (sau S2-09) | T6 20/11 | | ⬜ |
| S3-06 | Cắt đường cong tại điểm gián đoạn; đổi hệ số hoặc cận thì chỉ cập nhật vị trí đỉnh của đường cong, miền và khối, không tạo mesh mới | Đổi hệ số trong Sandbox thấy hình cập nhật ngay; đo thời gian cập nhật trên máy thật (sau S2-10, S2-11) | CN 22/11 | | ⬜ |

### Hùng — Bài tập và UI

| # | Việc | Xong khi | Hạn | Issue | Trạng thái |
| --- | --- | --- | --- | --- | --- |
| S3-01 | Cấu trúc dữ liệu bài tập (ScriptableObject) | Một bài mẫu có target ID, hàm, cận a và b, câu hỏi, đáp án; có test đọc dữ liệu | T7 21/11 | | ⬜ |
| S3-07 | Nạp một bài mẫu từ dữ liệu và gọi vẽ qua interface trong `Core` | Mở Sandbox thấy đồ thị và khối của bài mẫu, không viết cứng hàm trong code (sau S3-01, S2-19) | CN 22/11 | | ⬜ |

### Cả nhóm

| # | Việc | Người chính | Xong khi | Hạn | Trạng thái |
| --- | --- | --- | --- | --- | --- |
| S3-02 | Hỏi giảng viên xác nhận hướng thể tích khối tròn xoay | Thái | Có câu trả lời; cập nhật `DECISIONS.md` thành đã chốt hoặc sửa lại kế hoạch | T2 16/11 (gửi) | ⬜ |
| S3-03 | Viết và nộp báo cáo tuần 2 (kỳ 09–15/11) | Thái | Bản EN nộp tối 16/11; lưu trong `Docs/weekly_report/week2/` | T2 16/11 | ⬜ |

## Lịch trong tuần

| Ngày | Việc |
| --- | --- |
| T2 16/11 | Thái merge asmdef (S2-19) để mọi người làm trên nhánh riêng, gửi câu hỏi cho giảng viên, nộp báo cáo tuần 2; Duy và Hùng clone repo, Duy cài Vuforia (S2-01) |
| T3 17/11 | Marker v1 phải có số sao — dưới 4 sao thì sửa ngay; xong mục tiêu học tập (S2-14) và parser (S2-09) |
| T4 18/11 | Cập nhật trạng thái giữa tuần; xong đo tracking (S2-03), bộ bài POE (S2-15), lập luận lý thuyết (S2-25), tóm tắt bài nghiên cứu (S2-23) |
| T5 19/11 | `GraphRoot` và Extended Tracking (S2-04, S2-05) |
| T6 20/11 | APK đầu tiên có gọi NCalc (S2-06); khối tròn xoay chạy trong Sandbox (S2-10); 50 test parser (S3-05) |
| T7 21/11 | Họp tích hợp trên máy Android thật: Tracking + Graphing (S2-13); đo độ lệch hệ trục (S3-04); dữ liệu bài tập (S3-01) |
| CN 22/11 | Demo Gate 1, review sprint, lập sprint 4, viết báo cáo tuần 3 |

## Rủi ro

| Rủi ro | Dấu hiệu sớm | Phương án |
| --- | --- | --- |
| Giảng viên không đồng ý hướng khối tròn xoay | Chưa có trả lời vào T4 | Làm trước các việc không phụ thuộc hướng (S2-01 – S2-06, S2-19, S2-08, S2-09, S2-11); hỏi lại trực tiếp trên lớp |
| Dồn hai sprint vào một tuần, không kịp Gate 1 | S2-01 hoặc S2-19 chưa xong vào T3 | Ưu tiên phần A trước phần B, theo đường găng S2-01 → S2-02 → S2-04 → S2-13; lùi S2-07, S2-18, S2-21, S2-24 rồi S3-06, S3-07 sang sprint 4 |
| Marker ít đặc trưng, tracking chập chờn | Dưới 4 sao vào T3 | Thêm chi tiết sắc nét ở khung viền, giảm vùng lưới lặp; thử lại ngay trong ngày |
| Vuforia chưa hỗ trợ Unity 6000.6.4f1 | Lỗi khi import package | Kiểm tra bảng tương thích trước khi cài; nếu cần, cả nhóm đổi bản Unity và ghi vào `DECISIONS.md` |
| NCalc không chạy trên Android (IL2CPP) | Lỗi runtime trên APK dù Editor chạy được | APK ngày T6 phải có gọi NCalc; dự phòng tự viết parser shunting-yard |

## Review (điền ở buổi họp CN 22/11)

- **Đạt Gate 1?**
- **Việc chuyển sang sprint 4:**
- **Retro:** giữ … · bỏ … · thử …
