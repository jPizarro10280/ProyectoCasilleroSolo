using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IPrealertumService
    {
        PrealertumDTO AddPrealertum(PrealertumDTO prealertum);
        PrealertumDTO UpdatePrealertum(PrealertumDTO prealertum);
        void DeletePrealertum(int id);
        List<PrealertumDTO> GetPrealertums();
        PrealertumDTO GetPrealertumByID(int id);
    }
}
