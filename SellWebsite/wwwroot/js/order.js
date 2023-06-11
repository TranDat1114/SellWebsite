
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
            { data: 'zipcode' }
        ]
    });
}

