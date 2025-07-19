using barbershop.Context;
using barbershop.Extensions;
using barbershop.Interface;
using barbershop.model;
using System.Text.Json;


namespace barbershop.Service
{
    public class PeluqueriaServiceTicket : IControladorTicket
    {
        private readonly PeluqueriaContext _context;
        private readonly ILogger<PeluqueriaServiceTicket> _logger;

        public PeluqueriaServiceTicket(PeluqueriaContext context,ILogger<PeluqueriaServiceTicket> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<string> AddTicketsCabecera(TicketsCabecera TicketsCabecera)
        {
            var response = "Realizado";
            try
            {

                TicketsCabecera.FechaTicket = DateTime.Now;

                if (TicketsCabecera.detalle_tickets != null)
                {
                    foreach (var det in TicketsCabecera.detalle_tickets)
                {
                    det.FechaTicketDet = DateTime.Now;
                }
                }
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

        public async Task<string> Delete(Guid iD)
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
        public Task<string> DeleteTicketsCabecera(Guid iD)
        {
            throw new NotImplementedException();
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
    }
}