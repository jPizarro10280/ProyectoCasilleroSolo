using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IRolHelper
    {
        void Add(RolViewModel rol);
        void Update(RolViewModel rol);
        void Delete(int id);
        List<RolViewModel> Get();
        RolViewModel GetByID(int id);
    }
}
