using barbershop.Interface;
using barbershop.model;
using barbershop.Model;
using barbershop.Context;

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
                        total = cabecera.TotalTicketCab
                        // TotalServicios y TotalVecesServicio se agregan después
                    };

    var listado = resultado.ToList();

    // Total monetario acumulado de todos los servicios
    var totalServicios = listado.Sum(x => x.subtotal);

    // Conteo total de veces que se ha usado cada servicio
    var conteoServicios = listado
        .GroupBy(x => x.servicio)
        .Select(g => new
        {
            NombreServicio = g.Key,
            TotalVeces = g.Count()
        })
        .ToList();

    // Asignar los totales a cada registro
    foreach (var item in listado)
    {
        var conteo = conteoServicios.FirstOrDefault(c => c.NombreServicio == item.servicio);
        item.TotalServicios = totalServicios;
        item.TotalVecesServicio = conteo?.TotalVeces ?? 0;
    }

    var paginacion = new PaginationDto<ReporteTicket>
    {
        data = listado.AsQueryable(),
        total = listado.Count,
        pageSize = qParams.pageSize,
        currentPage = qParams.page
    };
    return paginacion;
}

    }
}