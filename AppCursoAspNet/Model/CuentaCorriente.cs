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
    
    public partial class CuentaCorriente
    {
        public CuentaCorriente()
        {
            this.Turno = new HashSet<Turno>();
        }
    
        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
    
        public virtual ICollection<Turno> Turno { get; set; }
        public virtual Empresa Empresa { get; set; }
    }
}
