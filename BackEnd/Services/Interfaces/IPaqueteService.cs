using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IPaqueteService
    {
        void AddPaquete(PaqueteDTO paquete);
        void UpdatePaquete(PaqueteDTO paquete);
        void DeletePaquete(int id);
        List<PaqueteDTO> GetPaquetes();
        PaqueteDTO GetPaqueteByID(int id);
    }
}
