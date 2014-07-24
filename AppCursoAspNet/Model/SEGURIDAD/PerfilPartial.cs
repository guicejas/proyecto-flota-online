using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.SEGURIDAD
{
    public partial class Perfil
    {
        public string IDgrupo
        {
            get
            {
                return this.Grupo.IDGrupo;
            }
        }

        public string IDpermiso
        {
            get
            {
                return this.Permiso.IDPermiso;
            }
        }

        public string IDformulario
        {
            get
            {
                return this.Formulario.IDFormulario;
            }
        }
    }
}
