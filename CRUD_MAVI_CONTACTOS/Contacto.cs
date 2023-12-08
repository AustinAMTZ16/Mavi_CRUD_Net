using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_MAVI_CONTACTOS
{
    public class Contacto
    {
        public int IdContacto { get; set; }
        public string NumeroTelefono { get; set; }
        public int IdUsuario { get; set; }

        public Contacto(string numeroTelefono, int idUsuuario)
        {
            NumeroTelefono = numeroTelefono;
            IdUsuario = idUsuuario;

        }
    }
}
