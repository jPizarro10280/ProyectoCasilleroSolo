using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IUsuarioRolHelper
    {
        UsuarioRolViewModel Add(UsuarioRolViewModel usuarioRol);
        UsuarioRolViewModel Update(UsuarioRolViewModel usuarioRol);
        void Delete(int id);
        List<UsuarioRolViewModel> Get();
        UsuarioRolViewModel GetByID(int id);
    }
}
