using barbershop.Context;
using barbershop.Dtos;
using barbershop.Extensions;
using barbershop.Interface;
using barbershop.model;
using barbershop.model.Parameters;

namespace barbershop.Service
{
    public class PeluqueriaServiceFile : IControladorFile
    {
        private readonly PeluqueriaContext _context;
        public PeluqueriaServiceFile(PeluqueriaContext context)
        {
            _context = context;

        }

        public async Task<string> AddFiles(Files Files)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Files.Add(Files);
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message + "Mensaje : " + ex.Message;
                return response;
            }
            return response;
        }
        public async Task<PaginationDto<Files>> AllFiles(QueryParams qParams)
        {
            try
            {
                var files = await _context.Files
                .Select(x => new Files
                {
                    IdFiles = x.IdFiles,
                    //ExtensionFiles = x.ExtensionFiles,
                        ExtencionFiles = x.ExtencionFiles,
                    TamanioFiles = x.TamanioFiles,
                    PathFiles = x.PathFiles,
                    NombreArchivoFiles = x.NombreArchivoFiles,
                    _persona_id = x._persona_id,

                })
                .OrderBy(c => c.NombreArchivoFiles)
                .GetPagedAsync(qParams);
                return files;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message + " mensaje: " + ex.Message);
            }
        }
        public async Task<string> DeleteFiles(Guid iD)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Files.Remove(_context.Files.Where(x => x.IdFiles == iD).First());
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message;
                throw new Exception(response);
            }
            return response;
        }
        public async Task<string> UpdateFiles(Files Files)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Files.Update(Files);
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