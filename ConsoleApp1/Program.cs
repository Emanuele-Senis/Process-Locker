using EmanueleAlessandroSenis_ProcessManagement;

ProcessLocker locker = new ProcessLocker();

if (locker.IsFirstInstance())
{
    Console.WriteLine($"only one instance of the application {locker.CheckedProcessName} is running");
}
else
{
    Console.WriteLine($"error: another instance of the same application {locker.CheckedProcessName} is running");
}

//release and dispose the mutex
locker.Dispose();

Console.ReadKey();
