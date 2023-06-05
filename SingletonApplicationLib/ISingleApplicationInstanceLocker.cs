using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonApplicationLib
{
    public interface IProcessLocker
    {
        string CheckedProcessName { get; set; }
        bool IsFirstInstance();
        void SetToSelf();
    }
}
