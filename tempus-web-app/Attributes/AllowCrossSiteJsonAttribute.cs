using System.Web.Http.Filters;

namespace TempusWebApp.Attributes
{
  
  public class CrossDomainBypassAttribute: ActionFilterAttribute
  {
    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
#if DEBUG
      if (actionExecutedContext.Response != null)
      {
        actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
        actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Headers", "*");
        actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Methods", "*");
      }

      base.OnActionExecuted(actionExecutedContext);
#endif
    }
  }
}