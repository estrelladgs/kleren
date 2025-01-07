$(document).ready(function () {
    // Manejar clics en las opciones del sidebar
    $(".list-group-item[data-url]").click(function (e) {
        e.preventDefault(); // Previene el comportamiento por defecto del enlace

        // Remueve la clase 'active' de todos los elementos y agrega a solo el clickeado
        $(".list-group-item").removeClass("active");
        $(this).addClass("active");

        // Cargar la vista parcial correspondiente
        var url = $(this).data("url");
        console.log("URL de la vista parcial: ", url); // Depura la URL

        $("#contenidoPerfil").html('<div class="spinner-border text-primary" role="status"><span class="sr-only">Cargando...</span></div>');
        $("#contenidoPerfil").load(url, function (response, status, xhr) {
            if (status == "error") {
                console.error("Error al cargar la vista: " + xhr.status + " " + xhr.statusText);
                $("#contenidoPerfil").html('<div class="alert alert-danger">Ocurrió un error al cargar el contenido. Por favor, intenta nuevamente.</div>');
            }
        });
    });
    $(document).on('submit', '#formModificarDatos', function (e) {
        e.preventDefault(); // Previene el comportamiento predeterminado del formulario

        var $form = $(this); // Captura el formulario
        var formData = $form.serialize(); // Serializa los datos del formulario

        // Ajustar la fecha al formato correcto (yyyy-MM-dd) antes de enviar
        var fechaNacimiento = $('#FNac').val(); // Obtén el valor de la fecha
        if (fechaNacimiento) {
            var fechaParts = fechaNacimiento.split("/"); // Si es MM/dd/yyyy, lo dividimos
            if (fechaParts.length === 3) {
                var formattedDate = fechaParts[2] + "-" + fechaParts[0] + "-" + fechaParts[1];
                $('#FNac').val(formattedDate); // Actualiza el valor con el formato correcto
            }
        }

        // Muestra un indicador de carga
        $("#resultadoModificarDatos").html('<div class="spinner-border text-primary" role="status"><span class="sr-only">Guardando...</span></div>');

        // Realiza la petición AJAX
        $.ajax({
            url: $form.attr('action'), // La URL de la acción
            type: 'POST', // Tipo de solicitud (POST)
            data: $form.serialize(), // Los datos del formulario
            success: function (response) {
                console.log(response); // Verifica la respuesta en la consola
                // Si la respuesta contiene la vista parcial, la cargamos
                $("#contenidoPerfil").html(response); // Aquí renderizamos la vista parcial en el contenedor
            },
            error: function (xhr, status, error) {
                // Si ocurre un error en la solicitud, mostramos el error
                $("#resultadoModificarDatos").html('<div class="alert alert-danger">Ocurrió un error al guardar los cambios. Por favor, intenta nuevamente.</div>');
            }
        });
    });


    $(document).on('submit', '#formModificarContra', function (e) {
        e.preventDefault();

        var $form = $(this);
        var formData = $form.serialize();

        // Muestra un indicador de carga (opcional)
        $("#resultadoModificarContra").html('<div class="spinner-border text-primary" role="status"><span class="sr-only">Cambiando contraseña...</span></div>');

        // Realiza la solicitud AJAX
        $.ajax({
            url: $form.attr('action'), 
            type: 'POST', 
            data: formData, 
            success: function (response) {
                $("#contenidoPerfil").html(response); 
            },
            error: function (xhr, status, error) {
   
                $("#contenidoPerfil").html('<div class="alert alert-danger">Ocurrió un error al cambiar la contraseña. Por favor, intenta nuevamente.</div>');
            }
        });
    });

    $(document).on('submit', '#formIntroducirMedidas', function (e) {
        e.preventDefault(); 
        console.log("form enviado");
        var $form = $(this); 
        var formData = $form.serialize();

        // Muestra un indicador de carga mientras se procesa la solicitud
        $("#resultadoIntroducirMedidas").html('<div class="spinner-border text-primary" role="status"><span class="sr-only">Cambiando contraseña...</span></div>');

        $.ajax({
            url: $form.attr('action'), 
            type: 'POST',
            data: formData, 
            success: function (response) {
                console.log("success");
                console.log(response);
                $("#contenidoPerfil").html(response);
            },
            error: function (xhr, status, error) {
                // Muestra un mensaje de error
                $("#misDatosCard").find(".spinner-border").remove(); // Elimina el spinner en caso de error
                $("#misDatosCard").prepend('<div class="alert alert-danger">Ocurrió un error. Por favor, intenta nuevamente.</div>');
            }
        });
    });


    $(document).on('submit', '#formModificarMedidas', function (e) {
        e.preventDefault();
        console.log("form enviado");
        var $form = $(this);
        var formData = $form.serialize();

        // Muestra un indicador de carga mientras se procesa la solicitud
        $("#resultadoIntroducirMedidas").html('<div class="spinner-border text-primary" role="status"><span class="sr-only">Cambiando contraseña...</span></div>');

        $.ajax({
            url: $form.attr('action'),
            type: 'POST',
            data: formData,
            success: function (response) {
                console.log("success");
                console.log(response);
                $("#contenidoPerfil").html(response);
            },
            error: function (xhr, status, error) {
                // Muestra un mensaje de error
                $("#misDatosCard").find(".spinner-border").remove(); // Elimina el spinner en caso de error
                $("#misDatosCard").prepend('<div class="alert alert-danger">Ocurrió un error. Por favor, intenta nuevamente.</div>');
            }
        });
    });


    $(document).on('submit', '#formBorrarCuenta', function (e) {
        e.preventDefault(); // Previene el comportamiento predeterminado del formulario (que es hacer un submit convencional)

        var $form = $(this); // Captura el formulario
        var formData = $form.serialize(); // Serializa los datos del formulario para enviarlos en la solicitud

        // Muestra un indicador de carga (opcional)
        $("#contenidoPerfil").html('<div class="spinner-border text-primary" role="status"><span class="sr-only">Eliminando cuenta...</span></div>');

        // Realiza la solicitud AJAX
        $.ajax({
            url: $form.attr('action'), // URL a la que enviar la solicitud, que corresponde a la acción del controlador
            type: 'POST', // Tipo de solicitud (POST)
            data: formData, // Los datos serializados del formulario
            success: function (response) {
               
                window.location.href = '/Usuario/Login';
            },
            error: function (xhr, status, error) {
                // Si ocurre un error, muestra un mensaje de error
                $("#contenidoPerfil").html('<div class="alert alert-danger">Ocurrió un error al eliminar la cuenta. Por favor, intenta nuevamente.</div>');
            }
        });
    });


    // Botones dentro de vistas parciales
    $(document).on('click', '#btnModificarDatos', function (e) {
        e.preventDefault();
        var url = $(this).data("url");
        $("#contenidoPerfil").load(url);
    });

    $(document).on('click', '#btnModificarContra', function (e) {
        e.preventDefault();
        var url = $(this).data("url");
        $("#contenidoPerfil").load(url);
    });

    $(document).on('click', '#btnBorrarCuenta', function (e) {
        e.preventDefault();
        var url = $(this).data("url");
        $("#contenidoPerfil").load(url);
    });

    $(document).on('click', '#btnIntroducirMedidas', function (e) {
        e.preventDefault();
        var url = $(this).data("url");
        $("#contenidoPerfil").load(url);
    });

    $(document).on('click', '#btnModificarMedidas', function (e) {
        e.preventDefault();
        var url = $(this).data("url");
        $("#contenidoPerfil").load(url);
    });

    $(document).on('click', '#btnVerPedido', function (e) {
        e.preventDefault();
        var url = $(this).data("url");
        $("#contenidoPerfil").load(url);
    });

    $(document).on('click', '#btnVerDev', function (e) {
        e.preventDefault();
        var url = $(this).data("url");
        $("#contenidoPerfil").load(url);
    });


    $(document).on('click', '#btnTramitarDevolucion', function (e) {
        e.preventDefault();
        var url = $(this).data("url");
        $("#contenidoPerfil").load(url);
    });



    $(document).on('click', '#btnCancelar', function (e) {
        e.preventDefault();
        var url = $(this).data("url");
        $("#contenidoPerfil").load(url);
    });

    $(document).on('click', '#btnCerrar', function (e) {
        e.preventDefault();
        var url = $(this).data("url");
        $("#contenidoPerfil").load(url);
    });


   /* $(document).on('click', '[data-url]', function (e) {
        e.preventDefault();
        var url = $(this).data("url"); // Obtén la URL desde el atributo data-url
        var target = $(this).data("target"); // Obtén el contenedor objetivo desde data-target
        $(target).load(url); // Carga la vista parcial en el contenedor
    });*/

});
