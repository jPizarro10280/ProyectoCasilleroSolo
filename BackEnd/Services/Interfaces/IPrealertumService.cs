using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IPrealertumService
    {
        void AddPrealertum(PrealertumDTO prealertum);
        void UpdatePrealertum(PrealertumDTO prealertum);
        void DeletePrealertum(int id);
        List<PrealertumDTO> GetPrealertums();
        PrealertumDTO GetPrealertumByID(int id);
    }
}
