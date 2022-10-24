$(document).ready(function () {
    buscar()
})


function buscarProdutosPorCategoria() {
    $.ajax({
        method: "GET",
        url: "",
    })
}

function buscar() {
    $('#buscar').on("keyup", function () {
        var value = $(this).val().toLowerCase()
        $('#table-list tr').filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        })
    })
}