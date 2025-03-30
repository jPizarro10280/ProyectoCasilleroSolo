using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IDireccionHelper
    {
        void Add(DireccionViewModel direccion);
        void Update(DireccionViewModel direccion);
        void Delete(int id);
        List<DireccionViewModel> Get();
        DireccionViewModel GetByID(int id);
    }
}
