var dataTable;

$(document).ready(function () {
   loadDataTable();
});

function loadDataTable() {
   dataTable = $('#DT_load').DataTable({
      "ajax": {
         "url": "/employees/getall/",
         "type": "GET",
         "datatype": "json"
      },
      "columns": [
         { "data": "firstname", "width": "20%" },
         { "data": "lastname", "width": "20%" },
         { "data": "gender", "width": "20%" },
         {
            "data": "employeeid",
            "render": function (data) {
               return `<div class="text-center">
                        <a href="/employees/Upsert?employeeid=${data}" class='btn btn-success text-white' style='cursor:pointer; width:70px;'>
                            Edit
                        </a>
                        &nbsp;
                        <a class='btn btn-danger text-white' style='cursor:pointer; width:70px;'
                            onclick=Delete('/employees/Delete?employeeid='+${data})>
                            Delete
                        </a>
                        </div>`;
            }, "width": "40%"
         }
      ],
      "language": {
         "emptyTable": "no data found"
      },
      "width": "100%"
   });
}

function Delete(url) {
   swal({
      title: "Are you sure?",
      text: "Once deleted, you will not be able to recover",
      icon: "warning",
      buttons: true,
      dangerMode: true
   }).then((willDelete) => {
      if (willDelete) {
         $.ajax({
            type: "DELETE",
            url: url,
            success: function (data) {
               if (data.success) {
                  toastr.success(data.message);
                  dataTable.ajax.reload();
               }
               else {
                  toastr.error(data.message);
               }
            }
         });
      }
   });
}