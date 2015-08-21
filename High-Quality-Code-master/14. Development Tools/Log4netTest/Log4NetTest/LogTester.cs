using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Log4NetTest
{
    public static class LogTester
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void TestLogger()
        {
            log4net.GlobalContext.Properties["testProperty"] = "This is my test property information";

            Log.Debug("LogTester - Debug logging");
            Log.Info("LogTester - Info logging");
            Log.Warn("LogTester - Warn logging");
            Log.Error("LogTester - Error logging");
            Log.Fatal("LogTester - Fatal logging");
        }
    }
}
