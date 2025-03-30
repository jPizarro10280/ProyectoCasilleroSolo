using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IUsuarioRolService
    {
        UsuarioRolDTO AddUsuarioRol(UsuarioRolDTO usuarioRol);
        UsuarioRolDTO UpdateUsuarioRol(UsuarioRolDTO usuarioRol);
        void DeleteUsuarioRol(int id);
        List<UsuarioRolDTO> GetUsuarioRoles();
        UsuarioRolDTO GetUsuarioRolByID(int id);
    }
}
