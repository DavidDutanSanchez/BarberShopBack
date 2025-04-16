namespace barbershop.model
{
    public partial class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nombres { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public string Tipo_identificacion { get; set; } = null!;
        public DateOnly? Fecha_nacimiento { get; set; } = null!;

    }
}