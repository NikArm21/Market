$(document).ready(function () {
    addRow();
})


let addRow = function () {
    //var rowCount = parseInt($("#total").val());
    //rowCount++;
    //itemList++;
    //$("#total").val(rowCount);
    //var html = '';
    //html += '<tr id="inputRow">';
    //html += '<td><input asp-for class="productId" type="number" name="[' + (rowCount) + '].ProductId" asp-for="@Model.ItemList[i].ProductID"  /></td>';
    //html += '<td><input class ="name" type="text" disabled/></td>';
    //html += '<td><input class="count" type="number" name="[' + (rowCount) + '].Count" asp-for="@Model.ItemList[i].Count" /></td>';
    //html += '<td><input class="total" type="number" name="[' + (rowCount) + '].Total" asp-for="@Model.ItemList[i].Total"  disabled/></td>';
    //html += '<td><button type="button" class="btn btn-danger removeRow">Remove</button></td>';
    //html += '</tr>';

    //$('#newRow').append(html);

    $.ajax({
        type: 'GET',
        url: saleRowURL,
        success: function (html) {
            $('#newRow').append(html);
        }
    })
};



let t;
$(document).on('click', '.productId', function () {
    t = $(this);
    var total = $(this).closest('tr').find('.total').val();
    console.log(total); // or do anything you want with the total value
});

$(document).on("change", '.productId', function (e) {

    $(this).closest('tr').attr("data-productId", $(this).val());

    var total = $(this).closest('tr').find('.total').val();

    $.ajax({
        type: 'GET',
        url: "/Sale/GetProductById/" + parseInt($(this).val()),
        contentType: "application/json",
        dataType: "json",
        success: function (data) {
            if (data.success) {
                //addRow();
                var result = JSON.parse(data.product);

                $(`#inputRow[data-productId="${result.Product.Id}"] > td > .total`).val(total != '0' ? total + result.Product.Price : result.Product.Price)
                $(`#inputRow[data-productId="${result.Product.Id}"]`).attr("data-productCost", result.Product.Cost);
                $(`#inputRow[data-productid="${result.Product.Id}"] > td > .name`).val(result.Product.Name)

            }
        }
    })
});

$(document).on('click', '.removeRow', function () {
    //var rowCount = parseInt($("#total").val());
    //rowCount--;
    //$("#total").val(rowCount);
    $(this).closest('#inputRow').remove();

    $.ajax({
        type: 'GET',
        url: "/Sale/RemoveSaleRow/" + "?SaleRowId=" + parseInt($(this).closest('#inputRow').attr("data-saleRowId")),
        success: function (data) {
            if (data.success) {

            }
        }
    })
});

$(document).on('change', '.count', function () {

    $(this).closest("tr").find(".total").val(parseInt($(this).closest("tr").data("productcost")) * parseInt($(this).val()));
})

$(document).on("click", "#addRow", function () {
    addRow();
})


$(document).on("click", '.fucnKnopka', function (event) {

    // Prevent the form from submitting normally
    event.preventDefault();
    $("#dialogDiv .modal-dialog").load(receiptRowURL, function () {
        // Open the modal dialog
        $("#dialogDiv").modal('show').on('show.bs.modal', ShowReceipt());
    });









    //// Clear the selected products from the sale table
    //$('#saleTableBody tr').each(function () {
    //    $(this).find('.productId').val('');
    //    $(this).find('.name').val('');
    //    $(this).find('.count').val('');
    //    $(this).find('.total').val('');
    //});
});


function ShowReceipt() {
    // Loop through the rows of the sale table and extract the selected products
    var selectedProducts = [];
    $('#newRow tr').each(function () {
        var productId = $(this).find('.productId').val();
        var name = $(this).find('.name').val();
        var count = $(this).find('.count').val();
        var total = $(this).find('.total').val();
        if (productId && name && count && total) {
            selectedProducts.push({
                productId: productId,
                name: name,
                count: count,
                total: total
            });
        }
    });

    // Dynamically create a new HTML row that displays the selected products as a store sales receipt
    var receiptRow = '<tr><td colspan="4"><strong>Store Sales Receipt</strong></td></tr>';
    receiptRow += '<tr><td>Product ID</td><td class="ps-2">Name</td><td class="ps-2">Count</td><td class="ps-2">Total</td></tr>';
    for (var i = 0; i < selectedProducts.length; i++) {
        receiptRow += '<tr><td>' + selectedProducts[i].productId + '</td><td class="ps-2">' + selectedProducts[i].name + '</td><td class="ps-2">' + selectedProducts[i].count + '</td><td class="ps-2">' + selectedProducts[i].total + '</td></tr>';
    }

    // Append the new HTML row to the sales table
    $('.reciptDiv').append(receiptRow);
}