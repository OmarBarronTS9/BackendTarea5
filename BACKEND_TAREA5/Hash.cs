using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BACKEND_TAREA5.Backend
{
    public class Hash
    {
        public string HashMethodo()
        {
            string sSourceData, Salt;
            byte[] tmpSource;//guarda el hasheo (de lo que sea)
            byte[] tmpHash;

            sSourceData = usuario.contraseña;
            tmpSource = ASCIIEncoding.ASCII.GetBytes(sSourceData);//convierte la contraseña en simbolos ascii para crear el hash
            tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);//Aqui se realiza el hash
            Salt = ByteArrayToString(tmpHash);

            static string ByteArrayToString(byte[] arrInput)
            {
                int i;
                StringBuilder sOutput = new StringBuilder(arrInput.Length);
                for (i = 0; i < arrInput.Length - 1; i++)
                {
                    sOutput.Append(arrInput[i].ToString("X2"));
                }
                return sOutput.ToString();
            }

            return Salt;
        }
    }


}

