﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FOReserva.Models.ORM
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBReserva : DbContext
    {
        public DBReserva()
            : base("name=DBReserva")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<M20_ActualizarEstadoReservaHabitacion_Result> M20_ActualizarEstadoReservaHabitacion(Nullable<int> id_reserva, Nullable<int> estado)
        {
            var id_reservaParameter = id_reserva.HasValue ?
                new ObjectParameter("id_reserva", id_reserva) :
                new ObjectParameter("id_reserva", typeof(int));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("estado", estado) :
                new ObjectParameter("estado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<M20_ActualizarEstadoReservaHabitacion_Result>("M20_ActualizarEstadoReservaHabitacion", id_reservaParameter, estadoParameter);
        }
    
        public virtual ObjectResult<M20_DetalleReservaHabitacion_Result> M20_DetalleReservaHabitacion(Nullable<int> id_reserva)
        {
            var id_reservaParameter = id_reserva.HasValue ?
                new ObjectParameter("id_reserva", id_reserva) :
                new ObjectParameter("id_reserva", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<M20_DetalleReservaHabitacion_Result>("M20_DetalleReservaHabitacion", id_reservaParameter);
        }
    
        public virtual ObjectResult<M20_GuardarReservaHabitacion_Result> M20_GuardarReservaHabitacion(Nullable<int> id_reserva, Nullable<int> habitacion, Nullable<int> cantidad_dias, Nullable<System.DateTime> fecha_llegada, Nullable<int> hot_id, Nullable<int> usu_id, Nullable<int> estado)
        {
            var id_reservaParameter = id_reserva.HasValue ?
                new ObjectParameter("id_reserva", id_reserva) :
                new ObjectParameter("id_reserva", typeof(int));
    
            var habitacionParameter = habitacion.HasValue ?
                new ObjectParameter("habitacion", habitacion) :
                new ObjectParameter("habitacion", typeof(int));
    
            var cantidad_diasParameter = cantidad_dias.HasValue ?
                new ObjectParameter("cantidad_dias", cantidad_dias) :
                new ObjectParameter("cantidad_dias", typeof(int));
    
            var fecha_llegadaParameter = fecha_llegada.HasValue ?
                new ObjectParameter("fecha_llegada", fecha_llegada) :
                new ObjectParameter("fecha_llegada", typeof(System.DateTime));
    
            var hot_idParameter = hot_id.HasValue ?
                new ObjectParameter("hot_id", hot_id) :
                new ObjectParameter("hot_id", typeof(int));
    
            var usu_idParameter = usu_id.HasValue ?
                new ObjectParameter("usu_id", usu_id) :
                new ObjectParameter("usu_id", typeof(int));
    
            var estadoParameter = estado.HasValue ?
                new ObjectParameter("estado", estado) :
                new ObjectParameter("estado", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<M20_GuardarReservaHabitacion_Result>("M20_GuardarReservaHabitacion", id_reservaParameter, habitacionParameter, cantidad_diasParameter, fecha_llegadaParameter, hot_idParameter, usu_idParameter, estadoParameter);
        }
    
        public virtual ObjectResult<M20_HotelHistorialReservaHabitacion_Result> M20_HotelHistorialReservaHabitacion(Nullable<int> id_hotel)
        {
            var id_hotelParameter = id_hotel.HasValue ?
                new ObjectParameter("id_hotel", id_hotel) :
                new ObjectParameter("id_hotel", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<M20_HotelHistorialReservaHabitacion_Result>("M20_HotelHistorialReservaHabitacion", id_hotelParameter);
        }
    
        public virtual ObjectResult<M20_UsuarioHistorialReservaHabitacion_Result> M20_UsuarioHistorialReservaHabitacion(Nullable<int> id_usuario)
        {
            var id_usuarioParameter = id_usuario.HasValue ?
                new ObjectParameter("id_usuario", id_usuario) :
                new ObjectParameter("id_usuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<M20_UsuarioHistorialReservaHabitacion_Result>("M20_UsuarioHistorialReservaHabitacion", id_usuarioParameter);
        }
    
        public virtual ObjectResult<M20_BuscarHotelesPorCiudad_Result> M20_BuscarHotelesPorCiudad(Nullable<int> id_ciudad, Nullable<int> cantidad_dias, Nullable<System.DateTime> fecha_llegada)
        {
            var id_ciudadParameter = id_ciudad.HasValue ?
                new ObjectParameter("id_ciudad", id_ciudad) :
                new ObjectParameter("id_ciudad", typeof(int));
    
            var cantidad_diasParameter = cantidad_dias.HasValue ?
                new ObjectParameter("cantidad_dias", cantidad_dias) :
                new ObjectParameter("cantidad_dias", typeof(int));
    
            var fecha_llegadaParameter = fecha_llegada.HasValue ?
                new ObjectParameter("fecha_llegada", fecha_llegada) :
                new ObjectParameter("fecha_llegada", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<M20_BuscarHotelesPorCiudad_Result>("M20_BuscarHotelesPorCiudad", id_ciudadParameter, cantidad_diasParameter, fecha_llegadaParameter);
        }
    
        public virtual ObjectResult<M20_GenerarReservaHabitacion_Result> M20_GenerarReservaHabitacion(Nullable<int> hot_id, Nullable<int> usu_id, Nullable<int> cantidad_dias, Nullable<System.DateTime> fecha_llegada)
        {
            var hot_idParameter = hot_id.HasValue ?
                new ObjectParameter("hot_id", hot_id) :
                new ObjectParameter("hot_id", typeof(int));
    
            var usu_idParameter = usu_id.HasValue ?
                new ObjectParameter("usu_id", usu_id) :
                new ObjectParameter("usu_id", typeof(int));
    
            var cantidad_diasParameter = cantidad_dias.HasValue ?
                new ObjectParameter("cantidad_dias", cantidad_dias) :
                new ObjectParameter("cantidad_dias", typeof(int));
    
            var fecha_llegadaParameter = fecha_llegada.HasValue ?
                new ObjectParameter("fecha_llegada", fecha_llegada) :
                new ObjectParameter("fecha_llegada", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<M20_GenerarReservaHabitacion_Result>("M20_GenerarReservaHabitacion", hot_idParameter, usu_idParameter, cantidad_diasParameter, fecha_llegadaParameter);
        }
    
        public virtual ObjectResult<M20_ObtenerCiudades_Result> M20_ObtenerCiudades()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<M20_ObtenerCiudades_Result>("M20_ObtenerCiudades");
        }
    }
}
