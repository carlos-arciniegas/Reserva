﻿using FOReserva.Models.Restaurantes;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace FOReserva.Servicio
{
    /*Clase para el manejo Reservas de restaurantes en DB*/
    public class ManejadorSQLReserva : manejadorSQL
    {
        /*Constructor del ManejadorSQL para Reservas*/
        public ManejadorSQLReserva() : base() { }

        /*Buscar Restaurantes por Nombre*/
        public List<CRestaurantModel> buscarRestName(string restName)
        {
            string query = "Select rst_id, rst_nombre, rst_direccion From Restaurante where rst_nombre LIKE '%"+restName+"%'";
            SqlDataReader read = Executer(query);
            List<CRestaurantModel> lista_rest = new List<CRestaurantModel>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    int id = read.GetInt32(0);
                    string nombre = read.GetString(1);
                    string dir = read.GetString(2);
                    CRestaurantModel resta = new CRestaurantModel();
                    resta.Name = nombre;
                    resta.Addres = dir;
                    lista_rest.Add(resta);
                }
            }
            CloseConnection();
            return lista_rest;
        }

        /* Buscar restaurante por ciudad */
        public List<CRestaurantModel> buscarRestCity(string cityName)
        {
            string query = "SELECT res.rst_id ,res.rst_nombre ,res.rst_direccion FROM Restaurante as res, Lugar as lug where res.fk_lugar = lug.lug_id and lug.lug_tipo_lugar = 'ciudad' and lug.lug_nombre LIKE '%" + cityName + "%'"; ;
            SqlDataReader read = Executer(query);
            List<CRestaurantModel> lista_rest = new List<CRestaurantModel>();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    int id = read.GetInt32(0);
                    string nombre = read.GetString(1);
                    string dir = read.GetString(2);
                    CRestaurantModel resta = new CRestaurantModel();
                    resta.Name = nombre;
                    resta.Addres = dir;
                    lista_rest.Add(resta);
                }
            }
            CloseConnection();
            return lista_rest;
        }

        public void CrearReserva(CReservation_Restaurant reserva)
        {
            string query = @"INSERT INTO Reserva ( Tipo, Reserva_Nombre, Fecha, Hora,
            Cantidad_Personas, FK_RESTAURANTE, FK_USUARIO) 
            VALUES('"+reserva.GetType()+@"','"+reserva.Name+@"',
            convert(date, '2016-12-20'), '"+reserva.Time+"',"+reserva.Count+","+
            @"1, 4)";
            CloseConnection();
        }
    }
}