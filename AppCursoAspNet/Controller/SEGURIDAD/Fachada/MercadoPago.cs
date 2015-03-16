using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mercadopago;
using System.Collections;

namespace Controladora.SEGURIDAD.Fachada
{
    public class MercadoPago
    {
        private string descripcion;
        private string precio;
        private string nombre;
        private string email;
        private string id;
        private string currency;
        private string codigo;
        private string auto_return;
        private string quantity;

        public string getdescripcion()
        {
            return descripcion;
        }
        public void setdescripcion(string _descripcion)
        {
            this.descripcion = _descripcion;
        }
        public string getprecio()
        {
            return precio;
        }
        public void setprecio(string _precio)
        {
            this.precio = _precio;
        }
        public string getnombre()
        {
            return nombre;
        }
        public void setnombre(string _nombre)
        {
            this.nombre = _nombre;
        }
        public string getemail()
        {
            return email;
        }
        public void setemail(string _email)
        {
            this.email = _email;
        }
        public string getid()
        {
            return id;
        }
        public void setid(string _id)
        {
            this.id = _id;
        }
        public string getcurrency()
        {
            return currency;
        }
        public void setcurrency(string _currency)
        {
            this.currency = _currency;
        }

        public string getcodigo()
        {
            return codigo;
        }
        public void setcodigo(string _codigo)
        {
            this.codigo = _codigo;
        }

        public string getauto_return()
        {
            return auto_return;
        }
        public void setauto_return(string _auto_return)
        {
            this.auto_return = _auto_return;
        }
        public string getquantity()
        {
            return quantity;
        }
        public void setquantity(string _quantity)
        {
            this.quantity = _quantity;
        }



        public string generarURL() {
         
        string url;

        MP mp = new MP("919996648151981", "GjTCamDdthf23kl2F5MZrUUVL7hMfV6K");

        string seteoItem = "{\"items\": [{\"id\": \""+codigo+"\",\"title\": \"" + descripcion + "\",\"currency_id\": \""+currency+"\",\"description\": \"" + descripcion + "\",\"quantity\": "+quantity+",\"unit_price\": " + precio + "}],  \"payer\": {\"name\": \"" + nombre + "\",\"email\": \"" + email + "\",},  \"auto_return\": \"" + auto_return + "\",\"back_urls\": {\"failure\": \"http://localhost:50196/View/FinCheckout?idtipo=" + id + "\",\"pending\": \"http://localhost:50196/View/FinCheckout?idtipo=" + id + "\",\"success\": \"http://localhost:50196/View/FinCheckout?idtipo=" + id + "\"}, \"external_reference\": \"" + id + "\", }";

        Hashtable preference = mp.createPreference(seteoItem);

        url = (((Hashtable)preference["response"])["sandbox_init_point"]).ToString();
            
        return url;
    }



    }
}
