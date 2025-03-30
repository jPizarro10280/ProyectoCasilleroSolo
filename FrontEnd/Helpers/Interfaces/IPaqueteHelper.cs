using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IPaqueteHelper
    {
        PaqueteViewModel Add(PaqueteViewModel paquete);
        PaqueteViewModel Update(PaqueteViewModel paquete);
        void Delete(int id);
        List<PaqueteViewModel> Get();
        PaqueteViewModel GetByID(int id);
    }
}
