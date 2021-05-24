using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND_TAREA5.Models
{
    public class UserModel
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage ="El usuario no debe de estar vacio")]
        public string User { get; set; }

        [Required(ErrorMessage = "El Email no debe de estar vacio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña no debe de estar vacia")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")  ]
        [NotMapped] // Esto quiere decir que el campo no existe dentro de la tabla
        public string ConfirmaPassword { get; set; }
        public string Sal { get; set; }
    }
}
