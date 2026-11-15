# PROGRESS REPORT — Tuần 2 (bản tiếng Việt để đọc)

> Bản dịch của `Progress Report Week 2 – Project 2615 (EN).md`. Bản nộp là bản tiếng Anh.

| Mục | Nội dung |
| --- | --- |
| Course | Augmented Reality – 20261 |
| Project code | 2615 |
| Project title | 3D Function Grapher on Paper – Vẽ đồ thị hàm số 2D/3D trên phiếu bài tập bằng AR |
| Design thinking page | https://www.figma.com/board/eeyqr3DnJk9avPdyrD8QcS/Untitled?node-id=0-1&p=f&t=R2Ikjy8rmYRArX16-0 |
| Members | 1. Trương Văn Thái – 20231627 · 2. Âu Mạnh Hùng – 20231593 · 3. Đào Khánh Duy – 20231583 |
| Reported working period | từ 09/11/2026 đến 15/11/2026 (tuần 2/8) |

## 1. Tóm tắt tiến độ

Tuần 2 nhóm dành cho thiết kế bài học. Cuối tuần 1 nhóm chưa trả lời được câu hỏi "mục tiêu bài học trong AR là gì", trong khi câu trả lời này quyết định bài tập, tương tác và loại đồ thị nào đáng làm. Nhóm họp 2 buổi (08/11 và 10/11) để chốt.

Kết quả là đề xuất thu hẹp đề tài vào một bài học: thể tích khối tròn xoay (SGK Toán 12 Kết nối tri thức, tập 2, Bài 13 – Ứng dụng hình học của tích phân). Marker trên phiếu neo hệ trục in; app vẽ y = f(x) trên [a, b], tô miền giữa đồ thị và trục Ox, rồi dựng khối tròn xoay quanh Ox nổi lên khỏi trang giấy. Học sinh tự lập V = π∫f(x)²dx; AR dùng để kiểm tra hình dung, không đưa đáp án. Đề xuất giữ chu trình Dự đoán – Quan sát – Giải thích (POE) và đang chờ giảng viên xác nhận phạm vi.

Nhóm cũng đã xác định 4 mục tiêu học tập, luồng của một bài tập, phạm vi MVP và tương tác chính (chồng n đĩa mỏng, kéo thanh trượt tăng n đến khi khớp khối).

Tiến độ cộng dồn: hết tuần 2/8. Phần phân tích, kế hoạch, quy ước nhóm và hướng bài học đã có. Tuần 3 cài đặt prototype đầu tiên theo hướng này và kiểm tra Gate 1 (marker tracking) ngày 22/11.

## 2. Các hoạt động kỹ thuật

**Activity 1: Họp về bài tập và tương tác (08/11).** Ba ý được đưa ra: mỗi marker là một bài tập cụ thể có câu hỏi a, b, c; bấm vào hình thì hiện danh sách thứ cần vẽ thêm, bấm vào cạnh thì hiện độ dài; nhập phương trình thì vẽ đồ thị. Nhóm chưa chọn được vì chưa xác định mục tiêu bài học trong AR: ý bấm vào hình thuộc hình học trong khi đề tài là đồ thị hàm số, còn "bài cố định theo marker" và "nhập phương trình tự do" là hai kiểu dùng khác nhau. Nhóm thống nhất viết mục tiêu bài học trước.

**Activity 2: Chọn hướng bài học (10/11).** Đầu buổi nhóm xét hướng hình học không gian Oxyz (mặt phẳng, lập phương trình mặt phẳng) rồi loại: mỗi bài phải dựng mô hình riêng, module vẽ đồ thị gần như không dùng, và lệch tên đề tài. Nhóm chọn thể tích khối tròn xoay: vẫn lấy vẽ đồ thị hàm số làm trung tâm, có vật thể 3D thật sự khó hình dung từ trang giấy 2D, và khớp đúng một bài trong SGK.

**Activity 3: Thiết kế bài học theo hướng mới.**

- Mục tiêu học tập: xác định miền quay; nhận ra khối tạo thành; lập đúng tích phân thể tích; giải thích f(x) là bán kính tiết diện và vì sao phải bình phương.
- Luồng một bài: quét phiếu → app vẽ đồ thị, tô miền → học sinh dự đoán khối → app hiện khối → học sinh lập tích phân, nộp đáp số → app chấm và chỉ ra bước sai (quên bình phương, quên π, sai cận). Không hiện đáp án trước khi học sinh nộp.
- MVP: một marker; f(x) ≥ 0 trên [a, b]; chỉ quay quanh Ox; 3–4 bài từ nhận diện miền đến phát hiện lỗi; ghi log số lần thử theo mã ẩn danh.
- Ngoài MVP: OCR, miền giữa hai đồ thị, trục quay khác, mặt z = f(x, y).

**Activity 4: Bổ sung sau buổi họp.** Tương tác chính là chồng n đĩa mỏng, kéo thanh trượt tăng n đến khi khớp khối, để trả lời "vì sao tích phân là thể tích"; tiết diện tại x là phần phụ. Ví dụ không dùng toàn hàm bậc nhất (ra hình nón, giải được bằng ⅓πr²h); thêm √x và sin x trên [0, π], có thể gắn vật thật như bình, ly. MVP cho chọn hàm từ danh sách và sửa hệ số; nhập tự do để sau Gate 2. Người đánh giá là bạn cùng lớp đã học tích phân, nên bài kiểm tra trước/sau cần câu đủ khó để không đạt điểm tối đa ngay từ đầu. Nhóm sẽ chuẩn bị câu trả lời cho câu hỏi "khác GeoGebra 3D ở đâu".

**Activity 5: Cập nhật kế hoạch (làm ngày 16/11).** Sửa tài liệu phân tích & kế hoạch, lộ trình sprint và tổng quan dự án theo hướng mới; lập kế hoạch sprint 3. Hạn nộp cuối kỳ trong kế hoạch đổi thành 13h30 thứ Tư 23/12/2026.

## 3. Đóng góp cá nhân

Vai trò cố định cả dự án: Duy – Tracking và marker; Thái – Vẽ đồ thị trong AR + AI; Hùng – Bài tập AR và tương tác.

| Thành viên | Việc đã làm tuần 2 | Đầu ra | Đóng góp vào tiến độ chung |
| --- | --- | --- | --- |
| Member 1: Trương Văn Thái – 20231627 | Tham gia cả 2 buổi họp; viết biên bản và sổ quyết định; sửa kế hoạch, lộ trình và lập sprint 3 theo hướng mới | Biên bản 08/11 và 10/11; sổ quyết định; tài liệu phân tích & kế hoạch đã sửa; kế hoạch sprint 3 | Ghi lại hướng bài học và chuyển thành kế hoạch cụ thể cho 3 module |
| Member 2: Âu Mạnh Hùng – 20231593 | Tham gia các buổi họp về bài tập và hướng bài học | Góp ý về ý tưởng bài tập, mục tiêu học tập và luồng bài | Định hình phạm vi module Bài tập AR và UI mình phụ trách |
| Member 3: Đào Khánh Duy – 20231583 | Tham gia các buổi họp về bài tập và hướng bài học | Góp ý về ý tưởng bài tập và thứ marker cần neo (hệ trục in) | Định hình phạm vi module Tracking và marker mình phụ trách |

## 4. Review code đã phát triển

### 4.1 Phát triển thuật toán

Tuần này mới thiết kế, chưa cài đặt:

- **Khối tròn xoay:** lấy mẫu x trên [a, b]; tại mỗi mẫu dựng một vòng đỉnh bán kính f(x) quanh Ox; nối các vòng liền nhau bằng tam giác. Bỏ tam giác có đỉnh NaN/∞. Kéo thanh trượt chỉ cập nhật vị trí đỉnh, không tạo mesh mới.
- **Chồng n đĩa:** chia [a, b] thành n phần bằng nhau; mỗi phần là một hình trụ bán kính f(xᵢ), dày (b − a)/n. App hiện tổng thể tích các đĩa cạnh giá trị đúng để học sinh thấy nó hội tụ khi n tăng.
- **Miền tô:** một mesh phẳng giữa đường cong đã lấy mẫu và trục Ox, nằm trùng hệ trục in.
- **Chấm bằng luật:** so đáp số học sinh nộp với thể tích đúng và với các giá trị sinh ra từ lỗi thường gặp: π∫f(x)dx (quên bình phương), ∫f(x)²dx (quên π), và tích phân với cận sai. Trùng giá trị nào thì báo cho học sinh bước sai tương ứng.
- **Đọc biểu thức (như tuần 1):** tiền xử lý cách viết giáo khoa (`2x` → `2*x`, `sin x` → `sin(x)`, `x²` → `x^2`), rồi NCalc biên dịch một lần.

### 4.2 Mã nguồn đã viết hoặc sửa

- Chưa có code chức năng.
- Repo: https://github.com/navihat/3d_grapher — thay đổi tài liệu trong tuần: 2 biên bản họp, sổ quyết định, kế hoạch và các file sprint đã sửa.

### 4.3 Kết quả kiểm thử

Chưa có code nên tuần này chưa kiểm thử chức năng.

## 5. TODO

### a) Vấn đề còn tồn đọng

1. Hướng bài học (khối tròn xoay) chưa được giảng viên xác nhận.
2. Chưa cài Vuforia; chưa kiểm tra tương thích với Unity 6000.6.4f1.
3. Chưa có marker và chưa chạy app trên máy Android, nên rủi ro lớn nhất (tracking) chưa được kiểm chứng.
4. Các việc cài đặt của sprint 2 chuyển sang sprint 3, nên tuần 3 nặng việc.
5. Tài liệu quy ước nhóm còn là bản nháp; cam kết nhóm chưa ký.

### b) Việc cần làm tuần sau (16/11 – 22/11, sprint 3)

**Thái – Vẽ đồ thị**

- [ ] S3-02: hỏi giảng viên xác nhận hướng bài học
- [ ] S2-19: tạo `Assets/_Project/` với 5 asmdef; chốt 2 interface trong `Core`
- [ ] S2-08, S2-09: thêm NCalc; tiền xử lý biểu thức + 30 test EditMode
- [ ] S2-11, S2-10: đường cong y = f(x) và tô miền; khối tròn xoay quanh Ox
- [ ] S2-13: gắn đồ thị và khối lên target của Duy, chạy trên Android
- [ ] S2-25: lập luận lý thuyết học tập theo hướng mới
- [ ] S3-05, S3-06: 50 test parser kèm kiểm tra miền; điểm gián đoạn và cập nhật mesh tại chỗ

**Duy – Tracking và marker**

- [ ] S2-01: cài Vuforia, license key Basic
- [ ] S2-02, S2-03: phiếu marker v1 có hệ trục in, đạt 4–5 sao; in thử và đo tracking
- [ ] S2-04, S2-05: `GraphRoot` trùng hệ trục in; Extended Tracking
- [ ] S2-06: scene Main và Sandbox; APK chạy trên 2 máy Android
- [ ] S3-04: đo và chỉnh độ lệch giữa hệ trục AR và hệ trục in

**Hùng – Bài tập và UI**

- [ ] S2-14, S2-15: mục tiêu học tập; bộ hàm kèm cận và 3–4 bài POE
- [ ] S2-16, S2-17: wireframe 4 màn hình trên Figma; FigJam phần Ideate
- [ ] S3-01: cấu trúc dữ liệu bài tập (ScriptableObject)
- [ ] S3-07: nạp một bài mẫu từ dữ liệu và vẽ qua interface trong `Core`
- [ ] S2-18: SUS bản tiếng Việt và mẫu pre/post test

**Nghiên cứu**

- [ ] S2-23: đọc lại 3 bài nghiên cứu, mỗi người 1 bài, tóm tắt tối đa 1 trang/bài
- [ ] S2-24: phân tích lại 4 dự án, kèm so sánh với GeoGebra 3D

**Cả nhóm**

- [ ] S2-21: chốt tài liệu quy ước nhóm, ký cam kết nhóm

### c) Mốc tiếp theo

**Gate 1 (22/11/2026, dời từ 15/11): marker tracking ổn định.** Đạt khi cả 4 điều sau đúng trên máy Android thật:

1. Marker v1 đạt 4–5 sao trên Vuforia Target Manager.
2. Nhận phiếu ở khoảng cách 20–40 cm, nghiêng tới 60°.
3. Gốc O và trục của đồ thị AR trùng hệ trục in (lệch không quá 2–3 mm khi nhìn thẳng).
4. Che tay một góc phiếu, đồ thị vẫn còn.

Nếu đến 22/11 tracking vẫn kém, nhóm đổi thiết kế phiếu ngay đầu sprint 4; nếu vẫn kém, cân nhắc bản web dự phòng (MindAR.js).

**Lộ trình 8 tuần**

| Tuần | Ngày | Mục tiêu | Gate |
| --- | --- | --- | --- |
| 1 | 02–08/11 | Đăng ký đề, phân tích, kế hoạch, khởi tạo project, quy ước nhóm | |
| 2 | 09–15/11 | Hướng bài học: thể tích khối tròn xoay; mục tiêu học tập, luồng bài, phạm vi MVP | |
| 3 | 16–22/11 | Phiếu in v1; parser + test; đường cong y = f(x), tô miền, khối tròn xoay trên hệ trục in, chạy trên Android; dữ liệu bài tập | **Gate 1:** marker tracking ổn định |
| 4 | 23–29/11 | Chồng n đĩa với thanh trượt; danh sách hàm sửa được hệ số; bàn phím toán nhập đáp số; luồng POE và chấm điểm; ghi log | |
| 5 | 30/11–06/12 | Ghép 3 module; Extended Tracking; nháp nội dung bài và câu hỏi pre/post | **Gate 2:** chốt tính năng lõi |
| 6 | 07–13/12 | Đủ 3–4 bài POE; in phiếu chính thức; thử nội bộ | **Gate 3:** sẵn sàng thử nghiệm |
| 7 | 14–20/12 | Đánh giá với 5–10 bạn cùng lớp: pre-test → học với app → post-test + SUS | |
| 8 | 21–23/12 | Phân tích số liệu, báo cáo, video demo, slide; nộp trước 13h30 ngày 23/12 | |
