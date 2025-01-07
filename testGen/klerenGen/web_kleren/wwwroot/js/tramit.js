// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

    function validarFormulario() {
    var nombre = document.getElementById('nombre').value;
    var apellidos = document.getElementById('apellidos').value;
    var correo = document.getElementById('correo').value;
    var telefono = document.getElementById('telefono').value;
    var calle = document.getElementById('calle').value;
    var numero = document.getElementById('numero').value;
    var escalera = document.getElementById('escalera').value;
    var piso = document.getElementById('piso').value;
    var puerta = document.getElementById('puerta').value;
    var codpos = document.getElementById('codpos').value;
    var ciudad = document.getElementById('ciudad').value;
    var provincia = document.getElementById('provincia').value;

    // Validación de campos de texto (requiere que no sean vacíos)
    if (isNullOrWhiteSpace(nombre) ||
    isNullOrWhiteSpace(apellidos) ||
    isNullOrWhiteSpace(correo) ||
    isNullOrWhiteSpace(calle) ||
    isNullOrWhiteSpace(puerta) ||
    isNullOrWhiteSpace(ciudad) ||
    isNullOrWhiteSpace(provincia)) {
        alert("Todos los campos son obligatorios y no deben estar vacíos.");
    return false; // Previene el envío del formulario
        }

    // Validación de campos numéricos (requiere que sean números válidos)
    if (isNaN(numero) || numero.trim() === "") {
        alert("El campo 'Número' debe ser un número válido.");
    return false;
        }

    if (isNaN(telefono) || telefono.trim() === "") {
        alert("El campo 'Telefono' debe ser un número válido.");
        return false;
    }

    if (isNaN(codpos) || codpos.trim() === "") {
        alert("El campo 'Código Postal' debe ser un número válido.");
    return false;
        }

    // Validación de campos numéricos opcionales (piso y escalera)
    if (piso.trim() !== "" && isNaN(piso)) {
        alert("El campo 'Piso' debe ser un número válido.");
    return false;
        }

    if (escalera.trim() !== "" && isNaN(escalera)) {
        alert("El campo 'Escalera' debe ser un número válido.");
    return false;
        }

    return true; // Permite el envío del formulario si todo es válido
    }

    // Función para verificar si el valor está vacío o tiene solo espacios en blanco
    function isNullOrWhiteSpace(str) {
        return !str || str.trim().length === 0;
    }

// Función para mostrar u ocultar los campos de pago dependiendo del método elegido
function mostrarCamposPago() {
    // Intentamos obtener el input de método de pago seleccionado
    var metodoPagoElement = document.querySelector('input[name="metodoPago"]:checked');

    // Si no hay un input seleccionado, terminamos la función
    if (!metodoPagoElement) {
        return; // No hace nada si no hay un input de metodoPago seleccionado
    }

    // Si el input existe, obtenemos su valor
    var metodoPago = metodoPagoElement.value;

    if (metodoPago === "tarjeta") {
        document.getElementById("camposTarjeta").style.display = "block"; // Mostrar campos de tarjeta
        // Asegurar que los campos de tarjeta estén habilitados
        document.getElementById('numeroTarjeta').disabled = false;
        document.getElementById('fechaExpiracion').disabled = false;
        document.getElementById('cvv').disabled = false;
    } else {
        document.getElementById("camposTarjeta").style.display = "none"; // Ocultar campos de tarjeta
        // Deshabilitar los campos de tarjeta si no se selecciona tarjeta
        document.getElementById('numeroTarjeta').disabled = true;
        document.getElementById('fechaExpiracion').disabled = true;
        document.getElementById('cvv').disabled = true;
    }
}

// Escuchar cambios en los métodos de pago (radio buttons)
document.querySelectorAll('input[name="metodoPago"]').forEach(function (input) {
    input.addEventListener('change', mostrarCamposPago);
});

// Llamada inicial para asegurarnos de que se muestren los campos correctos al cargar
document.addEventListener('DOMContentLoaded', function () {
    mostrarCamposPago();
});
