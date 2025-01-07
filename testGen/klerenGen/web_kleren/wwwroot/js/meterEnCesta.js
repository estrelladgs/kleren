// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// meterEnCesta.js

var addToCartForm = document.getElementById('addToCartForm');

document.addEventListener('DOMContentLoaded', function () {
    var addToCartForm = document.getElementById('addToCartForm');

    if (addToCartForm) {
        addToCartForm.addEventListener('submit', function (e) {
            e.preventDefault();

            var formData = new FormData(this);

            fetch('/Articulo/MeterEnCesta', {
                method: 'POST',
                body: formData
            })
                .then(response => response.json())
                .then(data => {
                    var mensajeDiv = document.getElementById('mensajeRespuesta');
                    if (mensajeDiv) {
                        mensajeDiv.textContent = data.message;
                        mensajeDiv.style.display = 'block';
                        mensajeDiv.className = data.success ? 'alert alert-success' : 'alert alert-danger';
                    }
                })
                .catch(error => {
                    console.error('Error:', error);
                });
        });
    }
});



/*
document.getElementById('addToCartForm').addEventListener('submit', function (e) {
    e.preventDefault();

    var formData = new FormData(this);

    fetch('/Articulo/MeterEnCesta', {
        method: 'POST',
        body: formData
    })
        .then(response => response.json())
        .then(data => {
            var mensajeDiv = document.getElementById('mensajeRespuesta');
            mensajeDiv.textContent = data.message;
            mensajeDiv.style.display = 'block';
            mensajeDiv.className = data.success ? 'alert alert-success' : 'alert alert-danger';
        })
        .catch(error => {
            console.error('Error:', error);
        });
});*/
