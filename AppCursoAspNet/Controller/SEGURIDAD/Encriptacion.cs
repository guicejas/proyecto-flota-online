using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Controladora.SEGURIDAD
{
    public class Encriptacion
    {
        public string encriptar(string passVista)
        {
            string passEncriptado = string.Empty;
            SHA512 sha512 = SHA512.Create();

            UTF8Encoding encoding = new UTF8Encoding();

            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha512.ComputeHash(encoding.GetBytes(passVista));

            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x1}", stream[i]);
            }

            return passEncriptado = sb.ToString();
        }
    }
}
