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
        /// <summary>
        /// Declare the db context
        /// </summary>
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
      
            if (emp == null)
            {
                return NotFound();
            }
            return Ok(emp);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, Employee updateEmp)
        {
        var employee = await   _appDbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            employee.Name = updateEmp.Name;
            employee.Email = updateEmp.Email;
            employee.Salary = updateEmp.Salary;
            employee.Phone = updateEmp.Phone;
            employee.Department = updateEmp.Department;

            await  _appDbContext.SaveChangesAsync();

            return Ok(employee);
  
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _appDbContext.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _appDbContext.Employees.Remove(employee);

            await _appDbContext.SaveChangesAsync();

            return Ok(employee);    

        }


    }
}
