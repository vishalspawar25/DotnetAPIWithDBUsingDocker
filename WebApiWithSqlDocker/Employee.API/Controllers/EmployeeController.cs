using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeDbContext _employeeDbContext;

    public EmployeeController(EmployeeDbContext employeeDbContext)
    {
        _employeeDbContext = employeeDbContext;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Employee>> GetEmpployees()
    {
        return _employeeDbContext.Employees;
    }

    [HttpPost]
    public async Task<ActionResult> Create(Employee employee)
    {
        await _employeeDbContext.Employees.AddAsync(employee);
        await _employeeDbContext.SaveChangesAsync();
        return Ok();
    }

}