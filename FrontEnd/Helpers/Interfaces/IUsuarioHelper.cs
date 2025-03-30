using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IUsuarioHelper
    {
        void Add(UsuarioViewModel usuario);
        void Update(UsuarioViewModel usuario);
        void Delete(int id);
        List<UsuarioViewModel> Get();
        UsuarioViewModel GetByID(int id);
    }
}
