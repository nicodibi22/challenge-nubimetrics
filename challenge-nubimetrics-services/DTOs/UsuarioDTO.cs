using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_services.DTOs
{
    public class UsuarioDTO
    {
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }

    }
}
