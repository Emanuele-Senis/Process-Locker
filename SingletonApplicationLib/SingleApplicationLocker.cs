using System;
using System.Diagnostics;
using System.Threading;

namespace SingletonApplicationLib
{

    public class SingleApplicationLocker : ISingleApplicationLocker, IDisposable
    {
        /// <summary>
        /// The Mutex which checks whether the current application is the first instance or not
        /// </summary>
        private Mutex _uniqueInstanceMutex;
        
        /// <summary>
        /// The currently checked application name
        /// </summary>
        public string CheckedApplicationName { get; set; }

        public SingleApplicationLocker(string applicationToLock = "")
        {
            if (string.IsNullOrWhiteSpace(applicationToLock))
            {
                SetToSelf();
            }
            else 
            {
                CheckedApplicationName = applicationToLock;
            }
        }

        /// <summary>
        /// Checks if the program running is the first that started or not
        /// </summary>
        /// <returns>True if the program is the first instance, false if it isn't</returns>
        public bool IsFirstInstance()
        {
            _uniqueInstanceMutex = new Mutex(true, CheckedApplicationName, out bool isFirstInstance);
            return isFirstInstance;
        }

        public void Dispose()
        {
            _uniqueInstanceMutex?.ReleaseMutex();
            _uniqueInstanceMutex?.Dispose();
        }
        /// <summary>
        /// reset the application to check to the current running one
        /// </summary>
        public void SetToSelf()
        {
            Process currentProcess = Process.GetCurrentProcess();
            CheckedApplicationName = currentProcess.ProcessName;
        }
        ~SingleApplicationLocker()
        {
            Dispose();
        }
    }
 
}