using SingletonApplicationLib;

SingleApplicationLocker locker = new SingleApplicationLocker();

if (locker.IsFirstInstance())
{
    Console.WriteLine($"only one instance of the application {locker.CheckedApplicationName} is running");
}
else
{
    Console.WriteLine($"error: another instance of the same application {locker.CheckedApplicationName} is running");
}
//release and dispose the mutex
locker.Dispose();

Console.ReadKey();
