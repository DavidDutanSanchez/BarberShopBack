using barbershop.model;

namespace barbershop.Interface
{
    public interface IControladorServicio
    {
        //CRUD Servicios
        Task<PaginationDto<Servicios>> AllServicios(QueryParams qParams);
        Task<string> UpdateServicios(Servicios Servicios);
        Task<string> AddServicios(Servicios Servicios);
        Task<string> DeleteServicios(Guid iD);
    }
}