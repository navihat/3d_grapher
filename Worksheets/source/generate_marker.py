import os
import math
import random
from PIL import Image, ImageDraw, ImageFont

def create_worksheet_marker():
    # Kích thước A4 Landscape ở 300 DPI: 297mm x 210mm
    # 1 inch = 25.4 mm -> 300 dpi -> 1 mm ≈ 11.811 pixels -> 1 cm ≈ 118.11 pixels
    DPI = 300
    PX_PER_CM = int(DPI / 2.54) # ~118 px/cm
    WIDTH = int(297 * DPI / 25.4)   # 3508 px
    HEIGHT = int(210 * DPI / 25.4)  # 2480 px

    # Khởi tạo ảnh nền trắng RGB
    img = Image.new("RGB", (WIDTH, HEIGHT), color=(255, 255, 255))
    draw = ImageDraw.Draw(img)

    # 1. KHUNG VIỀN NGOÀI & BỎ QUA 8% RÌA (Vuforia bỏ qua 8% mép ngoài)
    margin_x = int(WIDTH * 0.08) # ~280 px
    margin_y = int(HEIGHT * 0.08) # ~198 px
    
    inner_w = WIDTH - 2 * margin_x
    inner_h = HEIGHT - 2 * margin_y

    # Vẽ khung bo đôi
    draw.rectangle([margin_x, margin_y, WIDTH - margin_x, HEIGHT - margin_y], outline=(0, 0, 0), width=8)
    draw.rectangle([margin_x + 15, margin_y + 15, WIDTH - margin_x - 15, HEIGHT - margin_y - 15], outline=(40, 40, 40), width=3)

    # 2. HỌA TIẾT BẤT ĐỐI XỨNG CỰC NHIỀU ĐẶC TRƯNG GÓC CẠNH (Tạo điểm 5 sao cho Vuforia)
    # Vuforia cần các góc sắc nhọn, tương phản cao, không lặp lại tuần hoàn.
    random.seed(2615) # Seed cố định theo mã đề tài 2615 để đảm bảo tái lập 100%

    def draw_feature_cluster(cx, cy, size, density):
        """Vẽ cụm hoa văn hình học góc cạnh bất đối xứng quanh tâm (cx, cy)"""
        for _ in range(density):
            dx = random.randint(-size, size)
            dy = random.randint(-size, size)
            shape_type = random.choice(["tri", "poly", "cross", "rect"])
            col = random.choice([(0, 0, 0), (20, 20, 20), (50, 50, 50)])
            s = random.randint(15, 45)
            
            if shape_type == "tri":
                p1 = (cx + dx, cy + dy)
                p2 = (cx + dx + s, cy + dy + random.randint(-s, s))
                p3 = (cx + dx + random.randint(-s, s), cy + dy + s)
                draw.polygon([p1, p2, p3], fill=col)
            elif shape_type == "poly":
                pts = [
                    (cx + dx, cy + dy),
                    (cx + dx + s, cy + dy),
                    (cx + dx + s + 10, cy + dy + s),
                    (cx + dx - 5, cy + dy + s + 10)
                ]
                draw.polygon(pts, fill=col)
            elif shape_type == "cross":
                draw.line([(cx + dx - s, cy + dy), (cx + dx + s, cy + dy)], fill=col, width=6)
                draw.line([(cx + dx, cy + dy - s), (cx + dx, cy + dy + s)], fill=col, width=6)
            elif shape_type == "rect":
                draw.rectangle([cx + dx, cy + dy, cx + dx + s, cy + dy + s], fill=col)

    # Đặt 4 cụm hoa văn đặc trưng cực dày ở 4 góc (bên trong vùng hữu dụng của Vuforia)
    corner_offset_x = margin_x + 120
    corner_offset_y = margin_y + 120
    draw_feature_cluster(corner_offset_x, corner_offset_y, 90, 35)
    draw_feature_cluster(WIDTH - corner_offset_x, corner_offset_y, 90, 42)
    draw_feature_cluster(corner_offset_x, HEIGHT - corner_offset_y, 90, 38)
    draw_feature_cluster(WIDTH - corner_offset_x, HEIGHT - corner_offset_y, 90, 45)

    # Họa tiết dọc theo dải viền trên và dưới để tăng tracking khi nghiêng camera
    for i in range(1, 8):
        pos_x = margin_x + int(i * inner_w / 8)
        draw_feature_cluster(pos_x, margin_y + 40, 35, 12)
        draw_feature_cluster(pos_x, HEIGHT - margin_y - 40, 35, 12)

    for i in range(1, 6):
        pos_y = margin_y + int(i * inner_h / 6)
        draw_feature_cluster(margin_x + 40, pos_y, 35, 12)
        draw_feature_cluster(WIDTH - margin_x - 40, pos_y, 35, 12)

    # 3. TIÊU ĐỀ VÀ THÔNG TIN PHIẾU BÀI TẬP
    header_y = margin_y + 80
    draw.text((margin_x + 220, header_y), "PHIẾU HỌC TẬP AR — TOÁN 12 (KẾT NỐI TRI THỨC)", fill=(0, 0, 0))
    draw.text((margin_x + 220, header_y + 40), "BÀI 13: ỨNG DỤNG HÌNH HỌC CỦA TÍCH PHÂN — THỂ TÍCH KHỐI TRÒN XOAY", fill=(20, 20, 20))
    draw.line([(margin_x + 220, header_y + 80), (WIDTH - margin_x - 220, header_y + 80)], fill=(0, 0, 0), width=4)

    # 4. HỆ TRỤC TỌA ĐỘ Oxy CHUẨN XÁC (1 đơn vị = 1 cm)
    # Đặt gốc O ở vị trí chuẩn:
    # Gốc O cách mép trái phiếu 12 cm, cách mép dưới phiếu 8 cm
    origin_x = margin_x + int(8 * PX_PER_CM)   # ~1224 px
    origin_y = HEIGHT - margin_y - int(5 * PX_PER_CM) # ~1690 px

    # Lưới toạ độ nhẹ (1 cm x 1 cm)
    grid_units_x = 12 # 12 cm sang phải, 2 cm sang trái
    grid_units_y = 9  # 9 cm lên trên, 2 cm xuống dưới
    
    # Vẽ lưới mờ
    for u in range(-2, grid_units_x + 1):
        x = origin_x + u * PX_PER_CM
        draw.line([(x, origin_y - grid_units_y * PX_PER_CM), (x, origin_y + 2 * PX_PER_CM)], fill=(215, 215, 215), width=2)
    for v in range(-2, grid_units_y + 1):
        y = origin_y - v * PX_PER_CM
        draw.line([(origin_x - 2 * PX_PER_CM, y), (origin_x + grid_units_x * PX_PER_CM, y)], fill=(215, 215, 215), width=2)

    # Trục Ox
    ox_start = origin_x - int(2.5 * PX_PER_CM)
    ox_end = origin_x + int((grid_units_x + 0.8) * PX_PER_CM)
    draw.line([(ox_start, origin_y), (ox_end, origin_y)], fill=(0, 0, 0), width=6)
    # Mũi tên Ox
    draw.polygon([(ox_end, origin_y), (ox_end - 25, origin_y - 12), (ox_end - 25, origin_y + 12)], fill=(0, 0, 0))
    draw.text((ox_end - 10, origin_y + 15), "x (cm)", fill=(0, 0, 0))

    # Trục Oy
    oy_start = origin_y + int(2.5 * PX_PER_CM)
    oy_end = origin_y - int((grid_units_y + 0.8) * PX_PER_CM)
    draw.line([(origin_x, oy_start), (origin_x, oy_end)], fill=(0, 0, 0), width=6)
    # Mũi tên Oy
    draw.polygon([(origin_x, oy_end), (origin_x - 12, oy_end + 25), (origin_x + 12, oy_end + 25)], fill=(0, 0, 0))
    draw.text((origin_x + 20, oy_end), "y (cm)", fill=(0, 0, 0))

    # Gốc O
    draw.text((origin_x - 35, origin_y + 12), "O", fill=(0, 0, 0))

    # Vạch chia và số trên Ox (1cm = 1 đơn vị)
    for u in range(1, grid_units_x + 1):
        x = origin_x + u * PX_PER_CM
        draw.line([(x, origin_y - 10), (x, origin_y + 10)], fill=(0, 0, 0), width=4)
        draw.text((x - 8, origin_y + 18), str(u), fill=(0, 0, 0))

    # Vạch chia và số trên Oy (1cm = 1 đơn vị)
    for v in range(1, grid_units_y + 1):
        y = origin_y - v * PX_PER_CM
        draw.line([(origin_x - 10, y), (origin_x + 10, y)], fill=(0, 0, 0), width=4)
        draw.text((origin_x - 35, y - 10), str(v), fill=(0, 0, 0))

    # 5. KHUNG BÀI TẬP VÀ CHU TRÌNH POE (Bên phải hệ trục)
    box_x1 = origin_x + int(6.5 * PX_PER_CM)
    box_y1 = margin_y + 160
    box_x2 = WIDTH - margin_x - 80
    box_y2 = origin_y - int(3 * PX_PER_CM)

    draw.rectangle([box_x1, box_y1, box_x2, box_y2], outline=(0, 0, 0), width=4)
    draw.rectangle([box_x1, box_y1, box_x2, box_y1 + 50], fill=(230, 230, 230))
    draw.text((box_x1 + 20, box_y1 + 15), "BÀI TẬP 1 (POE): QUAY ĐƯỜNG CONG QUANH Ox", fill=(0, 0, 0))

    exercise_text = [
        "Cho hàm số: y = f(x) = sqrt(x) trên đoạn [0, 4].",
        "Miền phẳng (H) giới hạn bởi đồ thị y = sqrt(x), trục hoành và đường thẳng x = 4.",
        "",
        "[Bước 1 - Dự đoán]: Khi quay miền (H) quanh trục Ox một vòng,",
        "khối tròn xoay tạo thành có hình dạng gì? Thể tích dự đoán khoảng bao nhiêu?",
        "",
        "[Bước 2 - Quan sát]: Quét camera vào hệ trục bên cạnh để thấy đồ thị & khối 3D.",
        "Kéo thanh trượt số đĩa n (1 -> 50) để quan sát các lát cắt hội tụ về khối thực.",
        "",
        "[Bước 3 - Giải thích & Tính toán]:",
        "Thiết lập công thức tích phân thể tích: V = pi * integral[0, 4] (sqrt(x))^2 dx.",
        "Nhập kết quả vào ứng dụng để kiểm tra đáp án."
    ]

    ty = box_y1 + 75
    for line in exercise_text:
        draw.text((box_x1 + 25, ty), line, fill=(20, 20, 20))
        ty += 38

    # 6. GHI CHÚ TỶ LỆ & TARGET ID
    footer_text = f"Mã Marker: worksheet_lesson13_01  |  Tỷ lệ in: 1 đơn vị = 1.0 cm (Khổ A4 ngang: 297mm x 210mm)  |  Đề tài 2615"
    draw.text((margin_x + 100, HEIGHT - margin_y - 50), footer_text, fill=(70, 70, 70))

    # Lưu file PNG
    output_png = "Worksheets/targets/worksheet_v1.png"
    os.makedirs(os.path.dirname(output_png), exist_ok=True)
    img.save(output_png, "PNG", dpi=(300, 300))
    print(f"Đã tạo marker thành công: {output_png} (Kích thước: {WIDTH}x{HEIGHT})")

    # In ra tọa độ gốc O tương đối so với tâm ảnh (phục vụ tính toán GraphRoot trong Unity)
    # Trong Vuforia: Tâm ảnh là (0,0), chiều rộng = 0.297m, chiều cao = 0.210m
    center_x = WIDTH / 2.0
    center_y = HEIGHT / 2.0
    
    # Tính offset từ tâm ảnh tới gốc O (theo mét)
    offset_x_m = (origin_x - center_x) * (0.297 / WIDTH)
    # Trục Y trong ảnh đi xuống, trong Unity Y đi lên (hoặc Z đi tới)
    offset_y_m = (center_y - origin_y) * (0.210 / HEIGHT)

    print(f"Toạ độ gốc O trên ảnh: ({origin_x}, {origin_y})")
    print(f"Offset từ tâm ImageTarget đến gốc O: X = {offset_x_m:.4f} m, Y = {offset_y_m:.4f} m")

if __name__ == "__main__":
    create_worksheet_marker()
