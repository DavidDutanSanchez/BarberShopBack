namespace barbershop.model
{
    public partial class Files
    {
        public Guid IdFiles { get; set; } = Guid.NewGuid();
        //public string ExtensionFiles { get; set; } = null!;
          public string ExtencionFiles { get; set; } = null!;
        public decimal TamanioFiles { get; set; } = 0;
        public string PathFiles { get; set; } = null!;
        public string NombreArchivoFiles { get; set; } = null!;
        public Guid _persona_id { get; set; } = Guid.NewGuid();
        public virtual Personas? persona { get; set; } = null!;
    }
}