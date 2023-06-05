using EmanueleAlessandroSenis_ProcessManagement;
namespace Test
{
    internal class Program
    {
        static void Main()
        {
            ProcessLocker locker = new ProcessLocker();
            if (locker.IsFirstInstance())
            {
                Console.WriteLine("is the first program instance");
            }
            else
            {
                Console.WriteLine("it isn't the first program instance");
            }
        }
    }
}