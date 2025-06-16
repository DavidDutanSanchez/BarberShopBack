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
}