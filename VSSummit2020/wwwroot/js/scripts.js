/*!
    * Start Bootstrap - SB Admin v6.0.1 (https://startbootstrap.com/templates/sb-admin)
    * Copyright 2013-2020 Start Bootstrap
    * Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-sb-admin/blob/master/LICENSE)
    */
(function ($) {
    "use strict";

    // Add active state to sidbar nav links
    var path = window.location.href; // because the 'href' property of the DOM element is the absolute path
    $("#layoutSidenav_nav .sb-sidenav a.nav-link").each(function () {
        if (this.href === path) {
            $(this).addClass("active");
        }
    });

    // Toggle the side navigation
    $("#sidebarToggle").on("click", function (e) {
        e.preventDefault();
        $("body").toggleClass("sb-sidenav-toggled");
    });
})(jQuery);

$(document).ready(function () {
    $('#dataTable').DataTable({
        "language": {
            "lengthMenu": "Mostrar _MENU_ linhas por p&aacutegina",
            "zeroRecords": "Nada para exibir",
            "info": "P&aacutegina _PAGE_ de _PAGES_",
            "infoEmpty": "Nada para exibir",
            "infoFiltered": "(filtrado de _MAX_ linhas)",
            "search": "Procurar:",
            "paginate": {
                "first": "Primeira",
                "last": "&Uacuteltima",
                "next": "Pr&oacutexima",
                "previous": "Anterior"
            },
            "aria": {
                "sortAscending": ": ative para filtrar a coluna de forma ascendente",
                "sortDescending": ": ative para filtrar a coluna de forma descendente"
            }
        }
    });
});
