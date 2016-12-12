﻿jQuery(document).ready(function () {

    $("#gestionAviones").click(function (e) {
        e.preventDefault();
        var url = '/gestion_aviones/M02_GestionAviones';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty()
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#m02_agregaravion").click(function (e) {
        e.preventDefault();
        var url = '/gestion_aviones/M02_AgregarAvion';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });


    $("#m04_crearvuelo").click(function (e) {
        e.preventDefault();
        var url = '/gestion_vuelo/M04_GestionVuelo_Crear';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });
    $("#m04_visualizarvuelo").click(function (e) {
        e.preventDefault();
        var url = '/gestion_vuelo/M04_GestionVuelo_Visualizar';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });

        //e.preventDefault();
        //var url = '/gestion_vuelo/M04_VisualizarVuelo';
        //var method = 'GET';
        //var data = '';
        //$.ajax(
        //    {
        //        url: url,
        //        type: method,
        //        data: data,
        //        success: function (data, textStatus, jqXHR) {
        //            alert(data);

        //            $("#contenido").empty();
        //            $("#contenido").append(data);
        //        },
        //        error: function (jqXHR, errorThrown) {
        //            alert(jqXHR.data);
        //            alert(errorThrown);
        //        }
        //    });

    });

    
    $("#m08AgregarAutomovil").click(function (e) {
        e.preventDefault();
        var url = '/gestion_automoviles/M08_AgregarAutomovil';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });

    });



    $("#m08VisualizarAutomoviles").click(function (e) {
        e.preventDefault();
        var url = '/gestion_automoviles/M08_VisualizarAutomoviles';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });

    });

    //INICIO M06_Gestion_Comida
    $("#gestionComida").click(function (e) {
        //M06_AgregarComida
        e.preventDefault();
        var url = '/gestion_comida_vuelo/M06_AgregarComida';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });
    $("#editarComida").click(function (e) {
        //M06_EditarComida
        e.preventDefault();
        var url = '/gestion_comida_vuelo/M06_EditarComida';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });
    $("#gestionComidaVuelo").click(function (e) {
        //M06_AgregarPorVuelo
        e.preventDefault();
        var url = '/gestion_comida_vuelo/M06_AgregarPorVuelo';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                }
            });
    });
    //FIN M06_Gestion_Comida



    $("#crearhotel").click(function (e) {
        e.preventDefault();
        var url = '/gestion_hoteles/M09_GestionHoteles_Crear';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });
    $("#modificarhotel").click(function (e) {
        e.preventDefault();
        var url = '/gestion_hoteles/M09_GestionHoteles_ModificarHotel';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {
                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });   


    $("#m05_crearboleto").click(function (e) {
        e.preventDefault();
        var url = '/gestion_boletos/M05_CrearBoleto';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });
});