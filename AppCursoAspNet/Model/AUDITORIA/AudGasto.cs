//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo.AUDITORIA
{
    using System;
    using System.Collections.Generic;
    
    public partial class AudGasto
    {
        public int Id { get; set; }
        public int IdGasto { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public Nullable<System.DateTime> HoraEmision { get; set; }
        public Nullable<System.DateTime> FechaEmision { get; set; }
        public int TipoGasto { get; set; }
        public string Vehiculo { get; set; }
        public string Usuario { get; set; }
        public System.DateTime FechayHora { get; set; }
        public string Operacion { get; set; }
        public string IdFlota { get; set; }
    }
}
