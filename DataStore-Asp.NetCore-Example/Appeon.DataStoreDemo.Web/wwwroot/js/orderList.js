$(function() {
    var table = $('#datatable-checkbox1').DataTable({
        "processing": true,
        "serverSide": true,
        //"data": [{ "SalesOrderID": 75124, "RevisionNumber": 2, "OrderDate": "2018-10-19T17:29:29.007", "DueDate": "2018-10-29T00:00:00", "ShipDate": "2018-10-19T17:29:29.007", "Status": 1, "OnlineOrderFlag": true, "SalesOrderNumber": "SO75124", "PurchaseOrderNumber": null, "AccountNumber": "1", "CustomerID": 11000, "SalesPersonID": null, "TerritoryID": null, "BillToAddressID": 22601, "ShipToAddressID": 22601, "ShipMethodID": 1, "CreditCardID": 10695, "CreditCardApprovalCode": null, "CurrencyRateID": null, "SubTotal": 53.9900, "TaxAmt": 0.0000, "Freight": 1.0000, "TotalDue": 54.9900, "Comment": null, "ModifiedDate": "2018-10-19T17:29:29.007" }, { "SalesOrderID": 75126, "RevisionNumber": 3, "OrderDate": "2018-10-19T17:38:23.033", "DueDate": "2018-10-29T00:00:00", "ShipDate": "2018-10-19T17:38:23.033", "Status": 1, "OnlineOrderFlag": true, "SalesOrderNumber": "SO75126", "PurchaseOrderNumber": "111", "AccountNumber": "111", "CustomerID": 11000, "SalesPersonID": null, "TerritoryID": null, "BillToAddressID": 22601, "ShipToAddressID": 22601, "ShipMethodID": 1, "CreditCardID": 10695, "CreditCardApprovalCode": "111", "CurrencyRateID": null, "SubTotal": 1466.4900, "TaxAmt": 1.0000, "Freight": 1.0000, "TotalDue": 1468.4900, "Comment": null, "ModifiedDate": "2018-10-19T17:38:23.033" }, { "SalesOrderID": 75127, "RevisionNumber": 1, "OrderDate": "2018-10-22T18:11:58.017", "DueDate": "2018-11-01T00:00:00", "ShipDate": "2018-10-22T18:11:58.017", "Status": 1, "OnlineOrderFlag": true, "SalesOrderNumber": "SO75127", "PurchaseOrderNumber": null, "AccountNumber": null, "CustomerID": 11001, "SalesPersonID": null, "TerritoryID": null, "BillToAddressID": 14489, "ShipToAddressID": 14489, "ShipMethodID": 1, "CreditCardID": null, "CreditCardApprovalCode": null, "CurrencyRateID": null, "SubTotal": 0.0000, "TaxAmt": 11.0000, "Freight": 11.0000, "TotalDue": 22.0000, "Comment": null, "ModifiedDate": "2018-10-22T18:11:58.017" }, { "SalesOrderID": 75128, "RevisionNumber": 1, "OrderDate": "2018-10-22T18:18:49.073", "DueDate": "2018-11-01T00:00:00", "ShipDate": "2018-10-22T18:18:49.073", "Status": 1, "OnlineOrderFlag": true, "SalesOrderNumber": "SO75128", "PurchaseOrderNumber": null, "AccountNumber": null, "CustomerID": 11001, "SalesPersonID": null, "TerritoryID": null, "BillToAddressID": 14489, "ShipToAddressID": 14489, "ShipMethodID": 1, "CreditCardID": null, "CreditCardApprovalCode": null, "CurrencyRateID": null, "SubTotal": 0.0000, "TaxAmt": 1.0000, "Freight": 0.0000, "TotalDue": 1.0000, "Comment": null, "ModifiedDate": "2018-10-22T18:18:49.073" }, { "SalesOrderID": 75129, "RevisionNumber": 2, "OrderDate": "2018-10-22T18:31:50.07", "DueDate": "2018-11-01T00:00:00", "ShipDate": "2018-10-22T18:31:50.07", "Status": 1, "OnlineOrderFlag": true, "SalesOrderNumber": "SO75129", "PurchaseOrderNumber": null, "AccountNumber": null, "CustomerID": 11001, "SalesPersonID": null, "TerritoryID": null, "BillToAddressID": 14489, "ShipToAddressID": 14489, "ShipMethodID": 1, "CreditCardID": null, "CreditCardApprovalCode": null, "CurrencyRateID": null, "SubTotal": 0.0000, "TaxAmt": 1.0000, "Freight": 0.0000, "TotalDue": 1.0000, "Comment": null, "ModifiedDate": "2018-10-22T18:31:50.07" }, { "SalesOrderID": 75130, "RevisionNumber": 1, "OrderDate": "2018-10-22T18:54:53.073", "DueDate": "2018-11-01T00:00:00", "ShipDate": "2018-10-22T18:54:53.073", "Status": 1, "OnlineOrderFlag": true, "SalesOrderNumber": "SO75130", "PurchaseOrderNumber": null, "AccountNumber": null, "CustomerID": 11001, "SalesPersonID": null, "TerritoryID": null, "BillToAddressID": 14489, "ShipToAddressID": 14489, "ShipMethodID": 1, "CreditCardID": null, "CreditCardApprovalCode": null, "CurrencyRateID": null, "SubTotal": 0.0000, "TaxAmt": 0.0000, "Freight": 0.0000, "TotalDue": 0.0000, "Comment": null, "ModifiedDate": "2018-10-22T18:54:53.073" }, { "SalesOrderID": 75131, "RevisionNumber": 1, "OrderDate": "2018-10-22T18:57:39.05", "DueDate": "2018-11-01T00:00:00", "ShipDate": "2018-10-22T18:57:39.05", "Status": 1, "OnlineOrderFlag": true, "SalesOrderNumber": "SO75131", "PurchaseOrderNumber": null, "AccountNumber": null, "CustomerID": 11000, "SalesPersonID": null, "TerritoryID": null, "BillToAddressID": 22601, "ShipToAddressID": 22601, "ShipMethodID": 1, "CreditCardID": null, "CreditCardApprovalCode": null, "CurrencyRateID": null, "SubTotal": 0.0000, "TaxAmt": 0.0000, "Freight": 0.0000, "TotalDue": 0.0000, "Comment": null, "ModifiedDate": "2018-10-22T18:57:39.05" }, { "SalesOrderID": 75132, "RevisionNumber": 1, "OrderDate": "2018-10-22T19:01:56.017", "DueDate": "2018-11-01T00:00:00", "ShipDate": "2018-10-22T19:01:56.017", "Status": 1, "OnlineOrderFlag": true, "SalesOrderNumber": "SO75132", "PurchaseOrderNumber": null, "AccountNumber": null, "CustomerID": 11001, "SalesPersonID": null, "TerritoryID": null, "BillToAddressID": 14489, "ShipToAddressID": 14489, "ShipMethodID": 1, "CreditCardID": null, "CreditCardApprovalCode": null, "CurrencyRateID": null, "SubTotal": 0.0000, "TaxAmt": 0.0000, "Freight": 0.0000, "TotalDue": 0.0000, "Comment": null, "ModifiedDate": "2018-10-22T19:01:56.017" }, { "SalesOrderID": 75133, "RevisionNumber": 1, "OrderDate": "2018-10-22T19:03:35.083", "DueDate": "2018-11-01T00:00:00", "ShipDate": "2018-10-22T19:03:35.083", "Status": 1, "OnlineOrderFlag": true, "SalesOrderNumber": "SO75133", "PurchaseOrderNumber": null, "AccountNumber": null, "CustomerID": 11001, "SalesPersonID": null, "TerritoryID": null, "BillToAddressID": 14489, "ShipToAddressID": 14489, "ShipMethodID": 1, "CreditCardID": null, "CreditCardApprovalCode": null, "CurrencyRateID": null, "SubTotal": 0.0000, "TaxAmt": 0.0000, "Freight": 0.0000, "TotalDue": 0.0000, "Comment": null, "ModifiedDate": "2018-10-22T19:03:35.083" }, { "SalesOrderID": 75134, "RevisionNumber": 1, "OrderDate": "2018-10-22T19:05:21.03", "DueDate": "2018-11-01T00:00:00", "ShipDate": "2018-10-22T19:05:21.03", "Status": 1, "OnlineOrderFlag": true, "SalesOrderNumber": "SO75134", "PurchaseOrderNumber": null, "AccountNumber": null, "CustomerID": 11000, "SalesPersonID": null, "TerritoryID": null, "BillToAddressID": 22601, "ShipToAddressID": 22601, "ShipMethodID": 1, "CreditCardID": null, "CreditCardApprovalCode": null, "CurrencyRateID": null, "SubTotal": 0.0000, "TaxAmt": 0.0000, "Freight": 0.0000, "TotalDue": 0.0000, "Comment": null, "ModifiedDate": "2018-10-22T19:05:21.03" }],
        "ajax": function (data, callback, settings) {
            var param = {};
            param.draw = data.draw;
            param.pageIndex = (data.start / data.length) + 1;
            param.pageSize = data.length;

            param.sex = $('#select-sex option:selected').val();
            param.search = $('#search').val();
            $.ajax({
                type: "Post",
                data: param,
                url: "./Index?handler=Search",
                dataType: "json",
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                success: function (data) {
                    data = JSON.parse(data);
                    callback(data);
                }
            });
        },
        'columns': [
            {
                "data": null,
                "render": function (data, type, row) {
                    return "<input type='checkbox' value='" + data.SalesOrderID + "'>";
                }
            },
            {
                'data': null,
                'render': function (data, type, row) {
                    return '<a href="./Edit?id='+ data.SalesOrderID+'" class="btn btn-info btn-xs"><i class="fa fa-pencil"></i> Edit </a>';
                }
            },
            { "data": "SalesOrderID","width":120 },
            {
                "data": "OrderDate",
                "width": 120,
                'render': function (data, type, row) {
                    if (data == null || data.trim() == "") { return ""; }
                    else { return convertDate(data)}
                }
            },
            { "data": "CustomerID" },
            { "data": "Status" },
            { "data": "SalesOrderNumber" },
            { "data": "ShipToAddressID" },
            { "data": "SubTotal" },
            { "data": "TaxAmt" },
            { "data": "Freight" },
            { "data": "TotalDue" },
            {
                "data": "ModifiedDate",
                "width": 120,
                'render': function (data, type, row) {
                    if (data == null || data.trim() == "") { return ""; }
                    else { return convertDate(data) }
                }
            },
            
            
        ],
        'paging': true, 
        'scrollX':true,
        'lengthChange': true,
        'searching': false,
        'ordering': false,
        'info': true,
        'autoWidth': false,
        'dom': "t<'dataTables_info'il>p",
        'language': {
            "sProcessing": "Loading...",
            "sLengthMenu": "Show _MENU_ records",
            "sZeroRecords": "No records to display",
            "sInfo": "Showing _START_ to _END_ of _TOTAL_ records",
            "sSearch": "Search:",
            "sUrl": "",
            "sEmptyTable": "No records to display",
            "sLoadingRecords": "Loading...",
            "sInfoThousands": ",",
            "oPaginate": {
                "first": "First",
                "previous": "Previous",
                "next": "Next",
                "last": "Last"
            }
        }
    });
    $('#btnDel').on('click', function () {
        var isChk = $('tbody tr').find('td:eq(0)').find("input[type=checkbox]").is(':checked');
        if (!isChk) {
            alert("Please select at least one order.");
        } else {
            var result = confirm("Are you sure you want to delete the selected record(s)?");
            if (result) {
                var ids = "";
                $('tbody tr').find('td:eq(0)').find("input[type=checkbox]:checked").each(function () {
                    ids += $(this).val()+","; 
                })
                ids = ids.substring(0, ids.length-1);
                $.ajax({
                    type: "get",
                    url: "./Index?handler=Delete&ids=" + ids ,
                    success: function (data) {
                        if (data.code == 1) {
                            new PNotify({
                                title: 'Delete Success',
                                text: 'Delete Success',
                                type: 'success',
                                styling: 'bootstrap3'
                            });
                            window.location.href = "./Index";
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

        }
    });

    function convertDate(date) {
        date = date.slice(0, 10);
        var arr = date.split("-")
        if (arr.length == 3) {
            var year = arr[0];
            var month = arr[1];
            var day = arr[2];

            return day + "/" + month + "/" + year;
        } else {
            return "";
        }
        
    }
    
});