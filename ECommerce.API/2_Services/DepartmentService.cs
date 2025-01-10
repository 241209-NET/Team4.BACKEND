
using ECommerce.API.Model;
using ECommerce.API.Repository;
namespace ECommerce.API.Service;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;

    }

    public IEnumerable<Department> GetAllDepartments()
    {
        return _departmentRepository.GetAllDepartments();
    }
    public Department? GetDepartmentById(int id)
    {
        return _departmentRepository.GetDepartmentById(id);
    }
    public IEnumerable<Department>? GetDepartmentByName(string name)
    {
        return _departmentRepository.GetDepartmentByName(name);
    }
    public Department DeleteDepartmentById(int id)
    {
        return _departmentRepository.DeleteDepartmentById(id);
    }

    public Task<Department> AddDepartment(Department department)
    {
        return _departmentRepository.AddDepartment(department);
    }
}