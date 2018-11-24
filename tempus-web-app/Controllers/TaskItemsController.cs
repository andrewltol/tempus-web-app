using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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
  public class TaskItemsController : ApiController
  {
    private readonly ITaskService _taskService;

    public TaskItemsController()
    {
      _taskService = new SqlTaskService();
    }

    // GET: api/TaskItems
    public async Task<IList<TaskItem>> GetTaskItems()
    {
      return await _taskService.GetAll();
    }

    // GET: api/TaskItems/5
    [ResponseType(typeof(TaskItem))]
    public async Task<IHttpActionResult> GetTaskItem(int id)
    {
      TaskItem taskItem = await _taskService.Get(id);
      if (taskItem == null)
      {
        return NotFound();
      }

      return Ok(taskItem);
    }

    // PUT: api/TaskItems/5
    [ResponseType(typeof(void))]
    public async Task<IHttpActionResult> PutTaskItem(int id, TaskItem taskItem)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != taskItem.Id)
      {
        return BadRequest();
      }

      if (!await _taskService.Exists(id))
      {
        return NotFound();
      }

      try
      {
        await _taskService.Update(taskItem);
      }
      catch (DbUpdateConcurrencyException dce)
      {
        return InternalServerError(dce);
      }

      return StatusCode(HttpStatusCode.NoContent);
    }

    // POST: api/TaskItems
    [ResponseType(typeof(TaskItem))]
    public async Task<IHttpActionResult> PostTaskItem(TaskItem taskItem)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      try
      {
        await _taskService.Add(taskItem);
      }
      catch (Exception e)
      {
        InternalServerError(e);
      }

      return CreatedAtRoute("DefaultApi", new { id = taskItem.Id }, taskItem);
    }

    // DELETE: api/TaskItems/5
    [ResponseType(typeof(TaskItem))]
    public async Task<IHttpActionResult> DeleteTaskItem(int id)
    {
      TaskItem taskItem = await _taskService.Get(id);
      if (taskItem == null)
      {
        return NotFound();
      }

      

      return Ok(taskItem);
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
        _taskService.Dispose();
      }
      base.Dispose(disposing);
    }
  }
}