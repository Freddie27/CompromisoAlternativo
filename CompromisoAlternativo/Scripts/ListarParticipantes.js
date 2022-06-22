
    var tabladata;


    jQuery.ajax({
        url: '@Url.Action("ListarParticipantes", "Home")',
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        succes: function (data) {
            console.log(data)
    }

        })

    tabladata = $("#tabla").DataTable({
        responsive: true,
        ordering: false,
    "ajax": {
        url: '@Url.Action("ListarParticipantes", "Home")',
        type: "GET",
        dataType: "json"
        },
    "columns": [
        {"data": "PART_RUT" },
        {"data": "PART_NOMBRE" },
        {"data": "PART_FONO" },
        {"data": "PART_EMAIL" },
        { "data": "PART_INSTITUCION" }

        ]

    });


function abrirModal(json) {

    if (json !=)

}