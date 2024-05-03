$(document).ready(() => {
    RenderListTask('0');
})

$('#addtask').click(function () {
    //lay du lieu tu form
    var id = $('#idcard').val();
    var ten = $('#tennhiemvu').val();
    var uutien = $('#uutien').val();
    var trangthai = $('#trangthai').val();
    var mota = $('#mota').val();

    //xu ly ajax gui du lieu ve controller
    if (id == '') {
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
                var value = $('input[type="radio"]:checked').val();
                console.log("VALUE:", value);
                RenderListTask(value);
            },
            error: function () {
                alert('Them that bai');
            }
        });
    } else {
        $.ajax({
            url: '/Tasks/EditTask',
            type: 'PUT',
            data: {
                id: id,
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
    }
})

function RenderListTask(trangthai) {
    console.log("TRANG THAI:", trangthai)
    $('#listtasks').empty();
    $.ajax({
        url: '/Tasks/GetListTask',
        type: 'GET',
        success: function (data) {
            console.log("DATA RESULT:", data)
            if (data.length > 0) {
                var temp = data.filter(item => item.status == trangthai || trangthai == '0');
                temp.map((item, index) => {
                    $('#listtasks').append(`
                    <tr>
                        <td class="align-middle text-center">${index + 1}</td>
                        <td class="align-middle">${item.Name}</td>
                        <td class="align-middle text-center">${item.priority}</td>
                        <td class="align-middle text-center ${item.status == "1" ? "text-primary" : item.status == "2" ? "text-warning" : "text-danger"}">${item.status == "1" ? "Hoàn thành" : item.status == "2" ? "Đang làm" : "Hủy bỏ"}</td>
                        <td class="text-center">
                            <a class="btn btn-primary" href="javascript:EditTask('${item.id}')"><i class='bx bx-edit' ></i></a>
                            <a class="btn btn-danger" href="javascript:DeleteTask('${item.id}')"><i class='bx bx-trash-alt'></i></a>
                        </td>
                    </tr>`);
                });
            } else {
                $('#listtasks').append(`<tr><td class="text-center" colspan="5">No data</td></tr>`);
            }
        }
    });
 }

function EditTask(id) {
    //xu ly ajax gui du lieu ve controller
    $.ajax({
        url: '/Tasks/GetTaskById/' + id,
        type: 'GET',
        success: function (data) {
            $('#idcard').val(data.id);
            $('#tennhiemvu').val(data.name);
            $('#uutien').val(data.priority);
            $('#trangthai').val(data.status);
            $('#mota').val(data.note);
            $('#staticBackdropLabel').html('Chỉnh sửa nhiệm vụ');
            $('#addtask').html('Cập nhật');
            $('#staticBackdrop').modal('show');
        },
        error: function () {
            alert('Sua that bai');
        }
    });
}

function DeleteTask(id) {
    //xu ly ajax gui du lieu ve controller
    $.ajax({
        url: '/Tasks/DeleteTask/' + id,
        type: 'DELETE',
        success: function (data) {
            var value = $('input[type="radio"]:checked').val();
            RenderListTask(value);
        },
        error: function () {
            alert('Xoa that bai');
        }
    });
}

//xử lý sự kiện cho các radio trả về giá trị value
$('input[type="radio"]').change(function () {
    var value = $(this).val();
    console.log(value);
    RenderListTask(value);
})
