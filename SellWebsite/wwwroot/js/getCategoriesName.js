
$(document).ready(function () {
    loadData();
});
function loadData() {
    $.ajax({
        url: '/Customer/Home/GetCategories',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            $("#category-list").empty()
            $.each(data.data, function (index, item) {
                // Tạo một phần tử <li> mới và thêm nội dung
                var listItem = `<li><div class="dropdown-item">${item}</div></li>`;
                // Thêm phần tử <li> vào danh sách
                $('#category-list').append(listItem);
            });
        },
        error: function (xhr, status, error) {
            // Xử lý lỗi (nếu có)
            console.log("fail")
        }
    });
}

