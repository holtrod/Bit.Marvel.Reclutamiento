// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function AgregarComicSucursal(id) {
    data = {}
    data.id = id;
    data.idSucursal = $("#Id").val();
    $.ajax({
        url: '/Sucursales/AgregarComicsSucursal',
        type: 'POST',
        contentType: "application/json",
        data: JSON.stringify(data),
        success: function (data) {
            
        },
        error: function (data) {
            console.log('La respuesta no fue exitosa', data)
        },
        complete: function () {

        }
    });
}