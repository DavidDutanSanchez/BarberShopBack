using barbershop.Context;
using barbershop.Extensions;
using barbershop.Interface;
using barbershop.model;

namespace barbershop.Service
{
    public class PeluqueriaServicePersona : IControladorPersona
    {
        private readonly PeluqueriaContext _context;
        public PeluqueriaServicePersona(PeluqueriaContext context)
        {
            _context = context;

        }
        public async Task<string> AddPersonas(Personas Personas)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Personas.Add(Personas);
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message + "Mensaje : " + ex.Message;
                return response;
            }
            return response;
        }
        public async Task<PaginationDto<Personas>> AllPersonas(QueryParams qParams)
        {
            try
            {
                var personas = await _context.Personas
                .Select(x => new Personas
                {
                    IdPersona = x.IdPersona,
                    CedulaPersona = x.CedulaPersona,
                    NombresPersona = x.NombresPersona,
                    ApellidosPersona = x.ApellidosPersona,
                    DireccionPersona = x.DireccionPersona,
                    FechaNacimientoPersona = x.FechaNacimientoPersona,
                    CelularPersona = x.CelularPersona,
                    CorreoPersona = x.CorreoPersona,

                })
                .OrderBy(c => c.NombresPersona)
                .GetPagedAsync(qParams);
                return personas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message + " mensaje: " + ex.Message);
            }
        }
        public async Task<string> DeletePersonas(Guid iD)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Personas.Remove(_context.Personas.Where(x => x.IdPersona == iD).First());
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message + " mensaje: " + ex.Message);
            }
            return response;
        }
        public async Task<string> UpdatePersonas(Personas Personas)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Personas.Update(Personas);
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