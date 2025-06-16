namespace barbershop.model
{
    public partial class TicketsCabecera
    {
        public Guid IdTickets { get; set; } = Guid.NewGuid();
        public DateTime FechaTicket { get; set; } = DateTime.Now;
        public byte EstadoTicketCab { get; set; } = 0;
        public decimal TotalTicketCab { get; set; } = 0;
        public Guid _usuario_id { get; set; } = Guid.NewGuid();
        public virtual Usuarios usuario { get; set; } = null!;
        public virtual List<TicketsDetalle>? detalle_tickets { get; set; } = null!;
    }
    public partial class TicketsDetalle
    {
        public Guid IdTicketsDetalle { get; set; } = Guid.NewGuid();
        public decimal SubTotalTicketDet { get; set; } = 0;
        public DateTime FechaTicketDet { get; set; } = DateTime.Now;
        public Guid _ticket_cabecera { get; set; } = Guid.NewGuid();
        public Guid _servicio_id { get; set; } = Guid.NewGuid();
        public Guid _producto_id { get; set; } = Guid.NewGuid();
        public virtual TicketsCabecera? ticektCabecera { get; set; } = null!;
        public virtual Servicios? servicios { get; set; } = null!;
        public virtual Productos? productos { get; set; } = null!;
    }
}