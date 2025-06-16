namespace barbershop.model
{
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