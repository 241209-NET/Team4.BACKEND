

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
        try
        {
            var departmentList = _departmentService.GetAllDepartments();
            return Ok(departmentList);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("id/{id}")]
    public IActionResult GetDepartmentById(int id)
    {
        try
        {

            return Ok(_departmentService.GetDepartmentById(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("name/{name}")]
    public IActionResult GetDepartmentByName(string name)
    {
        try
        {

            return Ok(_departmentService.GetDepartmentByName(name));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult AddDepartment(Department department)
    {
        try
        {

            return Ok(_departmentService.AddDepartment(department));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    public IActionResult DeleteDepartment(int id)
    {
        try
        {
            return Ok(_departmentService.DeleteDepartmentById(id));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }

}