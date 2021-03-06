﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.SEGURIDAD;

namespace Controladora.SEGURIDAD
{
    public class ControladoraFlotas
    {

        public List<Flota> ListarFlotas()
        {
            return Modelo.SingletonSeguridad.ObtenerInstancia().Flotas.OrderBy(c => c.RazonSocial).ToList();
        }


        public void AgregarFlota(Flota oFlota)
        {
            Modelo.SingletonSeguridad.ObtenerInstancia().Flotas.Add(oFlota);
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public void EliminarFlota(string IDFlota)
        {
            Flota oFlota = Modelo.SingletonSeguridad.ObtenerInstancia().Flotas.Find(IDFlota);
            oFlota.Usuario.Clear();

            Modelo.SingletonSeguridad.ObtenerInstancia().Flotas.Remove(oFlota);
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public void ModificarFlota(Flota oFlota)
        {
            Modelo.SingletonSeguridad.ObtenerInstancia().Entry(oFlota).State = System.Data.Entity.EntityState.Modified;
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public Flota ObtenerFlota(string flotaId)
        {
            int idFlota = Convert.ToInt32(flotaId);

            Flota oFlota = Modelo.SingletonSeguridad.ObtenerInstancia().Flotas.Find(idFlota);
            return oFlota;
        }

        public bool VerificarFlota(Flota oFlota)
        {
            List<Flota> Lista = Modelo.SingletonSeguridad.ObtenerInstancia().Flotas.Where(oFlo => oFlo.Id == oFlo.Id).ToList();
            if (Lista.Count > 0)
            {
                return false;
            }
            return true;
        }

        public List<Flota> ListarFlotasFiltrados(string razonSocial)
        {
            List<Flota> Filtrado = Modelo.SingletonSeguridad.ObtenerInstancia().Flotas.OrderBy(c => c.RazonSocial).ToList();

            if (razonSocial != null)
            {
                Filtrado = Filtrado.Where(oFlo => oFlo.RazonSocial.IndexOf(razonSocial, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }
            return Filtrado;
        }

        public Flota ObtenerFlotadeUsuario(string idUsuario)
        {
            Usuario oUsuario = Modelo.SingletonSeguridad.ObtenerInstancia().Usuarios.Find(idUsuario);
            return oUsuario.Flota;
        }
    }
}
