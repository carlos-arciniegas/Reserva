//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FOReserva.Models.ORM
{
    using System;
    
    public partial class M20_UsuarioHistorialReservaHabitacion_Result
    {
        public int hot_id { get; set; }
        public string hot_nombre { get; set; }
        public int usu_id { get; set; }
        public string fullname { get; set; }
        public int rha_id { get; set; }
        public int rha_habitacion { get; set; }
        public System.DateTime rha_fecha_llegada { get; set; }
        public int rha_cantidad_dias { get; set; }
        public Nullable<System.DateTime> rha_fecha_partida { get; set; }
        public int rha_estado { get; set; }
    }
}
