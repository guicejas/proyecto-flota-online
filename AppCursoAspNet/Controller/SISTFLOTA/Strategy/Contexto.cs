using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora.SISTFLOTA.Strategy
{
    public class Contexto
    {
        public static Controladora.SISTFLOTA.Strategy.Contexto instancia;
        public Controladora.SISTFLOTA.Strategy.IStrategy iStrategy;

        private Contexto(Controladora.SISTFLOTA.Strategy.IStrategy strategia)
        {
            this.iStrategy = strategia;
            System.Diagnostics.Debug.WriteLine(iStrategy.ToString() + "Soy la clase iStrategy padre - Contexto");
        }

        public static Contexto getINSTANCIA(string formato)
        {
            Controladora.SISTFLOTA.Strategy.IStrategy estrategia;

            switch (formato)
            {
                case "EXCEL":
                    {
                        estrategia = new Controladora.SISTFLOTA.Strategy.EXCELStrategy();
                        break;
                    }
                case "PDF":
                    {
                        estrategia = new Controladora.SISTFLOTA.Strategy.PDFStrategy();
                        break;
                    }
                default:
                    {
                        estrategia = new Controladora.SISTFLOTA.Strategy.PDFStrategy();
                        break;
                    }
            }

            System.Diagnostics.Debug.WriteLine("");
            instancia = new Contexto(estrategia);
            return instancia;
        }
        public string Hacer_Reporte(string Reporte)
        {
            string filename ="";

            switch (Reporte)
            {
                case "Reporte_Gastos":
                    filename = this.iStrategy.GenerarReporteGastos();
                    break;

                case "Reporte_VehiculosActivos":
                    this.iStrategy.GenerarReporteVehiculosActivos();
                    break;
            }
            return filename;
        }
    }
}
