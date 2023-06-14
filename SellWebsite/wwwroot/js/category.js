
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/category/getall' },
        "columns": [
            { data: 'id' },            
            { data: 'nameEnglish' },
            { data: 'descriptionEnglish' },
            { data: 'nameVietnamese' },
            { data: 'descriptionVietnamese' },
            {
                data: 'id',
                "render": function (data) {
                    return `
                    <td>
                        <a href="/admin/category/upsert?id=${data}" class="btn btn-primary text-nowrap w-100"><i class="bi bi-pencil-square"></i> Edit</a>
                    </td>                  
                        `
                }
            },
            {
                data: 'id',
                "render": function (data) {
                    return `
                    <td>
                        <a onClick=Delete('/admin/category/delete?id=${data}') class="btn btn-danger text-nowrap w-100"><i class="bi bi-trash3-fill"></i> Delete</a>
                    </td>                 
                        `
                }
            }
        ]
    });
}

