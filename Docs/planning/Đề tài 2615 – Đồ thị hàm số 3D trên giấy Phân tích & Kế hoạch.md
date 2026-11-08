# Đề tài 2615 – Đồ thị hàm số 3D trên giấy: Phân tích & Kế hoạch

Oct 28, 2026 · @Trương Văn Thái · Cập nhật 08/11/2026: kế hoạch 8 tuần, OCR thành tính năng thêm

## 1. Đề bài 2615 tóm tắt

Đề 2615 yêu cầu một ứng dụng AR nhận diện phiếu bài tập in và vẽ đồ thị hàm số 2D/3D nổi trên trang giấy, kèm bài tập có hướng dẫn. Thời gian thực hiện 8 tuần (02/11 – 27/12/2026), nhóm tối đa 3 người.

| Mục | Nguyên văn (EN) | Dịch |
| --- | --- | --- |
| Tên đề | 3D Function Grapher on Paper | Vẽ đồ thị hàm số 3D trên giấy |
| Yêu cầu kỹ thuật tối thiểu | Unity + Vuforia image target; plotting scripts in C# | Unity + Vuforia image target; script vẽ đồ thị bằng C# |
| Hoạt động phát triển | Design worksheet marker; input equations; plot 2D/3D graphs above the page; guided exercises | Thiết kế marker phiếu bài tập; nhập phương trình; vẽ đồ thị 2D/3D nổi trên trang; bài tập có hướng dẫn |
| Sản phẩm kỳ vọng | Grapher for functions and surfaces; worksheet | Công cụ vẽ hàm số và mặt cong; phiếu bài tập |
| Thiết bị | Most Android phones and iPhones | Hầu hết Android và iPhone |

Yêu cầu chung bắt buộc cho mọi đề:

- Mục tiêu học tập được phát biểu rõ.
- Lập luận ngắn dựa trên lý thuyết học tập.
- Đánh giá khả dụng hoặc học tập nhỏ với 5–10 người dùng thật (ví dụ SUS + bài kiểm tra trước/sau).

## 2. Điểm chưa rõ trong đề bài

Đề chỉ có 4 dòng mô tả, nên có 9 điểm nhóm cần tự quyết hoặc hỏi giảng viên trước khi làm. Cột "Đề xuất" là lựa chọn mặc định nếu giảng viên không quy định.

| # | Điểm chưa rõ | Câu hỏi cụ thể | Đề xuất đã quyết định | Hỏi GV? |
| --- | --- | --- | --- | --- |
| 1 | Đối tượng và nội dung Toán | Lớp mấy? Hàm một biến (y = f(x)) hay hai biến (z = f(x,y))? Có mặt tham số, mặt phẳng, mặt cầu không? | THPT lớp 10–12 (hàm bậc 2, bậc 3, khảo sát hàm số lớp 12, phương trình mặt phẳng/mặt cầu Oxyz lớp 12, hàm lượng giác) | Không |
| 2 | "Input equations" nhập bằng cách nào | Gõ trên app, chọn từ danh sách, hay đọc từ giấy (OCR)? | Gõ trên app + thanh trượt tham số; OCR là tính năng nâng cao | Không |
| 3 | Một marker hay nhiều marker | Cả phiếu một target, hay mỗi bài tập một target? | Mỗi bài tập một target, gắn sẵn hàm mặc định | Không |
| 4 | Đồ thị "above the page" đặt thế nào | Gốc tọa độ ở đâu? Đơn vị trục bằng bao nhiêu cm trên giấy? | In hệ trục lên phiếu, 1 đơn vị có thể tùy chỉnh (mặc định 1 đơn vị = 1 cm), đồ thị AR trùng hình in, có gốc tọa độ, hệ trục tọa độ | Không |
| 5 | "Guided exercises" gồm những gì | Bao nhiêu bài? Có chấm điểm tự động không? Có gợi ý từng bước không? | 6–8 bài, mỗi bài: dự đoán → xem đồ thị → trả lời câu hỏi, có chấm tự động \<Tự xây kịch bản sư phạm và kịch bản AR → sau đó sẽ hỏi thầy> | Có |
| 6 | Mức "2D/3D" | Phải có cả hai, hay 3D là chính? | Cả hai: đường cong 2D dựng đứng trên trang + mặt cong 3D | Không |
| 7 | Công nghệ bắt buộc hay gợi ý | "Minimum technical requirements" có bắt buộc Unity + Vuforia không? Được làm bản web (MindAR.js + Three.js) không? | Làm Unity + Vuforia; bản web chỉ là phương án dự phòng | Không |
| 8 | Thiết kế đánh giá | Pre/post quiz có cần nhóm đối chứng (học bằng giấy/GeoGebra) không? 5–10 người có phải là học sinh không? | Một nhóm, pre/post + SUS, 8–10 học sinh THPT | Không |
| 9 | Sản phẩm nộp | Nộp APK, video demo, báo cáo, mã nguồn? Định dạng báo cáo? Tiêu chí chấm? | APK + video + báo cáo + repo GitHub | Không |

## 3. Vấn đề khúc mắc và hướng giải quyết

Rủi ro lớn nhất là marker nhận diện kém: một dự án Unity + Vuforia gần giống đề này đã ghi nhận ảnh đồ thị có ít điểm đặc trưng, đạt điểm thấp và tracking chập chờn ([AR 3D Graphs](https://hdriessen.itch.io/ar-3d-graphs/devlog/418697/assignment-23-report)). Cần xử lý vấn đề này ngay trong tuần 2, trước Gate 1 (15/11).

### 3.1 Kỹ thuật

| Vấn đề | Vì sao khó | Hướng giải quyết |
| --- | --- | --- |
| Marker ít đặc trưng | Lưới ô và đường cong lặp lại, mảnh; Vuforia không lấy đặc trưng ở \~8% viền ngoài ảnh | Khung viền nhiều chi tiết sắc nét, không lặp, phân bố đều; mục tiêu 4–5 sao; PNG/JPEG RGB dưới 2.25 MB; in giấy mờ ([Vuforia best practices](https://developer.vuforia.com/library/objects/best-practices-designing-and-developing-image-based-targets)) |
| Tay che marker khi thao tác | Mất tracking, đồ thị biến mất | Bật Device Pose Observer / Extended Tracking để giữ đồ thị khi marker bị che ([Vuforia Image Targets](https://developer.vuforia.com/library/objects/image-targets)) |
| Khớp hệ trục AR với hệ trục in | Sai tỉ lệ thì đồ thị AR không trùng hình in | Nhập đúng chiều rộng thật của target (mét); đặt gốc O tại vị trí cố định trên phiếu; quy ước 1 đơn vị = 1–2 cm |
| Đọc biểu thức người dùng gõ | Viết tắt kiểu giáo khoa: 2x, sin x, x²; lỗi thứ tự ưu tiên (một số parser tính -2^2 = 4) | Bước tiền xử lý chuẩn hóa (thêm dấu nhân ngầm, ngoặc cho hàm); bộ test đơn vị cho 30–50 biểu thức; báo lỗi cú pháp bằng tiếng Việt |
| Giá trị vô hạn, không xác định | 1/x, tan x, √(x) âm, ln x ≤ 0 sinh NaN/∞, lưới bị kéo dài | Kẹp z trong khoảng hiển thị; bỏ tam giác có đỉnh NaN; cắt đường cong tại điểm gián đoạn |
| Hiệu năng sinh lưới | Kéo thanh trượt tham số phải tính lại toàn bộ lưới | Lưới 60×60 đến 100×100 điểm; biên dịch biểu thức thành delegate một lần; chỉ cập nhật vị trí đỉnh, không tạo mesh mới |
| Hiển thị mặt cong dễ đọc | Mặt một màu khó nhìn độ cao; mặt sau bị ẩn; ánh sáng nhiều đồ thị ảnh hưởng nhau | Tô màu theo độ cao + đường đồng mức; shader hai mặt; mỗi đồ thị một layer ánh sáng |
| Gõ công thức trên điện thoại | Bàn phím mặc định thiếu ^, √, π | Bàn phím toán riêng (giống máy tính Casio) + hàm mẫu chọn nhanh |
| Build iPhone | Unity cần Mac + Xcode để build iOS | Ưu tiên build Android; iPhone chỉ làm nếu mượn được Mac |

### 3.2 Sư phạm và đánh giá

| Vấn đề | Hướng giải quyết |
| --- | --- |
| AR chỉ gây "wow", không có ích học tập | Mỗi bài theo chu trình Dự đoán – Quan sát – Giải thích (POE): học sinh đoán hình dạng trước, xem đồ thị, rồi trả lời câu hỏi |
| Đồ thị 3D ngoài chương trình THPT | Lõi bám chương trình Toán 12 (khảo sát hàm số, mặt phẳng và mặt cầu trong Oxyz); z = f(x,y) là phần mở rộng |
| Thiếu nhóm đối chứng | Thiết kế một nhóm pre/post; ghi rõ hạn chế trong báo cáo; nếu đủ người thì so sánh với nhóm học bằng giấy hoặc GeoGebra 2D |
| Thử với học sinh dưới 18 tuổi | Xin phép trường/giáo viên; phiếu đồng ý; không thu thập thông tin cá nhân |
| Công cụ đo | Pre/post test 8–10 câu về liên hệ tham số – hình dạng; SUS bản tiếng Việt; 2–3 câu hỏi mở |

## 4. Tech stack và thư viện

Lõi dùng Unity + Vuforia theo đúng đề, parser NCalc (MIT) và Mesh API của Unity. Phần AI nâng cao là OCR công thức bằng pix2tex chạy trên server FastAPI; đây là tính năng thêm, chỉ làm sau khi lõi xong (mỗi bài đã có marker gắn sẵn hàm nên luồng chính không cần OCR; OCR chỉ phục vụ ô "tự khám phá" nơi học sinh viết tay phương trình của mình).

| Tầng | Chọn chính | Phương án khác | Ghi chú |
| --- | --- | --- | --- |
| Engine | Unity bản LTS mới nhất được Vuforia hỗ trợ | — | Kiểm tra bảng tương thích Unity–Vuforia trước khi cài |
| AR tracking | [Vuforia Engine](https://developer.vuforia.com/library/objects/image-targets), image target, giấy phép Basic miễn phí | Instant image target (tạo target ngay trong Unity Editor) | Có Device Pose Observer cho Extended Tracking |
| Đọc biểu thức | [NCalc](https://github.com/ncalc/ncalc): MIT, .NET Standard 2.0, biên dịch thành lambda | [mXparser](https://mathparser.org/mxparser-license/): nhiều hàm toán, miễn phí cho giáo dục, thương mại phải trả phí; hoặc tự viết (shunting-yard) | Tránh [codewriter Expression Parser](https://github.com/codewriter-packages/Expression-Parser/blob/main/README.md): không có sin/cos và tính -2^2 = 4 |
| Sinh mặt cong | Unity Mesh API, lưới đỉnh + tam giác | Point graph theo [Catlike Coding](https://catlikecoding.com/unity/tutorials/basics/mathematical-surfaces/) | Tutorial có sẵn mặt, mặt cầu, morphing theo tham số |
| Đường cong 2D, hệ trục | LineRenderer | Mesh dạng ống | Nhãn trục dùng TextMeshPro |
| Giao diện | uGUI + bàn phím toán tự làm, thanh trượt tham số | UI Toolkit | — |
| Bài tập, chấm điểm | ScriptableObject hoặc JSON mô tả bài | — | Mỗi bài: target ID, hàm mặc định, câu hỏi, đáp án |
| Ghi log học tập | File JSON cục bộ | Firebase | Dùng cho phân tích thời gian, số lần thử |
| AI nâng cao: OCR công thức (tính năng thêm) | [pix2tex (LaTeX-OCR)](https://github.com/lukas-blecher/LaTeX-OCR): ViT + Transformer, MIT, có API và Docker | Pix2Text, Mathpix (trả phí) | Chỉ làm sau Gate 2 nếu lõi ổn; chạy trên FastAPI/Docker; viết tay mới hỗ trợ một phần; cần bước chuyển LaTeX sang biểu thức |
| Bản web dự phòng | [MindAR.js](https://github.com/webarkit/mind-ar-js) (MIT) + Three.js + math.js | AR.js | Chạy cả iOS và Android qua trình duyệt, cần HTTPS |
| Thiết kế phiếu | Figma hoặc Canva, xuất PNG | Inkscape | Kiểm tra số sao trên Vuforia Target Manager sau mỗi bản |
| Quản lý mã | GitHub + Git LFS + .gitignore Unity | Unity Version Control | Phân công scene riêng để tránh xung đột |
| Khảo sát | Google Forms (pre/post test, SUS) | — | Xử lý số liệu bằng Python (pandas, scipy) |

## 5. Dự án và nghiên cứu đã có

Đã có ít nhất một dự án Unity + Vuforia làm gần đúng ý tưởng này, nhưng chỉ dùng vài hàm có sẵn. Khoảng trống 2615 có thể lấp là: nhập hàm tùy ý, bài tập có hướng dẫn theo chương trình Việt Nam, và đọc công thức từ giấy.

### 5.1 Dự án tham khảo

| Dự án | Công nghệ | Làm được gì | Bài học cho 2615 |
| --- | --- | --- | --- |
| [AR 3D Graphs (Driessen)](https://hdriessen.itch.io/ar-3d-graphs/devlog/418697/assignment-23-report) | Unity + Vuforia, LineRenderer cho trục, mesh cho mặt | Đồ thị 3D nổi trên bản in 2D; thanh trượt tham số a, b, tỉ lệ, xoay | Ảnh giống đồ thị tracking kém; đặt marker nằm phẳng; mỗi đồ thị một layer ánh sáng; chỉ có vài hàm có sẵn |
| [Math World (UBC Emerging Media Lab)](https://wiki.ubc.ca/Documentation:Math_World) | Unity + AR Foundation, thư viện ExpressionSolver | Nhập hàm z = f(x,y) tùy ý và xem trong AR | Có parser lúc chạy; nhóm nhấn mạnh chất lượng tracking là quyết định; chưa có số liệu đánh giá học tập |
| [Catlike Coding – Mathematical Surfaces](https://catlikecoding.com/unity/tutorials/basics/mathematical-surfaces/) | Unity C# | Thư viện hàm, mặt cong, mặt cầu, xuyến, morphing | Mẫu code cho phần vẽ mặt và chuyển đổi giữa các hàm |
| GeoGebra 3D Calculator (chế độ AR) | ARKit/ARCore, đặt trên mặt phẳng | Vẽ mọi hàm 3D trong AR | Sản phẩm chuẩn để so sánh; không gắn với phiếu giấy và bài tập |

### 5.2 Bài nghiên cứu

| Bài | Mẫu và phương pháp | Kết quả chính | Dùng cho 2615 |
| --- | --- | --- | --- |
| [Cheong et al., 2024, IEEE Access](https://doaj.org/article/be3fcd3ed7a14ebba5a0c49fce7c87e1) – GeoGebra 3D với AR trong Giải tích nhiều biến | 67 sinh viên: 39 nhóm AR, 28 nhóm PowerPoint | AR khả dụng hơn có ý nghĩa thống kê; không khác biệt về thái độ và mức tham gia | Trích dẫn cho phần lý do và thiết kế đánh giá khả dụng |
| [Ahmad & Junaini, 2020, iJET](https://online-journals.org/index.php/i-jet/article/view/14961) – AR học Toán, tổng quan hệ thống | 19 bài báo Scopus 2015–2019, PRISMA | Chia 8 chủ đề: loại app, công cụ, lợi ích, cách kiểm thử, chủ đề Toán | Khung tham khảo khi viết tổng quan |
| [IJLTER – Ảnh hưởng của AR trong giáo dục Toán, tổng quan hệ thống](https://ijlter.org/index.php/ijlter/article/view/7227) | 23 bài 2018–2022 từ Scopus và ERIC, PRISMA | AR dùng từ tiểu học đến đại học; hỗ trợ giảm lo âu Toán; cần nghiên cứu tác động dài hạn | Đặt 2615 trong bối cảnh nghiên cứu hiện có |

### 5.3 Lý thuyết học tập nền

- **Đa biểu diễn (Ainsworth):** phương trình, đồ thị 2D in và mặt 3D AR bổ sung cho nhau; học sinh học cách chuyển đổi giữa các biểu diễn.
- **Học đa phương tiện và mã hóa kép (Mayer, Paivio):** chữ và hình đặt sát nhau (nguyên tắc liền kề không gian) — đồ thị nổi ngay trên đề bài.
- **Dự đoán – Quan sát – Giải thích (POE):** cấu trúc cho mỗi bài tập có hướng dẫn.

## 6. Kế hoạch 8 tuần

Dự án chạy 8 tuần, từ 02/11 đến 27/12/2026, nộp toàn bộ sản phẩm cuối tuần 8. Tính năng lõi phải chốt trước 06/12 (hết tuần 5), để còn 3 tuần cho nội dung, thử nghiệm và báo cáo. So với bản 2.5 tháng: rút ngắn khoảng 2 tuần, phần nội dung + thử nghiệm + báo cáo từ 4 tuần còn 3 tuần, OCR chuyển thành tính năng thêm.

### 6.1 Lịch theo tuần

| Tuần | Ngày | Giai đoạn | Đầu ra chính | Gate |
| --- | --- | --- | --- | --- |
| 1 | 02–08/11 | Đăng ký, khởi tạo | Đăng ký đề; gửi câu hỏi ở mục 2; tạo project Unity + repo; cấu trúc thư mục và quy ước nhóm | |
| 2 | 09–15/11 | Prototype | Mục tiêu học tập; chọn 6–8 hàm theo SGK Toán 12; app thử 1 target + mặt z = x² + y² chạy trên máy thật; phiếu bài tập bản 1 đạt 4–5 sao; chốt lịch với trường thử nghiệm | **Gate 1 (15/11):** marker tracking ổn định |
| 3 | 16–22/11 | Xây lõi (1) | Parser + bộ test; vẽ đường cong 2D và mặt 3D; khớp hệ trục AR với hệ trục in; cấu trúc dữ liệu bài tập | |
| 4 | 23–29/11 | Xây lõi (2) | Thanh trượt tham số; bàn phím toán; nhiều target; luồng POE và chấm điểm; ghi log | |
| 5 | 30/11–06/12 | Ghép và hoàn thiện lõi | Ghép 3 phần vào Main scene; Extended Tracking; bản nháp nội dung bài tập và bộ câu hỏi pre/post | **Gate 2 (06/12):** chốt tính năng lõi |
| 6 | 07–13/12 | Nội dung và thử nội bộ | Đủ 6–8 bài theo POE; in phiếu chính thức; chạy thử với 2 người để sửa lỗi; OCR (pix2tex + FastAPI) chỉ khi lõi đã ổn | **Gate 3 (13/12):** app sẵn sàng thử nghiệm |
| 7 | 14–20/12 | Thử nghiệm | Pre-test → học với app 30–45 phút → post-test + SUS + phỏng vấn ngắn với 8–10 học sinh | |
| 8 | 21–27/12 | Báo cáo và nộp | Phân tích số liệu; viết báo cáo; quay video demo; chuẩn bị slide; nộp 27/12 | |

Hành động tại mỗi gate:

- **Gate 1:** nếu đến 15/11 marker vẫn tracking kém, đổi thiết kế phiếu hoặc chuyển sang bản web dự phòng.
- **Gate 2:** tính năng nào chưa xong thì cắt, không lùi lịch; từ đây chỉ sửa lỗi và thêm nội dung.
- **Gate 3:** nếu app chưa ổn định, giảm số bài dùng trong buổi thử nghiệm thay vì lùi buổi thử nghiệm.

Rủi ro lịch: tuần 7 (14–20/12) có thể trùng giai đoạn ôn và thi học kỳ I của nhiều trường THPT. Cần chốt lịch với trường ngay trong tuần 2–3 và có phương án dự phòng (ví dụ thử nghiệm qua giáo viên quen, ghi rõ hạn chế trong báo cáo).

### 6.2 Cần chuẩn bị ngay

- [ ] Cài thử app mẫu Vuforia trên cả 2 máy Android
- [ ] Tạo tài khoản Vuforia Developer, lấy license key Basic
- [ ] Cài Unity LTS tương thích Vuforia trên cả 3 máy tính; tạo repo GitHub + Git LFS
- [ ] Hỏi xem nhóm có mượn được Mac để build iPhone không
- [ ] Liên hệ trường THPT hoặc giáo viên Toán để hẹn lịch thử nghiệm tuần 7 (14–20/12/2026)
- [ ] Soạn phiếu đồng ý tham gia cho học sinh
- [ ] Chuẩn bị máy in và giấy A4 mờ
- [ ] Thu thập SUS bản tiếng Việt và mẫu pre/post test

### 6.3 Phân công 3 người

| Thành viên | Phần AR phụ trách (đầu cuối) | Việc phụ (nội dung + đánh giá) | Đầu ra demo được |
| --- | --- | --- | --- |
| Duy – Tracking và marker | Cài Vuforia; thiết kế và test phiếu/marker đạt 4–5 sao; nhiều target, mỗi bài một target; khớp hệ trục AR với hệ trục in; Extended Tracking; build APK | Soạn phiếu đồng ý, liên hệ trường thử nghiệm | Quét phiếu bất kỳ, hệ trục AR hiện đúng vị trí, không mất khi che tay |
| Thái – Vẽ đồ thị trong AR + AI | Parser; sinh đường cong 2D và mặt 3D trên marker; tô màu theo độ cao; xử lý gián đoạn; thanh trượt tham số cập nhật thời gian thực; OCR công thức (tính năng thêm, sau lõi) | Ghi log sự kiện, xử lý số liệu pre/post và SUS | Nhập hàm bất kỳ → đồ thị nổi trên giấy; kéo tham số thấy đồ thị đổi |
| Hùng – Bài tập AR và tương tác | Luồng bài tập POE trong AR (dự đoán → quan sát → trả lời); chạm chọn điểm trên đồ thị (raycast); gợi ý theo bậc; chấm điểm bằng luật; bàn phím toán và UI | Soạn nội dung bài tập và bộ câu hỏi pre/post; chủ trì buổi thử nghiệm | Làm trọn một bài tập trong AR, có điểm và phản hồi |

Cả 3 người đều làm một phần AR chạy trên điện thoại, khoảng 80–85% thời gian. Việc nội dung và đánh giá chia đều, mỗi người khoảng 15–20%; cả nhóm cùng có mặt buổi thử nghiệm. Mỗi người viết chương báo cáo về phần mình làm và review code của người khác hàng tuần. Ba phần ghép qua giao diện chung: Duy cung cấp gốc tọa độ theo target, Thái cung cấp hàm vẽ đồ thị, Hùng gọi cả hai trong bài tập.

### 6.4 Sản phẩm bàn giao

- File APK và mã nguồn trên GitHub
- Bộ phiếu bài tập in (PDF) kèm cơ sở dữ liệu target
- Báo cáo: mục tiêu học tập, lý thuyết, thiết kế, đánh giá (pre/post + SUS)
- Video demo 2–3 phút và slide trình bày

## Nguồn

- [Vuforia – Image Targets](https://developer.vuforia.com/library/objects/image-targets)
- [Vuforia – Best Practices for Designing and Developing Image-Based Targets](https://developer.vuforia.com/library/objects/best-practices-designing-and-developing-image-based-targets)
- [AR 3D Graphs – Assignment 2/3 Report (itch.io)](https://hdriessen.itch.io/ar-3d-graphs/devlog/418697/assignment-23-report)
- [Math World – UBC Wiki](https://wiki.ubc.ca/Documentation:Math_World)
- [Catlike Coding – Mathematical Surfaces](https://catlikecoding.com/unity/tutorials/basics/mathematical-surfaces/)
- [NCalc (GitHub)](https://github.com/ncalc/ncalc)
- [mXparser – License](https://mathparser.org/mxparser-license/)
- [codewriter Expression Parser – README](https://github.com/codewriter-packages/Expression-Parser/blob/main/README.md)
- [pix2tex / LaTeX-OCR (GitHub)](https://github.com/lukas-blecher/LaTeX-OCR)
- [MindAR.js (GitHub)](https://github.com/webarkit/mind-ar-js)
- [Cheong et al. (2024), Implementing GeoGebra 3D Calculator With Augmented Reality in Multivariable Calculus Education, IEEE Access](https://doaj.org/article/be3fcd3ed7a14ebba5a0c49fce7c87e1)
- [Ahmad & Junaini (2020), Augmented Reality for Learning Mathematics: A Systematic Literature Review, iJET](https://online-journals.org/index.php/i-jet/article/view/14961)
- [Assessing the Influence of Augmented Reality in Mathematics Education: A Systematic Literature Review, IJLTER](https://ijlter.org/index.php/ijlter/article/view/7227)
