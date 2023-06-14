
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/applicationuser/getall' },
        "columns": [
            { data: 'Name' },
            { data: 'Email' },
            { data: 'PhoneNumber' },
            { data: 'Role' }
        ]
    });
}

