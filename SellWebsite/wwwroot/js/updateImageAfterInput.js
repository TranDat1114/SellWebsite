// Lắng nghe sự kiện khi người dùng chọn tệp
$("#input-img").on("change", function (a) {
    // Lấy thông tin tệp được chọn
    var file = a.target.files[0];
    // Tạo FileReader object
    const reader = new FileReader();
    //Tạo 1 event khi gọi tới reader(reader onload) thì chuyển đổi file thành dạnh base64 và thẻ img của HTML có thể đọc được dạng base64 bằng src
    reader.onload = function (e) {
        document.querySelector("#preview-img").src = e.target.result;
    };
    //Gọi readder
    reader.readAsDataURL(file);
    //Hiện img mới
    $("#preview-img-div").removeAttr("hidden");
});
