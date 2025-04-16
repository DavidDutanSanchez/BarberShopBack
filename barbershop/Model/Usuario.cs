namespace barbershop.model
{
    public partial class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string usuario { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public DateTime? FechaCreacion { get; set; } = DateTime.Now;
        public string? Permisos { get; set; } = null!;
    }
}