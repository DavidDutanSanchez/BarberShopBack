namespace barbershop.model
{
    public partial class Productos
    {
        public Guid Idproductos { get; set; } = Guid.NewGuid();
        public string NombreProducto { get; set; } = null!;
        public decimal CostoProducto { get; set; } = 0;
        public int StockProducto { get; set; } = 0;
        public decimal IvaProducto { get; set; } = 0;
        public string CodigoProducto { get; set; } = null!;
        public virtual List<TicketsDetalle>? detalle_tickets { get; set; } = null!;
    }
}