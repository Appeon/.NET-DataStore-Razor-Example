$(function () {
    $('#submit').on('click', function () {
        var valErrNum = $('#demo-form2').find("ul.parsley-errors-list.filled").length;
        if (valErrNum>0) {
            return;
        }
        $.ajax({
            type: "post",
            url: "./Create",
            data: $('#demo-form2').serialize(),
            success: function (data) {
                //console.log(data);
                if (data.code == 1) {
                    new PNotify({
                        title: 'Save Success',
                        text: 'Save Success',
                        type: 'success',
                        styling: 'bootstrap3'
                    });
                    window.location.href = "./Edit?id=" + data.id;
                } else {
                    new PNotify({
                        title: 'Save Fail',
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


    

    $('#orderFlag').on('click', function () {
        if ($(this).prop('checked')) {
            $('.salesPersonID').attr('hidden', 'hidden');
            $('#salesPersonID').val("");
        } else {
            $('.salesPersonID').removeAttr('hidden');
            $('#salesPersonID').val("");
        }
    });

});