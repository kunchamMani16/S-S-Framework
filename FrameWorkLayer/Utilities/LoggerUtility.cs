using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrameWorkLayer.Utilities
{
    public class LoggerUtility
    {
        public ILog LoggerInstance;

        private static readonly LoggerUtility instance = new LoggerUtility();
        private LoggerUtility() { }
        public static LoggerUtility Instance
        {
            get
            {
                return instance;
            }
        }
            public void SetFile(string fileName)
            {
                SetConfig(fileName);
            }
            public void GetLogger<T>()
            {
                LoggerInstance = LogManager.GetLogger(typeof(T));
            }
            private void SetConfig(string fileName)
            {
            var path = Path.Combine(
            Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).Parent.Parent.FullName, fileName);
                XmlConfigurator.Configure(new FileInfo(path));
            }
            public void LogInfo(string message)
            {
                LoggerInstance.Info(message);
            }
            public  void LogError(string message, Exception exception)
            {
                LoggerInstance.Error(message, exception);
            }

    }
}
