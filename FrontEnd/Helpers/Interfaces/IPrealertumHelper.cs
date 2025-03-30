using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IPrealertumHelper
    {
        void Add(PrealertumViewModel prealertum);
        void Update(PrealertumViewModel prealertum);
        void Delete(int id);
        List<PrealertumViewModel> Get();
        PrealertumViewModel GetByID(int id);
    }
}
