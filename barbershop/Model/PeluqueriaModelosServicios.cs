namespace barbershop.model
{
    public partial class Servicios
    {
        public Guid IdServicio { get; set; } = Guid.NewGuid();
        public string NombreServicio { get; set; } = null!;
        public decimal CostoServicio { get; set; } = 0;
        public decimal ComisionServicio { get; set; } = 0;
        public virtual List<TicketsDetalle>? detalle_tickets { get; set; } = null!;
    }
}