using System;
using System.Linq;
using BACKEND_TAREA5.DataAccess;
using Microsoft.EntityFrameworkCore;
using BACKEND_TAREA5.Backend;
using BACKEND_TAREA5.Models;



namespace BACKEND_TAREA5
{
    public class Program
    {
        public static void Usuarios()
        {
            var UserQry= new UserSC().GetUser();
            var output = UserQry.ToList();
        }

        public static void UsuarioByID(int ID)
        {
           new UserSC().GetUserByID(ID);

        }

        public static void DeleteUsuario(int ID)
        {
           new UserSC().DeleteUser(ID);
        }

        public static void Main(string[] args)
        {
            //Usuarios();
            //UsuarioByID(10);
          
        }
    }
}
