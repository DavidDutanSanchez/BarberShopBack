using barbershop.Context;
using barbershop.Extensions;
using barbershop.Interface;
using barbershop.model;

namespace barbershop.Service
{
    public class PeluqueriaService : IControladorPersona
    {
        private readonly PeluqueriaContext _context;
        public PeluqueriaService(PeluqueriaContext context)
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

        public async Task<string> AddTicketsCabecera(TicketsCabecera TicketsCabecera)
        {
            var response = "Realizado";
            try
            {
                _ = _context.TicketsCabecera.Add(TicketsCabecera);
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message + "Mensaje : " + ex.Message;
                return response;
            }
            return response;
        }

        public async Task<string> AddTicketsDetalle(TicketsDetalle TicketsDetalle)
        {
            var response = "Realizado";
            try
            {
                _ = _context.TicketsDetalle.Add(TicketsDetalle);
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message + "Mensaje : " + ex.Message;
                return response;
            }
            return response;
        }

        public async Task<string> AddUsuarios(Usuarios Usuarios)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Usuarios.Add(Usuarios);
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
                    ExtensionFiles = x.ExtensionFiles,
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

        public async Task<PaginationDto<Productos>> AllProductos(QueryParams qParams)
        {
            try
            {
                var productos = await _context.Productos
                .Select(x => new Productos
                {
                    Idproductos = x.Idproductos,
                    NombreProducto = x.NombreProducto,
                    CostoProducto = x.CostoProducto,
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

        public async Task<PaginationDto<TicketsCabecera>> AllTicketsCabecera(QueryParams qParams)
        {
            try
            {
                var servicios = await _context.TicketsCabecera
                .Select(x => new TicketsCabecera
                {
                    IdTickets = x.IdTickets,
                    FechaTicket = x.FechaTicket,
                    EstadoTicketCab = x.EstadoTicketCab,
                    TotalTicketCab = x.TotalTicketCab,
                    _usuario_id = x._usuario_id,

                })
                .OrderBy(c => c.FechaTicket)
                .GetPagedAsync(qParams);
                return servicios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message + " mensaje: " + ex.Message);
            }
        }

        public async Task<PaginationDto<TicketsDetalle>> AllTicketsDetalle(QueryParams qParams)
        {
            try
            {
                var servicios = await _context.TicketsDetalle
                .Select(x => new TicketsDetalle
                {
                    IdTicketsDetalle = x.IdTicketsDetalle,
                    SubTotalTicketDet = x.SubTotalTicketDet,
                    FechaTicketDet = x.FechaTicketDet,
                    _ticket_cabecera = x._ticket_cabecera,
                    _servicio_id = x._servicio_id,
                    _producto_id = x._producto_id,

                })
                .OrderBy(c => c.FechaTicketDet)
                .GetPagedAsync(qParams);
                return servicios;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException?.Message + " mensaje: " + ex.Message);
            }
        }

        public async Task<PaginationDto<Usuarios>> AllUsuarios(QueryParams qParams)
        {
            try
            {
                var servicios = await _context.Usuarios
                .Select(x => new Usuarios
                {
                    IdUsuarios = x.IdUsuarios,
                    Usuario = x.Usuario,
                    ContraseniaUsuarios = x.ContraseniaUsuarios,
                    permisosUsuarios = x.permisosUsuarios,
                    _persona_id = x._persona_id,

                })
                .OrderBy(c => c.Usuario)
                .GetPagedAsync(qParams);
                return servicios;
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
                response = ex.InnerException?.Message;
                throw new Exception(response);
            }
            return response;
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

        public async Task<string> DeleteTicketsCabecera(Guid iD)
        {
            var response = "Realizado";
            try
            {
                _ = _context.TicketsCabecera.Remove(_context.TicketsCabecera.Where(x => x.IdTickets == iD).First());
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message;
                throw new Exception(response);
            }
            return response;
        }

        public async Task<string> DeleteTicketsDetalle(Guid iD)
        {
            var response = "Realizado";
            try
            {
                _ = _context.TicketsDetalle.Remove(_context.TicketsDetalle.Where(x => x.IdTicketsDetalle == iD).First());
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message;
                throw new Exception(response);
            }
            return response;
        }

        public async Task<string> DeleteUsuarios(Guid iD)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Usuarios.Remove(_context.Usuarios.Where(x => x.IdUsuarios == iD).First());
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

        public async Task<string> UpdateTicketsCabecera(TicketsCabecera TicketsCabecera)
        {
            var response = "Realizado";
            try
            {
                _ = _context.TicketsCabecera.Update(TicketsCabecera);
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message;
                throw new Exception(response);
            }
            return response;
        }

        public async Task<string> UpdateTicketsDetalle(TicketsDetalle TicketsDetalle)
        {
            var response = "Realizado";
            try
            {
                _ = _context.TicketsDetalle.Update(TicketsDetalle);
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message;
                throw new Exception(response);
            }
            return response;
        }

        public async Task<string> UpdateUsuarios(Usuarios Usuarios)
        {
            var response = "Realizado";
            try
            {
                _ = _context.Usuarios.Update(Usuarios);
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