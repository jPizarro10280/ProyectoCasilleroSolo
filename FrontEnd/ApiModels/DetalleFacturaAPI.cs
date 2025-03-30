namespace FrontEnd.ApiModels
{
    public class DetalleFacturaAPI
    {
        public int Id { get; set; }
        public int FacturaId { get; set; }

        public string Concepto { get; set; } = null!;

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal { get; set; }
    }
}
