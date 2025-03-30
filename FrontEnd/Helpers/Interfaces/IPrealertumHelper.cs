using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IPrealertumHelper
    {
        PrealertumViewModel Add(PrealertumViewModel prealertum);
        PrealertumViewModel Update(PrealertumViewModel prealertum);
        void Delete(int id);
        List<PrealertumViewModel> Get();
        PrealertumViewModel GetByID(int id);
    }
}
