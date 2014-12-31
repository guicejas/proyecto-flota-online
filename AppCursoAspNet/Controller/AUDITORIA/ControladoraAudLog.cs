using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.AUDITORIA;
using Modelo.SEGURIDAD;
using Modelo;


namespace Controladora.AUDITORIA
{
    public class ControladoraAudLog
    {
        private static volatile ControladoraAudLog instancia;

        private ControladoraAudLog()
        {
             
        }

        public static ControladoraAudLog getINSTANCIA
        {
            get
            {
                if (instancia == null) instancia = new ControladoraAudLog();
                return instancia;
            }
        }

        Controladora.SEGURIDAD.ControladoraUsuarios ctrlUsuarios = new SEGURIDAD.ControladoraUsuarios();


        public void AuditarLogIn(string oUsuario)
        {

            LoginLogout oLogIn = new LoginLogout();
            oLogIn.Usuario = oUsuario;
            oLogIn.FechayHora = DateTime.Now;
            oLogIn.Operacion = "LogIn";

            Modelo.SingletonAuditoria.ObtenerInstancia().LogInsOuts.Add(oLogIn);
            Modelo.SingletonAuditoria.ObtenerInstancia().SaveChanges();
        }

        public void AuditarLogOut(string oUsuario)
        {
            LoginLogout oLogOut = new LoginLogout();
            oLogOut.Usuario = oUsuario;
            oLogOut.FechayHora = DateTime.Now;
            oLogOut.Operacion = "LogOut";

            Modelo.SingletonAuditoria.ObtenerInstancia().LogInsOuts.Add(oLogOut);
            Modelo.SingletonAuditoria.ObtenerInstancia().SaveChanges();
        }

        public List<Modelo.AUDITORIA.LoginLogout> ListarLogs()
        {
            return Modelo.SingletonAuditoria.ObtenerInstancia().LogInsOuts.ToList();
        }

        public List<Modelo.AUDITORIA.LoginLogout> FiltrarLogs(string User, Nullable<System.DateTime> Fecha, string Operacion)
        {
            List<LoginLogout> Filtrado = Modelo.SingletonAuditoria.ObtenerInstancia().LogInsOuts.ToList();
            if (User != null)
                Filtrado = Filtrado.Where(oLog => oLog.Usuario.IndexOf(User, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (Fecha != null)
                Filtrado = Filtrado.Where(oLog => oLog.FechayHora.Date == Convert.ToDateTime(Fecha).Date).ToList();
            if (Operacion != null)
                Filtrado = Filtrado.Where(oLog => oLog.Operacion.IndexOf(Operacion, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();


            return Filtrado;

        }


    }
}
