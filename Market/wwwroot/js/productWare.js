$(document).on("click", "#findProduct", function () {

    var id = $("#searchProductId").val();
    if (id != '') {
        if (!$(".id-required").hasClass('hidden')) {
            $(".id-required").addClass('hidden')
        }
        if (!$(".not-found-product").hasClass('hidden')) {
            $(".not-found-product").addClass('hidden')
        }
        $.ajax({
            type: "GET",
            url: findProductURL + "?id=" + parseInt($("#searchProductId").val()),
            success: function (result) {
                if (result.success) {
                    if (!$(".not-found-product").hasClass('hidden')) {
                        $(".not-found-product").addClass('hidden')
                    }
                    $(".product-row").text(result);
                }
                else {
                    $(".not-found-product").removeClass('hidden');
                    return false;
                }
            }
        })
    }
    else {
        if (!$(".not-found-product").hasClass('hidden')) {
            $(".not-found-product").addClass('hidden')
        }
        $(".id-required").removeClass('hidden');
        return false;
    }
})


$(document).on("click", "#addProduct", function () {

    $("#dialogDiv .modal-dialog").load(addProductWareURL, function () {
        // Open the modal dialog
        $("#dialogDiv").modal('show');
    });
})


$(document).on("click", "#addProductToWare", function () {

    $.ajax({
        type: "POST",
        url: addProductWareURL,
        success: function (result) {
            if (result.success) {
                if (!$(".not-found-product").hasClass('hidden')) {
                    $(".not-found-product").addClass('hidden')
                }
                $(".product-row").text(result);
            }
            else {
                $(".not-found-product").removeClass('hidden');
                return false;
            }
        }
    })

})