using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IPrealertaPaqueteService
    {
        PrealertaPaqueteDTO AddPrealertaPaquete(PrealertaPaqueteDTO prealertaPaquete);
        PrealertaPaqueteDTO UpdatePrealertaPaquete(PrealertaPaqueteDTO prealertaPaquete);
        void DeletePrealertaPaquete(int id);
        List<PrealertaPaqueteDTO> GetPrealertaPaquetes();
        PrealertaPaqueteDTO GetPrealertaPaqueteByID(int id);
    }
}
