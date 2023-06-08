
| Tên thuộc tính    | Kiểu dữ liệu    | Mô tả                                            |
| ----------------- | --------------- | ------------------------------------------------ |
| Id                | int             | Mã định danh duy nhất của đơn hàng.              |
| ApplicationUserId | string          | Mã định danh của người dùng đặt hàng.            |
| ApplicationUser   | ApplicationUser | Tham chiếu tới thông tin người dùng đặt hàng.    |
| OrderTime         | DateTime        | Thời điểm đặt hàng.                              |
| ShippingDate      | DateTime        | Ngày giao hàng dự kiến.                          |
| OrderTotal        | decimal         | Tổng giá trị đơn hàng.                           |
| Discount          | decimal         | Giảm giá được áp dụng cho đơn hàng.              |
| OrderStatus       | string          | Trạng thái của đơn hàng.                         |
| PaymentStatus     | string          | Trạng thái thanh toán của đơn hàng.              |
| TrackingNumber    | string          | Mã theo dõi đơn hàng.                            |
| Carrier           | string          | Đơn vị vận chuyển đang xử lý đơn hàng.           |
| PaymentDate       | DateTime        | Thời điểm thanh toán đơn hàng.                   |
| PaymentDueDate    | DateTime        | Thời điểm thanh toán đơn hàng cần được hoàn tất. |
| PaymentId         | string          | Mã thanh toán của đơn hàng.                      |
| PayerId           | string          | Mã người thanh toán đơn hàng.                    |
| PhoneNumber       | string          | Số điện thoại của người nhận đơn hàng.           |
| Name              | string          | Tên người nhận đơn hàng.                         |
| StreetAddress     | string          | Địa chỉ đường phố của người nhận đơn hàng.       |
| City              | string          | Tên thành phố của người nhận đơn hàng.           |
| Country           | string          | Tên quốc gia của người nhận đơn hàng.            |
| State             | string          | Tên tiểu bang, tỉnh của người nhận đơn hàng.     |
| ZipCode           | string          | Mã bưu chính của người nhận đơn hàng.            |
