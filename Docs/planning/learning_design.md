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
