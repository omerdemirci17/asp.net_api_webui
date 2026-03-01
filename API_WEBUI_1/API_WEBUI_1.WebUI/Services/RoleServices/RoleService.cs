using API_WEBUI_1.Entity.Entities;
using API_WEBUI_1.WebUI.DTOs.RoleDTOs;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API_WEBUI_1.WebUI.Services.RoleServices
{
    public class RoleService(RoleManager<AppRole> _roleManager, IMapper _mapper) : IRoleService
    {
        public async Task CreateRoleAsync(CreateRoleDTO createRoleDTO)
        {
            var role = _mapper.Map<AppRole>(createRoleDTO);

            await _roleManager.CreateAsync(role);
        }

        public async Task DeleteRoleAsync(int id)
        {
            var value = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            await _roleManager.DeleteAsync(value);
            
        }

        public async Task<List<ResultRoleDTO>> GetAllRolesAsync()
        {
            var values = await _roleManager.Roles.ToListAsync();
            return _mapper.Map<List<ResultRoleDTO>>(values);
        }

        public async Task<UpdateRoleDTO> GetRoleByIdAsync(int id)
        {
            var value = await _roleManager.Roles.FirstOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<UpdateRoleDTO>(value);
        }
    }
}
