using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TempusWebApp.Attributes;
using TempusWebApp.Models;

namespace TempusWebApp.Controllers
{
  [CrossDomainBypass]
  public class TaskItemsController : ApiController
  {
    private TempusWebAppContext db = new TempusWebAppContext();

    // GET: api/TaskItems
    public IQueryable<TaskItem> GetTaskItems()
    {
      return db.TaskItems;
    }

    // GET: api/TaskItems/5
    [ResponseType(typeof(TaskItem))]
    public async Task<IHttpActionResult> GetTaskItem(int id)
    {
      TaskItem taskItem = await db.TaskItems.FindAsync(id);
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

      db.Entry(taskItem).State = EntityState.Modified;

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TaskItemExists(id))
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
        db.TaskItems.Add(taskItem);
        await db.SaveChangesAsync();
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
      TaskItem taskItem = await db.TaskItems.FindAsync(id);
      if (taskItem == null)
      {
        return NotFound();
      }

      db.TaskItems.Remove(taskItem);
      await db.SaveChangesAsync();

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
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool TaskItemExists(int id)
    {
      return db.TaskItems.Count(e => e.Id == id) > 0;
    }
  }
}