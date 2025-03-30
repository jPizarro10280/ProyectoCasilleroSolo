namespace FrontEnd.ApiModels
{
    public class PaqueteAPI
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string Estado { get; set; } = null!;

        public decimal? MontoTotal { get; set; }
    }
}
