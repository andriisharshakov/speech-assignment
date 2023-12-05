using CompanyApi.Domain.Entities;
using CompanyApi.Domain.Repositories;

namespace CompanyApi.Application.Services
{
    public class DepartmentService: IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public virtual async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _departmentRepository.GetAllDepartmentsAsync();
        }

        public virtual async Task<Department> GetDepartmentByIdAsync(int departmentId)
        {
            return await _departmentRepository.GetDepartmentByIdAsync(departmentId);
        }

        public virtual async Task AddDepartmentAsync(Department department)
        {
            await _departmentRepository.AddDepartmentAsync(department);
        }

        public virtual async Task UpdateDepartmentAsync(Department department)
        {
            await _departmentRepository.UpdateDepartmentAsync(department);
        }

        public virtual async Task DeleteDepartmentAsync(int departmentId)
        {
            await _departmentRepository.DeleteDepartmentAsync(departmentId);
        }
    }
}
