using System;

namespace TempusWebApp.Extensions
{
  public static class DateTimeExtensions
  {
    public static bool IsBetween(this DateTime date, DateTime startTime, DateTime endTime)
    {
      if (endTime == null)
      {
        return startTime < date;
      }
      else
      {
        if (endTime < startTime)
        {
          throw new InvalidOperationException("endTime precedes startTime");
        }

        return startTime < date && date < endTime;
      }
    }
  }
}
