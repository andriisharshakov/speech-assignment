using CompanyApi.Application.Services;
using CompanyApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    // GET: api/departments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
    {
        var departments = await _departmentService.GetAllDepartmentsAsync();

        return Ok(departments);
    }

    // GET: api/departments/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Department>> GetDepartment(int id)
    {
        var department = await _departmentService.GetDepartmentByIdAsync(id);

        if (department == null)
        {
            return NotFound();
        }

        return Ok(department);
    }

    // POST: api/departments
    [HttpPost]
    public async Task<ActionResult<Department>> PostDepartment(Department department)
    {
        await _departmentService.AddDepartmentAsync(department);

        return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
    }

    // PUT: api/departments/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutDepartment(int id, Department department)
    {
        if (id != department.Id)
        {
            return BadRequest();
        }

        await _departmentService.UpdateDepartmentAsync(department);

        return NoContent();
    }

    // DELETE: api/departments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        await _departmentService.DeleteDepartmentAsync(id);

        return NoContent();
    }

    // GET: api/departments/query?x=5
    [HttpGet("query")]
    public async Task<ActionResult<IEnumerable<Department>>> QueryDepartments(int x)
    {
        var departments = await _departmentService.GetAllDepartmentsAsync();

        // Filter departments with at least x employees
        var result = departments.Where(d => d.Employees.Count >= x).ToList();

        return Ok(result);
    }
}