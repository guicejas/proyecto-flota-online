using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.SEGURIDAD;
using Modelo.AUDITORIA;
using System.Data;

namespace Controladora.SEGURIDAD
{
    public class ControladoraLogin
    {
        ControladoraUsuarios ctrlUsuarios = new ControladoraUsuarios();
        Encriptacion oEncriptacion = new Encriptacion();

        public bool IniciarSesion(string IDUsuario, string clave) // es de tipo object ya que puede devolver distintos valores
        {
            int nroError;

            Usuario oUsuario; //declaracion de la variable Usuario
            oUsuario = ctrlUsuarios.BuscarUsuario(IDUsuario); //Se asigna a usuario el valor devuelto por BuscarUsuario()
            string password = oEncriptacion.encriptar(clave);

            if (oUsuario == null) //Si no se encontró ningún usuario con ese ID....
            {
                nroError = 1;
                return false;
            }
            if (oUsuario.Contraseña != password) //Si la contraseña ingresada no coincide con la del usuario..
            {
                nroError = 2;
                return false;
            }
            if (oUsuario.Habilitado == false) //si el usuario no está habilitado para iniciar sesión
            {
                nroError = 3;
                return false;
            }

            oUsuario.Activo = true;

            ctrlUsuarios.ModificarUsuario(oUsuario);
            //ctrlAudLog.AuditarLogIn(oUsuario);

            return true; //si está todo OK devuelve el usuario encontrado
        }

        public object ResetearContraseña(string IDUsuario)
        {
            int nroError;
            
            Usuario oUsuario; //declaracion de la variable Usuario
            oUsuario = ctrlUsuarios.BuscarUsuario(IDUsuario); //Se asigna a usuario el valor devuelto por BuscarUsuario()

            if (oUsuario == null) //Si no se encontró ningún usuario con ese ID....
            {
                nroError = 1;
                return nroError;
            }
            if (oUsuario != null) //Si se encontro el usuario...
            {
                ctrlUsuarios.CambiarContraseña(oUsuario);
            }

            return oUsuario; //si está todo OK devuelve el usuario encontrado
        }

        public void CerrarSesion(string IDusuario)
        {
            Usuario oUsuario = ctrlUsuarios.BuscarUsuario(IDusuario);
            oUsuario.Activo = false;
            ctrlUsuarios.ModificarUsuario(oUsuario);

            //ctrlAudLog.AuditarLogOut(oUsuario);
        }
    }
}
