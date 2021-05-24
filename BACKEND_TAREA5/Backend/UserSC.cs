using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BACKEND_TAREA5.DataAccess;
using BACKEND_TAREA5.Models;
using BACKEND_TAREA5.Hash;

namespace BACKEND_TAREA5.Backend
{
    public class UserSC : BaseSC
    {
        public IQueryable<Usuario> GetUser()
        {
            return DbContext.Usuarios.AsQueryable();

        }

        public Usuario GetUserByID(int ID)
        {
            var Userqry = GetUser().Where(w => w.IdUsuario == ID).ToList().FirstOrDefault();

            if(Userqry == null)
            {
                throw new Exception("El usuario con el ID solicitado no existe");
            }

            return Userqry;
        }

        public Usuario GetUserByUsername(string Username)
        {
            var Userqry = GetUser().Where(w => w.Usuario1 == Username).ToList().FirstOrDefault();

            if (Userqry == null)
            {
                throw new Exception("El usuario con ese Username solicitado no existe");
            }

            return Userqry;
        }

        public void AddUser(UserModel newUser)
        {
            Usuario usuario = new Usuario();
            usuario.Usuario1 = newUser.User;
            usuario.Email = newUser.Email;
            usuario.Contraseña = newUser.Password;
            string Sal = new HashMethod(usuario.Contraseña);
            usuario.Contraseña = Sal;
            var dbContext = new Tarea5Context();
            dbContext.Usuarios.Add(usuario);
            dbContext.SaveChanges();
        }

        public void DeleteUser(int ID)
        {
            var currentUser = GetUserByID(ID);

            try
            {
                DbContext.Usuarios.Remove(currentUser);
                DbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception("No se puede hacer el cambio en la base de datos: " + ex.Message + ". "
                    + ex.InnerException != null ? ex.InnerException.Message : "");
            }
        }
    }
}
