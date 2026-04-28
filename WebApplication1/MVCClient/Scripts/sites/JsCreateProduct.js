$(function () {
    $("input[type='button']").click(function () {
        var product = {
            Name: $("#Name").val(),
            Price: parseFloat($("#Price").val()),
            Stock: parseInt($("#Stock").val())
        };
        $.ajax({
            url: 'https://localhost:44393/api/product',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(product),
            success: function (result) {
                alert("Product created successfully!");
                window.location.href = '@Url.Action("Index", "JavascriptProduct")';
            },
            error: function (xhr, status, error) {
                alert("Error creating product: " + error);
            }
        });
    });
})