﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BOReserva.Models.gestion_vuelo;

namespace BOReserva.Servicio.Servicio_Vuelos
{
    public class manejadorSQL_Vuelos
    {
        //Inicializo el string de conexion en el constructor
        public manejadorSQL_Vuelos()
        {
            stringDeConexion = "Data Source=sql5032.smarterasp.net;Initial Catalog=DB_A1380A_reserva;User Id=DB_A1380A_reserva_admin;Password=ucabds1617a;";
        }
        //Atributo que ejecutara la conexion a la bd
        private SqlConnection conexion = null;
        //string que contendra la conexion a la bd
        private string stringDeConexion = null;



        public Boolean insertarVuelo(string Codigo, string Origen, string Destino, string Despegue, string Status, string Aterrizaje, string Matricula)
        {
            try
            {
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                SqlCommand cmd = new SqlCommand("M04_CrearVuelo", conexion);
                //le indico que voy a executar un Stored Procedure en la Base de Datos
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //le paso los parametros que espera el SP
                cmd.Parameters.Add("@CodVuelo", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@CodVuelo"].Value = Codigo;
                cmd.Parameters.Add("@CiudadOrigen", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@CiudadOrigen"].Value = Origen;
                cmd.Parameters.Add("@CiudadDestino", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@CiudadDestino"].Value = Destino;
                cmd.Parameters.Add("@FechaDespegue", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@FechaDespegue"].Value = Despegue;
                cmd.Parameters.Add("@Status", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@Status"].Value = Status;
                cmd.Parameters.Add("@FechaAterrizaje", System.Data.SqlDbType.DateTime);
                cmd.Parameters["@FechaAterrizaje"].Value = Aterrizaje;
                cmd.Parameters.Add("@MatriculaAvion", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@MatriculaAvion"].Value = Matricula;


                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader dr = cmd.ExecuteReader();
                //no leo el ExecuteReader por que no espero nada de la BD, por eso lo cierro
                dr.Close();
                conexion.Close();
                return true;
            }
            catch (SqlException e)
            {
                return false;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        // fin insertarVuelo



        public int idRutaVuelo( string Origen, string Destino)
        {
            try
            {
                int test = 0;
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                //le indico que voy a executar un Stored Procedure en la Base de Datos
                SqlCommand cmd = new SqlCommand("M04_BuscaIdRuta", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //le paso los parametros que espera el SP 
                cmd.Parameters.Add("@CiudadOrigen", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@CiudadOrigen"].Value = Origen;
                cmd.Parameters.Add("@CiudadDestino", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@CiudadDestino"].Value = Destino; 
                
                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    //leo y convierto el int esperado del ID de la tabla de ruta
                    test = (int)dr.GetSqlInt32(0);
                }
                //cierro el lector
                dr.Close();
                conexion.Close();
                return test;
            }
            catch (SqlException e)
            {
                throw(e);
                
            }
            catch (Exception e)
            {
                throw (e); 
                
            }
        }
        //fin idRutaVuelo

        public List<CCrear_Vuelo> consultarDestinos(String Origen)
        {
            try
            {
                var list = new List<CCrear_Vuelo>();
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                //le indico que voy a executar un Stored Procedure en la Base de Datos
                SqlCommand cmd = new SqlCommand("M04_BuscarDestinos", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //le paso los parametros que espera el SP
                cmd.Parameters.Add("@CiudadOrigen", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@CiudadOrigen"].Value = Origen;


                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var destinos = new CCrear_Vuelo
                    {
                        //leo los diferentes valores que cargaran la lista ya que espero varios resultados
                        _ciudadDestino = dr.GetSqlString(0).ToString(),
                    };
                    list.Add(destinos);
                }
                //cierro el lector
                dr.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return list;
            }
            catch (SqlException e)
            {
                throw e;
                //return null;
            }
            catch (Exception e)
            {
                throw e;
                //return null;
            }
        }
        // fin consultarDestinos



        public List<CCrear_Vuelo> buscarAviones(String Origen, String Destino)
        {
            try
            {
                var list = new List<CCrear_Vuelo>();
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                //le indico que voy a executar un Stored Procedure en la Base de Datos
                SqlCommand cmd = new SqlCommand("M04_ValidarAvionParaRuta", conexion);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                //le paso los parametros que espera el SP
                cmd.Parameters.Add("@CiudadOrigen", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@CiudadOrigen"].Value = Origen;
                cmd.Parameters.Add("@CiudadDestino", System.Data.SqlDbType.VarChar, 100);
                cmd.Parameters["@CiudadDestino"].Value = Destino; 
             


                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    var matriculas = new CCrear_Vuelo
                    {
                        //leo los diferentes valores que cargaran la lista ya que espero varios resultados
                        _matriculaAvion = dr.GetSqlString(0).ToString(),
                    };
                    list.Add(matriculas);
                }
                //cierro el lector
                dr.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return list;
            }
            catch (SqlException e)
            {
                throw e;
                //return null;
            }
            catch (Exception e)
            {
                throw e;
                //return null;
            }
        }
        //fin buscarAviones


         public List<CCrear_Vuelo> cargarOrigenes()
        {
            try
            {
                var list = new List<CCrear_Vuelo>();
                //Inicializo la conexion con el string de conexion
                conexion = new SqlConnection(stringDeConexion);
                //INTENTO abrir la conexion
                conexion.Open();
                //le indico que voy a executar un query en la BD
                SqlCommand query = conexion.CreateCommand();
                //ingreso la orden del query
                query.CommandText = "SELECT l.lug_nombre FROM Lugar l WHERE l.lug_tipo_lugar = 'ciudad' ORDER BY l.lug_nombre";
                //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                SqlDataReader dr = query.ExecuteReader();

                //creo un lector sql para la respuesta de la ejecucion del comando anterior               

                while (dr.Read())
                {
                    var destinos = new CCrear_Vuelo
                    {
                        //leo los diferentes valores que cargaran la lista ya que espero varios resultados
                        _ciudadOrigen = dr.GetSqlString(0).ToString(),
                    };
                    list.Add(destinos);
                }
                //cierro el lector
                dr.Close();
                //IMPORTANTE SIEMPRE CERRAR LA CONEXION O DARA ERROR LA PROXIMA VEZ QUE SE INTENTE UNA CONSULTA
                conexion.Close();
                return list;
            }
            catch (SqlException e)
            {
                throw e;
                //return null;
            }
            catch (Exception e)
            {
                throw e;
                //return null;
            }
        }
        //fin cargarOrigenes


         public string modeloAvion(string matriculaAvion)
         {
             try
             {
                 string matri = "";
                 //Inicializo la conexion con el string de conexion
                 conexion = new SqlConnection(stringDeConexion);
                 //INTENTO abrir la conexion
                 conexion.Open();
                 //indico que enviare un comando que ejecutara un Stored Procedure en la BD
                 SqlCommand cmd = new SqlCommand("M04_DetalleAvion_Modelo", conexion);
                 cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 //le paso el parametro que espera el SP
                 cmd.Parameters.Add("@MatriculaAvion", System.Data.SqlDbType.VarChar, 100);
                 cmd.Parameters["@MatriculaAvion"].Value = matriculaAvion;


                 //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                 SqlDataReader dr = cmd.ExecuteReader();

                 while (dr.Read())
                {
                     //tomo un unico valor como esperado segun comportamiento del SP
                    matri = dr.GetSqlString(0).ToString();
                }
                //cierro el lector
                dr.Close();
                conexion.Close();
                return matri;
             }
             catch (SqlException e)
             {
                 throw (e);
             }
             catch (Exception e)
             {
                 throw (e);

             }

         }
        //fin modeloAvion

         public string pasajerosAvion(string matriculaAvion)
         {
             try
             {
                 string matri = "";
                 //Inicializo la conexion con el string de conexion
                 conexion = new SqlConnection(stringDeConexion);
                 //INTENTO abrir la conexion
                 conexion.Open();
                 //indico que ejecutare un Stored Procedured en la BD 
                 SqlCommand cmd = new SqlCommand("M04_DetalleAvion_Pasajeros", conexion);
                 cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 //le paso los parametros que espera el SP
                 cmd.Parameters.Add("@MatriculaAvion", System.Data.SqlDbType.VarChar, 100);
                 cmd.Parameters["@MatriculaAvion"].Value = matriculaAvion;


                 //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                 SqlDataReader dr = cmd.ExecuteReader();

                 while (dr.Read())
                 {
                     //tomo un unico valor como esperado segun comportamiento del SP
                     matri = dr.GetSqlString(0).ToString();
                 }
                 //cierro el lector
                 dr.Close();
                 conexion.Close();

                 return matri;
             }
             catch (SqlException e)
             {
                 throw (e);

             }
             catch (Exception e)
             {
                 throw (e);

             }

         }
        //fin pasajerosAvion

            public string fechaVuelo(string fechaDes, string horaDes, string Origen, string Destino, string matriAvion)
            {
             try
             {
                 string fechaA = "";
                 string fecha = ""+fechaDes+" "+horaDes;
                 int resultado = idRutaVuelo(Origen, Destino);
                 //Inicializo la conexion con el string de conexion
                 conexion = new SqlConnection(stringDeConexion);
                 //INTENTO abrir la conexion
                 conexion.Open();
                 //le indico que ejecutare un Stored Procedure en la BD
                 SqlCommand cmd = new SqlCommand("M04_CalcularFechaAterrizaje", conexion);
                 //le paso los parametros que espera el SP
                 cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 cmd.Parameters.Add("@fechaDespegue", System.Data.SqlDbType.DateTime);
                 cmd.Parameters["@fechaDespegue"].Value = fecha;
                 cmd.Parameters.Add("@CiudadOrigen", System.Data.SqlDbType.VarChar, 100);
                 cmd.Parameters["@CiudadOrigen"].Value = Origen;
                 cmd.Parameters.Add("@CiudadDestino", System.Data.SqlDbType.VarChar, 100);
                 cmd.Parameters["@CiudadDestino"].Value = Destino; 
                 cmd.Parameters.Add("@matriculaAvion", System.Data.SqlDbType.VarChar, 100);
                 cmd.Parameters["@matriculaAvion"].Value = matriAvion;
                 cmd.Parameters.Add("@idRuta", System.Data.SqlDbType.Int, 100);
                 cmd.Parameters["@idRuta"].Value = resultado;

                 //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                 SqlDataReader dr = cmd.ExecuteReader();

                 while (dr.Read())
                 {
                     //tomo un unico valor como esperado segun comportamiento del SP
                     fechaA = dr.GetSqlDateTime(0).ToString();
                 }
                 //cierro el lector
                 dr.Close();
                 conexion.Close();

                 return fechaA;
             }
             catch (SqlException e)
             {
                 throw (e);

             }
             catch (Exception e)
             {
                 throw (e);

             }

         }//fin fechaVuelo


         public string distanciaAvion(string matriculaAvion)
         {
             try
             {
                 string dist = "";
                 //Inicializo la conexion con el string de conexion
                 conexion = new SqlConnection(stringDeConexion);
                 //INTENTO abrir la conexion
                 conexion.Open();
                 //indico que ejecutare un Stored Procedure en la BD
                 SqlCommand cmd = new SqlCommand("M04_DetalleAvion_Distancia", conexion);
                 cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 //le paso el parametro que espero en la base de datos
                 cmd.Parameters.Add("@MatriculaAvion", System.Data.SqlDbType.VarChar, 100);
                 cmd.Parameters["@MatriculaAvion"].Value = matriculaAvion;


                 //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                 SqlDataReader dr = cmd.ExecuteReader();

                 while (dr.Read())
                 {
                     //tomo un unico valor como esperado segun comportamiento del SP
                     dist = dr.GetSqlString(0).ToString();
                 }
                 //cierro el lector
                 dr.Close();
                 conexion.Close();

                 return dist;
             }
             catch (SqlException e)
             {
                 throw (e);

             }
             catch (Exception e)
             {
                 throw (e);

             }

         }//fin distancia avion


         public string velocidadAvion(string matriculaAvion)
         {
             try
             {
                 string dist = "";
                 //Inicializo la conexion con el string de conexion
                 conexion = new SqlConnection(stringDeConexion);
                 //INTENTO abrir la conexion
                 conexion.Open();
                 //le indico que ejecutare un Stored Procedure en la BD
                 SqlCommand cmd = new SqlCommand("M04_DetalleAvion_Velocidad", conexion);
                 cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 //le paso el parametro que espera el SP
                 cmd.Parameters.Add("@MatriculaAvion", System.Data.SqlDbType.VarChar, 100);
                 cmd.Parameters["@MatriculaAvion"].Value = matriculaAvion;


                 //creo un lector sql para la respuesta de la ejecucion del comando anterior               
                 SqlDataReader dr = cmd.ExecuteReader();

                 while (dr.Read())
                 {
                     //tomo un unico valor como esperado segun comportamiento del SP
                     dist = dr.GetSqlString(0).ToString();
                 }
                 //cierro el lector
                 dr.Close();
                 conexion.Close();

                 return dist;
             }
             catch (SqlException e)
             {
                 throw (e);

             }
             catch (Exception e)
             {
                 throw (e);

             }

         }
        //fin velocidadAvion



    }

}
