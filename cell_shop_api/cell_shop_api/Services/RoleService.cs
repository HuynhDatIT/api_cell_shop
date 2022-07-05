using AutoMapper;
using cell_shop_api.Services.InterfaceSevice;
using cell_shop_api.Unit_Of_Work;
using cell_shop_api.ViewModels.Request;
using cell_shop_api.ViewModels.Response;
using CellShop_Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace cell_shop_api.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateRoleAsync(string name)
        {
            var role = await _unitOfWork.RoleRepository.GetRoleByNameAsync(name);

            if (role != null) return false;

            var roleNew = new Role { Name = name };

            await _unitOfWork.RoleRepository.AddAsync(roleNew);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteRoleAsync(int id)
        {
            var role = await _unitOfWork.RoleRepository.GetByIdAsync(id);

            if (role == null) return false;

            role.Status = false;

            _unitOfWork.RoleRepository.Update(role);
            
            return _unitOfWork.SaveChanges() > 0;
        }

        public async Task<IEnumerable<GetRole>> GetAllAsync()
        {
            var roles = await _unitOfWork.RoleRepository.GetAllAsync();

            var getRoles = _mapper.Map<IEnumerable<GetRole>>(roles);

            return getRoles;
        }

        public async Task<GetRole> GetByIdAsync(int id)
        {
            var role = await _unitOfWork.RoleRepository.GetByIdAsync(id);

            var getrole = _mapper.Map<GetRole>(role);

            return getrole;
        }

        public async Task<bool> UpdateRoleAsync(UpdateRole updateRole)
        {
            var role = await _unitOfWork.RoleRepository.GetByIdAsync(updateRole.Id);

            if(role == null) return false;
           
            role.Name = updateRole.Name;

            _unitOfWork.RoleRepository.Update(role);

            return _unitOfWork.SaveChanges() > 0;
        }
    }
}
