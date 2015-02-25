using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladora
{
    public class ControladoraEmpresas
    {
        private static volatile ControladoraEmpresas instancia;

        ControladoraEmpresas()
        {
        }
        public static ControladoraEmpresas getINSTANCIA
        {
            get
            {
                if (instancia == null) instancia = new ControladoraEmpresas();
                return instancia;
            }
        }

        public void AgregarEmpresa(Modelo.Empresa oEmpresa)
        {
            Modelo.SingletonSistFlota.ObtenerInstancia().Empresas.Add(oEmpresa);
            Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
        }
        public bool EliminarEmpresa(long idEmpresa)
        {
            Modelo.Empresa oEmpresa = Modelo.SingletonSistFlota.ObtenerInstancia().Empresas.Find(idEmpresa);
            Modelo.SingletonSistFlota.ObtenerInstancia().Empresas.Remove(oEmpresa);
            try
            {
                Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
                return false;
            }
            catch
            {
                return true;
            }
        }
        public void ModificarEmpresa(Modelo.Empresa oEmpresa)
        {
            Modelo.SingletonSistFlota.ObtenerInstancia().Entry(oEmpresa).State = System.Data.Entity.EntityState.Modified;
            Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
        }
        public List<Modelo.Empresa> ListarEmpresas(string flotaId)
        {
            int flota = Convert.ToInt32(flotaId);

            if (flota == 0)
                return Modelo.SingletonSistFlota.ObtenerInstancia().Empresas.ToList();
            else
                return Modelo.SingletonSistFlota.ObtenerInstancia().Empresas.Where(oEmp => oEmp.fIDFlota == flota).ToList();

        }

        public bool VerificarEmpresa(Modelo.Empresa oEmpresa)
        {
            List<Modelo.Empresa> Lista = Modelo.SingletonSistFlota.ObtenerInstancia().Empresas.Where(oEmpr => oEmpr.Cuit == oEmpresa.Cuit).ToList();
            
            if (Lista.Count > 0)
            {
                return false;
            }
            return true;
        }

        
        public List<Modelo.Empresa> ListarEmpresasFiltrados(string flotaId, string cuit,string razonSocial, string localidad, string correo)
        {
            int flota = Convert.ToInt32(flotaId);
            List<Modelo.Empresa> Filtrado;

            if (flota == 0)
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Empresas.ToList();
            else
                Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Empresas.Where(oEmp => oEmp.fIDFlota == flota).ToList();

            if (cuit != null)
                Filtrado = Filtrado.Where(oEmp => oEmp.Cuit == Convert.ToInt64(cuit)).ToList();
            if (razonSocial != null)
                Filtrado = Filtrado.Where(oEmp => oEmp.RazonSocial.IndexOf(razonSocial, System.StringComparison.OrdinalIgnoreCase)>=0).ToList();
            if (localidad != null)
                Filtrado = Filtrado.Where(oEmp => oEmp.Localidad.IndexOf(localidad, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (correo != null)
                Filtrado = Filtrado.Where(oEmp => oEmp.Correo.IndexOf(correo, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            return Filtrado;
        }

        public Modelo.Empresa ObtenerEmpresa(long cuit)
        {
            Modelo.Empresa oEmpresa = Modelo.SingletonSistFlota.ObtenerInstancia().Empresas.Find(cuit);
            return oEmpresa;
        }

        public List<Modelo.CuentaCorriente> ListarCuentasCorrientes()
        {
           return Modelo.SingletonSistFlota.ObtenerInstancia().CuentaCorrientes.ToList();
        }
    }
}
