
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/order/getall' },
        "columns": [
            { data: 'id' },
            { data: 'applicationUser.name' },
            { data: 'applicationUser.email' },
            { data: 'applicationUser.phoneNumber' },
            { data: 'orderTotal' },
            { data: 'discount' },
            { data: 'paymentStatus' },
            { data: 'orderStatus' },
            { data: 'paymentId' },
            { data: 'city' },
            { data: 'country' },
            { data: 'state' },
            { data: 'zipcode' },
            {
                data: 'id',
                "render": function (data) {
                    return `
                    <td>
                        <a href="/admin/order/GetOrderDetail?idOrder=${data}" class="btn btn-primary text-nowrap w-100"><i class="bi bi-pencil-square"></i> Details</a>
                    </td>                  
                        `
                }
            }
        ]
    });
}

