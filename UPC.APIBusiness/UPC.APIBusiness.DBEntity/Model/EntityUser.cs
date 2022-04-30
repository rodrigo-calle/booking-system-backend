using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityUser : EntityBase
    {
        public int idusuario { get; set; }
        public string loginusuario { get; set; }
        public string passwordusuario { get; set; }
        public int idperfil { get; set; }
        public string nombres { get; set; }
        public string apellidopaterno { get; set; }
        public string apellidomaterno { get; set; }
        public string documentoidentidad { get; set; }
    }
}
