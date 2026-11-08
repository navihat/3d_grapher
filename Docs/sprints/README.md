# Sprints

Mỗi sprint kéo dài 1 tuần (thứ Hai – Chủ nhật), trùng với tuần trong kế hoạch 8 tuần (`Docs/planning/`) và báo cáo tuần (`Docs/weekly_report/`).

## Nhịp làm việc

| Khi nào | Việc |
| --- | --- |
| CN, họp cuối tuần | Review sprint vừa xong (demo, đánh dấu trạng thái, retro) → lập sprint mới từ [`_template.md`](_template.md) |
| Giữa tuần (T4) | Cập nhật trạng thái trong file sprint, báo việc bị chặn |
| CN, sau họp | Viết báo cáo tuần từ mục "Review" của file sprint |

- Tên file: `sprint-NN.md` (ví dụ `sprint-02.md`).
- Mã việc: `S<sprint>-<số>` (ví dụ `S2-07`). Khi đã có GitHub Projects, mỗi việc tạo một Issue và ghi số Issue vào cột `Issue`.
- Trạng thái: ⬜ chưa làm · 🔄 đang làm · ✅ xong · ⛔ bị chặn · ➡️ chuyển sprint sau.
- "Xong" theo [`team-contract.md`](../team/team-contract.md): đã merge vào `main`, có test với phần logic, đã chạy trên điện thoại thật nếu liên quan AR/UI.
- Chỉ lập chi tiết sprint sắp tới; các sprint sau chỉ có mục tiêu ở bảng dưới và được chi tiết hoá ở buổi họp CN trước đó.

## Lộ trình

| Sprint | Ngày | Mục tiêu sprint | Gate | File |
| --- | --- | --- | --- | --- |
| 1 | 02–08/11 | Đăng ký đề, khởi tạo project + repo, quy ước nhóm | | xem báo cáo tuần 1 |
| 2 | 09–15/11 | Quét phiếu in v1, mặt z = x² + y² nổi đúng trên hệ trục in, chạy trên Android thật | **Gate 1 (15/11):** marker tracking ổn định | [sprint-02.md](sprint-02.md) |
| 3 | 16–22/11 | Parser + bộ test; đường cong 2D và mặt 3D; khớp hệ trục AR với hệ trục in; cấu trúc dữ liệu bài tập | | |
| 4 | 23–29/11 | Thanh trượt tham số; bàn phím toán; nhiều target; luồng POE và chấm điểm; ghi log | | |
| 5 | 30/11–06/12 | Ghép 3 phần vào Main scene; Extended Tracking; nháp nội dung bài tập và câu hỏi pre/post | **Gate 2 (06/12):** chốt tính năng lõi | |
| 6 | 07–13/12 | Đủ 6–8 bài POE; in phiếu chính thức; thử nội bộ với 2 người; OCR chỉ khi lõi đã ổn | **Gate 3 (13/12):** app sẵn sàng thử nghiệm | |
| 7 | 14–20/12 | Thử nghiệm với 8–10 học sinh: pre-test → học với app → post-test + SUS + phỏng vấn | | |
| 8 | 21–27/12 | Phân tích số liệu, báo cáo, video demo, slide; nộp 27/12 | | |

Hành động khi trượt gate (theo planning mục 6.1):

- **Gate 1:** marker vẫn tracking kém → đổi thiết kế phiếu hoặc chuyển sang bản web dự phòng.
- **Gate 2:** tính năng chưa xong thì cắt, không lùi lịch; từ đây chỉ sửa lỗi và thêm nội dung.
- **Gate 3:** app chưa ổn định → giảm số bài trong buổi thử nghiệm, không lùi buổi thử nghiệm.
