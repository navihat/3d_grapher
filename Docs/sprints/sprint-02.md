# Sprint 2 — 09/11 – 15/11/2026

**Mục tiêu sprint:** quét phiếu in v1 bằng điện thoại Android, mặt z = x² + y² nổi đúng trên hệ trục in và không biến mất khi tay che một góc phiếu.

**Gate 1 (CN 15/11):** marker tracking ổn định. Đạt khi cả 4 điều sau đúng trên máy thật:

1. Marker v1 đạt 4–5 sao trên Vuforia Target Manager.
2. Nhận phiếu ở khoảng cách 20–40 cm, nghiêng tới 60°.
3. Gốc O và trục của đồ thị AR trùng hệ trục in (lệch không quá 2–3 mm khi nhìn thẳng).
4. Che tay một góc phiếu, đồ thị vẫn còn (Extended Tracking).

Trượt Gate 1 → đổi thiết kế phiếu trước khi làm tiếp; nếu vẫn kém, cân nhắc bản web dự phòng (MindAR.js).

Hiện trạng đầu sprint: project Unity mới (chưa có Vuforia, NCalc, `Assets/_Project/`); repo đã có trên GitHub (`navihat/3d_grapher`), đã mời Duy và Hùng. Các việc tuần 1 chưa xong được đưa vào sprint này.

## Việc

### Duy — Tracking và marker

| # | Việc | Xong khi | Issue | Trạng thái |
| --- | --- | --- | --- | --- |
| S2-01 | Cài Vuforia Engine vào project, thêm license key Basic | Project mở được trên cả 3 máy, không lỗi compile; license key không nằm trong repo public | | ⬜ |
| S2-02 | Thiết kế phiếu marker v1 (khung viền nhiều chi tiết, không lặp, tránh 8% viền ngoài) | Đạt 4–5 sao; PNG trong `Worksheets/targets/`, file gốc trong `Worksheets/source/` | | ⬜ |
| S2-03 | In thử trên A4 giấy mờ, đo tracking | Bảng kết quả: khoảng cách 20/40/60 cm × nghiêng 0/30/60° × che tay | | ⬜ |
| S2-04 | `GraphRoot`: gốc O trùng hệ trục in, nhập đúng chiều rộng thật của target (mét), 1 đơn vị = 1 cm | Một khối lập phương 1×1 cm đặt tại (1, 1) trùng ô (1, 1) trên phiếu | | ⬜ |
| S2-05 | Bật Extended Tracking (Device Pose Observer) | Che tay một góc phiếu, vật thể không biến mất | | ⬜ |
| S2-06 | Tạo `Scenes/Main.unity` và `Scenes/Sandbox/<Tên>.unity` cho 3 người; build APK | APK chạy trên 2 máy Android, ghi tên máy vào báo cáo tuần | | ⬜ |

### Thái — Vẽ đồ thị

| # | Việc | Xong khi | Issue | Trạng thái |
| --- | --- | --- | --- | --- |
| S2-07 | Tạo GitHub Projects board, CODEOWNERS theo module (remote GitHub, Git LFS, mời Duy và Hùng đã xong ở tuần 1) | Cả 3 người clone và push nhánh được; issue sprint 2 có trên board | | ⬜ |
| S2-08 | Thêm `NCalc.dll` vào `Assets/Plugins/` | Gọi được NCalc từ assembly `Grapher.Graphing` | | ⬜ |
| S2-09 | Tiền xử lý biểu thức kiểu giáo khoa (`2x`, `sin x`, `x²`) + bộ 30 test EditMode | 30 test chạy xanh, có `-2^2 = -4`; lỗi cú pháp trả thông báo tiếng Việt | | ⬜ |
| S2-10 | Sinh mặt z = f(x, y) trên lưới N×N, bỏ tam giác có đỉnh NaN/∞ | Vẽ được `x^2 + y^2`, `sin(x)*cos(y)`, `1/x`; đo thời gian sinh lưới N = 60 và N = 100 | | ⬜ |
| S2-11 | Hệ trục Oxyz và đường cong 2D bằng LineRenderer | Vẽ `y = x^2` dựng đứng trên mặt phiếu, kèm trục | | ⬜ |
| S2-12 | Tô màu mặt theo độ cao | Màu đổi theo z, nhìn rõ trên máy thật | | ⬜ |
| S2-13 | Gắn mặt cong làm con của `GraphRoot` (cùng Duy) | Mặt z = x² + y² nổi trên phiếu in, chạy trên Android | | ⬜ |

### Hùng — Bài tập và UI

| # | Việc | Xong khi | Issue | Trạng thái |
| --- | --- | --- | --- | --- |
| S2-14 | Viết mục tiêu học tập | 3–5 mục tiêu đo được, gắn với chương trình Toán 10–12 | | ⬜ |
| S2-15 | Chốt 6–8 hàm theo SGK + ý tưởng bài POE cho từng hàm | Danh sách hàm, mỗi hàm có câu dự đoán và câu hỏi giải thích; ghi vào `DECISIONS.md` | | ⬜ |
| S2-16 | Thiết kế UI trên Figma: ô nhập hàm, bàn phím toán, thanh trượt tham số | Wireframe 4 màn hình: quét phiếu → nhập hàm → xem đồ thị → trả lời | | ⬜ |
| S2-17 | Hoàn thiện FigJam phần Ideate | Link FigJam đưa vào báo cáo tuần 2 | | ⬜ |
| S2-18 | Thu thập SUS bản tiếng Việt và mẫu pre/post test | File lưu trên Drive nhóm | | ⬜ |

### Cả nhóm

| # | Việc | Người chính | Xong khi | Trạng thái |
| --- | --- | --- | --- | --- |
| S2-19 | Tạo `Assets/_Project/` với 5 asmdef; chốt 2 interface trong `Core` (gốc tọa độ theo target, vẽ đồ thị) | Thái (Duy, Hùng review) | Merge vào `main`; bảng interface trong `project-overview.md` cập nhật thành "đã chốt" | ⬜ |
| S2-21 | Review và chốt các file "bản nháp" trong `Docs/team/`, điền `team-contract.md` | Cả nhóm | Bỏ dòng "Bản nháp"; cả 3 người ký xác nhận | ⬜ |

## Lịch trong tuần

| Ngày | Việc |
| --- | --- |
| T2 09/11 | Duy và Hùng clone repo; tạo asmdef (S2-19) trước, để mọi người làm trên nhánh riêng |
| T4 11/11 | Cập nhật trạng thái giữa tuần; marker v1 phải có số sao — dưới 4 sao thì sửa ngay |
| T7 14/11 | Họp tích hợp trên máy Android thật: Tracking + Graphing (S2-13) |
| CN 15/11 | Demo Gate 1, review sprint, lập sprint 3, viết báo cáo tuần 2 |

## Rủi ro

| Rủi ro | Dấu hiệu sớm | Phương án |
| --- | --- | --- |
| Marker ít đặc trưng, tracking chập chờn | Dưới 4 sao vào T4 | Thêm chi tiết sắc nét ở khung viền, giảm vùng lưới lặp; thử lại ngay trong ngày |
| Vuforia chưa hỗ trợ Unity 6000.6.4f1 | Lỗi khi import package | Kiểm tra bảng tương thích trước khi cài; nếu cần, cả nhóm đổi bản Unity và ghi vào `DECISIONS.md` |
| NCalc không chạy trên Android (IL2CPP) | Lỗi runtime trên APK dù Editor chạy được | Build thử sớm một APK có gọi NCalc; dự phòng tự viết parser shunting-yard |
| Tích hợp dồn vào cuối tuần | S2-19 chưa merge vào T3 | Chốt interface đơn giản trước, chỉnh sau |

## Review (điền ở buổi họp CN 15/11)

- **Đạt Gate 1?**
- **Việc chuyển sang sprint 3:**
- **Retro:** giữ … · bỏ … · thử …
