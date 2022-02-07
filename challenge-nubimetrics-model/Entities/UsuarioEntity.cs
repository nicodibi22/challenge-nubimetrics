using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_models.Entities
{
    public class UsuarioEntity
    {
        public virtual int Id { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        
        public UsuarioEntity()
        {            
        }

        public virtual void Validar()
        {
            StringBuilder sb = new StringBuilder();
            if (string.IsNullOrEmpty(this.Nombre))
            {
                sb.Append("El nombre no puede ser nulo. ");
            }
            if (string.IsNullOrEmpty(this.Apellido))
            {
                sb.Append("El apellido no puede ser nulo. ");
            }
            if (string.IsNullOrEmpty(this.Email))
            {
                sb.Append("El e-mail no puede ser nulo. ");
            }

            if (sb.ToString().Trim().Length > 0)
                throw new InvalidOperationException(sb.ToString());
        }
    }
}
