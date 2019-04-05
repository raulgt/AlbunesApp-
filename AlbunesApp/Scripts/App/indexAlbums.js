$(document).ready(function () {

    var albumsSelect = $('#albumsSelect');
    var visualizarButton = $('#visualizarButton');
       

    visualizarButton.click(() => {

        var id = albumsSelect.val();       

        var oTable = $('#myDatatable').DataTable({        
            "bDestroy": true,  
            "bLengthChange": true, 
            responsive: true,    
            "lengthMenu": [5, 10, 25, 50],
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
                { "data": "title", "width": "50%" },
                {
                    "data": "thumbnailUrl", "autoWidth": true, "render": function (data) {
                        return '<img class="img-thumbnail" src="' + data + '">';
                    }
                },
                {
                    "data": "albumId", "autoWidth": true, "render": function (data) {  
                         return '<a class="btn btn-primary"><strong>Ver Comentarios</strong></a>';                        
                    }
                }
            ]        

        });

       
        // Se captura el evento on click sobre el boton para visualizar los comentarios
        $('#myDatatable tbody').on('click', 'a', function () {            
            var data = $('#myDatatable').DataTable().row($(this).parents('tr')).data();    
            if (data.albumId) {
                var url = '/Home/CommentsList';

                $.get(url, { id: data.albumId })
                    .done(function (res) {                      
                        if (res.data !== null) {
           
                            var number_of_rows = res.data.length;
                            var number_of_cols = 3;  

                            // Se crea de forma dinamica la tabla de comentarios   
                            var tableTitle = '<h3>Comentarios del Album</h3>';
                            var table_body = tableTitle + '<table class="table own-table"> <thead> <tr> <th scope="col">Nombre</th> <th scope="col">Email</th> <th scope="col">Descripción</th> </tr > </thead > <tbody>';

                            for (var i = 0; i < number_of_rows; i++) {
                                table_body += '<tr>';

                                for (var j = 0; j < number_of_cols; j++) {

                                    if (j === 0) {
                                        table_body += '<td>';
                                        table_body += res.data[i]["name"];
                                        table_body += '</td>';
                                    } else if (j === 1) {
                                        table_body += '<td>';
                                        table_body += res.data[i]["email"];
                                        table_body += '</td>';
                                    } else {
                                        table_body += '<td>';
                                        table_body += res.data[i]["body"];
                                        table_body += '</td>';
                                    }                                 
                                }
                                table_body += '</tr>';
                            }
                            table_body += ' </tbody></table>';
                            $('#tableDiv').html(table_body);                       
                             
                            toastr.success("Puede chequear los comentarios..!!", 'Exito: ', { positionClass: 'toast-bottom-right' });
                            $("html, body").animate({ scrollTop: $(document).height() }, 2000);
                        } else {
                            toastr.error("Ocurrio  un error al consultarl los comentarios", 'Error', { positionClass: 'toast-bottom-right' });
                        }
                    })
                    .fail(function (res) {                 
                        alert("Error: ocurrio un error con el servicio" + res.status + ": " + res.statusText);
                     
                    }); 
              
            }            
        });

        // Se limpia la tabla de comentarios
        albumsSelect.change(() => {          
            $('#tableDiv').html(" ");
        });

        

    });  


  


});