
using ECommerce.API.Model;
using ECommerce.API.Data;


namespace ECommerce.API.Repository;

public class DepartmentRepository : IDepartmentRepository
{

    private readonly ECommerceContext _eCommerceContext;
    public DepartmentRepository(ECommerceContext eCommerceContext) => _eCommerceContext = eCommerceContext;

    public IEnumerable<Department> GetAllDepartments()
    {

        return _eCommerceContext.Departments.ToList();

    }

    public Department? GetDepartmentById(int id)
    {
        return _eCommerceContext.Departments.Find(id);

    }
    public IEnumerable<Department>? GetDepartmentByName(string name)
    {
        return _eCommerceContext.Departments.Where(d => d.Name.Contains(name)).ToList();
    }
    public Department DeleteDepartmentById(int id)
    {
        var department = GetDepartmentById(id);
        _eCommerceContext.Departments.Remove(department!);
        _eCommerceContext.SaveChanges();

        return department;
    }

    public async Task<Department> AddDepartment(Department department)
    {

        await _eCommerceContext.Departments.AddAsync(department);
        await _eCommerceContext.SaveChangesAsync();
        return GetDepartmentById(department.Id);

    }


}