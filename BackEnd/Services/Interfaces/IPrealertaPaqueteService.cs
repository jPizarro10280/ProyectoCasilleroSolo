using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IPrealertaPaqueteService
    {
        void AddPrealertaPaquete(PrealertaPaqueteDTO prealertaPaquete);
        void UpdatePrealertaPaquete(PrealertaPaqueteDTO prealertaPaquete);
        void DeletePrealertaPaquete(int id);
        List<PrealertaPaqueteDTO> GetPrealertaPaquetes();
        PrealertaPaqueteDTO GetPrealertaPaqueteByID(int id);
    }
}
