# Progress Report Tuần 1 – Đề tài 2615 (bản nháp)

Nov 7, 2026 · @Trương Văn Thái

Đến 21:00 Chủ nhật 08/11, mỗi người có một kết quả làm thật (APK, đoạn code chạy được, hoặc bảng FigJam) để đưa vào báo cáo tuần 1. Phần phân tích đề và kế hoạch đã làm trong tuần ghi ở Activity 1–2 của báo cáo. Phần việc cần làm hôm nay và mai nằm ngay dưới; bản nháp báo cáo ở cuối sẽ được cập nhật theo kết quả thật sau buổi họp, các chỗ **\[ĐIỀN\]** để trống đến lúc đó.

## Việc cần làm 07–08/11 (đọc trước)

### Lịch

| Thời gian | Việc |
| --- | --- |
| T7 07/11, 19:00–23:00 | Mỗi người cài đặt + đọc tài liệu phần mình; báo vướng mắc vào nhóm chat trước 23:00 |
| CN 08/11, 08:00–12:00 | Làm prototype nhỏ của phần mình, ghi lại ảnh chụp, video, số liệu |
| CN 08/11, 14:00–15:00 | Họp online: mỗi người demo 10 phút, chốt việc tuần 2 |
| CN 08/11, 15:00–19:00 | Mỗi người viết phần của mình trong báo cáo (mục 2, 3, 4) |
| CN 08/11, 19:00–21:00 | Thái tổng hợp, cả nhóm đọc lại, nộp |

### Duy – Tracking và marker

Mục tiêu: có app Vuforia chạy trên điện thoại thật và biết marker bản 0 được mấy sao.

Nghiên cứu (T7 tối):

- [Getting Started with Vuforia Engine in Unity](https://developer.vuforia.com/library/getting-started/getting-started-vuforia-engine-unity)
- [Best Practices for Image-Based Targets](https://developer.vuforia.com/library/objects/best-practices-designing-and-developing-image-based-targets): đặc trưng, độ tương phản, viền 8%, thang sao
- [Image Targets](https://developer.vuforia.com/library/objects/image-targets): chiều rộng target, Device Pose Observer / Extended Tracking

Làm:

- [ ] Cài Unity LTS + Vuforia, tạo tài khoản Vuforia Developer và license key Basic
- [ ] Scene: 1 image target + 1 khối lập phương nổi trên đó; build APK, chạy trên 2 máy Android
- [ ] Thiết kế phiếu A4 bản 0 (khung viền nhiều chi tiết + đề bài + hệ trục Oxy); tải lên Target Manager lấy số sao
- [ ] In phiếu, thử tracking: khoảng cách 20/40/60 cm, nghiêng 30°/60°, che tay một góc

Đầu ra cho báo cáo: video 15 giây trên máy thật, ảnh số sao, bảng kết quả thử tracking, phiên bản Unity/Vuforia đã dùng.

### Thái – Vẽ đồ thị + AI

Mục tiêu: nhập một chuỗi như "x^2 + y^2" và Unity sinh được mặt cong tương ứng.

Nghiên cứu (T7 tối):

- [Catlike Coding – Mathematical Surfaces](https://catlikecoding.com/unity/tutorials/basics/mathematical-surfaces/): thư viện hàm, lưới điểm, morphing
- Unity Mesh API: vertices, triangles, RecalculateNormals, cập nhật đỉnh mà không tạo mesh mới
- [NCalc](https://github.com/ncalc/ncalc): cách đưa DLL .NET Standard 2.0 vào Unity, tham số, biên dịch thành lambda

Làm:

- [ ] Tạo repo GitHub + Git LFS + .gitignore Unity, thư mục Tracking / Graph / Exercise, mời Duy và Hùng
- [ ] Script `SurfaceMesh.cs`: lưới N×N, nhận biểu thức từ chuỗi qua NCalc, bỏ đỉnh NaN/∞
- [ ] Hệ trục Oxyz bằng LineRenderer
- [ ] Thử 10 biểu thức (x^2+y^2, sin(x)\*cos(y), 1/x, sqrt(x), -2^2…) và đo thời gian sinh lưới với N = 60 và N = 100
- [ ] Nếu Duy xong sớm: gắn mặt cong lên image target của Duy

Đầu ra cho báo cáo: link repo, ảnh mặt cong trong Unity, bảng test biểu thức (đúng/sai, thời gian ms).

### Hùng – Bài tập AR và design thinking

Mục tiêu: có link FigJam cho header báo cáo và một bài tập mẫu viết đầy đủ.

Nghiên cứu (T7 tối):

- 5 bước design thinking: Empathize, Define, Ideate, Prototype, Test
- SGK Toán 10–12 (chương trình 2018): hàm bậc hai, khảo sát hàm số lớp 12, mặt phẳng và mặt cầu trong Oxyz
- Phương pháp Dự đoán – Quan sát – Giải thích (POE); thang SUS

Làm:

- [ ] FigJam: Empathize (persona học sinh, khó khăn khi hình dung đồ thị), Define (câu "How might we…", mục tiêu học tập), bắt đầu Ideate
- [ ] Danh sách 6–8 hàm số theo chương trình, kèm ý tưởng bài tập cho từng hàm
- [ ] Viết đầy đủ 1 bài tập POE mẫu: đề, câu dự đoán, thao tác AR, câu hỏi, đáp án, quy tắc chấm
- [ ] Wireframe 4 màn hình trên Figma: quét phiếu → nhập hàm → xem đồ thị → trả lời câu hỏi

Đầu ra cho báo cáo: link FigJam, bài tập mẫu, ảnh wireframe.

### Cả nhóm

- [ ] Tạo nhóm chat và thư mục chung (Drive) để lưu ảnh, video, số liệu
- [ ] Mỗi người ghi lại vướng mắc gặp phải: dùng cho mục "Remaining issues"

## Bản nháp báo cáo (cập nhật sau buổi họp CN)

## PROGRESS REPORT

| Mục | Nội dung |
| --- | --- |
| Course | Augmented Reality – 20261 |
| Project code | 2615 |
| Project title | 3D Function Grapher on Paper – Vẽ đồ thị hàm số 2D/3D trên phiếu bài tập bằng AR |
| Design thinking page | **\[ĐIỀN\]** link FigJam do Hùng tạo |
| Members | Trương Văn Thái · **\[ĐIỀN\]** họ tên Duy · **\[ĐIỀN\]** họ tên Hùng |
| Reported working period | from 02/11/2026 to 08/11/2026 (tuần 1/8) |

## 1. Summary of latest progress

Tuần 1 là tuần khởi động: nhóm đã đăng ký đề 2615, phân tích yêu cầu, chọn công nghệ, chia vai và dựng môi trường phát triển. Ứng dụng nhắm tới học sinh THPT lớp 10–12: học sinh quét phiếu bài tập in, nhập hàm số, và thấy đồ thị 2D hoặc mặt cong 3D nổi ngay trên trang giấy, kèm bài tập có hướng dẫn theo chu trình Dự đoán – Quan sát – Giải thích (POE).

Về phân tích, nhóm đã làm rõ 9 điểm còn mở trong đề bài (đối tượng, cách nhập phương trình, số marker, hệ trục, bài tập, đánh giá) và tự quyết định phương án mặc định cho từng điểm. Nhóm đã khảo sát các dự án tương tự (AR 3D Graphs, Math World của UBC, GeoGebra 3D AR) và 3 bài nghiên cứu về AR trong dạy Toán. Rủi ro lớn nhất là phiếu bài tập dạng đồ thị có ít đặc trưng nên Vuforia nhận diện kém.

Về kỹ thuật, nhóm chọn Unity + Vuforia image target, NCalc để đọc biểu thức và Unity Mesh API để sinh mặt cong. Trong tuần, nhóm **\[ĐIỀN: đã / chưa\]** cài xong Unity và Vuforia trên 3 máy, chạy app mẫu Vuforia trên **\[ĐIỀN\]**/2 máy Android, và có bản nháp marker đầu tiên đạt **\[ĐIỀN\]** sao. Bảng design thinking (Empathize, Define) đã được dựng trên FigJam.

Tiến độ cộng dồn: khoảng 10% (1/8 tuần), đúng kế hoạch. Tuần 2 tập trung đưa marker lên 4–5 sao và hiển thị mặt cong đầu tiên trên phiếu giấy.

## 2. Review of technical activities

**Activity 1: Phân tích đề bài và khảo sát liên quan.** Làm rõ 9 điểm chưa rõ của đề và chốt phương án: mỗi bài tập một image target; hệ trục in trên phiếu, mặc định 1 đơn vị = 1 cm; nhập hàm bằng bàn phím toán + thanh trượt tham số; hỗ trợ cả đường cong 2D và mặt 3D. Khảo sát 4 dự án và 3 bài nghiên cứu; rút ra bài học chính là marker dạng đồ thị dễ tracking kém.

**Activity 2: Chọn công nghệ và kiến trúc.** Unity LTS + Vuforia Engine (giấy phép Basic); NCalc để đọc biểu thức (loại codewriter Expression Parser vì thiếu sin/cos và tính sai -2^2); Unity Mesh API cho mặt cong, LineRenderer cho đường cong và hệ trục. Kiến trúc chia 3 module ghép qua giao diện chung: Tracking (cung cấp gốc tọa độ theo target) → Graph (vẽ đồ thị) → Exercise (luồng bài tập, chấm điểm).

**Activity 3: Dựng môi trường và kiểm tra thiết bị.** Cài Unity + Vuforia trên 3 máy; tạo tài khoản Vuforia Developer và license key; tạo repo GitHub với Git LFS và .gitignore cho Unity; build app mẫu Vuforia ra APK và chạy trên 2 máy Android. Kết quả: **\[ĐIỀN: máy nào chạy được, ảnh chụp màn hình\]**.

**Activity 4: Thiết kế marker bản 0.** Thiết kế phiếu A4 có khung viền nhiều chi tiết, đề bài và hệ trục; tải lên Vuforia Target Manager để lấy điểm. Kết quả: **\[ĐIỀN: số sao, ảnh phiếu\]**.

**Activity 5: Design thinking – Empathize và Define trên FigJam.** Persona học sinh THPT gặp khó khi hình dung đồ thị và mặt cong; phát biểu vấn đề dạng "How might we…"; mục tiêu học tập; lý thuyết nền (đa biểu diễn, học đa phương tiện, POE); hành trình người dùng của một bài tập: quét phiếu → nhập hàm → xem đồ thị → trả lời.

## 3. Personal contribution

Vai trò cố định cả dự án: Duy phụ trách Tracking và marker, Thái phụ trách Vẽ đồ thị trong AR + AI, Hùng phụ trách Bài tập AR và tương tác. Cả 3 người đều làm phần AR và chia đều việc nội dung, đánh giá.

| Thành viên | Việc đã làm tuần 1 | Đầu ra | Đóng góp vào tiến độ chung |
| --- | --- | --- | --- |
| Member 1: Duy – Tracking và marker | Cài Vuforia, tạo license key; build app mẫu Vuforia chạy trên 2 máy Android; thiết kế marker bản 0 và kiểm tra số sao | APK mẫu, ảnh chụp trên máy thật, marker v0 **\[ĐIỀN\]** sao | Xác nhận thiết bị chạy được công nghệ chọn; đo được mức độ của rủi ro marker ngay từ đầu |
| Member 2: Trương Văn Thái – Vẽ đồ thị + AI | Phân tích đề, khảo sát dự án và nghiên cứu; so sánh và chọn thư viện parser; tạo repo GitHub; viết prototype sinh mặt z = x² + y² trong Unity (chưa AR) | Tài liệu phân tích và kế hoạch, repo, scene prototype **\[ĐIỀN: ảnh chụp\]** | Chốt phạm vi, công nghệ và kiến trúc module; kiểm chứng hướng sinh mặt cong |
| Member 3: Hùng – Bài tập AR và tương tác | Dựng bảng FigJam phần Empathize và Define; viết mục tiêu học tập; phác 1 bài tập POE mẫu và luồng màn hình | Link FigJam, bài tập mẫu, wireframe luồng bài tập | Xác định người dùng và trải nghiệm học tập; là đầu vào cho module Exercise |

Mỗi người sửa cột "Việc đã làm" cho đúng thực tế trước buổi họp.

## 4. Developed code review

### 4.1 Algorithmic development

- **Sinh mặt cong z = f(x,y):** lấy mẫu trên lưới N×N điểm trong miền \[xmin, xmax\] × \[ymin, ymax\], tính z cho mỗi điểm, nối mỗi ô thành 2 tam giác. Dự kiến N = 60–100.
- **Xử lý giá trị không xác định:** đỉnh có z là NaN hoặc ∞ thì bỏ các tam giác chứa nó; z ngoài khoảng hiển thị thì kẹp lại.
- **Đọc biểu thức:** tiền xử lý cách viết giáo khoa (2x → 2\*x, sin x → sin(x), x² → x^2), rồi biên dịch bằng NCalc thành delegate một lần để tính nhanh khi kéo thanh trượt.
- **Khớp hệ trục với phiếu:** chiều rộng thật của target (mét) quy đổi ra tỉ lệ đơn vị trục; gốc O đặt tại vị trí cố định trên phiếu.

### 4.2 Source code enhanced and/or revised

- Tạo repo GitHub: **\[ĐIỀN: link repo\]**, cấu trúc thư mục theo 3 module Tracking / Graph / Exercise, Git LFS, .gitignore cho Unity.
- Scene mẫu Vuforia (image target + khối 3D test) do Duy cài đặt.
- Script prototype `SurfaceMesh.cs` sinh mặt z = x² + y² trong Unity Editor do Thái viết. **\[ĐIỀN: đã xong / đang làm\]**

### 4.3 Testing result

| Kiểm thử | Thiết bị | Kết quả |
| --- | --- | --- |
| App mẫu Vuforia nhận diện image target | Android 1: **\[ĐIỀN: tên máy\]** | **\[ĐIỀN: đạt / không đạt\]** |
| App mẫu Vuforia nhận diện image target | Android 2: **\[ĐIỀN: tên máy\]** | **\[ĐIỀN: đạt / không đạt\]** |
| Điểm marker v0 trên Target Manager | — | **\[ĐIỀN\]**/5 sao |
| Prototype sinh mặt z = x² + y² | Unity Editor | **\[ĐIỀN\]** |

## 5. TODO

### a) List of remaining issues

1. Marker v0 chưa chắc đạt 4–5 sao; phiếu dạng đồ thị dễ tracking kém.
2. Chưa có Mac để build iPhone; hiện chỉ test được trên Android.
3. Chưa chốt danh sách 6–8 hàm số theo chương trình Toán 10–12.
4. Chưa có trường hoặc lớp THPT nhận thử nghiệm tuần 7.
5. Thời gian chỉ còn 7 tuần, nên OCR công thức chỉ làm nếu lõi xong đúng M2.

### b) List of tasks to carry out in the next period (09/11–15/11)

**Duy – Tracking và marker**

- [ ] Sửa marker thành bản v1 đạt 4–5 sao, in thử trên giấy A4 mờ
- [ ] Đặt gốc tọa độ và hệ trục AR trùng hệ trục in trên phiếu
- [ ] Bật Extended Tracking, thử che tay lên phiếu

**Thái – Vẽ đồ thị trong AR**

- [ ] Tích hợp NCalc, viết bước tiền xử lý và bộ test 30 biểu thức
- [ ] Đưa mặt cong và đường cong 2D lên target của Duy
- [ ] Tô màu mặt theo độ cao

**Hùng – Bài tập AR và tương tác**

- [ ] Chốt 6–8 hàm số và ý tưởng bài tập POE cho từng hàm
- [ ] Thiết kế UI: ô nhập hàm, bàn phím toán, thanh trượt tham số
- [ ] Hoàn thiện FigJam phần Ideate

**Cả nhóm**

- [ ] Liên hệ trường THPT để hẹn lịch thử nghiệm tuần 14–20/12
- [ ] Họp tích hợp cuối tuần 2 trên máy Android thật

### c) Milestone

Mốc M1 (15/11/2026): quét phiếu in, mặt z = x² + y² nổi đúng trên hệ trục in, chạy trên máy Android thật. Để đạt M1 cần: marker v1 đạt 4–5 sao, parser chạy được, và ghép xong module Tracking với module Graph. Nếu đến 15/11 marker vẫn tracking kém, nhóm đổi thiết kế phiếu trước khi làm tiếp.

&#91;embedded content: lộ trình 8 tuần · 3 mốc\]

Từ tuần 3, mỗi tuần so tiến độ với lộ trình này trong báo cáo.
