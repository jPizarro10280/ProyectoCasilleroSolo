using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IPaqueteHelper
    {
        void Add(PaqueteViewModel paquete);
        void Update(PaqueteViewModel paquete);
        void Delete(int id);
        List<PaqueteViewModel> Get();
        PaqueteViewModel GetByID(int id);
    }
}
