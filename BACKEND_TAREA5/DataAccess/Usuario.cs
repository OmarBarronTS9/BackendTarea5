using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace BACKEND_TAREA5.DataAccess
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public string Usuario1 { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Contraseña { get; set; }
        public string Sal { get; set; }
    }
}
