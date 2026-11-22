# Ghi Chú Nghiên Cứu & Khảo Sát Dự Án Liên Quan

> **Đề tài 2615:** 3D Function Grapher on Paper  
> **Người thực hiện:** Đào Khánh Duy (Tracking & Marker)  
> **Cập nhật ngày:** 22/11/2026 (Sprint 3 / Gate 1)

---

## 1. Tóm tắt bài nghiên cứu: Tổng quan hệ thống trên IJLTER (Task S2-23)

* **Tên bài báo:** *Assessing the Influence of Augmented Reality in Mathematics Education: A Systematic Literature Review* (Đánh giá ảnh hưởng của Thực tế tăng cường trong giáo dục Toán học: Tổng quan hệ thống).
* **Nguồn:** International Journal of Learning, Teaching and Educational Research (IJLTER).
* **Phương pháp & Mẫu nghiên cứu:** 
  * Phân tích tổng quan hệ thống (Systematic Literature Review - PRISMA) trên 23 công trình nghiên cứu giai đoạn 2018–2022 từ hai cơ sở dữ liệu lớn Scopus và ERIC.
  * Đối tượng học sinh trải dài từ tiểu học, trung học cơ sở đến THPT và đại học.
* **Kết quả chính:**
  1. **Hiệu quả nhận thức (Cognitive Impact):** AR hỗ trợ mạnh mẽ việc trực quan hóa các khái niệm không gian và hình học trừu tượng, giúp học sinh chuyển đổi linh hoạt giữa biểu diễn 2D trên trang giấy và vật thể 3D trong không gian.
  2. **Tác động tâm lý (Affective Impact):** Giúp giảm đáng kể sự lo âu đối với môn Toán (Math anxiety), tăng mức độ hào hứng và thời gian tập trung vào bài tập.
  3. **Hạn chế được chỉ ra:** Nhiều ứng dụng AR chỉ dừng ở mức gây ấn tượng ban đầu ("hiệu ứng wow"), thiếu khung sư phạm dẫn dắt khiến học sinh chỉ xem mà không thực sự hiểu bản chất toán học phía sau.
* **Bài học áp dụng cho Đề tài 2615:**
  * **Cần khung sư phạm chặt chẽ:** Đề tài áp dụng chu trình **Dự đoán – Quan sát – Giải thích (POE)** thay vì chỉ cho học sinh xem đồ thị 3D thụ động.
  * **Tránh "hiệu ứng wow" sáo rỗng:** Tương tác chính là cắt lát $n$ đĩa mỏng quanh trục $Ox$, giúp học sinh tự trả lời câu hỏi *"Tại sao tích phân lại là thể tích?"*.

---

## 2. Phân tích dự án tham khảo: AR 3D Graphs của Driessen (Task S2-24)

* **Dự án:** *AR 3D Graphs* (Tác giả: H. Driessen, Đại học Công nghệ Eindhoven, nền tảng Unity + Vuforia).
* **Những gì dự án đã làm được:**
  * Vẽ đồ thị mặt cong 3D nổi trên bản in 2D bằng Unity Mesh API kết hợp Vuforia Image Target.
  * Có thanh trượt tinh chỉnh tham số hệ số $a, b$, tỉ lệ phóng to/thu nhỏ và xoay đồ thị.
  * Dùng `LineRenderer` vẽ hệ trục tọa độ 3D.
* **Những hạn chế kỹ thuật của dự án:**
  1. **Tracking kém ổn định trên mặt phẳng giấy:** Ảnh in đồ thị thông thường có quá ít điểm đặc trưng (ít góc nhọn, đường nét cong mượt, lặp lại) $\to$ Vuforia chấm điểm sao rất thấp (1–2 sao), đồ thị bị giật và chập chờn khi nghiêng camera.
  2. **Thiếu tính sư phạm:** Dự án chỉ cung cấp vài hàm toán học cố định làm sẵn, không gắn với bài tập trong sách giáo khoa và không có tương tác giải thích khái niệm.
* **Bài học áp dụng cho Module Tracking của Duy:**
  * **Thiết kế Marker chuyên dụng:** Khung viền phiếu in bắt buộc phải có hoa văn hình học bất đối xứng, mật độ góc cạnh cao và nằm cách mép giấy $>8\%$ để đạt điểm tối đa 4–5 sao trên Vuforia Target Manager.
  * **Căn chuẩn tỉ lệ cứng:** Phải khai báo chính xác kích thước thực tế của marker theo mét (`0.297m` cho khổ A4) và đặt gốc `GraphRoot` bù trừ tọa độ chính xác để đồ thị khớp hoàn toàn với hệ trục in sẵn.
  * **Bật Extended Tracking:** Bắt buộc kích hoạt Device Pose Observer để khi học sinh che tay lên giấy làm bài, đồ thị không bị biến mất đột ngột như trong dự án của Driessen.

---

## 3. Bảng đo đạc thực nghiệm Tracking Marker v1 (Task S2-03 & S3-04)

* **Thiết bị thử nghiệm:** Điện thoại Android (Camera Full HD, Android 13).
* **Vật liệu in:** Giấy A4 mờ (Matte paper 80gsm), in laser đen trắng 300 DPI.
* **Kích thước target in:** $297 \times 210\text{ mm}$ (Width khai báo trong Vuforia: `0.297m`).

### Bảng 1: Khả năng nhận diện theo khoảng cách và góc nghiêng (Task S2-03)

| Cự ly (cm) | Góc nhìn vuông góc ($0^\circ$) | Góc nghiêng $30^\circ$ | Góc nghiêng $60^\circ$ | Khi che tay $30\%$ diện tích phiếu |
| :---: | :---: | :---: | :---: | :---: |
| **20 cm** | Nhận diện tức thì (< 0.2s), rất ổn định | Ổn định, không rung | Ổn định, nhận đủ feature | Extended Tracking giữ vị trí tốt |
| **40 cm** *(khoảng cách cầm tay chuẩn)* | Rất ổn định, tracking mượt mà | Rất ổn định | Bắt tốt, không rung giật | Extended Tracking giữ vị trí ổn định |
| **60 cm** | Ổn định, bắt đầu có độ trễ nhẹ | Bắt được, hơi nhạy sáng | Khó bắt nếu ánh sáng yếu | Mất tracking nếu che quá $50\%$ |

### Bảng 2: Độ lệch hệ trục AR so với hệ trục in trên giấy (Task S3-04)

*Tiêu chuẩn đạt Gate 1: Độ lệch khi nhìn trực diện $\le 2\text{–}3\text{ mm}$.*

| Điểm kiểm tra trên hệ trục | Tọa độ lý thuyết trên giấy | Độ lệch nhìn trực diện ($0^\circ$) | Độ lệch góc nghiêng $30^\circ$ | Đánh giá |
| :--- | :---: | :---: | :---: | :---: |
| **Gốc tọa độ $O$** | $(0, 0)\text{ cm}$ | $\approx 0.5\text{ mm}$ | $\approx 1.0\text{ mm}$ | **Đạt xuất sắc** |
| **Điểm trên trục $Ox$ (1)** | $(2, 0)\text{ cm}$ | $\approx 1.0\text{ mm}$ | $\approx 1.5\text{ mm}$ | **Đạt** ($\le 2\text{mm}$) |
| **Điểm trên trục $Ox$ (2)** | $(4, 0)\text{ cm}$ | $\approx 1.0\text{ mm}$ | $\approx 2.0\text{ mm}$ | **Đạt** ($\le 2\text{mm}$) |
| **Điểm trên trục $Oy$ (1)** | $(0, 2)\text{ cm}$ | $\approx 0.5\text{ mm}$ | $\approx 1.2\text{ mm}$ | **Đạt** ($\le 2\text{mm}$) |
| **Điểm trên trục $Oy$ (2)** | $(0, 4)\text{ cm}$ | $\approx 1.2\text{ mm}$ | $\approx 1.8\text{ mm}$ | **Đạt** ($\le 2\text{mm}$) |
