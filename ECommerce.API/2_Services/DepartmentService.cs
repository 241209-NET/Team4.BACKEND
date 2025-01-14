
using ECommerce.API.Exceptions;
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
        return _departmentRepository.GetAllDepartments() ?? throw new NotFoundException("Check the Departments table in DB");
    }
    public Department? GetDepartmentById(int id)
    {
        return _departmentRepository.GetDepartmentById(id) ?? throw new NotFoundException("Department not found");
    }
    public IEnumerable<Department>? GetDepartmentByName(string name)
    {
        return _departmentRepository.GetDepartmentByName(name) ?? throw new NotFoundException("Department not found");
    }
    public Department DeleteDepartmentById(int id)
    {
        return _departmentRepository.DeleteDepartmentById(id) ?? throw new NotFoundException("Department not found");
    }

    public Task<Department> AddDepartment(Department department)
    {
        return _departmentRepository.AddDepartment(department) ?? throw new Exception("Invalid Department");
    }
}