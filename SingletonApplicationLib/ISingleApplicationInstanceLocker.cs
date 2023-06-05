using System;
using System.Collections.Generic;
using System.Text;

namespace SingletonApplicationLib
{
    public interface ISingleApplicationLocker
    {
        string CheckedApplicationName { get; set; }
        bool IsFirstInstance();
        void SetToSelf();
    }
}
