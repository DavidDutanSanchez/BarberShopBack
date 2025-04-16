namespace barbershop.model
{
    public partial class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; } = 0;
        public decimal? Commmision { get; set; } = 0;
        public DateTime? Fecha_registro { get; set; } = null!;

    }
}