namespace FrontEnd.Models
{
    public class FacturaViewModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int PaqueteId { get; set; }
        public DateTime FechaEmision { get; set; }

        public decimal MontoTotal { get; set; }

        public decimal Impuestos { get; set; }

        public string Estado { get; set; } = null!;
    }
}
