

using ECommerce.API.Model;
using ECommerce.API.Service;
using Microsoft.AspNetCore.Mvc;


[Route("/[controller]")]
[ApiController]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentController(IDepartmentService departmentService) => _departmentService = departmentService;

    [HttpGet]
    public IActionResult GetAllDepartments()
    {
        var departmentList = _departmentService.GetAllDepartments();
        return Ok(departmentList);
    }

    [HttpGet("id/{id}")]
    public IActionResult GetDepartmentById(int id)
    {
        return Ok(_departmentService.GetDepartmentById(id));
    }

    [HttpGet("name/{name}")]
    public IActionResult GetDepartmentByName(string name)
    {
        return Ok(_departmentService.GetDepartmentByName(name));
    }

    [HttpPost]
    public IActionResult AddDepartment(Department department)
    {
        return Ok(_departmentService.AddDepartment(department));
    }

    [HttpDelete]
    public IActionResult DeleteDepartment(int id)
    {
        return Ok(_departmentService.DeleteDepartmentById(id));
    }

}