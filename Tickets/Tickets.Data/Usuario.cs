using System;
using System.Collections.Generic;

#nullable disable

namespace Tickets.Data
{
    public partial class Usuario
    {
        public Usuario()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string NumeroIdentificacion { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
