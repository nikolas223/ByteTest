const Create = function (controller) {
    $("#myModalBody").load(`/${controller}/Create`, function () {
        $("#myModal").modal("show");
    });
}

const Update = function (controller, id) {
    $("#myModalBody").load(`/${controller}/Update/${id}`, function () {
        $("#myModal").modal("show");
    });
}

const Delete = function (controller, id) {
    const r = confirm("Are you sure you want to Delete?");
    if (r === true) {
        $.ajax({
            type: "DELETE",
            url: `/${controller}/Delete/${id}`,
            success: function (response) {
                window.location.reload();
            },
            error: function (error) {
                alert(error.responseJSON.join("\n"));
            }
        })
    }
}


