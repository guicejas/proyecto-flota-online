using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.SEGURIDAD
{
    public partial class TipoLicencia
    {
        public string tipo
        {
            get
            {

                return ObjectContext.GetObjectType(this.GetType()).Name;
                //return this.GetType().Name;
            }
        }


    }

}
