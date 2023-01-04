using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public EmployeesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _appDbContext.Employees.ToListAsync();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> AddlEmployees([FromBody] Employee employee)
        {
           employee.Id = Guid.NewGuid();
           await _appDbContext.Employees.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();

            return Ok(employee);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
          var emp = await _appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(emp);
        }

    }
}
