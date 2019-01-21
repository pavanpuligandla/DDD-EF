using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace ProjectAllocation.Core
{
    public class AppExceptionLogger : ExceptionLogger
    {
        public override void Log(ExceptionLoggerContext context)
        {
            LogManager.GetCurrentClassLogger().Log(LogLevel.Fatal, context.Exception);
            base.Log(context);
        }
    }
}