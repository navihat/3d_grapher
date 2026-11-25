# Bộ bài POE – Diện tích hình phẳng và thể tích khối tròn xoay quanh Ox

Sprint 3 · Hùng (S2-14, S2-15) · Bản nháp để Thái review · Căn cứ: SGK Toán 12 tập 2 (Kết nối tri thức), Bài 13, mục 1a (diện tích hình phẳng giới hạn bởi một đồ thị, trục hoành, x = a, x = b) và mục 2b (thể tích khối tròn xoay)

## Mục tiêu học tập

Mục tiêu bám theo phần "Kiến thức, kĩ năng" của Bài 13 (dùng tích phân tính diện tích hình phẳng và thể tích vật thể) và hai công thức trong khung kiến thức của SGK: S = ∫ₐᵇ |f(x)| dx (mục 1a) và V = π∫ₐᵇ f²(x) dx (mục 2b). Bộ bài gồm 4 bài; mỗi mục tiêu gắn với những bài đo nó.

| Mục tiêu | Nội dung | Bằng chứng đạt | Bài đo |
| --- | --- | --- | --- |
| MT1 | Xác định miền phẳng giới hạn bởi y = f(x), trục Ox, x = a, x = b từ đồ thị hoặc công thức; tìm các điểm đồ thị cắt Ox trong \[a; b\] | Nêu đúng a, b và các điểm f(x) = 0 trong \[a; b\] (nếu có) | 1, 2, 4 |
| MT2 | Lập và tính S = ∫ₐᵇ \|f(x)\| dx: bỏ dấu giá trị tuyệt đối khi f không đổi dấu, tách đoạn tại nghiệm khi f đổi dấu; phân biệt S với ∫ₐᵇ f(x) dx | S đúng; giải thích được vì sao S khác ∫f khi f đổi dấu | 1, 2 |
| MT3 | Mô tả khối tròn xoay tạo thành khi quay miền quanh Ox; dự đoán hoặc so sánh thể tích | Dự đoán đúng hình dạng hoặc kết quả so sánh, kèm lý do | 3, 4 |
| MT4 | Giải thích mặt cắt vuông góc với Ox là hình tròn bán kính f(x), diện tích S(x) = πf²(x); lập và tính V = π∫ₐᵇ f²(x) dx | Nêu đúng bán kính; V đúng | 3, 4 |
| MT5 | Phân biệt công thức diện tích với công thức thể tích; phát hiện và sửa lời giải sai | Chỉ ra lỗi thiếu bình phương và giải thích; sửa đúng | 3 |

**Tiêu chí đạt chung:** đúng ít nhất 4/5 câu trong bài test sau (mỗi câu ứng với một mục tiêu), trong đó phải có MT2 và MT4. Việc nhận diện đúng hình AR hoặc đọc kết quả từ ứng dụng không phải bằng chứng duy nhất.

## Lập luận lý thuyết học tập

Thái (S2-25) · Bản nháp chờ Hùng review

**Khó khăn cần giải quyết.** Học sinh thường thuộc công thức V = π∫ₐᵇ f²(x) dx nhưng không giải thích được vì sao có π và bình phương, hay vì sao tích phân lại là thể tích. Các nghiên cứu về hiểu tích phân cho thấy học sinh làm được phép tính nhưng ít người hiểu tích phân là giới hạn của tổng các phần nhỏ (Orton, 1983; Sealey, 2014). Với khối tròn xoay còn thêm một bước khó: phải tưởng tượng được khối 3D từ một hình phẳng 2D in trên giấy. Ba lý thuyết dưới đây giải thích vì sao các tính năng của app giúp được ở chỗ này. Đây cũng là câu trả lời cho hạn chế mà tổng quan IJLTER nêu ra ([research-notes.md](research-notes.md), mục 1): nhiều app AR chỉ gây "hiệu ứng wow", không có khung sư phạm.

### 1. Đa biểu diễn (Ainsworth)

Ainsworth (2006) đưa ra khung DeFT, theo đó dùng nhiều biểu diễn cùng lúc có ba chức năng: **bổ sung** cho nhau (mỗi biểu diễn cho thấy điều mà biểu diễn khác không cho thấy), **ràng buộc** cách hiểu (biểu diễn quen thuộc giúp đọc biểu diễn lạ) và **xây dựng hiểu biết sâu hơn** khi người học tự nối các biểu diễn với nhau. Ainsworth cũng chỉ ra cái giá: người học phải hiểu từng biểu diễn và phải chuyển được giữa chúng; nếu không được hỗ trợ, họ thường xem từng biểu diễn riêng lẻ mà không nối lại.

Bài này có bốn biểu diễn của cùng một đại lượng: công thức f(x) và tích phân, đồ thị và miền phẳng trên giấy, khối tròn xoay 3D, và tổng các đĩa mỏng.

| Chức năng (Ainsworth) | Tính năng của app | Mục tiêu |
| --- | --- | --- |
| Bổ sung | Phiếu in giữ đồ thị 2D và miền phẳng (đọc được a, b, nghiệm); AR thêm khối 3D, cho thấy hình dạng khối mà hình phẳng không cho thấy | MT1, MT3 |
| Ràng buộc | Khối AR mọc lên từ đúng miền phẳng in sẵn, trục Ox của khối trùng trục Ox in (Gate 1: lệch ≤ 2–3 mm), nên học sinh dùng đồ thị quen thuộc để đọc khối lạ | MT3 |
| Xây dựng hiểu biết sâu | **Thanh chọn x:** tô cùng lúc điểm (x; f(x)) trên đồ thị và mặt cắt tròn bán kính f(x) trên khối, kèm giá trị πf²(x). Học sinh thấy bán kính mặt cắt chính là tung độ của đồ thị, từ đó giải thích được vì sao phải bình phương | MT4, MT5 |
| Xây dựng hiểu biết sâu | **Thanh trượt n đĩa:** chồng n đĩa mỏng, đĩa thứ i có thể tích π·f(xᵢ)²·Δx; tăng n thì chồng đĩa khớp dần với khối và tổng tiến tới giá trị tích phân. Đây là cầu nối giữa tổng Riemann và công thức tích phân (Sealey, 2014) | MT4 |

Để giảm cái giá chuyển đổi biểu diễn mà Ainsworth cảnh báo, app **liên kết động** các biểu diễn (kéo một thanh, mọi biểu diễn cập nhật cùng lúc) và không đưa thêm biểu diễn ngoài bốn loại trên.

### 2. Học đa phương tiện (Mayer) và mã hóa kép (Paivio)

Theo thuyết mã hóa kép, thông tin bằng lời và bằng hình được xử lý ở hai hệ riêng; khi cả hai hệ cùng được dùng và nối với nhau thì nhớ và hiểu tốt hơn (Paivio, 1986). Mayer (2009) xây thuyết học đa phương tiện trên ý này, cộng thêm hai giả định: mỗi kênh có sức chứa giới hạn, và người học phải chủ động chọn, sắp xếp, tích hợp thông tin. Từ đó Mayer rút ra các nguyên tắc thiết kế; app dùng những nguyên tắc sau:

| Nguyên tắc (Mayer, 2009) | Nội dung | Tính năng của app |
| --- | --- | --- |
| Liền kề không gian | Chữ và hình liên quan đặt sát nhau | Đồ thị và khối nổi ngay trên đề bài in trên phiếu, không phải nhìn qua lại giữa sách và màn hình khác. Đây cũng là cách tránh hiệu ứng chia tách chú ý (split-attention) của thuyết tải nhận thức (Sweller và cộng sự, 1998) |
| Liền kề thời gian | Lời và hình xuất hiện cùng lúc | Khi kéo thanh chọn x, giá trị f(x) và πf²(x) hiện ngay cạnh mặt cắt, cùng lúc mặt cắt thay đổi |
| Báo hiệu | Làm nổi phần quan trọng | Tô màu miền phẳng; Bài 2 tô hai phần trên và dưới Ox hai màu; làm nổi mặt cắt đang chọn |
| Mạch lạc | Bỏ chi tiết không phục vụ mục tiêu | Không có hiệu ứng trang trí, không xoay khối tự động; chỉ hiện những hình phục vụ câu hỏi của bài (ví dụ khung trụ mờ ở Bài 3 chỉ để so sánh thể tích) |
| Phân đoạn | Chia bài thành bước do người học điều khiển nhịp | Mỗi bài đi theo bốn bước Dự đoán → Quan sát → Giải thích → Lập tích phân; học sinh tự bấm sang bước sau |

### 3. Dự đoán – Quan sát – Giải thích (POE)

POE do White và Gunstone (1992) đề xuất để thăm dò hiểu biết của người học: người học **dự đoán** kết quả và nêu lý do, **quan sát** điều xảy ra, rồi **giải thích** chỗ khác nhau giữa dự đoán và quan sát. Dự đoán trước buộc học sinh lộ ra quan niệm sẵn có; khi quan sát mâu thuẫn với dự đoán, học sinh có lý do để sửa quan niệm. Kearney (2004) dùng POE với video và mô phỏng trên máy tính và thấy hình thức này giúp học sinh trao đổi, xem lại quan niệm của mình; đây là trường hợp gần với app vì phần "quan sát" cũng do phần mềm đảm nhiệm.

| Bước POE | Tính năng của app | Ví dụ trong bộ bài |
| --- | --- | --- |
| Dự đoán | 3 câu trắc nghiệm (kết quả + lý do); **app khóa hình AR cho tới khi học sinh nộp dự đoán**, để học sinh không xem rồi mới "đoán" | Bài 3: khối có hình dạng gì, thể tích khoảng bao nhiêu phần hình trụ |
| Quan sát | Hiện khối, thanh chọn x, thanh trượt n đĩa, hình so sánh (tam giác OAB, khung trụ) | Bài 1: so độ cao đồ thị với đoạn OB tại cùng x |
| Giải thích | Câu hỏi mở đối chiếu dự đoán với điều thấy được; chấm theo rubric Đúng / Một phần / Sai | Bài 2: vì sao ∫sin x dx = 0 mà diện tích dương |
| Lập tích phân (bước thêm của nhóm) | Ô nhập tích phân và đáp số; app chấm và chỉ ra bước sai (quên bình phương, quên π, sai cận); không hiện đáp án trước khi nộp | Bài 3: tìm lỗi thiếu bình phương trong lời giải mẫu |

Bước thứ tư được thêm vì POE gốc dừng ở giải thích, còn mục tiêu MT2, MT4 yêu cầu học sinh lập và tính được tích phân. Các lời giải "tự nhiên nhưng sai" (Bài 2: tính ∫f thay vì ∫|f|; Bài 3: thiếu bình phương) được chọn có chủ đích để dự đoán của học sinh có khả năng sai, tạo ra mâu thuẫn mà bước Quan sát giải quyết.

### Tóm tắt: tính năng → lý thuyết → mục tiêu

| Tính năng | Lý thuyết | Mục tiêu |
| --- | --- | --- |
| Đồ thị và khối AR trùng hệ trục in trên phiếu | Đa biểu diễn (ràng buộc); liền kề không gian | MT1, MT3 |
| Tô miền, tô hai màu theo dấu f | Báo hiệu | MT1, MT2 |
| Thanh chọn x: điểm trên đồ thị ↔ mặt cắt πf²(x) | Đa biểu diễn (xây dựng hiểu biết); liền kề thời gian | MT4, MT5 |
| Thanh trượt n đĩa mỏng | Đa biểu diễn (tổng Riemann ↔ tích phân) | MT4 |
| Khóa AR đến khi nộp dự đoán | POE (dự đoán) | MT3 |
| Câu hỏi giải thích + rubric | POE (giải thích) | MT2, MT5 |
| Chấm tích phân, chỉ ra bước sai | POE (bước lập tích phân); phản hồi theo lỗi cụ thể | MT2, MT4, MT5 |
| Bốn bước, học sinh tự sang bước | Phân đoạn; mạch lạc | tất cả |

**Giới hạn và cách kiểm chứng.** Các lý thuyết trên chỉ cho biết thiết kế có cơ sở, không chứng minh app hiệu quả. Nhóm sẽ kiểm chứng bằng bài test trước/sau theo 5 mục tiêu và thang SUS với 5–10 bạn cùng lớp (xem `DECISIONS.md`, 08/11). Mẫu nhỏ và người thử đã học tích phân, nên kết quả chỉ mang tính gợi ý; bài test cần có câu đủ khó (giải thích vì sao bình phương, phát hiện lời giải sai) để tránh đạt điểm tối đa ngay từ đầu.

### Tài liệu tham khảo

- Ainsworth, S. (2006). DeFT: A conceptual framework for considering learning with multiple representations. *Learning and Instruction, 16*(3), 183–198.
- Kearney, M. (2004). Classroom use of multimedia-supported predict–observe–explain tasks in a social constructivist learning environment. *Research in Science Education, 34*(4), 427–453.
- Mayer, R. E. (2009). *Multimedia learning* (2nd ed.). Cambridge University Press.
- Orton, A. (1983). Students' understanding of integration. *Educational Studies in Mathematics, 14*(1), 1–18.
- Paivio, A. (1986). *Mental representations: A dual coding approach*. Oxford University Press.
- Sealey, V. (2014). A framework for characterizing student understanding of Riemann sums and definite integrals. *Journal of Mathematical Behavior, 33*, 230–249.
- Sweller, J., van Merriënboer, J. J. G., & Paas, F. G. W. C. (1998). Cognitive architecture and instructional design. *Educational Psychology Review, 10*(3), 251–296.
- White, R. T., & Gunstone, R. F. (1992). *Probing understanding*. Falmer Press.

## Cách dùng

Mỗi bài đi theo bốn bước: **Dự đoán (Predict)** → **Quan sát (Observe)** → **Giải thích (Explain)** → **Lập tích phân và nộp đáp số**. Mỗi bài có 3 câu dự đoán trắc nghiệm; học sinh nộp dự đoán xong, app mới hiện hình AR. App không hiện đáp án trước khi học sinh nộp lời giải.

Với mọi bài: hình phẳng giới hạn bởi đồ thị y = f(x) liên tục trên \[a; b\], trục Ox và hai đường thẳng x = a, x = b. Phần A (Bài 1, 2) tính diện tích theo công thức SGK S = ∫ₐᵇ |f(x)| dx. Phần B (Bài 3, 4; SGK yêu cầu f(x) ≥ 0 trên \[a; b\]) quay hình phẳng quanh trục Ox và tính V = π∫ₐᵇ f²(x) dx.

| Bài | Hàm, cận | Nguồn SGK | Mục tiêu | Đáp án |
| --- | --- | --- | --- | --- |
| 1 | y = x³, \[0; 2\] | Ví dụ 1 (H.4.13) | MT1, MT2 | S = 4 |
| 2 | y = sin x, \[0; 2π\] | Ví dụ 2 (H.4.14) | MT1, MT2 | S = 4 (∫f = 0) |
| 3 | y = 2x − x², \[0; 2\] | Bài tập 4.17 | MT3, MT4, MT5 | V = 16π/15 |
| 4 | y = √(4 − x²), \[−2; 2\] | Ví dụ 8 (R = 2, H.4.27) | MT1, MT3, MT4 | V = 32π/3 |

## Phần A – Diện tích hình phẳng (SGK mục 1a)

Hai bài đi từ trường hợp f không đổi dấu (Bài 1) đến trường hợp f đổi dấu (Bài 2), đúng mạch của SGK: Ví dụ 1 → Ví dụ 2. Bài 2 dùng một lời giải "tự nhiên nhưng sai" (tính ∫f(x)dx thay vì ∫|f(x)|dx), nên dự đoán trước giúp học sinh thấy vì sao SGK cần dấu giá trị tuyệt đối.

### Bài 1 – Diện tích dưới đường cong so với tam giác (SGK Ví dụ 1)

**Đề bài.** Cho hình phẳng giới hạn bởi đồ thị hàm số y = x³, trục hoành và hai đường thẳng x = 0, x = 2. Tam giác OAB có O(0; 0), A(2; 0), B(2; 8) được vẽ nét đứt và có diện tích 8. Yêu cầu: dự đoán diện tích miền so với tam giác OAB, giải thích dự đoán, rồi lập tích phân và tính diện tích S.

**Dự đoán (trước khi xem AR).**

1. Diện tích miền được tô so với diện tích tam giác OAB:  
   A. Lớn hơn  
   B. Nhỏ hơn  
   C. Bằng nhau
2. Diện tích miền được tô chiếm khoảng bao nhiêu phần diện tích tam giác OAB?  
   A. Gần cả tam giác  
   B. Khoảng 3/4  
   C. Khoảng một phần tư  
   D. Khoảng một nửa
3. Lý do nào giải thích đúng nhất dự đoán của em?  
   A. Miền được tô và tam giác OAB có chung đáy OA và chung cận x = 2, nên diện tích bằng nhau.  
   B. Tại mọi giá trị x trong (0; 2), đồ thị y = x³ cao hơn đoạn OB, nên miền được tô lớn hơn tam giác.  
   C. Tại mọi giá trị x trong (0; 2), đồ thị y = x³ thấp hơn đoạn OB, nên miền được tô nằm trong tam giác.  
   D. Đồ thị y = x³ tăng rất nhanh nên miền được tô có diện tích rất lớn.

**Quan sát (AR).** App tô miền phẳng và hiện tam giác OAB chồng lên đồ thị. Học sinh kéo thanh chọn x để so sánh độ cao của đồ thị với đoạn OB tại cùng một x.

**Giải thích.** Tại x = 1, đồ thị cao bao nhiêu và đoạn OB cao bao nhiêu? Từ đó giải thích vì sao miền nhỏ hơn tam giác.

**Lập tích phân.** Viết tích phân tính diện tích S theo công thức S = ∫|f(x)|dx và tính giá trị. Vì sao ở bài này có thể bỏ dấu giá trị tuyệt đối?

**Đáp án Dự đoán.** 1. B; 2. D; 3. C.

**Đáp án.** Nhỏ hơn, khoảng một nửa; đồ thị nằm phía dưới đoạn OB. Đường thẳng OB là y = 4x, và x³ ≤ 4x trên \[0; 2\] (vì x² ≤ 4). Vì x³ ≥ 0 trên \[0; 2\] nên |x³| = x³ và S = ∫₀² x³ dx = x⁴/4 |₀² = **4**, bằng một nửa diện tích tam giác OAB.

**Rubric Explain.** Đúng: so sánh f(x) với đường thẳng OB tại một hoặc nhiều giá trị x (tại x = 1: 1 so với 4) và kết luận. Một phần: nói "đồ thị cong xuống nên nhỏ hơn" mà không so sánh số. Sai: kết luận bằng nhau vì cùng đáy và cùng cận.

### Bài 2 – Một chu kỳ của sin x (SGK Ví dụ 2)

**Đề bài.** Cho hình phẳng giới hạn bởi đồ thị hàm số y = sin x, trục hoành và hai đường thẳng x = 0, x = 2π. Một bạn học sinh tính ∫₀^{2π} sin x dx = −cos x |₀^{2π} = 0 và kết luận diện tích bằng 0. Yêu cầu: dự đoán và giải thích, rồi tính diện tích S đúng.

**Dự đoán (trước khi xem AR).**

1. Kết luận S = 0 của bạn học sinh:  
   A. Đúng, vì tích phân bằng 0 thì diện tích bằng 0  
   B. Sai, vì hình phẳng này có diện tích dương  
   C. Chưa đủ cơ sở để kết luận
2. Gọi S₁ là diện tích phần miền phía trên trục hoành. Diện tích S của cả miền gấp mấy lần S₁?  
   A. 0 lần  
   B. 1/2 lần  
   C. 1 lần  
   D. 2 lần
3. Lý do nào giải thích đúng nhất vì sao tích phân bằng 0 nhưng diện tích khác 0?  
   A. Hai phần miền có diện tích bằng nhau nhưng tích phân của chúng trái dấu nên cộng lại bằng 0; còn diện tích thì phải cộng cả hai phần.  
   B. Phần miền phía dưới trục hoành không thuộc hình phẳng cần tính diện tích.  
   C. Hàm sin x tuần hoàn nên tích phân trên một chu kỳ luôn bằng diện tích.  
   D. Phần miền phía trên trục hoành có diện tích lớn hơn phần phía dưới.

**Quan sát (AR).** App tô hai phần miền hai màu. Học sinh kéo thanh chọn x để thấy f(x) đổi dấu tại x = π và so sánh độ cao hai phần tại các điểm đối xứng qua x = π.

**Giải thích.** Vì sao ∫₀^{2π} sin x dx = 0 mà hình phẳng vẫn có diện tích dương? Tích phân của nửa dưới trục hoành mang dấu gì?

**Lập tích phân.** Tách S = ∫₀^{2π} |sin x| dx thành hai tích phân bỏ được dấu giá trị tuyệt đối và tính S.

**Đáp án Dự đoán.** 1. B; 2. D; 3. A.

**Đáp án.** Không đồng ý; S gấp 2 lần S₁. sin x ≥ 0 trên \[0; π\] và sin x ≤ 0 trên \[π; 2π\], nên S = ∫₀^π sin x dx + ∫_π^{2π} (−sin x) dx = 2 + 2 = **4**. Hai phần có diện tích bằng nhau (mỗi phần 2); ∫ sin x dx trên hai đoạn là 2 và −2 nên triệt tiêu nhau, cho kết quả 0 của bạn học sinh.

**Rubric Explain.** Đúng: nêu hai phần có diện tích 2 và 2, tích phân của chúng là 2 và −2 nên cộng lại bằng 0, còn diện tích phải lấy giá trị tuyệt đối trước khi cộng. Một phần: nói "phần dưới trục là số âm" mà không giải thích vì sao tổng bằng 0. Sai: kết luận S = 0.

## Phần B – Khối tròn xoay quanh Ox (SGK mục 2b)

Hai bài dùng công thức V = π∫ₐᵇ f²(x) dx. Ở cả hai bài f(x) ≥ 0 trên \[a; b\] như điều kiện của SGK, nên bán kính mặt cắt đúng bằng f(x).

### Bài 3 – Tìm lỗi sai (SGK Bài tập 4.17)

**Đề bài.** Cho hình phẳng giới hạn bởi parabol y = 2x − x², trục hoành và hai đường thẳng x = 0, x = 2. Quay hình phẳng này quanh trục Ox. Yêu cầu: dự đoán hình dạng khối và thể tích so với hình trụ, tìm lỗi sai trong lời giải dưới đây, rồi giải lại cho đúng. Một bạn học sinh viết lời giải: *V = π∫₀² (2x − x²) dx = π(x² − x³/3) |₀² = 4π/3*.

**Dự đoán.**

1. Khối tạo thành có hình dạng nào?  
   A. Hình nón  
   B. Khối thắt lại ở giữa, như chiếc đồng hồ cát  
   C. Hình trụ  
   D. Khối phình ở giữa, thon dần về hai đầu
2. So với hình trụ bán kính 1, chiều dài 2 (thể tích 2π), thể tích khối này khoảng bao nhiêu?  
   A. Gần bằng  
   B. Khoảng 3/4  
   C. Khoảng một nửa  
   D. Chưa đến một phần tư
3. Lý do nào giải thích đúng nhất vì sao thể tích khối nhỏ hơn thể tích hình trụ?  
   A. Bán kính của khối nhỏ hơn hoặc bằng 1 tại mọi x trong \[0; 2\] và chỉ bằng 1 tại một điểm.  
   B. Chiều dài của khối ngắn hơn chiều dài của hình trụ.  
   C. Khối là một phần của hình nón nên luôn nhỏ hơn hình trụ.  
   D. Mặt cắt của khối là hình tròn còn mặt cắt của hình trụ là hình vuông.

**Quan sát (AR).** App hiện khối và hình trụ bán kính 1, chiều dài 2 dạng khung mờ bao quanh để đối chiếu. Học sinh chọn mặt cắt tại x = 0,5; 1; 1,5 và đọc bán kính.

**Giải thích.** Lời giải của bạn học sinh sai ở đâu? Vì sao bán kính phải được bình phương trong công thức thể tích?

**Lập tích phân.** Viết lại tích phân đúng và tính thể tích.

**Đáp án Dự đoán.** 1. D; 2. C; 3. A.

**Đáp án.** C: khối phình ở giữa và thon dần về hai đầu, bán kính lớn nhất là f(1) = 1. Thể tích khoảng một nửa thể tích hình trụ, nhỏ hơn hình trụ vì f(x) ≤ 1 trên \[0; 2\]. Lời giải của bạn sai vì dùng π∫f(x)dx thay vì π∫f²(x)dx: tích phân đó là π nhân với diện tích hình phẳng (vì f ≥ 0 trên \[0; 2\], S = ∫₀² (2x − x²) dx = 4/3), không phải thể tích. Đúng là V = π∫₀² (2x − x²)² dx = π∫₀² (4x² − 4x³ + x⁴) dx = π(32/3 − 16 + 32/5) = **16π/15** ≈ 3,35 (khoảng 53% của 2π).

**Rubric Explain.** Đúng: chỉ ra lỗi thiếu bình phương và nêu được mặt cắt là hình tròn bán kính f(x) nên diện tích mặt cắt là πf²(x). Một phần: chỉ ra lỗi nhưng không giải thích. Sai: không phát hiện được lỗi.

### Bài 4 – Nửa hình tròn thành khối cầu (SGK Ví dụ 8, R = 2)

**Đề bài.** Cho hình phẳng giới hạn bởi nửa đường tròn y = √(4 − x²), trục hoành và hai đường thẳng x = −2, x = 2. Quay hình phẳng này quanh trục Ox. Yêu cầu: dự đoán hình dạng khối tạo thành, giải thích, rồi tính thể tích khối đó.

**Dự đoán.**

1. Khối tạo thành có hình dạng nào?  
   A. Hình trụ  
   B. Hình cầu  
   C. Hình nón  
   D. Khối bầu dục dẹt
2. Nếu quay cả hình tròn (thêm nửa phía dưới Ox) thay vì chỉ nửa phía trên, thể tích khối tạo thành thay đổi thế nào?  
   A. Gấp đôi  
   B. Giảm một nửa  
   C. Không đổi
3. Lý do nào giải thích đúng nhất vì sao quay nửa hình tròn phía trên Ox đã tạo ra cả khối này?  
   A. Quay nửa hình tròn chỉ tạo ra nửa khối, nhưng thể tích vẫn tính được bằng công thức của cả khối.  
   B. Nửa hình tròn phía trên và phía dưới Ox có cùng bán kính nên thể tích của chúng cộng lại thành một khối.  
   C. Khi quay quanh Ox, chỉ các điểm nằm trên trục Ox mới tạo ra khối.  
   D. Mỗi điểm của nửa đường tròn quay một vòng quanh Ox đã quét ra cả một đường tròn, nên các đường tròn đó phủ kín khối.

**Quan sát (AR).** App hiện khối và làm nổi mặt cắt tại x do học sinh chọn. Khi x tiến tới −2 hoặc 2, mặt cắt thu nhỏ dần về một điểm.

**Giải thích.** Vì sao quay nửa hình tròn đã đủ tạo ra khối cầu? Bán kính mặt cắt tại x bằng bao nhiêu?

**Lập tích phân.** Tính thể tích và đối chiếu với công thức 4πR³/3.

**Đáp án Dự đoán.** 1. B; 2. C; 3. D.

**Đáp án.** Khối cầu bán kính 2. Thể tích không đổi khi quay cả hình tròn (không cần quay thêm nửa phía dưới) vì mỗi điểm của nửa hình tròn quay một vòng đã quét ra toàn bộ đường tròn mặt cắt. Bán kính mặt cắt tại x là √(4 − x²). V = π∫₋₂² (4 − x²) dx = π(4x − x³/3) |₋₂² = **32π/3** ≈ 33,51, khớp 4πR³/3 với R = 2.

**Rubric Explain.** Đúng: nêu được mỗi điểm trên nửa đường tròn quay thành một đường tròn, hoặc mặt cắt là hình tròn bán kính √(4 − x²). Một phần: nói "vì đối xứng" mà không giải thích. Sai: cho rằng phải quay cả hình tròn.
