using barbershop.model;

namespace barbershop.Interface
{
    public interface IControladorUsuario
    {
        //CRUD Usuarios
        Task<PaginationDto<Usuarios>> AllUsuarios(QueryParams qParams);
        Task<string> UpdateUsuarios(Usuarios Usuarios);
        Task<string> AddUsuarios(Usuarios Usuarios);
        Task<string> DeleteUsuarios(Guid iD);
    }
}