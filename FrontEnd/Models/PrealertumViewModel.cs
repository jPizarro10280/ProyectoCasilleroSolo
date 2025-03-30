namespace FrontEnd.Models
{
    public class PrealertumViewModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public string NumeroSeguimiento { get; set; } = null!;

        public string? Descripcion { get; set; }

        public decimal Peso { get; set; }

        public string Estado { get; set; } = null!;

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }
    }
}
