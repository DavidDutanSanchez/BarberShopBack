namespace barbershop.model
{
    public partial class TicketsCabecera
    {
        public Guid IdTickets { get; set; } = Guid.NewGuid();
        public DateTime FechaTicket { get; set; } = DateTime.Now;
        public bool EstadoTicketCab { get; set; } = false;
        public decimal TotalTicketCab { get; set; } = 0;
        public Guid _usuario_id { get; set; } = Guid.NewGuid();
        public virtual Usuarios? usuario { get; set; } = null!;
        public virtual List<TicketsDetalle>? detalle_tickets { get; set; } = null!;
    }
    public partial class TicketsDetalle
    {
        public Guid IdTicketsDetalle { get; set; } = Guid.NewGuid();
        public decimal SubTotalTicketDet { get; set; } = 0;
        public DateTime FechaTicketDet { get; set; } = DateTime.Now;
        public Guid _ticket_cabecera { get; set; } = Guid.NewGuid();
        public Guid? _servicio_id { get; set; } = Guid.NewGuid();
        public Guid? _producto_id { get; set; } = null!;
        public int CantidadTicketDet { get; set; } = 0;
        public virtual TicketsCabecera? ticektCabecera { get; set; } = null!;
        public virtual Servicios? servicios_det { get; set; } = null!;
        public virtual Productos? productos_det { get; set; } = null!;
    }
}