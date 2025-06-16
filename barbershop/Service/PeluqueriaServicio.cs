using barbershop.Context;
using barbershop.Extensions;
using barbershop.Interface;
using barbershop.model;

namespace barbershop.Service
{
    public class PeluqueriaServiceServicio : IControladorServicio
    {
        private readonly PeluqueriaContext _context;
        public PeluqueriaServiceServicio(PeluqueriaContext context)
        {
            _context = context;

        }
        public async Task<string> AddServicios(Servicios Servicios)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Servicios.Add(Servicios);
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message + "Mensaje : " + ex.Message;
                return response;
            }
            return response;
        }
        public async Task<PaginationDto<Servicios>> AllServicios(QueryParams qParams)
        {
            try
            {
                var servicios = await _context.Servicios
                .Select(x => new Servicios
                {
                    IdServicio = x.IdServicio,
                    NombreServicio = x.NombreServicio,
                    CostoServicio = x.CostoServicio,
                    ComisionServicio = x.ComisionServicio,

                })
                .OrderBy(c => c.NombreServicio)
                .GetPagedAsync(qParams);
                return servicios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message + " mensaje: " + ex.Message);
            }
        }
        public async Task<string> DeleteServicios(Guid iD)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Servicios.Remove(_context.Servicios.Where(x => x.IdServicio == iD).First());
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message;
                throw new Exception(response);
            }
            return response;
        }
                public async Task<string> UpdateServicios(Servicios Servicios)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Servicios.Update(Servicios);
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