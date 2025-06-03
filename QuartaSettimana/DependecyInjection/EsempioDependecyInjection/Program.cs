using System;
public interface ILogger
{
    void Log(string messagge);
}

public class ConsoleLogger : ILogger
{
    public void Log(string messagge)
    {
        Console.WriteLine($"LOG: {messagge}");
    }
}
public class UserService
{
    private readonly ILogger _logger;

    public UserService(ILogger logger)
    {
        _logger = logger;
    }

    public void CreateUser(string name)
    {
        _logger.Log($"User: {name} created.");
    }

}
public class Programs {
    public void Main()
    {
        ILogger logger1 = new ConsoleLogger();

        UserService userservice = new UserService(logger1);

        userservice.CreateUser("alice");
    }
}