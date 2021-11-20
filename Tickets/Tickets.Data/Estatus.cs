using System;
using System.Collections.Generic;

#nullable disable

namespace Tickets.Data
{
    public partial class Estatus
    {
        public Estatus()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int IdEstatus { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
