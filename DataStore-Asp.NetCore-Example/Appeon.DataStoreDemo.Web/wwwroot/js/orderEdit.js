$(function () {


    $('#btnAdd').on('click', function () {
        var modal = $('#detailModal');

        modal.find("input").not("#salesOrderID").val("");
        modal.find("select option:first").prop("selected", true);
        modal.find('#specialOfferID').val(1);
        modal.find('#salesOrderDetailID').val(0);

        modal.modal('show');
    });

    $('#btnAddDetail').on('click', function () {
        var modal = $('#detailModal');

        modal.find('#save').attr('asp-page-handler', 'CreateDetail');
        modal.find('#save').attr('formaction', '/SalesOrders/Edit?handler=CreateDetail');

        modal.find("input").not("#salesOrderID").val("");
        modal.find("select option:first").prop("selected", true);
        modal.find('#specialOfferID').val(1);
        modal.find('#salesOrderDetailID').val(0);

        modal.modal('show');
    });

    $('.btn-info.btn-xs').on('click', function () {
        var modal = $('#detailModal');

        modal.modal('show');

        modal.find('#save').attr('asp-page-handler', 'UpdateDetail');
        modal.find('#save').attr('formaction', '/SalesOrders/Edit?handler=UpdateDetail');

        modal.find('#salesOrderID').val(
            $(this).parents("tr").find("td.detailId input.salesOrderID").val());

        modal.find('#salesOrderDetailID').val(
            $(this).parents("tr").find("td.detailId input.salesOrderDetailID").val());

        modal.find('#carrierTrackingNumber').val(
            $(this).parents("tr").find("td.detailId input.carrierTrackingNumber").val());

        modal.find('#specialOfferID').val(
            $(this).parents("tr").find("td.detailId input.specialOfferID").val());

        modal.find('#productID').val(
            $(this).parents("tr").find("td.productID input").val());

        modal.find('#unitPrice').val(
            $(this).parents("tr").find("td.unitPrice input").val());

        modal.find('#orderQty').val(
            $(this).parents("tr").find("td.orderQty input").val());

        modal.find('#unitPriceDiscount').val(
            $(this).parents("tr").find("td.unitPriceDiscount input").val());

        modal.find('#lineTotal').val(
            $(this).parents("tr").find("td.lineTotal input").val());
    });

    $('.btn-danger.btn-xs').on('click', function () {
        var salesOrderID = $(this).parents("tr").find("td.detailId input.salesOrderID").val();
        var salesOrderDetailID = $(this).parents("tr").find("td.detailId input.salesOrderDetailID").val();
        if (confirm("Are you sure you want to delete the record?")){
            $.ajax({
                type: "get",
                url: "./Edit?handler=DeleteDetail&salesOrderID=" + salesOrderID + "&salesOrderDetailID=" + salesOrderDetailID,
                success: function (data) {
                    if (data.code == 1) {
                        new PNotify({
                            title: 'Delete Success',
                            text: 'Delete Success',
                            type: 'success',
                            styling: 'bootstrap3'
                        });
                        refreshDetail(data.id);
                    } else {
                        new PNotify({
                            title: 'Delete Fail',
                            text: data.message,
                            type: 'error',
                            styling: 'bootstrap3'
                        });
                        //window.location.href = "./Edit?id=" + data.id;
                    }
                },
                error: function (err) {
                    console.log(err);
                    //alert(err);
                }
            });
        }
    });


    

    function refreshDetail(detailId) {
        $(".salesOrderDetailID").each(function () {
            var id = $(this).val();
            if (id==detailId) {
                $(this).parents("tr").remove();
            }
        })
    }

    $('#submit').on('click', function () {
        var valErrNum = $('#demo-form2').find("ul.parsley-errors-list.filled").length;
        if (valErrNum > 0) {
            return;
        }
        $.ajax({
            type: "post",
            url: "./Edit",
            data: $('#demo-form2').serialize(),
            success: function (data) {
                if (data.code == 1) {
                    new PNotify({
                        title: 'Save Success',
                        text: 'Save Success',
                        type: 'success',
                        styling: 'bootstrap3'
                    });
                    //window.location.href = "./Edit?id=" + data.id;
                } else {
                    new PNotify({
                        title: 'Save Fail',
                        text: data.message,
                        type: 'error',
                        styling: 'bootstrap3'
                    });
                    //window.location.href = "./Edit?id=" + data.id;
                }
            },
            error: function (err) {
                console.log(err);
                //alert(err);
            }
        });
        return false;
    });

    if ($('#orderFlag').prop('checked')) {
        $('.salesPersonID').attr('hidden', 'hidden');
    } else {
        $('.salesPersonID').removeAttr('hidden');
    }

    $('#productID').on('change', function () {
        var productID = $('#productID').val();

        $.ajax({
            type: "get",
            url: "./Edit?handler=RetrieveProduct&id=" + productID,
            contentType: "application/x-www-form-urlencoded",
            //dataType: "json",
            //async: true,
            success: function (data) {
                console.log(data);
                if (data.code == 1) {
                    setVals(data.product[0]);
                }
            },
            error: function (err) {
                console.log(err);
                //alert(err);
            }
        });
    });

    function setVals(data) {
        $('#productID').val(data.product_Productid);
        $('#unitPrice').val(data.product_Listprice);
        $('#orderQty').val(1);

        reCalcLineTotal();
    }

    function reCalcLineTotal() {
        var unitPriceDiscount = $('#unitPriceDiscount').val();
        if (!unitPriceDiscount) {
            unitPriceDiscount = 0;
        } else {
            unitPriceDiscount = parseFloat(unitPriceDiscount);
        }

        var orderQty = $('#orderQty').val();
        if (!orderQty) {
            orderQty = 0;
        } else {
            orderQty = parseInt(orderQty);
        }

        var unitPrice = $('#unitPrice').val();
        if (!unitPrice) {
            unitPrice = 0;
        } else {
            unitPrice = parseFloat(unitPrice);
        }

        var lineTotal = orderQty * (1 - unitPriceDiscount) * unitPrice;

        $('#lineTotal').val(lineTotal);
    }

    //$('.reCalc').on('change', reCalcLineTotal);
    $('#orderQty').on('change', reCalcLineTotal);
    $('#unitPriceDiscount').on('change', reCalcLineTotal);
    $('#unitPrice').on('change', reCalcLineTotal);
    
});