$(function () {
    
    $('#customerSelect').on('change', function () {
        var customerId = $('#customerSelect').val();

        $.ajax({
            type: "get",
            url: "./Create?handler=RetrieveDddw&customerId=" + customerId,
            contentType: "application/x-www-form-urlencoded",
            success: function (data) {
                //console.log(data);
                if (data.code == 1) {
                    setSelectOptions(data);
                }
            },
            error: function (err) {
                console.log(err);
                //alert(err);
            }
        });
    });



    function setSelectOptions(data) {
        // Creditcard
        $('#creditCardID').find('option').remove();
        $('#creditCardID').val("");

        var creditCardOptions = '';// '<option value="">please select</option>';
        $.each(data.creditcards, function (v, o) {
            creditCardOptions += '<option value=' + o.creditcard_Creditcardid + '>' + o.creditcard_Cardnumber + '</option>';
        });
        $("#creditCardID").html(creditCardOptions);
        //for (var i = 0; i < data.creditcards.length; i++) {
        //    $("#creditCardID").append('<option value=' + data.creditcards[i].creditcard_Creditcardid + '>'
        //        + data.creditcards[i].creditcard_CardNumber + '</option>');
        //}

        // Address Options
        var addressOptions = '';
        $.each(data.customerAddresses, function (v, o) {
            addressOptions += '<option value=' + o.businessentityaddress_Addressid + '>' + o.address_Addressline1 + '</option>';
        });

        // BillToAddress
        $('#billToAddressID').find('option').remove();
        $('#billToAddressID').val("");
        $("#billToAddressID").html(addressOptions);

        // ShipToAddress
        $('#shipToAddressID').find('option').remove();
        $('#shipToAddressID').val("");
        $("#shipToAddressID").html(addressOptions);
    }
});