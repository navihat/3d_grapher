# PROGRESS REPORT — Tuần 3 (bản tiếng Việt để đọc)

> Bản dịch của `Progress Report Week 3 – Project 2615 (EN).md`. Bản nộp là bản tiếng Anh.

| Mục | Nội dung |
| --- | --- |
| Course | Augmented Reality – 20261 |
| Project code | 2615 |
| Project title | 3D Function Grapher on Paper – Vẽ đồ thị hàm số 2D/3D trên phiếu bài tập bằng AR |
| Design thinking page | https://www.figma.com/board/eeyqr3DnJk9avPdyrD8QcS/Design-thinking---AR-app?node-id=44-218 |
| Members | 1. Trương Văn Thái – 20231627 · 2. Âu Mạnh Hùng – 20231593 · 3. Đào Khánh Duy – 20231583 |
| Reported working period | từ 16/11/2026 đến 22/11/2026 (tuần 3/8) |

## 1. Tóm tắt tiến độ

Tuần 3 khối lượng gấp đôi: làm bù các việc cài đặt của sprint 2 cộng việc của sprint 3, kèm Gate 1 (marker tracking ổn định) ngày 22/11. Nhóm chưa đạt Gate 1.

Đã có: Vuforia Engine 11.4.4 đã cài vào project; phiếu marker v1 sinh bằng script; module `Core` và `Tracking` với interface `ITargetOrigin` và bản cài đặt dùng Vuforia; scene Main và scene Sandbox. Về bài học: đã viết mục tiêu học tập và bộ 4 bài POE theo SGK (Toán 12, Bài 13); bảng Figma đã có phần Ideate và wireframe 5 màn hình cho luồng chính. Toàn bộ đã được review và merge vào `main` ngày 23/11 (pull request #1–#3).

Chưa xong: module vẽ đồ thị (parser, đường cong, khối tròn xoay) chưa bắt đầu trong tuần, nên chưa có đồ thị nào nổi trên phiếu. Bên tracking, marker chưa có số sao, chiều rộng target trong Unity chưa khớp kích thước in, Extended Tracking chưa bật, nên bảng đo tracking và độ lệch hệ trục phải đo lại.

Tiến độ cộng dồn: hết tuần 3/8. Phần thiết kế bài học và thiết lập tracking đã có; module vẽ đồ thị và phần ghép AR chậm khoảng một tuần so với kế hoạch. Một phần đã được bù vào đầu tuần 4 (xem mục 5b).

## 2. Các hoạt động kỹ thuật

**Activity 1: Cài Vuforia và module tracking (Duy).** Đã import Vuforia Engine 11.4.4 và cấu hình license Basic. Module `Tracking` cài đặt `ITargetOrigin` (trong `Core`): `TargetOrigin` gắn trên ImageTarget của Vuforia, cung cấp mã target, transform gốc `GraphRoot`, trạng thái đang được theo dõi hay không, và phát sự kiện khi trạng thái tracking thay đổi (Tracked, Extended Tracked, Lost). Module khác chỉ dùng interface nên không phụ thuộc Vuforia. Đã tạo scene Main, scene Sandbox (`Sandbox/DuyTest`) và device database Vuforia cho phiếu.

**Activity 2: Phiếu marker v1 (Duy).** Script Python (`Worksheets/source/generate_marker.py`) sinh phiếu A4 có hệ trục Oxy in sẵn, khung viền nhiều chi tiết, không lặp, chừa trống 8% viền ngoài theo khuyến nghị của Vuforia. Kết quả là `Worksheets/targets/worksheet_v1.png`. Chưa ghi số sao trên Vuforia Target Manager.

**Activity 3: Đo tracking lần đầu (Duy).** In phiếu trên giấy A4 mờ, thử trên điện thoại Android 13 ở 20/40/60 cm và nghiêng 0°/30°/60°. Nhận diện ổn định ở 20–40 cm với mọi góc; ở 60 cm chậm hơn và mất ở 60° khi thiếu sáng. Độ lệch giữa hệ trục AR và hệ trục in được đo tại gốc O và 4 điểm trên hai trục. Ở buổi review nhóm thấy số liệu này chưa dùng được cho Gate 1: chiều rộng target trong Unity vẫn là 1 thay vì 0,297 m, và Extended Tracking chưa bật khi đo cột che tay. Hai bảng sẽ đo lại sau khi sửa.

**Activity 4: Mục tiêu học tập và bộ bài POE (Hùng).** Năm mục tiêu đo được, gắn với Bài 13: xác định miền phẳng (MT1); lập và tính S = ∫|f(x)|dx, kể cả khi f đổi dấu (MT2); mô tả khối tròn xoay (MT3); giải thích mặt cắt là hình tròn bán kính f(x) và lập V = π∫f(x)²dx (MT4); phát hiện và sửa lời giải sai (MT5). Bốn bài bám theo ví dụ trong SGK, mỗi bài có 3 câu dự đoán, một câu giải thích có rubric (đúng / một phần / sai) và bước lập tích phân:

| Bài | Hàm và cận | Nguồn SGK | Mục tiêu | Đáp án |
| --- | --- | --- | --- | --- |
| 1 | y = x³ trên [0; 2], so với tam giác OAB | Ví dụ 1 | MT1, MT2 | S = 4 |
| 2 | y = sin x trên [0; 2π] | Ví dụ 2 | MT1, MT2 | S = 4 (∫f = 0) |
| 3 | y = 2x − x² trên [0; 2], tìm lỗi trong lời giải mẫu | Bài tập 4.17 | MT3, MT4, MT5 | V = 16π/15 |
| 4 | y = √(4 − x²) trên [−2; 2], nửa hình tròn → khối cầu | Ví dụ 8 | MT1, MT3, MT4 | V = 32π/3 |

Bộ bài được mở rộng để có cả diện tích hình phẳng lẫn thể tích, theo đúng thứ tự trong SGK. Bài 2 và Bài 3 mỗi bài dùng một lời giải "tự nhiên nhưng sai" (∫f thay cho ∫|f|; thiếu bình phương) để dự đoán của học sinh dễ sai, rồi bước quan sát giải quyết mâu thuẫn. Hùng cũng viết một tài liệu đề xuất dài hơn cho bài học (ý tưởng, mục tiêu, chuỗi bài, luồng app, phạm vi MVP, đánh giá).

**Activity 5: Design thinking và wireframe trên Figma (Hùng).** Phần Ideate trên FigJam nối ba khó khăn (khó hình dung các hàm phức tạp; kiến thức khô khan, không "sống"; các công cụ nổi tiếng chưa dễ tiếp cận với phần lớn học sinh THPT) với bốn hướng giải pháp: công cụ biểu diễn trực quan; tương tác, đổi tham số và quan sát từ nhiều góc độ; app trên điện thoại (linh hoạt hơn web trên máy tính); chỉ giữ chức năng cần cho bài học. Từ đó ra ý tưởng "ứng dụng AR xây dựng cùng các phiếu bài tập".

![Design thinking – Ideate (Figma)](figma-design-thinking.png)

Wireframe mô phỏng luồng cơ bản qua 5 màn hình:

1. **Quét phiếu:** khung camera kèm hướng dẫn đặt phiếu trên mặt phẳng.
2. **Nhập dữ kiện:** sau khi nhận phiếu, học sinh nhập f(x), cận a, b và trục quay (Ox; Oy ghi "sắp có"), rồi bấm vẽ đồ thị.
3. **Miền và dự đoán:** miền được tô trên hệ trục in; hai câu trắc nghiệm (vật thể có dạng gì; thể tích khoảng bao nhiêu) phải nộp trước khi hiện khối.
4. **Khối AR và lát cắt:** các tab Miền / Khối / Lát cắt; thanh trượt di chuyển lát cắt theo x và hiện bán kính; chia miền 4 → 8 lát.
5. **Tự lập tích phân:** học sinh điền V = ∫ₐᵇ [ … ] dx; app chỉ ra bước sai (ví dụ bán kính tiết diện), có nút gợi ý và đếm số lần gợi ý, số lần thử.

![Wireframe – luồng cơ bản (Figma)](figma-wireframe.png)

**Activity 6: Review, merge và quy tắc repo (Thái).** Thái review và merge ba pull request ngày 23/11. Khi review phát hiện hai vấn đề trên nhánh tracking: gói Vuforia (`.tgz`) được commit không qua Git LFS và license key nằm trong repo. Đã chuyển gói sang LFS và gỡ key; vì key cũ đã lộ nên phải cấp key mới. Thêm hai quy tắc vào `gitflow.md`: file nhị phân lớn đi qua LFS, và không viết lại lịch sử đã push. Thái cũng nộp báo cáo tuần 2 và viết kế hoạch sprint 3 ngày 16/11.

## 3. Đóng góp cá nhân

Vai trò cố định cả dự án: Duy – Tracking và marker; Thái – Vẽ đồ thị trong AR + AI; Hùng – Bài tập AR và tương tác.

| Thành viên | Việc trong tuần 3 | Sản phẩm | Đóng góp vào tiến độ chung |
| --- | --- | --- | --- |
| Member 1: Trương Văn Thái – 20231627 | Kế hoạch sprint 3; báo cáo tuần 2; review và merge PR #1–#3; xử lý LFS và license key; thêm quy tắc repo. Các việc vẽ đồ thị dự kiến trong tuần bị trễ | `sprint-03.md`; báo cáo tuần 2; `gitflow.md` cập nhật | Giữ repo chung sạch và gỡ chặn cho hai module kia; module vẽ đồ thị là chỗ chậm chính của tuần |
| Member 2: Âu Mạnh Hùng – 20231593 | Mục tiêu học tập; 4 bài POE; tài liệu đề xuất bài học; phần Ideate trên FigJam; wireframe 5 màn hình | `learning_design.md`; `y-tuong-ar-do-thi-va-the-tich.md`; bảng Figma | Chốt app phải dạy gì và mỗi màn hình làm gì, làm căn cứ cho code bài tập và UI |
| Member 3: Đào Khánh Duy – 20231583 | Cài Vuforia; `ITargetOrigin` + `TargetOrigin`; script sinh marker và marker v1; scene Main và Sandbox; đo tracking lần đầu; ghi chú nghiên cứu (tổng quan IJLTER, AR 3D Graphs) | `Assets/_Project/Core`, `Assets/_Project/Tracking`; `generate_marker.py`, `worksheet_v1.png`; `research-notes.md` | Dựng nền mà mọi tính năng AR neo vào; Gate 1 còn cần sửa chiều rộng target và bật Extended Tracking |

## 4. Review mã nguồn

### Thuật toán

- **Gốc tọa độ theo target (đã cài):** đồ thị là con của `GraphRoot` dưới ImageTarget. Khi chiều rộng target bằng chiều rộng in thật (0,297 m) và 1 đơn vị = 1 cm, điểm (x, y) trên giấy ứng với vị trí local (x, 0, y) của `GraphRoot` theo cm, nên đồ thị nằm trên hệ trục in. Việc sửa chiều rộng chưa xong.
- **Trạng thái tracking (đã cài):** trạng thái Vuforia được quy về ba trạng thái: `TRACKED` → Tracked, `EXTENDED_TRACKED` → Extended Tracked, `NO_POSE`/`LIMITED` → Lost. Module bài tập sẽ dùng để tạm dừng hoạt động và báo khi mất phiếu.
- **Sinh marker (đã cài):** script vẽ hệ trục ở giữa và lấp khung viền bằng hình bất đối xứng, nhiều góc nhọn — loại đặc trưng Vuforia chấm điểm cao; 8% viền ngoài để trống.
- **Chấm điểm chỉ ra bước sai (đã thiết kế, theo wireframe và bộ bài):** so biểu thức dưới dấu tích phân học sinh nhập với f(x)² và các dạng sai thường gặp (f(x), thiếu π, sai cận); khớp dạng nào thì báo bước sai tương ứng.

### Mã nguồn thêm mới / chỉnh sửa

- Repo: https://github.com/navihat/3d_grapher
- PR #1 – thiết kế bài học (Hùng), PR #2 – cài Vuforia, `TargetOrigin`, marker v1 (Duy), PR #3 – quy tắc LFS và không viết lại lịch sử (Thái); cả ba merge ngày 23/11.
- Code mới: `Core/ITargetOrigin.cs`, `Tracking/TargetOrigin.cs`, `Tracking/TrackingStatusEvent.cs`, `Worksheets/source/generate_marker.py`; scene `Main.unity`, `Sandbox/DuyTest.unity`.

### Kết quả kiểm thử

- Tracking (Android 13, giấy A4 mờ, in laser): nhận ổn định ở 20–40 cm với nghiêng 0°, 30°, 60°; ở 60 cm chậm và mất ở 60° khi thiếu sáng. Độ lệch hệ trục đo được trong khoảng 2 mm, nhưng chưa được tính cho Gate 1 vì chiều rộng target sai và Extended Tracking tắt; sẽ đo lại.
- Chưa có test EditMode trong tuần: phần code vẽ đồ thị, nơi có unit test, chưa viết.
- Chưa có APK nên chưa thử trên máy thứ hai.

## 5. TODO

### a) Các vấn đề còn tồn đọng

1. Chưa đạt Gate 1: marker v1 chưa có số sao; chiều rộng target trong Unity là 1 thay vì 0,297 m; Extended Tracking tắt; phải đo lại bảng tracking và độ lệch.
2. License key Vuforia cũ đã lộ, cần thay.
3. Chưa có đồ thị nổi trên phiếu và chưa build APK.
4. Giảng viên chưa xác nhận hướng khối tròn xoay; `DECISIONS.md` vẫn ghi là đề xuất.
5. Bộ bài chưa ghi vào `DECISIONS.md` (đáp án Bài 3, V = 16π/15, đã kiểm tra lại).
6. Wireframe cho nhập f(x) tự do và dùng ví dụ y = x (ra hình nón), trong khi MVP dự kiến chọn hàm từ danh sách, sửa hệ số và dùng ví dụ không phải bậc nhất; cần thống nhất trước khi code UI.
7. Chưa làm: GitHub Projects board, SUS tiếng Việt và mẫu pre/post test, chốt tài liệu quy ước nhóm và ký team contract.
8. Tạm dừng đọc lại 3 bài báo và 4 dự án (S2-23, S2-24) vì phần lớn không còn hợp hướng mới; phần của Duy đã xong.

### b) Việc cần làm trong kỳ tới (23/11 – 29/11, sprint 4)

Các mục đánh dấu xong được hoàn thành ngày 23–26/11, đầu tuần 4.

**Thái – Vẽ đồ thị**

- [x] S2-19: asmdef `Graphing`, `Exercises`, `UI`; interface `IGraphRenderer` trong `Core` (PR #4)
- [x] S2-08, S2-09: plugin NCalc; tiền xử lý biểu thức kiểu giáo khoa kèm test EditMode (PR #5)
- [x] S2-11, S2-10: đường cong y = f(x) và tô miền; khối tròn xoay quanh Ox (PR #5)
- [x] S3-05, S3-06: kiểm tra miền (f xác định và ≥ 0 trên [a, b]); cắt đường cong tại điểm gián đoạn; thanh trượt Sandbox đo thời gian dựng lại (PR #6)
- [x] S2-25: lập luận lý thuyết học tập (đa biểu diễn, học đa phương tiện, POE) gắn với tính năng app (PR #7)
- [x] S2-07: CODEOWNERS theo module
- [ ] S2-13: gắn đồ thị và khối vào `GraphRoot`, chạy trên Android (cùng Duy)
- [ ] Chồng n đĩa với thanh trượt; mặt cắt tại x
- [ ] GitHub Projects board

**Duy – Tracking và marker**

- [ ] S2-02: ghi số sao của marker v1; dưới 4 sao thì sửa thiết kế
- [ ] S2-04: đặt chiều rộng target 0,297 m; kiểm tra khối 1×1 cm tại (1, 1)
- [ ] S2-05: bật Extended Tracking (Device Pose Observer)
- [ ] S2-03, S3-04: đo lại tracking và độ lệch hệ trục
- [ ] S2-06: APK chạy trên 2 máy Android, có gọi NCalc
- [ ] Thay license key Vuforia đã lộ

**Hùng – Bài tập và UI**

- [ ] S2-15: ghi bộ bài vào `DECISIONS.md`
- [ ] Thống nhất wireframe với MVP (chọn hàm từ danh sách, sửa hệ số)
- [ ] S3-01: cấu trúc dữ liệu bài tập (ScriptableObject)
- [ ] S3-07: nạp bài mẫu từ dữ liệu và vẽ qua `IGraphRenderer`
- [ ] Màn hình luồng POE và bàn phím toán nhập tích phân
- [ ] S2-18: SUS tiếng Việt và mẫu pre/post test

**Cả nhóm**

- [ ] S3-02: lấy xác nhận của giảng viên về hướng bài học
- [ ] S2-21: chốt tài liệu quy ước nhóm, ký team contract
- [ ] Họp tích hợp trên máy thật: tracking + vẽ đồ thị

### c) Mốc

**Gate 1 (dời lần nữa, mục tiêu 29/11/2026): marker tracking ổn định.** Đạt khi cả 4 điều sau đúng trên máy Android thật:

1. Marker v1 đạt 4–5 sao trên Vuforia Target Manager.
2. Nhận phiếu ở 20–40 cm, nghiêng tới 60°.
3. Gốc O và trục của đồ thị AR trùng hệ trục in (lệch không quá 2–3 mm khi nhìn thẳng).
4. Che tay một góc phiếu, đồ thị vẫn còn.

Theo phương án khi trượt lần hai, đầu sprint 4 nhóm xem lại thiết kế phiếu; nếu sau các sửa trên tracking vẫn kém thì xét bản web dự phòng (MindAR.js). Gate 2 (06/12) giữ nguyên: tính năng chưa xong thì cắt.

**Lộ trình 8 tuần**

| Tuần | Ngày | Mục tiêu | Gate |
| --- | --- | --- | --- |
| 1 | 02–08/11 | Đăng ký đề, phân tích, kế hoạch, khởi tạo project, quy ước nhóm | |
| 2 | 09–15/11 | Hướng bài học: thể tích khối tròn xoay; mục tiêu học tập, luồng bài tập, phạm vi MVP | |
| 3 | 16–22/11 | Vuforia, marker v1, module tracking; mục tiêu học tập, 4 bài POE, wireframe | Trượt Gate 1 |
| 4 | 23–29/11 | Vẽ đồ thị trên phiếu (code đã xong), chạy trên Android; sửa cho Gate 1; chồng n đĩa; dữ liệu bài tập; màn hình POE và chấm điểm | **Gate 1 (thử lại)** |
| 5 | 30/11–06/12 | Ghép 3 module; nháp nội dung bài tập và câu hỏi pre/post | **Gate 2:** chốt tính năng lõi |
| 6 | 07–13/12 | Đủ 3–4 bài POE; in phiếu chính thức; thử nội bộ | **Gate 3:** sẵn sàng thử nghiệm |
| 7 | 14–20/12 | Đánh giá với 5–10 bạn cùng lớp: pre-test → học với app → post-test + SUS | |
| 8 | 21–23/12 | Phân tích số liệu, báo cáo, video demo, slide; nộp trước 13h30 23/12 | |
