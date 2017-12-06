$(function () {
    $('#example1').DataTable({
        language: {
            search: "Buscar :",
            lengthMenu : "Mostrar _MENU_ registros por pagina",
            emptyTable: "No hay datos",
            infoEmpty: "Mostrando 0 de 0 datos",
            info: "Mostrando _PAGE_ de _PAGES_",
            paginate: {
                first: "Primero",
                previous: "Anterior",
                next: "Siguiente",
                last: "Ultimo"
            }
        }
    });
    $('#example2').DataTable({
        "paging": true,
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false
    });
});