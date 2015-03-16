using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mercadopago;
using System.Collections;

namespace Controladora.SEGURIDAD.Fachada
{
   public class FachadaMercadoPagoBasica
    {
       MercadoPago oMercadoPago;

       public FachadaMercadoPagoBasica(string descripcion, string precio, string nombre, string email, string id)
       {

           oMercadoPago = new MercadoPago();
           oMercadoPago.setauto_return("approved");
           oMercadoPago.setcodigo("BasicaTrypep");
           oMercadoPago.setcurrency("ARS");
           oMercadoPago.setquantity("1");
           oMercadoPago.setdescripcion(descripcion);
           oMercadoPago.setemail(email);
           oMercadoPago.setid(id);
           oMercadoPago.setnombre(nombre);
           oMercadoPago.setprecio(precio);

       }

       public string obtenerURL()
       {
           return oMercadoPago.generarURL();
       }

    }
}
