using BackEnd.DTO;
using DAL.Implementations;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IDireccionService
    {
        public DireccionDTO AddDireccion(DireccionDTO direccion);
        public DireccionDTO UpdateDireccion(DireccionDTO direccion);
        public void DeleteDireccion(int id);
        public List<DireccionDTO> GetDirecciones();
        DireccionDTO GetDireccionByID(int id);
    }
}
