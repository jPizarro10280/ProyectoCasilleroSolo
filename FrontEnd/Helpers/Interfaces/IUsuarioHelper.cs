using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IUsuarioHelper
    {
        UsuarioViewModel Add(UsuarioViewModel usuario);
        UsuarioViewModel Update(UsuarioViewModel usuario);
        void Delete(int id);
        List<UsuarioViewModel> Get();
        UsuarioViewModel GetByID(int id);
    }
}
