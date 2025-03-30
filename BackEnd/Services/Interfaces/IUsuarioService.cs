using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IUsuarioService
    {
        UsuarioDTO AddUsuario(UsuarioDTO usuario);
        UsuarioDTO UpdateUsuario(UsuarioDTO usuario);
        void DeleteUsuario(int id);
        List<UsuarioDTO> GetUsuarios();
        UsuarioDTO GetUsuarioByID(int id);
    }
}
