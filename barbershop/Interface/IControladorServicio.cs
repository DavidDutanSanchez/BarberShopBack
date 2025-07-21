using barbershop.Dtos;
using barbershop.model;
using barbershop.model.Parameters;

namespace barbershop.Interface
{
    public interface IControladorServicio
    {
        Task<PaginationDto<Servicios>> AllServicios(QueryParams qParams);
        Task<string> UpdateServicios(Servicios Servicios);
        Task<string> AddServicios(Servicios Servicios);
        Task<string> DeleteServicios(Guid iD);
    }
}