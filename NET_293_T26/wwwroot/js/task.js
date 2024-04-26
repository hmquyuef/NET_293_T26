$(document).ready(() => {
    RenderListTask();
})

$('#addtask').click(function () {
    //lay du lieu tu form
    var ten = $('#tennhiemvu').val();
    var uutien = $('#uutien').val();
    var trangthai = $('#trangthai').val();
    var mota = $('#mota').val();

    //xu ly ajax gui du lieu ve controller
    $.ajax({
        url: '/Tasks/AddTask',
        type: 'POST',
        data: {
            ten: ten,
            uutien: uutien,
            trangthai: trangthai,
            mota: mota
        },
        success: function (data) {
            $('#staticBackdrop').modal('hide');
            RenderListTask();
            
        },
        error: function () {
            alert('Them that bai');
        }
    });
})

function RenderListTask() {
    $('#listtasks').empty();
    $.ajax({
        url: '/Tasks/GetListTask',
        type: 'GET',
        success: function (data) {
            console.log("DATA RESULT:", data)
            data.map((item, index) => {
                $('#listtasks').append(`
                <tr>
                    <td>${index + 1}</td>
                    <td>${item.name}</td>
                    <td>${item.priority}</td>
                    <td>${item.status}</td>
                    <td>
                        <button class="btn btn-primary" onclick="EditTask(${item.id})">Sửa</button>
                        <button class="btn btn-danger" onclick="DeleteTask(${item.id})">Xóa</button>
                    </td>
                    </tr>`)
            })
        }
    });
 }

//function DeleteTask(id) {
//    //xu ly ajax gui du lieu ve controller
//    $.ajax({
//        url: '/Tasks/DeleteTask',
//        type: 'POST',
//        data: {
//            id: id
//        }
//        success: function (data) {
//            RenderListTask();
//        },
//        error: function () {
//            alert('Xoa that bai');
//        }
//    });
//}


