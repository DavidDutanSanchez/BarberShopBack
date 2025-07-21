using barbershop.Dtos;
using barbershop.model;
using barbershop.model.Parameters;

namespace barbershop.Interface
{
    public interface IControladorReporte
    {
        //Task<<ReporteTicket>> ObtenerReporteTicketsAsync();
        Task<PaginationDto<ReporteTicket>> ObtenerReporteTicketsAsync(QueryParams qParams);
    }
}
