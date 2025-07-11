namespace barbershop.Model
{
   public class ReporteTicket
{
    public DateTime fechaTicket { get; set; }
    public string usuario { get; set; }
    public string producto { get; set; }
    public string servicio { get; set; }
    public int cantidad { get; set; }
    public decimal subtotal { get; set; }
    public decimal total { get; set; }

    public decimal TotalServicios { get; set; }

    public int TotalVecesServicio { get; set; }
}

}