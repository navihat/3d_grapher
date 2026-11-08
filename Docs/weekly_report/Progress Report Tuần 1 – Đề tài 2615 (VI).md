# PROGRESS REPORT — Tuần 1 (bản tiếng Việt để đọc)

> Bản dịch của `Progress Report Week 1 – Project 2615 (EN).md`. Bản nộp là bản tiếng Anh.

| Mục | Nội dung |
| --- | --- |
| Course | Augmented Reality – 20261 |
| Project code | 2615 |
| Project title | 3D Function Grapher on Paper – Vẽ đồ thị hàm số 2D/3D trên phiếu bài tập bằng AR |
| Design thinking page | https://www.figma.com/board/eeyqr3DnJk9avPdyrD8QcS/Untitled?node-id=0-1&p=f&t=R2Ikjy8rmYRArX16-0 |
| Members | 1. Trương Văn Thái – 20231627 · 2. Âu Mạnh Hùng – 20231593 · 3. Đào Khánh Duy – 20231583 |
| Reported working period | từ 02/11/2026 đến 08/11/2026 (tuần 1/8) |

## 1. Tóm tắt tiến độ

Tuần 1 là tuần khởi động, tập trung vào phân tích đề, lập kế hoạch và dựng nền móng cho làm việc nhóm. Ứng dụng nhắm tới học sinh THPT lớp 10–12: học sinh quét phiếu bài tập in bằng điện thoại Android, thấy đường cong 2D hoặc mặt cong 3D nổi đúng trên hệ trục in sẵn, rồi làm bài theo chu trình Dự đoán – Quan sát – Giải thích (POE).

Nhóm đã viết tài liệu phân tích và kế hoạch: làm rõ 9 điểm còn mở trong đề và chốt phương án mặc định cho từng điểm, liệt kê rủi ro kỹ thuật và sư phạm kèm hướng xử lý, chọn công nghệ (Unity + Vuforia, NCalc, Unity Mesh API), khảo sát 4 dự án tương tự và 3 bài nghiên cứu, xác định lý thuyết học tập nền, và lập lịch 8 tuần với 3 gate. Rủi ro lớn nhất là phiếu dạng đồ thị có ít đặc trưng nên Vuforia nhận diện kém; rủi ro này được kiểm tra ở Gate 1 (15/11).

Nhóm đã tạo repo GitHub, project Unity 6000.6.4f1 (URP, Force Text), cấu trúc thư mục, kiến trúc 5 module, bộ quy ước nhóm (code, git, Unity, cam kết nhóm), sổ quyết định và kế hoạch chi tiết sprint 2 (22 việc).

Tiến độ cộng dồn: hết tuần 1/8. Phần phân tích, kế hoạch và quy ước đã xong. Còn chuyển sang tuần 2: cài Vuforia, chạy thử trên máy Android và thiết kế marker. Chưa có code chức năng. Tuần 2 tập trung đạt Gate 1: phiếu in v1 tracking ổn định và mặt z = x² + y² nổi đúng trên hệ trục in; song song, nhóm đọc lại tài liệu để viết mục tiêu học tập và lập luận lý thuyết học tập.

## 2. Các hoạt động kỹ thuật

**Activity 1: Phân tích đề bài.** Làm rõ 9 điểm còn mở và chốt phương án: đối tượng THPT lớp 10–12; nhập hàm bằng bàn phím trên app + thanh trượt tham số (OCR là tính năng thêm); mỗi bài tập một image target; hệ trục in trên phiếu, mặc định 1 đơn vị = 1 cm; 6–8 bài theo POE, chấm tự động; hỗ trợ cả đường cong 2D và mặt 3D; chỉ build Android; đánh giá một nhóm với pre/post test + SUS trên 5–10 bạn cùng lớp (thử nghiệm ở trường THPT nằm ngoài phạm vi môn học). Câu hỏi về hình thức bài tập có hướng dẫn được đánh dấu cần hỏi giảng viên.

**Activity 2: Khảo sát dự án và nghiên cứu liên quan.** Khảo sát 4 dự án (AR 3D Graphs của Driessen, Math World của UBC, Catlike Coding – Mathematical Surfaces, GeoGebra 3D AR) và 3 bài nghiên cứu (Cheong et al. 2024; Ahmad & Junaini 2020; tổng quan trên IJLTER). Bài học chính: marker giống đồ thị tracking kém, và các dự án hiện có chỉ vẽ vài hàm có sẵn hoặc không gắn với phiếu bài tập. Lý thuyết nền: đa biểu diễn (Ainsworth), học đa phương tiện và mã hóa kép (Mayer, Paivio), POE.

**Activity 3: Chọn công nghệ và thiết kế kiến trúc.** Unity + Vuforia Engine (giấy phép Basic); NCalc để đọc biểu thức (loại codewriter Expression Parser vì thiếu sin/cos và tính -2^2 = 4); Unity Mesh API cho mặt cong, LineRenderer cho đường cong và hệ trục. Kiến trúc 5 module, mỗi module một assembly definition: `Core` (interface chung) ← `Tracking`, `Graphing` ← `Exercises`, `UI`. Đã phác 2 interface giữa các module (gốc tọa độ theo target, vẽ đồ thị), sẽ chốt ở tuần 2. Đồ thị là con của gốc tọa độ (`ImageTarget → GraphRoot → Surface`) nên module vẽ không phụ thuộc Vuforia.

**Activity 4: Dựng project và quy ước làm việc nhóm.** Tạo project Unity 6000.6.4f1 với URP, Asset Serialization = Force Text để scene/prefab đọc và diff được. Tạo repo GitHub và mời Duy, Hùng; cấu hình `.gitignore` cho Unity, `.gitattributes` cho Git LFS (ảnh, PDF, DOCX, DLL) và UnityYAMLMerge; commit theo Conventional Commits. Viết tài liệu nhóm: tổng quan kiến trúc, quy ước code C#, git workflow (GitHub Flow, Conventional Commits, quy tắc scene), quy trình làm việc với Unity (`.meta`, GUID), cam kết nhóm, hướng dẫn cho AI agent (`AGENTS.md`). Các tài liệu này đang ở dạng bản nháp, chờ cả nhóm chốt.

**Activity 5: Lập kế hoạch.** Lịch 8 tuần (02/11 – 27/12/2026) với 3 gate; phân công 3 vai trò; sổ quyết định (3 quyết định đầu tiên); kế hoạch sprint 2 gồm 22 việc có tiêu chí "xong khi" và 4 tiêu chí đạt Gate 1.

## 3. Đóng góp cá nhân

Vai trò cố định cả dự án: Duy – Tracking và marker; Thái – Vẽ đồ thị trong AR + AI; Hùng – Bài tập AR và tương tác.

| Thành viên | Việc đã làm tuần 1 | Đầu ra | Đóng góp vào tiến độ chung |
| --- | --- | --- | --- |
| Member 1: Trương Văn Thái – 20231627 | Phân tích đề; khảo sát dự án và nghiên cứu; chọn công nghệ và thiết kế kiến trúc; tạo repo GitHub, project Unity và cấu trúc thư mục; viết quy ước nhóm; lập kế hoạch 8 tuần và sprint 2 | Tài liệu phân tích & kế hoạch; repo GitHub và project Unity; 5 tài liệu quy ước nhóm; `AGENTS.md`; sổ quyết định; kế hoạch sprint 2 | Chốt phạm vi, công nghệ, kiến trúc và cách làm việc nhóm cho 7 tuần còn lại |
| Member 2: Âu Mạnh Hùng – 20231593 | Tham gia thảo luận phân tích đề và kế hoạch; thống nhất phân công | Góp ý cho phương án đề xuất và phân công | Xác nhận phạm vi phần Bài tập AR và UI mình phụ trách |
| Member 3: Đào Khánh Duy – 20231583 | Tham gia thảo luận phân tích đề và kế hoạch; thống nhất phân công | Góp ý cho phương án đề xuất và phân công | Xác nhận phạm vi phần Tracking và marker mình phụ trách |

## 4. Review code đã phát triển

### 4.1 Phát triển thuật toán

Tuần này mới thiết kế, chưa cài đặt:

- **Sinh mặt cong z = f(x, y):** lấy mẫu trên lưới N×N (N = 60–100) trong miền [xmin, xmax] × [ymin, ymax], mỗi ô nối thành 2 tam giác. Khi kéo thanh trượt chỉ cập nhật vị trí đỉnh, không tạo mesh mới.
- **Giá trị không xác định:** bỏ các tam giác có đỉnh NaN/∞; kẹp z trong khoảng hiển thị; cắt đường cong 2D tại điểm gián đoạn.
- **Đọc biểu thức:** tiền xử lý cách viết giáo khoa (`2x` → `2*x`, `sin x` → `sin(x)`, `x²` → `x^2`), rồi NCalc biên dịch thành delegate một lần.
- **Khớp hệ trục với phiếu:** nhập chiều rộng thật của target (mét) để quy đổi tỉ lệ; gốc O đặt tại vị trí cố định trên phiếu.

### 4.2 Mã nguồn đã viết hoặc sửa

- Chưa có code chức năng.
- Project Unity 6000.6.4f1 (URP) với scene mẫu mặc định.
- Repo GitHub: https://github.com/navihat/3d_grapher — `.gitignore`, `.gitattributes` (Git LFS, UnityYAMLMerge); đã mời Duy và Hùng.

### 4.3 Kết quả kiểm thử

Tuần này chưa có code nên chưa kiểm thử chức năng. Đã kiểm tra cấu hình project: Asset Serialization = Force Text trong `ProjectSettings/EditorSettings.asset`.

## 5. TODO

### a) Vấn đề còn tồn đọng

1. Chưa cài Vuforia; chưa kiểm tra Vuforia có hỗ trợ Unity 6000.6.4f1 không.
2. Chưa có marker và chưa chạy app trên máy Android, nên rủi ro lớn nhất (tracking) chưa được kiểm chứng.
3. Tài liệu quy ước nhóm còn là bản nháp; cam kết nhóm chưa ký.
4. Chưa chốt mục tiêu học tập và danh sách 6–8 hàm số theo chương trình.

### b) Việc cần làm tuần sau (09/11 – 15/11, sprint 2)

**Thái – Vẽ đồ thị**

- [ ] S2-07: GitHub Projects board + CODEOWNERS theo module
- [ ] S2-19: tạo `Assets/_Project/` với 5 asmdef; chốt 2 interface trong `Core`
- [ ] S2-08, S2-09: thêm NCalc; tiền xử lý biểu thức + 30 test EditMode
- [ ] S2-10, S2-11: sinh mặt z = f(x, y); hệ trục và đường cong 2D (tô màu theo độ cao chuyển sang tuần 3)
- [ ] S2-13: gắn mặt cong lên target của Duy

**Duy – Tracking và marker**

- [ ] S2-01: cài Vuforia, license key Basic
- [ ] S2-02, S2-03: phiếu marker v1 đạt 4–5 sao; in thử và đo tracking
- [ ] S2-04, S2-05: `GraphRoot` trùng hệ trục in; Extended Tracking
- [ ] S2-06: scene Main và Sandbox; build APK chạy trên 2 máy Android

**Hùng – Bài tập và UI**

- [ ] S2-14, S2-15: mục tiêu học tập; chốt 6–8 hàm và ý tưởng bài POE
- [ ] S2-16, S2-17: wireframe 4 màn hình trên Figma; FigJam phần Ideate
- [ ] S2-18: SUS bản tiếng Việt và mẫu pre/post test

**Nghiên cứu – ưu tiên cao**

- [ ] S2-23: đọc lại 3 bài nghiên cứu, mỗi người 1 bài, tóm tắt tối đa 1 trang/bài
- [ ] S2-24: phân tích lại 4 dự án, mỗi người phần gần module của mình
- [ ] S2-25 (Thái): lập luận lý thuyết học tập gắn với tính năng của app

**Cả nhóm**

- [ ] S2-21: chốt tài liệu quy ước nhóm, ký cam kết nhóm

### c) Mốc tiếp theo

**Gate 1 (15/11/2026): marker tracking ổn định.** Đạt khi cả 4 điều sau đúng trên máy Android thật:

1. Marker v1 đạt 4–5 sao trên Vuforia Target Manager.
2. Nhận phiếu ở khoảng cách 20–40 cm, nghiêng tới 60°.
3. Gốc O và trục của đồ thị AR trùng hệ trục in (lệch không quá 2–3 mm khi nhìn thẳng).
4. Che tay một góc phiếu, đồ thị vẫn còn.

Để đạt Gate 1 cần: Duy và Hùng clone repo và cài môi trường ngay thứ Hai để 3 người làm song song, Vuforia chạy được trên Unity 6000.6.4f1, marker v1 có số sao trước thứ Tư 11/11, và ghép Tracking với Graphing vào thứ Bảy 14/11. Nếu đến 15/11 marker vẫn tracking kém, nhóm đổi thiết kế phiếu trước khi làm tiếp; nếu vẫn kém, cân nhắc bản web dự phòng (MindAR.js).

**Lộ trình 8 tuần**

| Tuần | Ngày | Mục tiêu | Gate |
| --- | --- | --- | --- |
| 1 | 02–08/11 | Đăng ký đề, phân tích, kế hoạch, khởi tạo project, quy ước nhóm | |
| 2 | 09–15/11 | Phiếu in v1; mặt z = x² + y² nổi đúng trên hệ trục in, chạy trên Android | **Gate 1:** marker tracking ổn định |
| 3 | 16–22/11 | Parser + bộ test; đường cong 2D và mặt 3D; khớp hệ trục; dữ liệu bài tập | |
| 4 | 23–29/11 | Thanh trượt tham số; bàn phím toán; nhiều target; luồng POE và chấm điểm; ghi log | |
| 5 | 30/11–06/12 | Ghép 3 module; Extended Tracking; nháp nội dung bài và câu hỏi pre/post | **Gate 2:** chốt tính năng lõi |
| 6 | 07–13/12 | Đủ 6–8 bài POE; in phiếu chính thức; thử nội bộ | **Gate 3:** sẵn sàng thử nghiệm |
| 7 | 14–20/12 | Đánh giá với 5–10 bạn cùng lớp: pre-test → học với app → post-test + SUS | |
| 8 | 21–27/12 | Phân tích số liệu, báo cáo, video demo, slide; nộp 27/12 | |
