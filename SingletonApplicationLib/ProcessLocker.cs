using System;
using System.Diagnostics;
using System.Threading;

namespace SingletonApplicationLib
{

    public class ProcessLocker : IProcessLocker, IDisposable
    {
        /// <summary>
        /// The Mutex which checks whether the currently checked process is the first instance or not
        /// </summary>
        protected Mutex _uniqueInstanceMutex;
        
        /// <summary>
        /// The currently checked process name
        /// </summary>
        public string CheckedProcessName { get; set; }

        public ProcessLocker(string applicationToLock = "")
        {
                CheckedProcessName = applicationToLock;
        }

        /// <summary>
        /// Checks if the program process is the first that started or not
        /// </summary>
        /// <returns>True if the process is the first instance, false if it isn't</returns>
        public bool IsFirstInstance()
        {
            if (string.IsNullOrWhiteSpace(CheckedProcessName))
            {
                SetToSelf();
            }
            _uniqueInstanceMutex = new Mutex(true, CheckedProcessName, out bool isFirstInstance);
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
            CheckedProcessName = currentProcess.ProcessName;
        }
        ~ProcessLocker()
        {
            Dispose();
        }
    }
 
}