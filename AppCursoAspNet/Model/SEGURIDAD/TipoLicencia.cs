//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo.SEGURIDAD
{
    using System;
    using System.Collections.Generic;
    
    public partial class TipoLicencia
    {
        public TipoLicencia()
        {
            this.Licencia = new HashSet<Licencia>();
        }
    
        public int Id { get; set; }
        public int Duracion { get; set; }
        public string Descripcion { get; set; }
        public short Activo { get; set; }
    
        public virtual ICollection<Licencia> Licencia { get; set; }
    }
}
