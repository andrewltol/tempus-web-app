using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TempusWebApp.Models;

namespace TempusWebApp.Controllers
{
  public class QualificationsController : ApiController
  {
    private TempusWebAppContext db = new TempusWebAppContext();

    // GET: api/Qualifications
    public IQueryable<Qualification> GetQualifications()
    {
      return db.Qualifications;
    }

    // GET: api/Qualifications/5
    [ResponseType(typeof(Qualification))]
    public async Task<IHttpActionResult> GetQualification(int id)
    {
      Qualification qualification = await db.Qualifications.FindAsync(id);
      if (qualification == null)
      {
        return NotFound();
      }

      return Ok(qualification);
    }

    // PUT: api/Qualifications/5
    [ResponseType(typeof(void))]
    public async Task<IHttpActionResult> PutQualification(int id, Qualification qualification)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != qualification.Id)
      {
        return BadRequest();
      }

      db.Entry(qualification).State = EntityState.Modified;

      try
      {
        await db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!QualificationExists(id))
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

    // POST: api/Qualifications
    [ResponseType(typeof(Qualification))]
    public async Task<IHttpActionResult> PostQualification(Qualification qualification)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      db.Qualifications.Add(qualification);
      await db.SaveChangesAsync();

      return CreatedAtRoute("DefaultApi", new { id = qualification.Id }, qualification);
    }

    // DELETE: api/Qualifications/5
    [ResponseType(typeof(Qualification))]
    public async Task<IHttpActionResult> DeleteQualification(int id)
    {
      Qualification qualification = await db.Qualifications.FindAsync(id);
      if (qualification == null)
      {
        return NotFound();
      }

      db.Qualifications.Remove(qualification);
      await db.SaveChangesAsync();

      return Ok(qualification);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        db.Dispose();
      }
      base.Dispose(disposing);
    }

    private bool QualificationExists(int id)
    {
      return db.Qualifications.Count(e => e.Id == id) > 0;
    }
  }
}