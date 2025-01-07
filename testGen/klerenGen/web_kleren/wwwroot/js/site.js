// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).on("click", ".toggle-favorite", function (e) {
    e.preventDefault();

    var button = $(this);
    var idArticulo = button.data("id");
    var esFavorito = button.data("favorito");

    $.ajax({
        url: '/ListaDeseos/ToggleFavorito',
        method: 'POST',
        data: {
            idArticulo: idArticulo,
            favorito: esFavorito
        },
        success: function (response) {
            if (response.success) {
                button.data("favorito", response.favorito);
                var iconClass = response.favorito ? "fas" : "far";
                button.find("i").attr("class", iconClass + " fa-heart");

                if (!response.favorito && window.location.pathname === '/ListaDeseos/Index') {
                    $('#articulo-' + idArticulo).remove();

                    // Si ya no quedan artículos, mostrar el mensaje de "No tienes favoritos"
                    if ($('#misFavoritos').find('.card').length === 0) {
                        $('#tituloPagina').text('¡Vaya! Aún no has añadido nada a tus favoritos');
                    }

                }

            } else {
                alert(response.message || "Error al actualizar favorito.");
            }
        },
        error: function () {
            alert("Ocurrió un error al procesar la solicitud.");
        }
    });
});

$('#modalCompartir').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var recipient = button.data('whatever') // Extract info from data-* attributes
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    modal.find('.modal-title').text('New message to ' + recipient)
    modal.find('.modal-body input').val(recipient)
})


$(document).ready(function () {
    $('#generarEnlace').on('click', function () {
        // Deshabilitar botón mientras se genera el enlace
        var boton = $(this);
        boton.prop('disabled', true).text('Generando...');

        $.ajax({
            url: '/ListaDeseos/Compartir', 
            type: 'GET',
            success: function (response) {
                $('#enlace').val(response.enlace);

                boton.prop('disabled', false)
                    .removeClass('btn-primary')
                    .addClass('btn-success')
                    .text('Copiar')
                    .off('click') // Desvincula el evento actual
                    .on('click', function () {
                        // Copiar el texto al portapapeles
                        navigator.clipboard.writeText($('#enlace').val())
                            .then(() => {
                                //alert('Enlace copiado al portapapeles');
                            })
                            .catch(err => {
                                console.error('Error al copiar: ', err);
                            });
                    });
            },
            error: function () {
                alert('Error al generar el enlace. Inténtalo de nuevo.');
                boton.prop('disabled', false).text('Generar enlace');
            }
        });
    });
});

document.addEventListener("DOMContentLoaded", function () {

    const tallaInputs = document.querySelectorAll('input[name="TallaSel"]');
    const colorInputs = document.querySelectorAll('input[name="ColorSel"]');
    const botonContainer = document.getElementById("boton-container");

    function obtenerArticuloIdDesdeUrl() {
        const urlParts = window.location.pathname.split('/');
        const articuloId = urlParts[urlParts.length - 1];
        return articuloId;
    }

    function comprobarStock() {
        const tallaSeleccionada = document.querySelector('input[name="TallaSel"]:checked');
        const colorSeleccionado = document.querySelector('input[name="ColorSel"]:checked');

        const botonContainer = document.getElementById('boton-container');
        const botonAvisoContainer = document.getElementById('boton-aviso-container');

        if (tallaSeleccionada && colorSeleccionado) {
            const tallaId = tallaSeleccionada.value;
            const colorId = colorSeleccionado.value;
            const articuloId = obtenerArticuloIdDesdeUrl();

            fetch(`/Articulo/ComprobarStock?tallaId=${tallaId}&colorId=${colorId}&articuloId=${articuloId}`)
                .then(response => response.json())
                .then(data => {
                    if (data.tieneStock) {
                        botonContainer.style.display = 'block';
                        botonAvisoContainer.style.display = 'none';
                    } else {
                        botonContainer.style.display = 'none';
                        botonAvisoContainer.style.display = 'block';
                    }
                })
                .catch(error => console.error("Error al comprobar el stock:", error));
        }
    }

    tallaInputs.forEach(input => input.addEventListener("change", comprobarStock));
    colorInputs.forEach(input => input.addEventListener("change", comprobarStock));
});
