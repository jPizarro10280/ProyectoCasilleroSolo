using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IUsuarioRolHelper
    {
        void Add(UsuarioRolViewModel usuarioRol);
        void Update(UsuarioRolViewModel usuarioRol);
        void Delete(int id);
        List<UsuarioRolViewModel> Get();
        UsuarioRolViewModel GetByID(int id);
    }
}
