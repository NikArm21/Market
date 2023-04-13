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
                addRow();
                var result = JSON.parse(data.product);

                $(`#inputRow[data-productId="${result.Product.Id}"] > td > .total`).val(total != '' ? total + result.Product.Cost : result.Product.Cost)
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
});

$(document).on('change', '.count', function () {

    $(this).closest("tr").find(".total").val(parseInt($(this).closest("tr").data("productcost")) * parseInt($(this).val()));
})

$(document).on("click", "#addRow", function () {
    addRow();
})


//$(document).on("click", "#postResult", function () {

//    //var itemList = [
//    //    { ProductID: 1, Count: 2, Total: 10.0 },
//    //    { ProductID: 2, Count: 1, Total: 5.0 }
//    //];

//    //// set the value of the hidden input field to the JSON representation of the list
//    //document.getElementById("list-items").value = JSON.stringify(itemList);

//    $("#formSale").submit();
//})