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

        public ControladoraEmpresas()
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
        public void EliminarEmpresa(long idEmpresa)
        {
            Modelo.Empresa oEmpresa = Modelo.SingletonSistFlota.ObtenerInstancia().Empresas.Find(idEmpresa);
            Modelo.SingletonSistFlota.ObtenerInstancia().Empresas.Remove(oEmpresa);
            Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
        }
        public void ModificarEmpresa(Modelo.Empresa oEmpresa)
        {
            Modelo.SingletonSistFlota.ObtenerInstancia().Entry(oEmpresa).State = System.Data.Entity.EntityState.Modified;
            Modelo.SingletonSistFlota.ObtenerInstancia().SaveChanges();
        }
        public List<Modelo.Empresa> ListarEmpresas()
        {
            return Modelo.SingletonSistFlota.ObtenerInstancia().Empresas.ToList();

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

        
        public List<Modelo.Empresa> ListarEmpresasFiltrados(string cuit,string razonSocial, string localidad, string correo)
        {
            List<Modelo.Empresa> Filtrado = Modelo.SingletonSistFlota.ObtenerInstancia().Empresas.ToList();
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
    }
}
