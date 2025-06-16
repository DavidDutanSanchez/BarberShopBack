using barbershop.model;

namespace barbershop.Interface
{
    public interface IControladorFile
    {
        //CRUD Files
        Task<PaginationDto<Files>> AllFiles(QueryParams qParams);
        Task<string> UpdateFiles(Files Files);
        Task<string> AddFiles(Files Files);
        Task<string> DeleteFiles(Guid iD);
    }
}