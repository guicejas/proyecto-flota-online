using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Modelo.SEGURIDAD;
using Modelo;


namespace Controladora.AUDITORIA
{
    public class ControladoraAudLog
    {
/*
        public void AuditarLogIn(Usuario oUsuario)
        {
            LoginLogout oLogIn = new LoginLogout();
            oLogIn.Usuario = oUsuario.IDusuario;
            oLogIn.FechayHora = DateTime.Now;
            oLogIn.Operacion = "LogIn";

            Modelo.Auditoria.ObtenerInstancia().AddToLogInsOuts(oLogIn);
            Modelo.Auditoria.ObtenerInstancia().SaveChanges();
        }

        public void AuditarLogOut(Usuario oUsuario)
        {
            LoginLogout oLogOut = new LoginLogout();
            oLogOut.Usuario = oUsuario.IDusuario;
            oLogOut.FechayHora = DateTime.Now;
            oLogOut.Operacion = "LogOut";

            Modelo.Auditoria.ObtenerInstancia().AddToLogInsOuts(oLogOut);
            Modelo.Auditoria.ObtenerInstancia().SaveChanges();
        }

        public List<LoginLogout> ListarLogs()
        {
            return Modelo.Auditoria.ObtenerInstancia().LogInsOuts.ToList();
        }

        public List<LoginLogout> FiltrarLogs(string User, DateTime Fecha, string Operacion)
        {
            List<LoginLogout> Filtrado = Modelo.Auditoria.ObtenerInstancia().LogInsOuts.ToList();
            if (User != "")
                Filtrado = Filtrado.Where(oLog => oLog.Usuario.Contains(User)).ToList();
            //if (Fecha != null)
                Filtrado = Filtrado.Where(oLog => oLog.FechayHora.Date == Fecha.Date).ToList();
            if (Operacion != null)
                if (Operacion != "Todos")
                    Filtrado = Filtrado.Where(oLog => oLog.Operacion.Contains(Operacion)).ToList();


            return Filtrado;

        }

*/
    }
}
