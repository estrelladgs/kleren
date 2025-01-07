$(document).on("click", ".color-button", function (e) {
    e.preventDefault();

    console.log("hola ");


    var button = $(this); // Botón seleccionado
    var colorId = button.data("color-id");
    var articuloId = button.data("articulo-id");

    console.log("Color seleccionado: " + colorId + ", Artículo ID: " + articuloId);

    $.ajax({
        url: '/Articulo/ActualizarImagenes',
        method: 'GET',
        data: {
            id: articuloId,
            P_color: colorId
        },

        success: function (response) {
            // Reemplazar el contenedor de imágenes con el HTML recibido
            $('#imagenes-container').html(response);

            // Actualizar estilos de botones seleccionados
            $(".color-button").removeClass("btn-dark").addClass("btn-outline-dark");
            button.removeClass("btn-outline-dark").addClass("btn-dark");
        },
        error: function () {
            alert("Ocurrió un error al cargar las imágenes del color seleccionado.");
        }
    });
});

