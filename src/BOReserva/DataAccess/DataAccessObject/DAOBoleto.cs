﻿using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using BOReserva.Models.gestion_ruta_comercial;


namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOBoleto : DAO, IDAOBoleto
    {

        public DAOBoleto() { }

        int IDAO.Agregar(Entidad e)
        {
            Boleto boleto = (Boleto)e;
            SqlConnection conexion = Connection.getInstance(_connexionString);
            try
            {
                conexion.Open();
                String sql = "INSERT INTO Boleto (bol_escala,bol_ida_vuelta,bol_costo,bol_fk_lugar_origen,bol_fk_lugar_destino,bol_fk_pasajero,bol_fecha,bol_tipo_boleto) VALUES(" + boleto._escala + "," + boleto._ida_vuelta + "," + boleto._costo + "," + boleto._idOrigen + "," + boleto._idDestino + "," + boleto._idPasajero + ",'" + boleto._fechaBoleto.ToString("yyyy/MM/dd") + "','" + boleto._tipoBoleto + "')";
                Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Ocurrio un SqlException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 2;
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Ocurrio una NullReferenceException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 3;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Ocurrio una ArgumentNullException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 4;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio una Exception");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return 5;
            }
        }

        int IDAO.Eliminar(int id) {
            try
            {
                SqlConnection conexion = Connection.getInstance(_connexionString);
                conexion.Open();
                String sql = "DELETE FROM Boleto WHERE bol_id = " + id + "";
                System.Diagnostics.Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conexion.Close();
                return 1;
            }
            catch (SqlException ex)
            {
                return 0;
            }
        }

        Entidad IDAO.Consultar(int id)
        {
           
            try
            {
                SqlConnection conexion = Connection.getInstance(_connexionString);
                Boleto boleto = new Boleto();
                conexion.Open();
                String sql = "SELECT * FROM Boleto WHERE bol_id = " + id + "";

                // FALTA OBTENER EL/LOS VUELOS DE ESE BOLETO
                SqlCommand cmd = new SqlCommand(sql, conexion);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        var fecha = reader["bol_fecha"];
                        List<BoletoVuelo> lista = M05ListarVuelosBoleto(id);
                        Pasajero pasajero = MBuscarDatosPasajero(reader.GetInt32(reader.GetOrdinal("bol_fk_pasajero")));
                        DateTime fechaboleto = Convert.ToDateTime(fecha).Date;

                        boleto = new Boleto(Int32.Parse(reader["bol_id"].ToString()), Int32.Parse(reader["bol_ida_vuelta"].ToString()),
                                               Int32.Parse(reader["bol_escala"].ToString()), double.Parse(reader["bol_costo"].ToString()),
                                               MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_origen"].ToString())),
                                               MBuscarnombreciudad(Int32.Parse(reader["bol_fk_lugar_destino"].ToString())), fechaboleto,
                                               reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_origen")),
                                               reader.GetInt32(reader.GetOrdinal("bol_fk_lugar_destino")),
                                               reader["bol_tipo_boleto"].ToString());
                        boleto._vuelos = lista;
                        boleto._pasajero = pasajero;
                    }
                    cmd.Dispose();
                    conexion.Close();
                    return boleto;
                }
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        public List<BoletoVuelo> M05ListarVuelosBoleto(int id_boleto)
        {
            List<BoletoVuelo> listavuelos = new List<BoletoVuelo>();
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT bol_fk_vuelo FROM Boleto_Vuelo WHERE bol_fk_boleto =" + id_boleto + "";
                System.Diagnostics.Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        BoletoVuelo datosVuelo = MBuscarDatosVuelo(Int32.Parse(reader["bol_fk_vuelo"].ToString()));
                        listavuelos.Add(datosVuelo);
                    }
                }
                cmd.Dispose();
                con.Close();
                int inte = listavuelos.Count;
                return listavuelos;
            }
            catch (SqlException ex)
            {
                return null;
            }
        }

        public RutaBoleto MBuscarDatosRuta(int id)
        {
            RutaBoleto ruta = null;
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT rut_FK_lugar_origen, rut_FK_lugar_destino FROM Ruta WHERE rut_id =" + id + "";
                System.Diagnostics.Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ruta = new RutaBoleto(id, Int32.Parse(reader["rut_FK_lugar_origen"].ToString()), Int32.Parse(reader["rut_FK_lugar_destino"].ToString()),
                             MBuscarnombreciudad(Int32.Parse(reader["rut_FK_lugar_origen"].ToString())),
                             MBuscarnombreciudad(Int32.Parse(reader["rut_FK_lugar_destino"].ToString())));


                    }
                }
                cmd.Dispose();
                con.Close();
                return ruta;
            }
            catch (SqlException ex)
            {
                return ruta;
            }
        }
        public BoletoVuelo MBuscarDatosVuelo(int id)
        {
            BoletoVuelo vuelo = null;
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT vue_fecha_despegue, vue_fecha_aterrizaje, vue_fk_ruta FROM Vuelo WHERE vue_id =" + id + "";
                System.Diagnostics.Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        RutaBoleto rut = MBuscarDatosRuta(Int32.Parse(reader["vue_fk_ruta"].ToString()));

                        vuelo = new BoletoVuelo(id, reader.GetDateTime(reader.GetOrdinal("vue_fecha_despegue")),
                                           reader.GetDateTime(reader.GetOrdinal("vue_fecha_aterrizaje")),
                                           Int32.Parse(reader["vue_fk_ruta"].ToString()),
                                           rut._origen, rut._destino, rut._nomOrigen, rut._nomDestino);
                    }
                }
                cmd.Dispose();
                con.Close();
                return vuelo;
            }
            catch (SqlException ex)
            {
                return vuelo;
            }
        }


        public Pasajero MBuscarDatosPasajero(int id)
        {
            Pasajero pas = null;
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT * FROM Pasajero WHERE pas_id = '" + id + "'";
                System.Diagnostics.Debug.WriteLine(sql);
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var fecha = reader["pas_fecha_nacimiento"];
                        DateTime fechanac = Convert.ToDateTime(fecha).Date;
                        pas = new Pasajero(Int32.Parse(reader["pas_id"].ToString()), reader["pas_primer_nombre"].ToString(),
                                             reader["pas_segundo_nombre"].ToString(), reader["pas_primer_apellido"].ToString(),
                                             reader["pas_segundo_apellido"].ToString(), reader["pas_sexo"].ToString(),
                                             fechanac, reader["pas_correo"].ToString());
                    }
                }
                cmd.Dispose();
                con.Close();
                return pas;
            }
            catch (SqlException ex)
            {
                return pas;
            }
        }

        public String MBuscarnombreciudad(int id)
        {
            String _ciudad = "No aplica";
            try
            {
                SqlConnection con = new SqlConnection(_connexionString);
                con.Open();
                String sql = "SELECT C.lug_nombre FROM LUGAR C WHERE C.lug_id = '" + id + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _ciudad = reader[0].ToString();
                    }
                }
                cmd.Dispose();
                con.Close();
                return _ciudad;
            }
            catch (SqlException ex)
            {
                return _ciudad;
            }
        }









    }
}