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
                if (result.success == false) {

                    $(".not-found-product").removeClass('hidden');
                    return false;
                }
                else {
                    if (!$(".not-found-product").hasClass('hidden')) {
                        $(".not-found-product").addClass('hidden')
                    }
                    $(".product-row").removeClass("hidden")
                    $(".product-row").append(result);
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

$(document).on("click", "#editProductInWare", function () {

    var productId = $(this).closest(".product-row").find(".row").data("productid")
    var mform = $("#addProductForm")[0];
    $.ajax({
        url: mform.action,
        type: mform.method,
        data: $(mform).serialize(),
        success: function (result) {
            if (result.success) {

                $(`.row[data-productid="${productId}"]`).remove()
            }
            else {

            }
        }
    });

})


$(document).on("click", "#addProductToWare", function () {

    var form = $("#addProductToWareForm");
    var actionUrl = form.attr('action');

    $.ajax({
        type: "POST",
        url: actionUrl,
        data: form.serialize(),
        success: function (result) {
            if (result.success) {
                $("#dialogDiv").modal("hide");
            }
            else {

                return false;
            }
        }
    })

})

$(document).on("click", "#removeRowEdit", function () {

    $(this).parent().parent().remove();
})