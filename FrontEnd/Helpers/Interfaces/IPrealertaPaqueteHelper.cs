using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IPrealertaPaqueteHelper
    {
        void Add(PrealertaPaqueteViewModel prealertaPaquete);
        void Update(PrealertaPaqueteViewModel prealertaPaquete);
        void Delete(int id);
        List<PrealertaPaqueteViewModel> Get();
        PrealertaPaqueteViewModel GetByID(int id);
    }
}
