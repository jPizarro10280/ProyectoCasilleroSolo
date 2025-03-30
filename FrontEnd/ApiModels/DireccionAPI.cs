namespace FrontEnd.ApiModels
{
    public class DireccionAPI
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public string Linea1 { get; set; } = null!;

        public string? Linea2 { get; set; }

        public string Ciudad { get; set; } = null!;

        public string Estado { get; set; } = null!;

        public string CodigoPostal { get; set; } = null!;

        public string Pais { get; set; } = null!;
    }
}
