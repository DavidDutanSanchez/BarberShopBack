using barbershop.Context;
using barbershop.Extensions;
using barbershop.Interface;
using barbershop.model;

namespace barbershop.Service
{
    public class PeluqueriaServiceProducto : IControladorProducto
    {
        private readonly PeluqueriaContext _context;
        public PeluqueriaServiceProducto(PeluqueriaContext context)
        {
            _context = context;

        }
        public async Task<string> AddProductos(Productos Productos)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Productos.Add(Productos);
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message + "Mensaje : " + ex.Message;
                return response;
            }
            return response;
        }
        public async Task<PaginationDto<Productos>> AllProductos(QueryParams qParams)
        {
            try
            {
                var productos = await _context.Productos
                .Select(x => new Productos
                {
                    Idproductos = x.Idproductos,
                    NombreProducto = x.NombreProducto,
                    // = x.CostoProducto,
                       CostroProducto   = x.CostroProducto  ,
                    StockProducto = x.StockProducto,
                    IvaProducto = x.IvaProducto,
                    CodigoProducto = x.CodigoProducto,

                })
                .OrderBy(c => c.NombreProducto)
                .GetPagedAsync(qParams);
                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message + " mensaje: " + ex.Message);
            }
        }
        public async Task<string> DeleteProductos(Guid iD)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Productos.Remove(_context.Productos.Where(x => x.Idproductos == iD).First());
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message;
                throw new Exception(response);
            }
            return response;
        }
        public async Task<string> UpdateProductos(Productos Productos)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Productos.Update(Productos);
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message;
                throw new Exception(response);
            }
            return response;
        }
    }
}