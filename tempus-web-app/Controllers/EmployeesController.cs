using System;
using System.Data.Entity.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TempusWebApp.Attributes;
using TempusWebApp.Models;
using TempusWebApp.Services;

namespace TempusWebApp.Controllers
{
  [CrossDomainBypass]
  public class EmployeesController : ApiController
  {
    private readonly IEmployeeService _employeeService;

    private TempusWebAppContext db = new TempusWebAppContext();

    public EmployeesController(IEmployeeService employeeService)
    {
      _employeeService = employeeService;
    }
    
    // GET: api/Employees
    public IList<Employee> GetEmployees()
    {
      return _employeeService.GetAll();
    }

    // GET: api/Employees/5
    [ResponseType(typeof(Employee))]
    public async Task<IHttpActionResult> GetEmployee(int id)
    {
      Employee employee = await _employeeService.Get(id);
      if (employee == null)
      {
        return NotFound();
      }

      return Ok(employee);
    }

    // PUT: api/Employees/5
    [ResponseType(typeof(void))]
    public async Task<IHttpActionResult> PutEmployee(int id, Employee employee)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != employee.Id)
      {
        return BadRequest();
      }

      try
      {
        await _employeeService.Update(employee);
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!EmployeeExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return StatusCode(HttpStatusCode.NoContent);
    }

    // POST: api/Employees
    [HttpPost, ResponseType(typeof(Employee))]
    public async Task<IHttpActionResult> PostEmployee([FromBody] Employee employee)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      try
      {
        await _employeeService.Add(employee);
      }
      catch (Exception e)
      {
        return InternalServerError(e);
      }

      return CreatedAtRoute("DefaultApi", new { id = employee.Id }, employee);
    }

    // DELETE: api/Employees/5
    [ResponseType(typeof(Employee))]
    public async Task<IHttpActionResult> DeleteEmployee(int id)
    {
      Employee employee = await _employeeService.Get(id);
      if (employee == null)
      {
        return NotFound();
      }

      await _employeeService.Delete(employee);

      return Ok(employee);
    }

    // Cross domain for DEBUG only
    [HttpOptions]
    public IHttpActionResult OptionsEndpoint()
    {
      return Ok();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool EmployeeExists(int id)
    {
      return db.Employees.Count(e => e.Id == id) > 0;
    }
  }
}