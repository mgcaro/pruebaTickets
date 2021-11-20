using System;
using System.Collections.Generic;

#nullable disable

namespace Tickets.Data
{
    public partial class Ticket
    {
        public int IdTicket { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int IdEstatus { get; set; }

        public virtual Estatus IdEstatusNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
