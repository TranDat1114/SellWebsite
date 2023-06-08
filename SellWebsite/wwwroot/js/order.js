
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/order/getall' },
        "columns": [
            { data: 'id' },
            { data: 'applicationUserId' },
            { data: 'applicationUser.name' },
            { data: 'applicationUser.userName' },
            { data: 'applicationUser.email' },
            { data: 'applicationUser.phoneNumber' },
            { data: 'orderTime' },
            { data: 'orderTotal' },
            { data: 'discount' },
            { data: 'paymentStatus' },
            { data: 'orderStatus' },
            { data: 'paymentDate' },
            { data: 'paymentId' },
            { data: 'payerId' },
            { data: 'city' },
            { data: 'country' },
            { data: 'state' },
            { data: 'zipcode' },

        ]
    });
}

