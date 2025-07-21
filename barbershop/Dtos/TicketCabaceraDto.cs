using barbershop.model;

namespace barbershop.Dtos
{
    public partial class TicketsCabeceraDto
    {
        public Guid idTickets { get; set; }
        public DateTime fechaTicket { get; set; }
        public bool estadoTicketCab { get; set; }
        public decimal totalTicketCab { get; set; }
        public Guid _usuario_id { get; set; }
        public virtual PersonaDto? persona_nueva { get; set; }
        public virtual Personas? persona { get; set; }
        public virtual List<TicketsDetalleDto>? detalle_tickets { get; set; }
    }
    public partial class TicketsDetalleDto
    {
        public Guid idTicketsDetalle { get; set; }
        public decimal subTotalTicketDet { get; set; }
        public DateTime fechaTicketDet { get; set; }
        public Guid _ticket_cabecera { get; set; }
        public Guid? _servicio_id { get; set; }
        public Guid? _producto_id { get; set; }
        public int cantidadTicketDet { get; set; }
        public virtual ServiciosDto? servicios { get; set; } = null!;
    }
    public partial class ServiciosDto
    {
        public Guid idServicio { get; set; }
        public string nombreServicio { get; set; }
        public decimal costoServicio { get; set; }
        public decimal comisionServicio { get; set; }
    }

    public partial class PersonaDto 
    {
        public Guid IdPersona { get; set; } = Guid.NewGuid();
        public string CedulaPersona { get; set; } = null!;
        public string NombresPersona { get; set; } = null!;
        public string ApellidosPersona { get; set; } = null!;
    }
}
