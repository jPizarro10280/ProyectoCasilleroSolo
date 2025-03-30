using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IPrealertaPaqueteHelper
    {
        PrealertaPaqueteViewModel Add(PrealertaPaqueteViewModel prealertaPaquete);
        PrealertaPaqueteViewModel Update(PrealertaPaqueteViewModel prealertaPaquete);
        void Delete(int id);
        List<PrealertaPaqueteViewModel> Get();
        PrealertaPaqueteViewModel GetByID(int id);
    }
}
