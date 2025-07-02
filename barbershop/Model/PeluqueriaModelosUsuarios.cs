using System.ComponentModel.DataAnnotations.Schema;

namespace barbershop.model
{
    public partial class Usuarios
    {
        public Guid IdUsuarios { get; set; } = Guid.NewGuid();
        public string Usuario { get; set; } = null!;
        //public string ContraseniaUsuarios { get; set; } = null!;
        public byte[] ContraseniaUsuarios { get; set; } = null!;
        public string permisosUsuarios { get; set; } = null!;
        public Guid _persona_id { get; set; } = Guid.NewGuid();
        public virtual Personas? persona { get; set; } = null!;
        public virtual List<TicketsCabecera>? list_ticket_cabs { get; set; } = null!;
        [NotMapped]
        public string? PersonaNombreCompleto { get; set; }
    }

    public class LoginRequest
    {
        public string Usuario { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
    }

   public class UsuarioLoginDto
    {
        public string Usuario { get; set; } = string.Empty;
        public string Contrasenia { get; set; } = string.Empty;
    }


}