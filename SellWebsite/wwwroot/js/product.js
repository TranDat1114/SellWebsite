
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/product/getall' },
        "columns": [
            { data: 'Id' },
            {
                data: 'Image',
                "render": function (data) {
                    return `
                    <img class="img-table" src="${data}" alt="img" />
                    `
                }
            },
            { data: 'Title' },
            { data: 'Author' },
            {
                data: 'Description',
                "render": function (data) {
                    return `
                     <td class="w-100">
                        <p class="text-truncate">${data}</p>
                    </td>
                    `
                }
            },
            { data: 'CreatedDate' },
            { data: 'UpdatedDate' },
            { data: 'License' },
            { data: 'Credits' },
            { data: 'PreviewUrl' },
            { data: 'DownloadCount' },
            { data: 'DownloadUrl' },
            { data: 'Price' },
            { data: 'PostsBy' },
            {
                data: 'Categories',
                "render": function (data) {
                    var categoriesHTML = '';
                    for (var i = 0; i < data.length; i++) {
                        categoriesHTML += `${data[i].NameEnglish} `;
                    }
                    return categoriesHTML;
                }

            },
            {
                data: 'Id',
                "render": function (data) {
                    return `
                    <td>
                        <a href="/admin/product/upsert?id=${data}" class="btn btn-primary text-nowrap w-100"><i class="bi bi-pencil-square"></i> Edit</a>
                    </td>                  
                        `
                }
            },
            {
                data: 'Id',
                "render": function (data) {
                    return `
                    <td>
                        <a onClick=Delete('/admin/product/delete?id=${data}') class="btn btn-danger text-nowrap w-100"><i class="bi bi-trash3-fill"></i> Delete</a>
                    </td>                 
                        `
                }
            }
        ]
    });
}