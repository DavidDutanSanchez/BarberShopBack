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
    }
}