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
            
            Usuario oUsuario; //declaracion de la variable Usuario
            oUsuario = ctrlUsuarios.BuscarUsuario(IDUsuario); //Se asigna a usuario el valor devuelto por BuscarUsuario()
            string password = oEncriptacion.encriptar(clave);

            if (oUsuario == null) //Si no se encontró ningún usuario con ese ID....
            {
                return false;
            }
            if (oUsuario.Contraseña != password) //Si la contraseña ingresada no coincide con la del usuario..
            {
                return false;
            }
            if (oUsuario.Habilitado == false) //si el usuario no está habilitado para iniciar sesión
            {
                return false;
            }

            oUsuario.Activo = true;

            ctrlUsuarios.ModificarUsuario(oUsuario);
            Controladora.AUDITORIA.ControladoraAudLog.getINSTANCIA.AuditarLogIn(IDUsuario);

            return true; //si está todo OK devuelve el usuario encontrado
        }

        public object ResetearContraseña(string mailUsuario)
        {
            int nroError;
            
            Usuario oUsuario; //declaracion de la variable Usuario
            oUsuario = ctrlUsuarios.BuscarUsuarioMail(mailUsuario); //Se asigna a usuario el valor devuelto por BuscarUsuario()

            if (oUsuario == null) //Si no se encontró ningún usuario con ese ID....
            {
                nroError = 1;
                return nroError;
            }
            if (oUsuario != null) //Si se encontro el usuario...
            {
                ctrlUsuarios.CambiarContraseña(oUsuario);
            }

            nroError = 2;
            return nroError;

            //return oUsuario; //si está todo OK devuelve el usuario encontrado
        }

        public void CerrarSesion(string IDusuario)
        {
            Usuario oUsuario = ctrlUsuarios.BuscarUsuario(IDusuario);
            oUsuario.Activo = false;
            ctrlUsuarios.ModificarUsuario(oUsuario);

            Controladora.AUDITORIA.ControladoraAudLog.getINSTANCIA.AuditarLogOut(IDusuario);
        }
    }
}
