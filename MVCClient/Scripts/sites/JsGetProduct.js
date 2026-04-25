    $(function () {
        $.ajax({
            url: "https://localhost:44393/api/product",
            type: "GET",
            success: function (response) {
                $('#AllProducts').DataTable({
                    data: response,
                    columns: [
                        { data: 'id' },
                        { data: 'name' },
                        { data: 'price' },
                        { data: 'stock' }
                    ]
                });

                console.log("Products fetched successfully:", response);
            },
            error: function (error) {
                console.error("Error fetching products:", error);
            }
        });
    });
