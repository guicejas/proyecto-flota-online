//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            this.Activo = 1;
            this.Gasto = new HashSet<Gasto>();
            this.Turno = new HashSet<Turno>();
        }
    
        public string Patente { get; set; }
        public Nullable<int> PatenteTaxi { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Año { get; set; }
        public string Color { get; set; }
        public int Kilometraje { get; set; }
        public int TurnoId { get; set; }
        public int fIDFlota { get; set; }
        public short Activo { get; set; }
    
        public virtual ICollection<Gasto> Gasto { get; set; }
        public virtual ICollection<Turno> Turno { get; set; }
    }
}
