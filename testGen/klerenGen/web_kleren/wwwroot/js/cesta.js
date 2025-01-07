// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*
$(document).on("click", ".btn-incrementar", function (e) {
    console.log('Botón incrementar clickeado');
    const idlinea = $(this).data('id');
    console.log('ID de línea (incrementar):', idlinea);

    $.ajax({
        url: '/LinPed/IncrementarCantidad',
        type: 'POST',
        data: { lineaId: idlinea },
        success: function (data) {
            console.log('Datos recibidos (incrementar):', data);
            console.log('Nueva cantidad:', data.nuevaCantidad);
            $('.cantidad[data-id="' + idlinea + '"]').text(data.nuevaCantidad);
        },
        error: function (xhr, status, error) {
            console.log('Error status:', status);
            console.log('Error completo:', error);
            console.log('Respuesta del servidor:', xhr.responseJSON);
            console.error('Error en la solicitud AJAX:', error);
            if (xhr.responseJSON && xhr.responseJSON.error) {
                alert(xhr.responseJSON.error);
            }
        }
    });
});

$(document).on("click", ".btn-decrementar", function (e) {
    console.log('Botón decrementar clickeado');
    const idlinea = $(this).data('id');
    console.log('ID de línea (decrementar):', idlinea);

    $.ajax({
        url: '/LinPed/DecrementarCantidad',
        type: 'POST',
        data: { lineaId: idlinea },
        success: function (data) {
            console.log('Datos recibidos (decrementar):', data);
            console.log('Nueva cantidad:', data.nuevaCantidad);
            $('.cantidad[data-id="' + idlinea + '"]').text(data.nuevaCantidad);
        },
        error: function (xhr, status, error) {
            console.log('Error status:', status);
            console.log('Error completo:', error);
            console.log('Respuesta del servidor:', xhr.responseJSON);
            console.error('Error en la solicitud AJAX:', error);
            if (xhr.responseJSON && xhr.responseJSON.error) {
                alert(xhr.responseJSON.error);
            }
        }
    });
});*/

function abrirSidebar(lineaId) {
    console.log('abrirSidebar llamado con lineaId:', lineaId);
    $.get(urlObtenerVistaEditarLinPed, { lineaId: lineaId }, function (data) {
        console.log('Respuesta recibida:', data);
        $('#sidebarContent').html(data);
        document.getElementById("editarSidebar").style.width = "250px";
    }).fail(function (jqXHR, textStatus, errorThrown) {
        console.error('Error en la petición AJAX:', textStatus, errorThrown);
    });
}

$(document).ready(function () {
    $(document).on('click', '.btn-editar', function () {
        var lineaId = $(this).data('id');
        abrirSidebar(lineaId);
    });

    $(document).on('submit', '#editarForm', function (e) { //AQUI!
        e.preventDefault();
        var form = $(this);
        $.ajax({
            url: form.attr('action'),
            type: 'POST',
            data: form.serialize(),
            success: function (response) {
                if (response.success) {
                    actualizarCesta();
                    cerrarSidebar();
                    //alert(response.message);
                    // Aquí puedes agregar código para actualizar la tabla si es necesario
                } else {
                    alert(response.error || 'Ocurrió un error al actualizar');
                }
            },
            error: function () {
                alert('Error en la comunicación con el servidor');
            }
        });
    });
});
function cerrarSidebar() {
    document.getElementById("editarSidebar").style.width = "0";
    $('#sidebarContent').html('');
}
function actualizarCesta() {
    $.ajax({
        url: '/LinPed/Cesta',
        type: 'GET',
        dataType: 'json',
        success: function (data) {
            console.log('Datos recibidos:', data);
            if (data.lineas && data.lineas.length > 0) {
                var $contenedorLineas = $('.container .col-md-8');
                $contenedorLineas.empty();

                data.lineas.forEach(function (item) {
                    var $lineaHtml = crearLineaHtml(item);
                    $contenedorLineas.append($lineaHtml);
                });

                // Actualizar el resumen del pedido
                $('.container .col-md-3 strong:first').text(data.totalArticulos);
                $('.container .col-md-3 strong:last').text(data.precioTotal.toFixed(2) + ' €');
            } else {
                $('.container .row').html('<p>Parece que no tienes nada en la cesta ¿Por qué no añades algo?</p>');
            }

            // Actualizar el badge con el total de artículos
            $('h1 .badge').text(data.totalArticulos + ' artículos');
        },
        error: function (xhr, status, error) {
            console.error('Error al actualizar la cesta:', error);
        }
    });
}

function crearLineaHtml(item) {
    return `
    <div class="card mb-3 shadow-sm" style="font-size: 1.1em;">
        <div class="row g-0 align-items-center">
            <div class="col-md-3">
                <img src="https://static.bershka.net/assets/public/9c17/4244/9ae9411b9902/d06cd425f699/05603360712-a3f/05603360712-a3f.jpg?ts=1725545296048&w=800"
                     class="img-fluid rounded-start" alt="Imagen de ${item.nombreArt}"
                     style="width: 100%; height: auto; object-fit: contain;">
            </div>
            <div class="col-md-9">
                <div class="card-body">
                    <div class="d-flex justify-content-between align-items-start">
                        <h5 class="card-title">${item.nombreArt}</h5>
                        <p class="card-text font-weight-bold">${item.precio.toFixed(2)} €</p>
                    </div>
                    <p class="card-text mb-2">
                        <span class="mr-3"><strong>Talla:</strong> ${item.tallaS }</span>
                        <span><strong>Color:</strong> ${item.colorS}</span>

                    </p>
                    ${item.prom ?
            `<p class="card-text">
                            <span class="text-decoration-line-through mr-2">${item.precioArt.toFixed(2)} €</span>
                            <span class="text-danger font-weight-bold">${item.precioOf.toFixed(2)} €</span>
                        </p>` :
            `<p class="card-text">${item.precioArt.toFixed(2)} €</p>`
        }
                    <div class="d-flex justify-content-between align-items-center mt-2">
                        <div>
                            <button class="btn btn-sm btn-outline-secondary btn-decrementar" data-id="${item.lineaId}">-</button>
                            <span class="mx-2 cantidad" data-id="${item.lineaId}">${item.cantidad}</span>
                            <button class="btn btn-sm btn-outline-secondary btn-incrementar" data-id="${item.lineaId}">+</button>
                        </div>
                        <button class="btn btn-sm btn-outline-primary btn-editar" data-id="${item.lineaId}">Editar</button>
                        <form asp-controller="LinPed" asp-action="EliminarDeCesta" method="post" class="d-inline">
                            <input type="hidden" name="lineaId" value="${item.lineaId}" />
                            <button type="submit" class="btn btn-sm btn-danger">Eliminar</button>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    `;
}


function crearResumenHtml(totalArticulos, precioTotal) {
    return `
    <div class="card shadow">
        <div class="card-body">
            <h5 class="card-title mb-4">Resumen del pedido</h5>
            <p class="card-text d-flex justify-content-between">
                <span>Total artículos:</span>
                <strong>${totalArticulos}</strong>
            </p>
            <p class="card-text d-flex justify-content-between">
                <span>Precio total:</span>
                <strong>${precioTotal.toFixed(2)} €</strong>
            </p>
            <a href="/Pedido/Tramitar" class="btn btn-primary btn-lg btn-block mt-4">Tramitar pedido</a>
        </div>
    </div>
    `;
}



$(document).on("click", ".btn-incrementar", function (e) {
    console.log('Botón incrementar clickeado');
    const idlinea = $(this).data('id');
    console.log('ID de línea (incrementar):', idlinea);

    $.ajax({
        url: '/LinPed/IncrementarCantidad',
        type: 'POST',
        data: { lineaId: idlinea },
        success: function (data) {
            console.log('Datos recibidos (incrementar):', data);
            console.log('Nueva cantidad:', data.nuevaCantidad);
            $('.cantidad[data-id="' + idlinea + '"]').text(data.nuevaCantidad);
            actualizarCesta();
        },
        error: function (xhr, status, error) {
            console.log('Error status:', status);
            console.log('Error completo:', error);
            console.log('Respuesta del servidor:', xhr.responseJSON);
            console.error('Error en la solicitud AJAX:', error);
            if (xhr.responseJSON && xhr.responseJSON.error) {
                alert(xhr.responseJSON.error);
            }
        }
    });
});

$(document).on("click", ".btn-decrementar", function (e) {
    console.log('Botón decrementar clickeado');
    const idlinea = $(this).data('id');
    console.log('ID de línea (decrementar):', idlinea);

    $.ajax({
        url: '/LinPed/DecrementarCantidad',
        type: 'POST',
        data: { lineaId: idlinea },
        success: function (data) {
            console.log('Datos recibidos (decrementar):', data);
            console.log('Nueva cantidad:', data.nuevaCantidad);
            $('.cantidad[data-id="' + idlinea + '"]').text(data.nuevaCantidad);
            actualizarCesta();
        },
        error: function (xhr, status, error) {
            console.log('Error status:', status);
            console.log('Error completo:', error);
            console.log('Respuesta del servidor:', xhr.responseJSON);
            console.error('Error en la solicitud AJAX:', error);
            if (xhr.responseJSON && xhr.responseJSON.error) {
                alert(xhr.responseJSON.error);
            }
        }
    });
});
// También actualizar después de editar
