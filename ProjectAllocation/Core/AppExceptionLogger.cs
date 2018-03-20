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
            //Obselete method LogException()
            //LogManager.GetCurrentClassLogger().LogException(LogLevel.Fatal, "Exception Logger caught an exception!", context.Exception);
            LogManager.GetCurrentClassLogger().Log(LogLevel.Fatal, context.Exception);
            base.Log(context);
        }
    }
}