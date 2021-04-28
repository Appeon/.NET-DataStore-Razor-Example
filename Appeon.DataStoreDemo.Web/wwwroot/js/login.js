$(function () {
    $('#loginPwd').val("K7dMpTY=");
    $('#submit').on('click', function () {
        var valErrNum = $('#loginForm').find("ul.parsley-errors-list.filled").length;
        if (valErrNum > 0) {
            return;
        }
        $.ajax({
            type: "post",
            url: "./Login",
            data: $('#loginForm').serialize(),
            success: function (data) {
                //console.log(data);
                if (data.code == 1) {
                    new PNotify({
                        title: 'Login Success',
                        text: 'Login Success',
                        type: 'success',
                        styling: 'bootstrap3'
                    });
                    window.location.href = "/Index"
                } else {
                    new PNotify({
                        title: 'Login Fail',
                        text: data.message,
                        type: 'error',
                        styling: 'bootstrap3'
                    });
                }
            },
            error: function (err) {
                console.log(err);
                //alert(err);
            }
        });
        return false;
    });
});