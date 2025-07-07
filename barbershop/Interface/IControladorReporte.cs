
using barbershop.model;
using barbershop.Model;



namespace barbershop.Interface
{
    public interface IControladorReporte
    {
        //Task<<ReporteTicket>> ObtenerReporteTicketsAsync();
        Task<PaginationDto<ReporteTicket>> ObtenerReporteTicketsAsync(QueryParams qParams);
    }
}
