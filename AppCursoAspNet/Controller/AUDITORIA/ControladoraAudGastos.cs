using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo;
using Modelo.AUDITORIA;


namespace Controladora.AUDITORIA
{
    public class ControladoraAudGastos
    {

       private static volatile ControladoraAudGastos instancia;

        private ControladoraAudGastos()
        {
             
        }

        public static ControladoraAudGastos getINSTANCIA
        {
            get
            {
                if (instancia == null) instancia = new ControladoraAudGastos();
                return instancia;
            }
        }

        public void AuditarGastosMOD(Gasto oGasto)
        {
            AudGasto oGastoAUDI = new AudGasto();

            oGastoAUDI.IdGasto = oGasto.Id;
            oGastoAUDI.Descripcion = oGasto.Descripcion;
            oGastoAUDI.Monto = oGasto.Monto;
            oGastoAUDI.Estado = oGasto.Estado;
            oGastoAUDI.FechaVencimiento = oGasto.FechaVencimiento;
            oGastoAUDI.HoraEmision = oGasto.HoraEmision;
            oGastoAUDI.FechaEmision = oGasto.FechaEmision;
            oGastoAUDI.TipoGasto = oGasto.TipodeGasto.Id;
            oGastoAUDI.Vehiculo = oGasto.Vehiculo.Patente;
            oGastoAUDI.Usuario = oGasto.Usuario;
            oGastoAUDI.FechayHora = Convert.ToDateTime(oGasto.FechayHora);
            oGastoAUDI.Operacion = oGasto.Operacion;

            Modelo.SingletonAuditoria.ObtenerInstancia().AudGastos.Add(oGastoAUDI);
            Modelo.SingletonAuditoria.ObtenerInstancia().SaveChanges();


        }

        public void AuditarGastosBAJA(Gasto oGasto, string oUsuario)
        {
            AudGasto oGastoAUDI = new AudGasto();

            oGastoAUDI.IdGasto = oGasto.Id;
            oGastoAUDI.Descripcion = oGasto.Descripcion;
            oGastoAUDI.Monto = oGasto.Monto;
            oGastoAUDI.Estado = oGasto.Estado;
            oGastoAUDI.FechaVencimiento = oGasto.FechaVencimiento;
            oGastoAUDI.HoraEmision = oGasto.HoraEmision;
            oGastoAUDI.FechaEmision = oGasto.FechaEmision;
            oGastoAUDI.TipoGasto = oGasto.TipodeGasto.Id;
            oGastoAUDI.Vehiculo = oGasto.Vehiculo.Patente;
            oGastoAUDI.Usuario = oUsuario;
            oGastoAUDI.FechayHora = Convert.ToDateTime(oGasto.FechayHora);
            oGastoAUDI.Operacion = "BAJA";

            //Modelo.Auditoria.ObtenerInstancia().AudGastos.Add(oGastoAUDI);
            //Modelo.Auditoria.ObtenerInstancia().SaveChanges();

            //AudGasto oGastoAUDIBaja = new AudGasto();

            //oGastoAUDIBaja.IdGasto = oGastoAUDI.IdGasto;
            //oGastoAUDIBaja.Descripcion = oGastoAUDI.Descripcion;
            //oGastoAUDIBaja.Monto = oGastoAUDI.Monto;
            //oGastoAUDIBaja.Estado = oGastoAUDI.Estado;
            //oGastoAUDIBaja.FechaVencimiento = oGastoAUDI.FechaVencimiento;
            //oGastoAUDIBaja.HoraEmision = oGastoAUDI.HoraEmision;
            //oGastoAUDIBaja.FechaEmision = oGastoAUDI.FechaEmision;
            //oGastoAUDIBaja.TipoGasto = oGastoAUDI.TipoGasto;
            //oGastoAUDIBaja.Vehiculo = oGastoAUDI.Vehiculo;
            //oGastoAUDIBaja.Usuario = oGastoAUDI.Usuario;
            //oGastoAUDIBaja.FechayHora = oGastoAUDI.FechayHora;
            //oGastoAUDIBaja.Operacion = "BAJA";

            Modelo.SingletonAuditoria.ObtenerInstancia().AudGastos.Add(oGastoAUDI);
            Modelo.SingletonAuditoria.ObtenerInstancia().SaveChanges();




        }


        public List<AudGasto> ListarGastos()
        {
            return Modelo.SingletonAuditoria.ObtenerInstancia().AudGastos.ToList();

        }


        public List<AudGasto> FiltrarAudGastos(string User, Nullable<System.DateTime> Fecha, string Operacion, string Gasto)
        {
            List<AudGasto> Filtrado = Modelo.SingletonAuditoria.ObtenerInstancia().AudGastos.ToList();
             if (User != null)
                Filtrado = Filtrado.Where(oLog => oLog.Usuario.IndexOf(User, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (Fecha != null)
                Filtrado = Filtrado.Where(oLog => oLog.FechayHora.Date == Convert.ToDateTime(Fecha).Date).ToList();
            if (Operacion != null)
                Filtrado = Filtrado.Where(oLog => oLog.Operacion.IndexOf(Operacion, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (Gasto != null)
                Filtrado = Filtrado.Where(oLog => oLog.IdGasto == Convert.ToInt32(Gasto)).ToList();


            return Filtrado;

        }


    }
}
