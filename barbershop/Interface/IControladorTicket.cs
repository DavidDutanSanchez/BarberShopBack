using barbershop.model;

namespace barbershop.Interface
{
    public interface IControladorTicket
    {
        //CRUD TicketsCabecera
        Task<PaginationDto<TicketsCabecera>> AllTicketsCabecera(QueryParams qParams);
        Task<string> UpdateTicketsCabecera(TicketsCabecera TicketsCabecera);
        Task<string> AddTicketsCabecera(TicketsCabecera TicketsCabecera);
        Task<string> DeleteTicketsCabecera(Guid iD);
        //CRUD TicketsDetalle
        Task<PaginationDto<TicketsDetalle>> AllTicketsDetalle(QueryParams qParams);
        Task<string> UpdateTicketsDetalle(TicketsDetalle TicketsDetalle);
        Task<string> AddTicketsDetalle(TicketsDetalle TicketsDetalle);
        Task<string> DeleteTicketsDetalle(Guid iD);
    }
}