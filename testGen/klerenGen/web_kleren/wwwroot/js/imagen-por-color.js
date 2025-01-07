$(document).ready(function () {
    console.log("Documento listo");

    function obtenerArticuloIdDesdeUrl() {
        const urlParts = window.location.pathname.split('/');
        const articuloId = urlParts[urlParts.length - 1];
        return articuloId;
    }

    const articuloId = obtenerArticuloIdDesdeUrl();

    // Manejar el cambio de color al seleccionar una opción
    $('.color-radio').on('change', function () {

        let colorId = $(this).val();  

        // Realizar la solicitud AJAX
        $.ajax({
            url: '/Articulo/ObtenerImagenPorColor',  
            type: 'GET',
            data: { ColorSel: colorId, articuloId: articuloId },  // Enviar los parámetros
            success: function (imagen) {       
                const botonContainer = document.getElementById("imagen-container");
                botonContainer.innerHTML = `
                    <img id="imagen-principal" src="${imagen.rutaArchivoString}"
                         alt="${imagen.textoAlternativo}" class="img-thumbnail" />
                `;
            },
            error: function () {
                console.error('Error al cargar la imagen.');
            }
        });
    });
});
