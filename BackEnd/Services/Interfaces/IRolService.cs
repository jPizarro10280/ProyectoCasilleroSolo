using BackEnd.DTO;
using Entities.Entities;

namespace BackEnd.Services.Interfaces
{
    public interface IRolService
    {
        void AddRol(RolDTO rol);
        void UpdateRol(RolDTO rol);
        void DeleteRol(int id);
        List<RolDTO> GetRoles();
        RolDTO GetRolByID(int id);
    }
}
