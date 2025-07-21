using barbershop.Context;
using barbershop.Interface;
using barbershop.model;
using Microsoft.EntityFrameworkCore;
using barbershop.Dtos;
using barbershop.model.Parameters;

namespace barbershop.Service
{
    public class PeluqueriaServiceReporte : IControladorReporte
    {
        private readonly PeluqueriaContext _context;

        public PeluqueriaServiceReporte(PeluqueriaContext context)
        {
            _context = context;
        }

        public async Task<PaginationDto<ReporteTicket>> ObtenerReporteTicketsAsync(QueryParams qParams)
        {
            var resultado = from detalle in _context.TicketsDetalle
                            join cabecera in _context.TicketsCabecera on detalle._ticket_cabecera equals cabecera.IdTickets
                            join usuario in _context.Usuarios on cabecera._usuario_id equals usuario.IdUsuarios
                            join producto in _context.Productos on detalle._producto_id equals producto.Idproductos into prodJoin
                            from producto in prodJoin.DefaultIfEmpty()
                            join servicio in _context.Servicios on detalle._servicio_id equals servicio.IdServicio into servJoin
                            from servicio in servJoin.DefaultIfEmpty()
                            select new ReporteTicket
                            {
                                fechaTicket = cabecera.FechaTicket,
                                usuario = usuario.Usuario,
                                producto = producto != null ? producto.NombreProducto : "",
                                servicio = servicio != null ? servicio.NombreServicio : "",
                                cantidad = detalle.CantidadTicketDet,
                                subtotal = detalle.SubTotalTicketDet,
                                total = detalle.SubTotalTicketDet, 
                                costoUnitarioServicio = servicio != null ? servicio.CostoServicio : 0

                            };

            // ✅ Filtros por fecha
            if (!string.IsNullOrWhiteSpace(qParams.fechaInicio) && DateTime.TryParse(qParams.fechaInicio, out var inicio))
            {
                resultado = resultado.Where(x => x.fechaTicket.Date >= inicio.Date);
            }

            if (!string.IsNullOrWhiteSpace(qParams.fechaFin) && DateTime.TryParse(qParams.fechaFin, out var fin))
            {
                resultado = resultado.Where(x => x.fechaTicket.Date <= fin.Date);
            }

            var listado = resultado.ToList();

            return new PaginationDto<ReporteTicket>
            {
                data = listado.AsQueryable(),
                total = listado.Count,
                pageSize = qParams.pageSize,
                currentPage = qParams.page
            };
        }
    }
}
