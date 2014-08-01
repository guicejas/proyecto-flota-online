using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo.SEGURIDAD;
using System.Net.Mail;

namespace Controladora.SEGURIDAD
{
    public class ControladoraUsuarios
    {
        Encriptacion oEncriptar = new Encriptacion();

        // ---- TEMPORAL INICIO ---- //
        public void CargaInicialBD()
        {

            if (Modelo.SingletonSeguridad.ObtenerInstancia().Usuarios.ToList().Count == 0)
            {

                Grupo oGrupo = new Grupo();
                oGrupo.IDGrupo = "Administrador";
                oGrupo.Descripcion = "Grupo de Administradores";
                Modelo.SingletonSeguridad.ObtenerInstancia().Grupos.Add(oGrupo);

                Grupo aGrupo = new Grupo();
                aGrupo.IDGrupo = "Invitado";
                aGrupo.Descripcion = "Grupo de Invitados";
                Modelo.SingletonSeguridad.ObtenerInstancia().Grupos.Add(aGrupo);

                Formulario oFormulario = new Formulario();
                oFormulario.IDFormulario = "GestionGrupos";
                oFormulario.Descripcion = "Formulario de Gestion de Grupos";
                Modelo.SingletonSeguridad.ObtenerInstancia().Formularios.Add(oFormulario);

                Formulario aFormulario = new Formulario();
                aFormulario.IDFormulario = "GestionPerfiles";
                aFormulario.Descripcion = "Formulario de Gestion de Perfiles";
                Modelo.SingletonSeguridad.ObtenerInstancia().Formularios.Add(aFormulario);

                Formulario cFormulario = new Formulario();
                cFormulario.IDFormulario = "GestionUsuarios";
                cFormulario.Descripcion = "Formulario de Gestion de Usuarios";
                Modelo.SingletonSeguridad.ObtenerInstancia().Formularios.Add(cFormulario);

                Formulario dFormulario = new Formulario();
                dFormulario.IDFormulario = "GestionGastos";
                dFormulario.Descripcion = "Formulario de Gestion de Gastos";
                Modelo.SingletonSeguridad.ObtenerInstancia().Formularios.Add(dFormulario);

                Formulario eFormulario = new Formulario();
                eFormulario.IDFormulario = "GestionVehiculos";
                eFormulario.Descripcion = "Formulario de Gestion de Vehiculos";
                Modelo.SingletonSeguridad.ObtenerInstancia().Formularios.Add(eFormulario);

                Formulario fFormulario = new Formulario();
                fFormulario.IDFormulario = "Monitor";
                fFormulario.Descripcion = "Formulario de Monitor";
                Modelo.SingletonSeguridad.ObtenerInstancia().Formularios.Add(fFormulario);

                Formulario gFormulario = new Formulario();
                gFormulario.IDFormulario = "Informes";
                gFormulario.Descripcion = "Formulario de Informes";
                Modelo.SingletonSeguridad.ObtenerInstancia().Formularios.Add(gFormulario);

                Permiso oPermiso = new Permiso();
                oPermiso.IDPermiso = "ALTA";
                oPermiso.Descripcion = "Permisos de alta";
                Modelo.SingletonSeguridad.ObtenerInstancia().Permisos.Add(oPermiso);

                Permiso bPermiso = new Permiso();
                bPermiso.IDPermiso = "MODIFICACION";
                bPermiso.Descripcion = "Permisos de modificación";
                Modelo.SingletonSeguridad.ObtenerInstancia().Permisos.Add(bPermiso);

                Permiso aPermiso = new Permiso();
                aPermiso.IDPermiso = "BAJA";
                aPermiso.Descripcion = "Permisos de baja";
                Modelo.SingletonSeguridad.ObtenerInstancia().Permisos.Add(aPermiso);

                Permiso dPermiso = new Permiso();
                dPermiso.IDPermiso = "CONSULTA";
                dPermiso.Descripcion = "Permisos de consulta";
                Modelo.SingletonSeguridad.ObtenerInstancia().Permisos.Add(dPermiso);

                Permiso cPermiso = new Permiso();
                cPermiso.IDPermiso = "TOTAL";
                cPermiso.Descripcion = "Permisos totales sobre el formulario";
                Modelo.SingletonSeguridad.ObtenerInstancia().Permisos.Add(cPermiso);

                Usuario oUsuario = new Usuario();
                oUsuario.IDUsuario = "admin";
                oUsuario.Contraseña = "admin";
                oUsuario.Email = "guillermo.cejas@admin.com";
                oUsuario.Activo = false;
                oUsuario.Habilitado = true;
                oUsuario.NombreApellido = "Guillermo Cejas";
                oUsuario.PrimeraVez = false;
                oUsuario.Grupo.Add(oGrupo);
                oUsuario.Contraseña = oEncriptar.encriptar(oUsuario.Contraseña);

                Modelo.SingletonSeguridad.ObtenerInstancia().Usuarios.Add(oUsuario);
                Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
            }
        }

        // ---- TEMPORAL FIN ---- //

        public void AgregarUsuario(Usuario oUsuario)
        {
            oUsuario.Contraseña = oEncriptar.encriptar(oUsuario.Contraseña);

            Modelo.SingletonSeguridad.ObtenerInstancia().Usuarios.Add(oUsuario);
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public void EliminarUsuario(string IDusuario)
        {
            Usuario oUsuario = Modelo.SingletonSeguridad.ObtenerInstancia().Usuarios.Find(IDusuario);
            oUsuario.Grupo.Clear();
            //foreach (Grupo g in oUsuario.Grupo)
            //    g.Usuario.Remove(oUsuario);

            //foreach (Usuario u in g.Usuario)
            //    if (u.IDusuario == oUsuario.IDusuario)
            //    {
            //        g.Usuario.Remove(u);
            //    }

            Modelo.SingletonSeguridad.ObtenerInstancia().Usuarios.Remove(oUsuario);
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public void ModificarUsuario(Usuario oUsuario)
        {
            Modelo.SingletonSeguridad.ObtenerInstancia().Entry(oUsuario).State = System.Data.Entity.EntityState.Modified;
            Modelo.SingletonSeguridad.ObtenerInstancia().SaveChanges();
        }

        public Usuario BuscarUsuario(string IDusuario)
        {
            Usuario user = Modelo.SingletonSeguridad.ObtenerInstancia().Usuarios.FirstOrDefault(oUsu => oUsu.IDUsuario == IDusuario);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public List<Usuario> ListarUsuarios()
        {
            return Modelo.SingletonSeguridad.ObtenerInstancia().Usuarios.ToList();
        }

        public bool VerificarUsuario(Usuario oUsuario)
        {
            List<Usuario> Lista = Modelo.SingletonSeguridad.ObtenerInstancia().Usuarios.Where(oUsu => oUsu.IDUsuario == oUsuario.IDUsuario).ToList();

            if (Lista.Count > 0)
            {
                return false;
            }
            return true;
        }

        private static string CrearRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        public void CambiarContraseña(Usuario oUsuario)
        {
            string nuevoPass = CrearRandomPassword(8);

            //try
            //{
            MailMessage correo = new MailMessage();
            correo.IsBodyHtml = true;
            correo.From = new MailAddress("trypep.sisflotaxis@gmail.com");
            correo.To.Add(oUsuario.Email.ToString());
            correo.Subject = "Nueva contraseña. Sistema Flota de Taxis";
            correo.Body = "<h2>SISTEMA GESTION FLOTA DE TAXIS</h2><br>" + oUsuario.NombreApellido.ToString() + ",<br><br>Su nueva contraseña es " + nuevoPass + "<br><br><br> <center><font color='grey' size='2'><hr> <br> La información que contiene este email, incluidos sus archivos adjuntos, es confidencial, y sólo para conocimiento y uso de las personas a las cuales está dirigida. La Trypep Sistemas no se hace responsable de las alteraciones que pudiera sufrir el mensaje una vez enviado.Si por error recibe este correo, le rogamos aceptar nuestras disculpas y, al mismo tiempo, le solicitamos notificarlo a la persona que lo envió, abstenerse de divulgar su contenido y borrarlo de inmediato. <br> <b><i>TRYPEP SISTEMAS</i></b></font></center><br>";



            SmtpClient cliente = new SmtpClient("smtp.gmail.com");
            cliente.Port = 587;
            cliente.Credentials = new System.Net.NetworkCredential("trypep.sisflotaxis@gmail.com", "trypeptaxis");
            cliente.EnableSsl = true;
            cliente.Send(correo);

            //}
            //catch
            //{
            //    return;
            //}

            oUsuario.Contraseña = oEncriptar.encriptar(nuevoPass);
            oUsuario.PrimeraVez = true;
            ModificarUsuario(oUsuario);

        }

    }
}
