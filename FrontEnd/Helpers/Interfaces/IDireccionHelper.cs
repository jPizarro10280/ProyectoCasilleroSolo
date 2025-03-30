using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IDireccionHelper
    {
        DireccionViewModel Add(DireccionViewModel direccion);
        DireccionViewModel Update(DireccionViewModel direccion);
        void Delete(int id);
        List<DireccionViewModel> Get();
        DireccionViewModel GetByID(int id);
    }
}
