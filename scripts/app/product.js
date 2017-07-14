var ProductController = function() {
    var deleteProduct = function() {
        $(".js-delete-product").click(function(event) {
            if (confirm("Are you sure?")) {
                var link = $(event.target);
                let serviceUrl = $.dnnSF().getServiceRoot("MVCModule") + "Product/Delete";
                var productId = link.attr("data-productId");
                var dataSend = {
                    productId: productId
                }
                $.ajax({
                    url: serviceUrl,
                    type: "post",
                    data: dataSend,
                    success: function() {
                        alert("Deleted");
                        link.closest("tr").remove();
                    },
                    error: function(error) {
                        alert(error.statusText);
                    }
                });
            }
        });
    };
    return {
        DeleteProduct: deleteProduct
    }
}();