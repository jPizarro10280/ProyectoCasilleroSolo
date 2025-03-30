using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IUsuarioRolService
    {
        void AddUsuarioRol(UsuarioRolDTO usuarioRol);
        void UpdateUsuarioRol(UsuarioRolDTO usuarioRol);
        void DeleteUsuarioRol(int id);
        List<UsuarioRolDTO> GetUsuarioRoles();
        UsuarioRolDTO GetUsuarioRolByID(int id);
    }
}
