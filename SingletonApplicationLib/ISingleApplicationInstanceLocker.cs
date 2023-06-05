
namespace SingletonApplicationLib
{
    public interface IProcessLocker
    {
        string CheckedProcessName { get; set; }
        bool IsFirstInstance();
    }
}
