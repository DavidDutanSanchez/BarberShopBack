using barbershop.Context;
using barbershop.Dtos;
using barbershop.Extensions;
using barbershop.Interface;
using barbershop.model;
using barbershop.model.Parameters;
using Microsoft.EntityFrameworkCore;


namespace barbershop.Service
{
    public class PeluqueriaServiceTicket : IControladorTicket
    {
        private readonly PeluqueriaContext _context;
        private readonly ILogger<PeluqueriaServiceTicket> _logger;

        public PeluqueriaServiceTicket(PeluqueriaContext context, ILogger<PeluqueriaServiceTicket> logger)
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
        public async Task<PaginationDto<TicketsCabeceraDto>> AllTicketsCabecera(QueryParams qParams, bool estado)
        {
            try
            {
                var servicios = await _context.TicketsCabecera
                .Where(x => x.EstadoTicketCab == estado)
                .Select(x => new TicketsCabeceraDto
                {
                    idTickets = x.IdTickets,
                    fechaTicket = x.FechaTicket,
                    estadoTicketCab = x.EstadoTicketCab,
                    totalTicketCab = x.TotalTicketCab,
                    _usuario_id = x._usuario_id,
                    persona = x.usuario.persona
                })
                .OrderBy(c => c.fechaTicket)
                .ApplySearch(qParams.search, t => t.persona.NombresPersona, t => t.persona.ApellidosPersona)
                .OrderBy(qParams.orderBy ?? nameof(TicketsCabeceraDto.fechaTicket), qParams.isOrderByDescending)
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
        public async Task<string> DeleteTicketsCabecera(Guid iD)
        {
            var response = "Realizado";
            try
            {
                var anularTicket = await _context.TicketsCabecera
                    .Include(tc => tc.detalle_tickets)
                    .FirstOrDefaultAsync(x => x.IdTickets == iD);

                if (anularTicket == null)
                    return $"Cabecera no encontrada: {iD}";
                anularTicket.EstadoTicketCab = false;

                _ = _context.TicketsCabecera.Update(anularTicket);
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
        public async Task<TicketsCabeceraDto?> TicketsCabeceraById(Guid id)
        {
            var cabecera = await _context.TicketsCabecera
                .Include(tc => tc.usuario).ThenInclude(u => u.persona)
                .FirstOrDefaultAsync(x => x.IdTickets == id);

            if (cabecera == null)
                return null;

            var detalle = await _context.TicketsDetalle
                .Where(x => x._ticket_cabecera == id)
                .Select(x => new TicketsDetalleDto
                {
                    idTicketsDetalle = x.IdTicketsDetalle,
                    subTotalTicketDet = x.SubTotalTicketDet,
                    fechaTicketDet = x.FechaTicketDet,
                    _ticket_cabecera = x._ticket_cabecera,
                    _servicio_id = x._servicio_id,
                    cantidadTicketDet = x.CantidadTicketDet,
                    servicios = x.servicios_det == null
                        ? null
                        : new ServiciosDto
                        {
                            idServicio = x.servicios_det.IdServicio,
                            nombreServicio = x.servicios_det.NombreServicio,
                            costoServicio = x.servicios_det.CostoServicio,
                            comisionServicio = x.servicios_det.ComisionServicio
                        }
                })
                .ToListAsync();

            var dto = new TicketsCabeceraDto
            {
                idTickets = cabecera.IdTickets,
                fechaTicket = cabecera.FechaTicket,
                estadoTicketCab = cabecera.EstadoTicketCab,
                totalTicketCab = cabecera.TotalTicketCab,
                _usuario_id = cabecera._usuario_id,
                persona_nueva = new PersonaDto
                {
                    IdPersona = cabecera.usuario.persona.IdPersona,
                    CedulaPersona = cabecera.usuario.persona.CedulaPersona,
                    NombresPersona = cabecera.usuario.persona.NombresPersona,
                    ApellidosPersona = cabecera.usuario.persona.ApellidosPersona,
                },
                detalle_tickets = detalle
            };

            return dto;
        }

        public async Task<string> UpdateTicketsCabecera(TicketsCabecera TicketsCabecera)
        {
            var response = "Realizado";
            try
            {
                var existing = await _context.TicketsCabecera
                    .Include(c => c.detalle_tickets)
                    .FirstOrDefaultAsync(c => c.IdTickets == TicketsCabecera.IdTickets);

                if (existing == null)
                    return $"Cabecera no encontrada: {TicketsCabecera.IdTickets}";

                existing.FechaTicket = TicketsCabecera.FechaTicket;
                existing.EstadoTicketCab = TicketsCabecera.EstadoTicketCab;
                existing.TotalTicketCab = TicketsCabecera.TotalTicketCab;
                existing._usuario_id = TicketsCabecera._usuario_id;

                var incomingIds = new HashSet<Guid>(
                    TicketsCabecera.detalle_tickets?.Select(d => d.IdTicketsDetalle)
                    ?? Enumerable.Empty<Guid>()
                );

                foreach (var child in existing.detalle_tickets.ToList())
                {
                    if (!incomingIds.Contains(child.IdTicketsDetalle))
                        _context.TicketsDetalle.Remove(child);
                }

                foreach (var det in TicketsCabecera.detalle_tickets ?? Enumerable.Empty<TicketsDetalle>())
                {
                    var match = existing.detalle_tickets
                        .FirstOrDefault(d => d.IdTicketsDetalle == det.IdTicketsDetalle);

                    if (match != null)
                    {
                        match.SubTotalTicketDet = det.SubTotalTicketDet;
                        match.CantidadTicketDet = det.CantidadTicketDet;
                        match.FechaTicketDet = det.FechaTicketDet;
                        match._servicio_id = det._servicio_id;
                    }
                    else
                    {
                        var newDetail = new TicketsDetalle
                        {
                            IdTicketsDetalle = det.IdTicketsDetalle,
                            SubTotalTicketDet = det.SubTotalTicketDet,
                            CantidadTicketDet = det.CantidadTicketDet,
                            FechaTicketDet = det.FechaTicketDet,
                            _servicio_id = det._servicio_id,
                            _ticket_cabecera = existing.IdTickets
                        };
                        _ = await AddTicketsDetalle(newDetail);
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response = ex.InnerException?.Message + " mensaje: " + ex.Message;
                return response;
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