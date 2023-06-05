namespace EmanueleAlessandroSenis_ProcessManagement
{
    public interface IProcessLocker
    {
        string CheckedProcessName { get; set; }
        bool IsFirstInstance();
    }
}
