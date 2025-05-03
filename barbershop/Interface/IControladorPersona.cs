using barbershop.model;

namespace barbershop.Interface
{
    public interface IControladorPersona
    {
        //CRUD Personas
        Task<PaginationDto<Personas>> AllPersonas(QueryParams qParams);
        Task<string> UpdatePersonas(Personas Personas);
        Task<string> AddPersonas(Personas Personas);
        Task<string> DeletePersonas(Guid iD);
        //CRUD Files
        Task<PaginationDto<Files>> AllFiles(QueryParams qParams);
        Task<string> UpdateFiles(Files Files);
        Task<string> AddFiles(Files Files);
        Task<string> DeleteFiles(Guid iD);
        //CRUD Productos
        Task<PaginationDto<Productos>> AllProductos(QueryParams qParams);
        Task<string> UpdateProductos(Productos Productos);
        Task<string> AddProductos(Productos Productos);
        Task<string> DeleteProductos(Guid iD);
        //CRUD Servicios
        Task<PaginationDto<Servicios>> AllServicios(QueryParams qParams);
        Task<string> UpdateServicios(Servicios Servicios);
        Task<string> AddServicios(Servicios Servicios);
        Task<string> DeleteServicios(Guid iD);
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
        //CRUD Usuarios
        Task<PaginationDto<Usuarios>> AllUsuarios(QueryParams qParams);
        Task<string> UpdateUsuarios(Usuarios Usuarios);
        Task<string> AddUsuarios(Usuarios Usuarios);
        Task<string> DeleteUsuarios(Guid iD);

    }
}