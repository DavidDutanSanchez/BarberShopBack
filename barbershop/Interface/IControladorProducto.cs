using barbershop.Dtos;
using barbershop.model;
using barbershop.model.Parameters;

namespace barbershop.Interface
{
    public interface IControladorProducto
    {
        //CRUD Productos
        Task<PaginationDto<Productos>> AllProductos(QueryParams qParams);
        Task<string> UpdateProductos(Productos Productos);
        Task<string> AddProductos(Productos Productos);
        Task<string> DeleteProductos(Guid iD);
    }
}