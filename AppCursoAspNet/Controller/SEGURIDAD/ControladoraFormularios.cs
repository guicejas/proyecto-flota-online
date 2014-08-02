using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.SEGURIDAD;

namespace Controladora.SEGURIDAD
{
    public class ControladoraFormularios
    {
        public List<Formulario> ListarFormularios()
        {
            return Modelo.SingletonSeguridad.ObtenerInstancia().Formularios.OrderBy(c => c.IDFormulario).ToList();
        }
    }
}
