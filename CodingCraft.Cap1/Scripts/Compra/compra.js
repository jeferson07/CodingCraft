(function () { 
    $("#adiciona-produto").click(function () {
        produtoId = $("#ProdutoId").val();
        if (produtoId) {
            $.ajax({
                url: '@Url.Action("AdicionaProduto", "Compra")',
                method: "GET",
                data: { id: produtoId },
                dataType: "html"
            }).done(function (data) {
                $("#lista-produto").append(data);
            });

        }
    });
})();