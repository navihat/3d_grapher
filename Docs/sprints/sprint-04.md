# Sprint 4 — 23/11 – 29/11/2026

**Mục tiêu sprint:** đồ thị y = f(x), miền và khối tròn xoay nổi đúng trên phiếu in, chạy trên Android thật; đạt Gate 1 (thử lại); có chồng n đĩa với thanh trượt n, dữ liệu bài tập và màn hình POE đầu tiên.

**Gate 1 (thử lại, CN 29/11):** marker tracking ổn định. Đạt khi cả 4 điều sau đúng trên máy thật:

1. Marker v1 đạt 4–5 sao trên Vuforia Target Manager.
2. Nhận phiếu ở khoảng cách 20–40 cm, nghiêng tới 60°.
3. Gốc O và trục của đồ thị AR trùng hệ trục in (lệch không quá 2–3 mm khi nhìn thẳng).
4. Che tay một góc phiếu, đồ thị vẫn còn (Extended Tracking).

Trượt lần này → đổi thiết kế phiếu; nếu sau đó tracking vẫn kém, chuyển sang bản web dự phòng (MindAR.js). Gate 2 (06/12) giữ nguyên.

Hiện trạng đầu sprint (23/11): sprint 3 trượt Gate 1; module vẽ đồ thị chưa bắt đầu. Việc còn dở của sprint 2 và 3 giữ mã cũ (`S2-xx`, `S3-xx`); việc mới của sprint 4 mang mã `S4-xx`. Danh sách lấy từ mục 5b báo cáo tuần 3 và lộ trình sprint 4 trong [`README.md`](README.md).

## Việc

### Duy — Tracking và marker

| # | Việc | Xong khi | Hạn | Issue | Trạng thái |
| --- | --- | --- | --- | --- | --- |
| S2-02 | Ghi số sao của marker v1 trên Vuforia Target Manager; dưới 4 sao thì sửa thiết kế | Số sao ghi vào báo cáo tuần 4; đạt 4–5 sao | T3 24/11 | | ⬜ |
| S4-01 | Thay license key Vuforia đã lộ | Key cũ bị thu hồi; key mới không nằm trong repo | T3 24/11 | | ⬜ |
| S2-04 | Đặt chiều rộng target 0,297 m; 1 đơn vị = 1 cm | Khối lập phương 1×1 cm đặt tại (1, 1) trùng ô (1, 1) trên phiếu | T4 25/11 | | ⬜ |
| S2-05 | Bật Extended Tracking (Device Pose Observer) | Che tay một góc phiếu, vật thể không biến mất | T4 25/11 | | ⬜ |
| S2-03, S3-04 | Đo lại tracking (20/40/60 cm × 0/30/60° × che tay) và độ lệch hệ trục (gốc O + 4 điểm, 3 góc nhìn) sau khi sửa S2-04, S2-05 | Hai bảng đo mới; lệch không quá 2–3 mm khi nhìn thẳng | T6 27/11 | | ⬜ |
| S2-06 | Build APK có gọi NCalc | APK chạy trên 2 máy Android, ghi tên máy vào báo cáo tuần | T6 27/11 | | ⬜ |
| S4-02 | *(nếu kịp)* Nhiều target: mỗi phiếu bài một target, `TargetOrigin` trả đúng mã target | Quét 2 phiếu khác nhau, app nhận đúng mã từng phiếu | CN 29/11 | | ⬜ |

### Thái — Vẽ đồ thị

| # | Việc | Xong khi | Hạn | Issue | Trạng thái |
| --- | --- | --- | --- | --- | --- |
| S2-19 | Asmdef `Graphing`, `Exercises`, `UI`; interface `IGraphRenderer` trong `Core` | Merge vào `main` | T4 25/11 | PR #4 | ✅ |
| S2-08, S2-09 | Plugin NCalc; tiền xử lý biểu thức kiểu giáo khoa + test EditMode | Test chạy xanh, lỗi cú pháp trả thông báo tiếng Việt | T4 25/11 | PR #5 | ✅ |
| S2-11, S2-10 | Đường cong y = f(x), tô miền; khối tròn xoay quanh Ox | Vẽ được `sqrt(x)` trên [0, 4] và `sin(x)` trên [0, π] trong Sandbox | T4 25/11 | PR #5 | ✅ |
| S3-05, S3-06 | Kiểm tra miền (f xác định và ≥ 0 trên [a, b]); cắt đường cong tại điểm gián đoạn; thanh trượt Sandbox đo thời gian dựng lại | Merge vào `main` | T4 25/11 | PR #6 | ✅ |
| S2-25 | Lập luận lý thuyết học tập gắn với tính năng app | Ghi vào `Docs/planning/`; merge vào `main` | T4 25/11 | PR #7 | ✅ |
| S2-07a | CODEOWNERS theo module | Merge vào `main` | T4 25/11 | | ✅ |
| S2-07b | GitHub Projects board | Việc sprint 4 có trên board, ghi số Issue vào file này | T5 26/11 | | ⬜ |
| S2-13 | Gắn đồ thị và khối làm con của `GraphRoot` (cùng Duy) | Đồ thị và khối tròn xoay nổi trên phiếu in, chạy trên Android (sau S2-04, S2-06) | T7 28/11 | | ⬜ |
| S4-03 | Chồng n đĩa mỏng xấp xỉ khối, thanh trượt n | Kéo n từ 4 → 32 thấy đĩa cập nhật ngay; đo thời gian dựng lại trên máy thật | CN 29/11 | | ⬜ |
| S4-04 | Mặt cắt tại x: thanh trượt di chuyển lát cắt, hiện bán kính f(x) | Lát cắt là hình tròn bán kính f(x), số hiện trên màn hình khớp giá trị tính tay | CN 29/11 | | ⬜ |
| S4-05 | Đổi hệ số của hàm (ví dụ a trong y = a·x − x²) qua API để UI gọi | Đổi hệ số → đường cong, miền và khối cập nhật, không tạo mesh mới | CN 29/11 | | ⬜ |

### Hùng — Bài tập và UI

| # | Việc | Xong khi | Hạn | Issue | Trạng thái |
| --- | --- | --- | --- | --- | --- |
| S2-15 | Ghi bộ 4 bài POE vào `DECISIONS.md` | Có hàm, cận, đáp án (Bài 3: V = 16π/15) | T2 23/11 | | ⬜ |
| S4-06 | Thống nhất wireframe với MVP: chọn hàm từ danh sách và sửa hệ số thay cho nhập f(x) tự do; bỏ ví dụ y = x | Wireframe cập nhật trên Figma, cả nhóm đồng ý | T3 24/11 | | ⬜ |
| S3-01 | Cấu trúc dữ liệu bài tập (ScriptableObject) | Một bài mẫu có target ID, hàm, cận a và b, câu hỏi, đáp án; có test đọc dữ liệu | T4 25/11 | | ⬜ |
| S3-07 | Nạp bài mẫu từ dữ liệu và vẽ qua `IGraphRenderer` | Mở Sandbox thấy đồ thị và khối của bài mẫu, không viết cứng hàm trong code (sau S3-01) | T6 27/11 | | ⬜ |
| S4-07 | Luồng POE: dự đoán (phải nộp trước khi hiện khối) → quan sát → giải thích | Chạy hết một bài trong Sandbox | CN 29/11 | | ⬜ |
| S4-08 | Bàn phím toán nhập biểu thức dưới dấu tích phân và đáp số | Nhập được `π`, `x²`, `√`, phân số; chuỗi nhập qua được parser của Graphing | CN 29/11 | | ⬜ |
| S4-09 | Chấm điểm chỉ ra bước sai: so với f(x)² và các dạng sai thường gặp (f(x), thiếu π, sai cận) | Test EditMode cho từng dạng sai, thông báo tiếng Việt | CN 29/11 | | ⬜ |
| S4-10 | Ghi log tương tác (lần thử, số gợi ý, thời gian mỗi bước), không lưu dữ liệu cá nhân | File log đọc được sau một lượt chơi | CN 29/11 | | ⬜ |
| S2-18 | Thu thập SUS bản tiếng Việt và mẫu pre/post test | File lưu trên Drive nhóm | CN 29/11 | | ⬜ |

### Cả nhóm

| # | Việc | Người chính | Xong khi | Hạn | Trạng thái |
| --- | --- | --- | --- | --- | --- |
| S4-11 | Viết và nộp báo cáo tuần 3 (kỳ 16–22/11) | Thái | Bản EN nộp; lưu trong `Docs/weekly_report/week3/` | T5 26/11 | ✅ |
| S3-02 | Lấy xác nhận của giảng viên về hướng thể tích khối tròn xoay | Thái | Cập nhật `DECISIONS.md` thành đã chốt hoặc sửa kế hoạch | T4 25/11 | ⬜ |
| S2-21 | Chốt các file "bản nháp" trong `Docs/team/`, ký `team-contract.md` | Cả nhóm | Bỏ dòng "Bản nháp"; cả 3 người ký | CN 29/11 | ⬜ |
| S4-12 | Họp tích hợp trên máy Android thật: Tracking + Graphing | Duy, Thái | Đồ thị và khối nổi trên phiếu (S2-13) | T7 28/11 | ⬜ |
| S4-13 | Demo Gate 1, review sprint 4, lập sprint 5 | Cả nhóm | Mục Review bên dưới được điền | CN 29/11 | ⬜ |
| S4-14 | Viết báo cáo tuần 4 (kỳ 23–29/11), mô tả đầy đủ PR #4–#7 | Thái | Lưu trong `Docs/weekly_report/week4/` | T2 30/11 | ⬜ |

## Lịch trong tuần

| Ngày | Việc |
| --- | --- |
| T2 23/11 | Merge PR #1–#3; ghi bộ bài vào `DECISIONS.md` (S2-15) |
| T3 24/11 | Số sao marker (S2-02), thay license key (S4-01); thống nhất wireframe (S4-06) |
| T4 25/11 | Merge PR #4–#7 (module vẽ đồ thị); chiều rộng target và Extended Tracking (S2-04, S2-05); dữ liệu bài tập (S3-01); cập nhật trạng thái giữa tuần |
| T5 26/11 | Nộp báo cáo tuần 3; GitHub Projects board |
| T6 27/11 | APK có NCalc (S2-06); đo lại tracking và độ lệch (S2-03, S3-04); nạp bài mẫu (S3-07) |
| T7 28/11 | Họp tích hợp trên máy thật (S2-13, S4-12) |
| CN 29/11 | Demo Gate 1; chồng n đĩa, mặt cắt, luồng POE, bàn phím toán, chấm điểm; review sprint, lập sprint 5 |

## Rủi ro

| Rủi ro | Dấu hiệu sớm | Phương án |
| --- | --- | --- |
| Trượt Gate 1 lần ba | S2-04, S2-05 chưa xong vào T5 | Đường găng S2-02 → S2-04 → S2-05 → S2-03 → S2-13 làm trước mọi việc khác của Duy; S4-02 (nhiều target) bỏ nếu chậm |
| Chưa có APK nên không kiểm được NCalc trên Android (IL2CPP) | S2-06 chưa xong vào T6 | Build APK tối giản chỉ gọi NCalc trước; dự phòng tự viết parser shunting-yard |
| Phần UI và bài tập dồn vào cuối tuần | S3-01 chưa xong vào T4 | Ưu tiên S3-01 → S3-07 → S4-07; S4-08 – S4-10 chuyển sang sprint 5 (trước Gate 2) |
| Giảng viên chưa xác nhận hướng bài học | Chưa có trả lời vào T4 | Hỏi trực tiếp trên lớp; tiếp tục làm theo đề xuất 10/11 |
| Nhiều đĩa hoặc đổi hệ số làm tụt khung hình trên máy thật | Thời gian dựng lại vượt 1 khung hình (~16 ms) | Giới hạn n tối đa; dùng chung một mesh đĩa và GPU instancing |

## Review (điền ở buổi họp CN 29/11)

- **Đạt Gate 1?**
- **Việc chuyển sang sprint 5:**
- **Retro:** giữ … · bỏ … · thử …
