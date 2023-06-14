# Process Locker

This library provides a C# class `ProcessLocker` that checks if another instance of the same process, such as the current running application, is running or not.
The class implements `IDisposable` and the provided interface `IProcessLocker`.

## Features

- Check if another instance of CheckedProcessName is running
- Automatically detect the current application name if the process is not specified 
- Implements IDisposable to properly release and dispose the Mutex
- Implements custom interface IProcessLocker for code reusability and decoupling purposes

### Include the namespace
```csharp
using EmanueleAlessandroSenis_ProcessManagement;
```

## Example

 ```csharp
ProcessLocker locker = new ProcessLocker();

if (locker.IsFirstInstance())
{
   //only one instance of locker.CheckedProcessName is running
}
else
{
   //there's another instance running of the same process running
}

//make sure to release and dispose the mutex when the mutex shouldn't hold ownership of the process
locker.Dispose();
 ```
