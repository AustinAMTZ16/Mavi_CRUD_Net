using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_MAVI_CONTACTOS
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nickname { get; set; }
        public string CorreoElectronico { get; set; }
        public string ClaveUsuario { get; set;}
        public Boolean EstadoUsuario { get; set; }

        public Usuario(string nickname, string correoElectronico, string claveUsuario) {
            Nickname = nickname;
            CorreoElectronico = correoElectronico;
            ClaveUsuario = claveUsuario;

        }
        
    }
}
