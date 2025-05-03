namespace barbershop.model
{
    public partial class Personas
    {
        public Guid IdPersona { get; set; } = Guid.NewGuid();
        public string CedulaPersona { get; set; } = null!;
        public string NombresPersona { get; set; } = null!;
        public string ApellidosPersona { get; set; } = null!;
        public string DireccionPersona { get; set; } = null!;
        public DateTime FechaNacimientoPersona { get; set; } = DateTime.Now;
        public string CelularPersona { get; set; } = null!;
        public string CorreoPersona { get; set; } = null!;
        public virtual List<Files>? _archivos { get; set; } = null!;
        public virtual List<Usuarios>? _usuarios { get; set; } = null!;
    }
    public partial class Files
    {
        public Guid IdFiles { get; set; } = Guid.NewGuid();
        public string ExtensionFiles { get; set; } = null!;
        public decimal TamanioFiles { get; set; } = 0;
        public string PathFiles { get; set; } = null!;
        public string NombreArchivoFiles { get; set; } = null!;
        public Guid _persona_id { get; set; } = Guid.NewGuid();
        public virtual Personas? persona { get; set; } = null!;
    }
    public partial class Productos
    {
        public Guid Idproductos { get; set; } = Guid.NewGuid();
        public string NombreProducto { get; set; } = null!;
        public decimal CostoProducto { get; set; } = 0;
        public int StockProducto { get; set; } = 0;
        public decimal IvaProducto { get; set; } = 0;
        public string CodigoProducto { get; set; } = null!;
        public virtual List<TicketsDetalle>? detalle_tickets { get; set; } = null!;
    }
    public partial class Servicios
    {
        public Guid IdServicio { get; set; } = Guid.NewGuid();
        public string NombreServicio { get; set; } = null!;
        public decimal CostoServicio { get; set; } = 0;
        public decimal ComisionServicio { get; set; } = 0;
        public virtual List<TicketsDetalle>? detalle_tickets { get; set; } = null!;
    }
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
    public partial class Usuarios
    {
        public Guid IdUsuarios { get; set; } = Guid.NewGuid();
        public string Usuario { get; set; } = null!;
        public string ContraseniaUsuarios { get; set; } = null!;
        public string permisosUsuarios { get; set; } = null!;
        public Guid _persona_id { get; set; } = Guid.NewGuid();
        public virtual Personas? persona { get; set; } = null!;
        public virtual List<TicketsCabecera>? list_ticket_cabs { get; set; } = null!;
    }
}