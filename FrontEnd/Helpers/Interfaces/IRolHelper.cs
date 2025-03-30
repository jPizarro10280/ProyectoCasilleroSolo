using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IRolHelper
    {
        RolViewModel Add(RolViewModel rol);
        RolViewModel Update(RolViewModel rol);
        void Delete(int id);
        List<RolViewModel> Get();
        RolViewModel GetByID(int id);
    }
}
