### OrderHeader

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

###OrderDetails

| Tên thuộc tính    | Kiểu dữ liệu    | Mô tả                                      |
| ----------------- | --------------- | ------------------------------------------ |
| Id                | int             | Mã định danh duy nhất của chi tiết đơn hàng |
| Count             | int             | Số lượng sản phẩm                          |
| Price             | decimal         | Giá sản phẩm                               |
| OrderHeaderId     | int             | Mã định danh của đơn hàng                   |
| OrderHeader       | OrderHeader     | Tham chiếu tới đơn hàng                     |
| ProductId         | int             | Mã định danh của sản phẩm                   |
| Product           | Product         | Tham chiếu tới thông tin sản phẩm            |


### Tên model: ShoppingCart

| Tên thuộc tính       | Kiểu dữ liệu | Mô tả                                           |
| -------------------- | ------------ | ----------------------------------------------- |
| CartId               | int          | Mã định danh của giỏ hàng.                      |
| Quantity             | int          | Số lượng sản phẩm trong giỏ hàng.               |
| ProductId            | int          | Mã định danh của sản phẩm.                      |
| Product              | Product      | Tham chiếu tới thông tin sản phẩm.              |
| ApplicationUserId    | string       | Mã định danh của người dùng sở hữu giỏ hàng.    |
| ApplicationUser      | ApplicationUser | Tham chiếu tới thông tin người dùng sở hữu giỏ hàng. |

### Tên model: Product

| Tên thuộc tính    | Kiểu dữ liệu         | Mô tả                                                 |
| ----------------- | -------------------- | ----------------------------------------------------- |
| Id                | int                  | Mã định danh của sản phẩm.                            |
| Title             | string               | Tiêu đề của sản phẩm.                                 |
| Author            | string               | Tác giả của sản phẩm.                                 |
| Description       | string               | Mô tả về sản phẩm.                                    |
| CreatedDate       | DateTime             | Ngày tạo sản phẩm.                                    |
| UpdatedDate       | DateTime             | Ngày cập nhật gần nhất của sản phẩm.                   |
| License           | string               | Giấy phép sử dụng sản phẩm.                           |
| Credits           | string               | Thông tin về nguồn gốc hoặc đóng góp cho sản phẩm.     |
| PreviewUrl        | string               | Đường dẫn đến hình ảnh/xem trước của sản phẩm.         |
| DownloadCount     | int                  | Số lần tải xuống của sản phẩm.                         |
| DownloadUrl       | string               | Đường dẫn để tải xuống sản phẩm.                       |
| Price             | decimal              | Giá của sản phẩm.                                     |
| PostsBy           | string               | Người đăng bài viết liên quan đến sản phẩm.             |
| Image             | string               | Đường dẫn đến hình ảnh của sản phẩm.                    |
| Categories        | ICollection<Category> | Các danh mục mà sản phẩm thuộc về (tùy chọn, có thể là null). |

### Tên model: Category

| Tên thuộc tính    | Kiểu dữ liệu         | Mô tả                                                |
| ----------------- | -------------------- | ---------------------------------------------------- |
| Id                | int                  | Mã định danh của danh mục.                           |
| Name              | string               | Tên của danh mục.                                    |
| Image             | string               | Đường dẫn đến hình ảnh của danh mục.                  |
| Description       | string               | Mô tả về danh mục.                                   |
| Products          | ICollection<Product> | Các sản phẩm thuộc danh mục (tùy chọn, có thể là null). |

  ### Tên model: ApplicationUser

| Tên thuộc tính   | Kiểu dữ liệu | Mô tả                           |
| ---------------- | ------------ | ------------------------------- |
| Name             | string       | Tên của người dùng              |
| StreetAddress    | string       | Địa chỉ đường phố               |
| City             | string       | Tên thành phố                   |
| Country          | string       | Tên quốc gia                    |
| State            | string       | Tên tiểu bang, tỉnh             |
| Zip Code         | string       | Mã bưu chính                    |


