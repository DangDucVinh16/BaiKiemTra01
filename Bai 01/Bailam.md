Câu 1:
Tiêu chí		           |Value Types (Kiểu giá trị)			            |Reference Types (Kiểu tham chiếu)
Các kiểu dữ liệu đại diện  |int, float, double, bool, char, struct, enum    |class, string, object, interface, delegate, array
Vị trí lưu trữ dữ liệu	   |trực tiếp trong stack hoặc trong đối tượng heap |Trên heap, biến con trỏ thì trong stack
Cơ chế gán (Assignment)	   |Sao chép toàn bộ giá trị			            |Sao chép địa chỉ tham chiếu
Cơ chế giải phóng bộ nhớ   |Tự động giải phóng ngay khi biến ra khỏi phạm vi|Do trình thu gom rác quản lý

Câu 2:
1. Khác biệt giữa init và set thông thường:

```
- set thông thường: Cho phép gán hoặc thay đổi giá trị của thuộc tính bất kỳ lúc nào trong suốt vòng đời của đối tượng.

- init (Init-only setter): Chỉ cho phép gán giá trị một lần duy nhất tại thời điểm khởi tạo đối tượng (qua Constructor hoặc Object Initializer { Name = "Value" }). Sau khi đối tượng khởi tạo xong, thuộc tính đó trở thành Read-only (chỉ đọc) và không thể sửa đổi.

```
2. Trường hợp sử dụng thực tế
Thuộc tính init được sử dụng khi bạn muốn tạo các đối tượng có tính chất Bất biến (Immutable Objects) nhưng vẫn muốn tận dụng cú pháp khởi tạo linh hoạt Object Initializers thay vì phải viết một Constructor quá nhiều tham số.

Câu 3: Phân biệt phương thức virtual (Lớp cha) và override (Lớp con)
Trong tính Đa hình (Polymorphism), virtual và override phối hợp với nhau để thực hiện cơ chế Late Binding (Dynamic Binding):

```
- Phương thức virtual ở lớp cha:
	+ Đánh dấu rằng phương thức này cho phép các lớp kế thừa ghi đè lại hành vi.
	+ Cung cấp sẵn một triển khai mặc định (default implementation). Nếu lớp con không ghi đè, nó sẽ dùng logic của lớp cha.

- Phương thức override ở lớp con:
	+ sử dụng ở lớp dẫn xuất để định nghĩa lại hoàn toàn hành vi của phương thức virtual từ lớp cha.

	+ gọi phương thức qua một tham chiếu kiểu lớp cha (ví dụ: BaseClass obj = new DerivedClass()), C# sẽ kiểm tra bảng V-Table và thi hành phương thức override của lớp con thay vì phương thức của lớp cha.

```
Câu 4:
Thành phần static (biến, phương thức, thuộc tính) được thiết kế theo nguyên lý quản lý bộ nhớ và kiến trúc hướng đối tượng của C#:

```
- chế lưu trữ và quản lý vùng nhớ: Thành phần static thuộc về mức độ Lớp (Class-level) chứ không thuộc về thể hiện cụ thể (Instance-level). Bộ nhớ cho các thành phần static chỉ được cấp phát một lần duy nhất khi Lớp được nạp vào bộ nhớ (Class Loader), tách biệt hoàn toàn với bộ nhớ của các đối tượng tạo ra bởi new.

- chất chia sẻ dữ liệu: Tất cả các đối tượng tạo từ lớp đó đều dùng chung một vùng nhớ static. Việc truy xuất qua tên lớp (ClassName.StaticMember) phản ánh chính xác rằng thành phần này thuộc sở hữu chung của toàn bộ Lớp, tránh nhầm lẫn rằng nó là dữ liệu riêng lẻ của một thể hiện.

- An toàn kiểu (Type Safety) và rõ ràng trong biên dịch: Trình biên dịch C# cố tình cấm truy xuất static qua instance để tránh gây mơ hồ về mặt ngữ nghĩa (semantic ambiguity) và tối ưu hóa quá trình gọi hàm ở mức IL (Intermediate Language).
```