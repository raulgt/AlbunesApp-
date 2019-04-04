$(document).ready(function () {

    var albumsSelect = $('#albumsSelect');
    var visualizarButton = $('#visualizarButton');




    visualizarButton.click(() => {

        var id = albumsSelect.val();

        var oTable = $('#myDatatable').DataTable({
            "bLengthChange": true,
            "bDestroy": true,
            responsive: true,
            "order": [[0, "asc"]],
            language: {
                processing: "Procesando",
                search: "Buscar:",
                lengthMenu: "Ver _MENU_ Filas",
                info: "_START_ - _END_ de _TOTAL_ elementos",
                infoEmpty: "0 - 0 de 0 elementos",
                infoFiltered: "(Filtro de _MAX_ entradas en total)",
                infoPostFix: "",
                loadingRecords: "Cargando datos.",
                zeroRecords: "No se encontraron datos",
                emptyTable: "No hay datos disponibles",
                paginate: {
                    first: "Primero",
                    previous: "Anterior",
                    next: "Siguiente",
                    last: "Ultimo"
                },
                aria: {
                    sortAscending: ": activer pour trier la colonne par ordre croissant",
                    sortDescending: ": activer pour trier la colonne par ordre décroissant"
                }
            },

            "ajax": {
                "url": '/Home/GetAlbumsDetail?id=' + id,
                "type": "get",
                "datatype": "json",
                "cache": "true"                
            },
            "columns": [
                { "data": "title", "autoWidth": true },
                { "data": "thumbnailUrl", "autoWidth": true },
                {
                    "data": "albumId", "autoWidth": true, "render": function (data) {
                       // var url = finder.getAppFile('inmuebles/edit/' + data);
                        var url = '/Home/Comments/' + data;
               
                        return '<a class="btn btn-table" href= ' + url + '>Ver Comentarios</a>';
                           }
                }
            ]
        });

    });
});