//------------------------------------------------------------------------------
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
    
    public partial class M20_BuscarHotelesPorCiudad_Result
    {
        public int hot_id { get; set; }
        public string hot_nombre { get; set; }
        public string hot_email { get; set; }
        public Nullable<int> hot_fk_ciudad { get; set; }
        public Nullable<int> hot_cantidad_habitaciones_disponible { get; set; }
    }
}
