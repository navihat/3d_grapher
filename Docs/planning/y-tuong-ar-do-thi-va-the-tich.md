# Đề xuất ý tưởng: Từ đồ thị hàm số đến thể tích vật thể bằng AR

> **Trạng thái:** Đề xuất để nhóm thảo luận, chưa phải quyết định thay đổi phạm vi dự án.  
> **Đối tượng dự kiến:** Học sinh lớp 12.  
> **Tài liệu tham khảo:** SGK Toán 12, bộ *Kết nối tri thức với cuộc sống*, tập 2, Chương IV, Bài 13 – Ứng dụng hình học của tích phân.

## 1. Ý tưởng

Học sinh nhập công thức hàm số và khoảng xét. Ứng dụng dùng marker trên phiếu để đặt hệ trục tọa độ và đồ thị đúng vị trí trên trang giấy. Học sinh chọn trục quay; ứng dụng làm nổi bật miền phẳng tương ứng rồi trực quan hóa khối tròn xoay trong không gian AR.

Hoạt động dùng hình ảnh 3D để giúp học sinh liên hệ ba biểu diễn:

1. Công thức hàm số và tích phân.
2. Đồ thị cùng miền phẳng trên hệ trục.
3. Vật thể 3D được tạo khi quay miền phẳng.

AR hỗ trợ quan sát và kiểm tra hình dung; học sinh vẫn cần lập tích phân và trình bày lập luận toán học để giải bài.

## 2. Căn cứ chương trình và mục tiêu dạy học

Ý tưởng bám theo Bài 13 trong SGK Toán 12 tập 2, trong đó học sinh sử dụng tích phân để tính diện tích hình phẳng và thể tích một số vật thể. Hoạt động đề xuất tập trung vào mối liên hệ giữa đồ thị, miền phẳng, khối tròn xoay và công thức tính thể tích.

### Mục tiêu học tập

Sau hoạt động, học sinh có thể:

1. Xác định miền phẳng được giới hạn bởi đồ thị, trục hoành và hai đường thẳng `x = a`, `x = b`.
2. Nhận biết vật thể tạo thành khi quay miền phẳng quanh trục hoành.
3. Lập tích phân tính thể tích trong trường hợp miền nằm phía trên trục hoành:
   `V = π ∫[a,b] (f(x))² dx`.
4. Giải thích vai trò của `f(x)` là bán kính tiết diện tròn và của `dx` là độ dày vi phân theo chiều trục quay.
dx nghĩa là một sự thay đổi vô cùng nhỏ của x. Không chỉ là 0.000000001 mà là vô cùng nhỏ.

Dấu ngoặc móc phía trước nghĩa là tổng vô hạn.

f(x) là kết quả của một hàm số f nào đó tại một giá trị cụ thể của x.

Vậy nên, về cơ bản, điều này có nghĩa là bạn đang cộng vô hạn tất cả các giá trị của f(x) nhân với d(x), tức là chiều cao của hàm số nhân với chiều rộng của nó, nhưng ở dạng vô hạn, vô cùng mỏng.

(thầy dạy toán của bạn chắc dở tệ khoản giải thích nhỉ)

Bạn biết cách tính diện tích hình chữ nhật rồi chứ? Chiều cao nhân chiều rộng.

Hãy tưởng tượng một hàm số kỳ quái, ngoằn ngoèo mà bạn không hiểu. Làm sao bạn tính được diện tích bên dưới nó?

Cách dễ nhất là vẽ các hình chữ nhật bao quanh nó và tính diện tích của chúng. Càng nhiều hình chữ nhật nhỏ hơn bạn vẽ, phép tính diện tích của bạn càng chính xác. Khi bạn có vô số hình chữ nhật, bạn sẽ có độ chính xác hoàn hảo. Chúng cũng sẽ vô cùng nhỏ. Do đó,

∫ f(x)dx cho bạn diện tích chính xác bên dưới đường cong f(x).

Đó là ý nghĩa của dx, và ∫ f(x)dx, theo nghĩa trực quan.


Theo nghĩa thực tiễn, giải phương trình, dx có nghĩa là bạn đang tích phân theo x nên bạn sử dụng các quy tắc tích phân trên x. Nếu bạn đang tính vận tốc của một vật gì đó, bạn sẽ tích phân gia tốc của nó theo thời gian, vì vậy nó sẽ là ∫ f(t)dt.
5. Tính thể tích và kiểm tra kết quả bằng một bài tập có dữ kiện mới.

### Tiêu chí đạt mục tiêu

Trong bài kiểm tra sau hoạt động, học sinh đạt ít nhất 4/5 câu đúng và phải thể hiện được:

- xác định đúng miền và trục quay;
- lập đúng tích phân thể tích;
- nêu được ý nghĩa hình học của bán kính trong công thức.

Không xem việc nhận diện đúng hình AR hoặc đọc kết quả từ ứng dụng là bằng chứng duy nhất cho việc đạt mục tiêu.

## 3. Lập luận sư phạm

Khó khăn học tập mà hoạt động nhắm tới là chuyển từ hình phẳng sang vật thể 3D và hiểu vì sao công thức tích phân biểu diễn thể tích. Đồ thị trên giấy thể hiện hàm số, nhưng chưa trực tiếp cho thấy miền quay tạo ra khối nào.

Ứng dụng đặt công thức, đồ thị, miền phẳng và vật thể 3D cạnh nhau để học sinh đối chiếu nhiều biểu diễn của cùng một bài toán. Học sinh có thể xoay góc nhìn, bật/tắt phần miền và vật thể, đồng thời quan sát các tiết diện vuông góc với trục quay. Cách tổ chức này hỗ trợ hình dung không gian và kết nối biểu diễn trực quan với lập luận giải tích; mô hình AR không thay thế việc tự lập tích phân.

## 4. Kịch bản bài học và chuỗi bài tập

### Bài 1 – Nhận diện miền và vật thể

- **Dữ kiện:** `f(x) = x`, `0 ≤ x ≤ 2`; miền giới hạn bởi đồ thị, trục `Ox`, `x = 0`, `x = 2`.
- **Nhiệm vụ:** Quan sát đồ thị trên phiếu, xác định miền cần quay, chọn trục quay `Ox`, rồi mô tả vật thể tạo thành.
- **Tương tác AR:** Marker neo hệ trục và đồ thị vào phiếu; ứng dụng tô miền phẳng và hiển thị khối tròn xoay. Học sinh xoay góc nhìn và bật/tắt miền hoặc khối để đối chiếu.
- **Mục đích:** Củng cố việc xác định đúng miền tạo khối trước khi lập công thức.

### Bài 2 – Lập tích phân thể tích

- **Dữ kiện:** Tiếp tục với `f(x) = x`, `0 ≤ x ≤ 2`, quay quanh `Ox`.
- **Nhiệm vụ:** Xác định bán kính tiết diện tại vị trí `x`, lập tích phân và tính thể tích:
  `V = π ∫[0,2] x² dx = 8π/3`.
- **Tương tác AR:** Ứng dụng có thể làm nổi bật một tiết diện tròn tại vị trí học sinh chọn và hiển thị bán kính tương ứng. Ứng dụng không tự điền tích phân trước khi học sinh trả lời.
- **Mục đích:** Kết nối bán kính của tiết diện với hàm số và biểu thức dưới dấu tích phân.

### Bài 3 – Chuyển giao sang hàm số mới

- **Dữ kiện:** `f(x) = 2 - x`, `0 ≤ x ≤ 2`; quay miền giới hạn bởi đồ thị và trục `Ox` quanh `Ox`.
- **Nhiệm vụ:** Xác định hình dạng miền, viết tích phân thể tích và tính kết quả. Sau đó đối chiếu hình dung với vật thể AR.
- **Đáp án tham khảo:** `V = π ∫[0,2] (2 - x)² dx = 8π/3`.
- **Mục đích:** Kiểm tra học sinh có thể áp dụng quy tắc cho hàm và hình dạng miền khác, không chỉ lặp lại ví dụ mẫu.

### Bài 4 – Giải thích và phát hiện lỗi

- **Tình huống:** Một lời giải viết `V = π ∫[0,2] f(x) dx`.
- **Nhiệm vụ:** Chỉ ra lỗi, giải thích tại sao bán kính phải được bình phương và sửa lại tích phân.
- **Mục đích:** Đánh giá hiểu biết về ý nghĩa hình học, không chỉ khả năng thế số vào công thức.

## 5. Luồng sử dụng ứng dụng

1. Học sinh quét marker trên phiếu.
2. Ứng dụng nhận diện target, căn hệ trục AR với hệ trục in sẵn và hiển thị bài tập tương ứng.
3. Học sinh nhập công thức `f(x)` hoặc sửa công thức mẫu, nhập khoảng `[a,b]`, chọn trục quay.
4. Graphing kiểm tra biểu thức và vẽ đồ thị; ứng dụng xác định, tô miền phẳng theo dữ liệu bài.
5. Học sinh trả lời câu hỏi về miền, vật thể và tích phân.
6. Sau khi học sinh nộp câu trả lời, ứng dụng mới hiển thị mô hình khối tròn xoay và phản hồi.
7. Ứng dụng lưu câu trả lời, số lần thử và kết quả để phục vụ đánh giá.

### Quy trình hoạt động mẫu của học sinh

**Bài học:** Tính thể tích khối tạo thành khi quay miền giới hạn bởi `y = x`, trục `Ox`, `x = 0`, `x = 2` quanh `Ox`.

| Bước | Học sinh thực hiện | Ứng dụng phản hồi |
| --- | --- | --- |
| 1. Mở bài | Chọn bài “Khối nào được tạo ra khi quay miền này quanh `Ox`?” | Hiển thị hướng dẫn quét marker trên phiếu. |
| 2. Quét phiếu | Hướng camera vào marker và điều chỉnh để trang giấy nằm rõ trong khung hình. | Nhận diện phiếu, căn hệ trục AR với hệ trục in. Nếu chưa nhận diện được, báo trạng thái và hướng dẫn quét lại. |
| 3. Nhập dữ kiện | Nhập hoặc xác nhận `f(x) = x`, khoảng `[0, 2]`, chọn trục quay `Ox`. | Kiểm tra cú pháp và miền xác định; nếu hợp lệ, vẽ đồ thị lên hệ trục đã căn. |
| 4. Xác định miền | Chọn miền giới hạn bởi đồ thị, trục `Ox` và hai đường `x = 0`, `x = 2`. | Tô sáng miền đã chọn để học sinh xác nhận trước khi tiếp tục. |
| 5. Khám phá hình dạng | Xoay góc nhìn và mô tả vật thể dự kiến tạo thành; bật/tắt các lớp đồ thị và miền để quan sát. | Sau khi học sinh xác nhận câu trả lời, hiển thị khối tròn xoay được neo trên marker. Có thể làm nổi một tiết diện tại vị trí `x` do học sinh chọn. |
| 6. Lập lời giải | Tự xác định bán kính tiết diện và nhập tích phân tính thể tích. | Chưa hiện công thức đáp án; kiểm tra lời giải và chỉ ra bước cần xem lại nếu sai. |
| 7. Nhận phản hồi | Đối chiếu lời giải của mình với gợi ý, sửa nếu cần. | Giải thích `r(x) = x`, nên `V = π ∫[0,2] x² dx = 8π/3`. Mô hình AR giúp kiểm tra hình dung nhưng không thay cho phép tính. |
| 8. Làm bài mới | Thử bài tương tự, chẳng hạn `f(x) = 2 - x` trên `[0, 2]`, vẫn quay quanh `Ox`. | Cho nhập hàm mới và thực hiện lại các bước; chỉ hiện đáp án sau khi học sinh nộp lời giải. |
| 9. Kết thúc | Trả lời câu hỏi ngắn: “Bán kính tiết diện trong công thức thể tích lấy từ đâu?” | Ghi nhận câu trả lời, số lần thử và kết quả để phục vụ đánh giá. |

**Nguyên tắc sư phạm:** Học sinh đi từ công thức đến đồ thị và miền phẳng, quan sát khối 3D, rồi tự lập tích phân. Ứng dụng không hiển thị sẵn đáp án trước khi học sinh thử giải; AR hỗ trợ hình dung không gian còn lập luận và tính toán vẫn do học sinh thực hiện.

### Vai trò của marker

- Marker xác định phiếu/bài tập đang sử dụng và cung cấp mốc neo cho hệ trục.
- Đồ thị và miền phẳng phải trùng với trục in trên phiếu.
- Khối tròn xoay được dựng từ cùng hệ tọa độ và hiển thị nổi lên khỏi mặt giấy.
- Mất tracking cần được báo rõ; không giả định marker vẫn được nhận diện khi camera không thấy target.

### Vai trò của nhập công thức

- Cho phép học sinh nhập hàm và khoảng xét để thay đổi ví dụ, thay vì chỉ xem mô hình dựng sẵn.
- MVP nên giới hạn cú pháp và công bố trước các hàm được hỗ trợ; báo lỗi tiếng Việt nếu công thức không hợp lệ.
- Với hoạt động tính thể tích, chỉ chấp nhận trường hợp mà miền và công thức có diễn giải rõ ràng. Đề xuất MVP giới hạn `f(x) ≥ 0` trên `[a,b]`, miền nằm giữa đồ thị và trục `Ox`, quay quanh `Ox`.

## 6. Phạm vi MVP và ngoài phạm vi

### MVP

- Một marker bài tập có hệ trục 2D in sẵn.
- Nhập một hàm một biến và khoảng `[a,b]`.
- Vẽ đồ thị trên hệ trục đã căn chỉnh với marker.
- Tô miền giữa đồ thị và trục `Ox`.
- Tạo khối tròn xoay quanh `Ox`.
- Ba đến bốn bài tập theo chuỗi từ nhận diện đến vận dụng.
- Phản hồi đáp án và ghi lại kết quả học tập cơ bản.

### Để sau MVP

- OCR công thức từ giấy.
- Nhiều trục quay, nhiều miền bị chặn bởi hai đồ thị, hoặc miền đổi dấu.
- Tích phân số tổng quát cho biểu thức bất kỳ.
- Mặt `z = f(x,y)` và các nội dung không thuộc mục tiêu bài học này.
- Nhiều bài học và marker cùng lúc.

## 7. Đánh giá thử nghiệm

Thử nghiệm với 5–10 người dùng theo yêu cầu của đề tài:

1. **Bài kiểm tra trước/sau:** câu hỏi ngắn về xác định miền quay, bán kính tiết diện và lập tích phân thể tích. Dùng bài tương đương nhưng không trùng hoàn toàn để hạn chế học thuộc đáp án.
2. **Đánh giá khả dụng:** dùng SUS hoặc bảng hỏi khả dụng ngắn sau khi hoàn thành hoạt động.
3. **Quan sát quá trình:** ghi nhận học sinh có căn đúng đồ thị trên marker, hiểu thao tác, tự lập được tích phân và cần trợ giúp ở bước nào.
4. **Tiêu chí xem xét:** điểm sau hoạt động, thay đổi giữa trước/sau, lỗi lập tích phân thường gặp, lỗi tracking và phản hồi khả dụng. Với cỡ mẫu nhỏ, báo cáo kết quả mô tả; không khẳng định hiệu quả cho toàn bộ học sinh lớp 12.

## 8. Các điểm cần nhóm xác nhận

1. Nhóm có muốn chuyển trọng tâm sư phạm từ POE/khảo sát đồ thị sang ứng dụng tích phân tính thể tích không?
2. Mục tiêu chính là học sinh hiểu cách lập tích phân, hay ưu tiên trải nghiệm trực quan hóa khối tròn xoay?
3. Có đủ thời gian mở rộng Graphing để dựng miền phẳng và khối tròn xoay, ngoài đường cong/mặt hiện tại không?
4. Bài tập sẽ yêu cầu học sinh nhập công thức tự do hay chọn/sửa công thức được cung cấp?
5. Giảng viên có chấp thuận phạm vi bài học và hình thức đánh giá đề xuất không?

## 9. Tài liệu liên quan

- [Project overview](../team/project-overview.md) – phạm vi và kiến trúc hiện tại.
- [Phân tích và kế hoạch đề tài 2615](Đề tài%202615%20–%20Đồ%20thị%20hàm%20số%203D%20trên%20giấy%20Phân%20tích%20%26%20Kế%20hoạch.md) – yêu cầu đề tài, kế hoạch và đánh giá.
- SGK Toán 12, bộ *Kết nối tri thức với cuộc sống*, tập 2, Chương IV, Bài 13 – Ứng dụng hình học của tích phân.
