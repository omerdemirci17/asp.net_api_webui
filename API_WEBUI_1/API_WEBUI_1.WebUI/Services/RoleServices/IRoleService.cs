using API_WEBUI_1.WebUI.DTOs.RoleDTOs;

namespace API_WEBUI_1.WebUI.Services.RoleServices
{
    public interface IRoleService
    {
        Task<List<ResultRoleDTO>> GetAllRolesAsync();
        Task<UpdateRoleDTO> GetRoleByIdAsync(int id);

        Task CreateRoleAsync(CreateRoleDTO createRoleDTO);
        Task DeleteRoleAsync(int id);
    }
}
