﻿namespace FrontEnd.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Contrasena { get; set; } = null!;

        public string? Telefono { get; set; }
    }
}
