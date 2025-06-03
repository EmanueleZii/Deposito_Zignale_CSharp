using System;
//esercizio 1
public interface IGreter
{
    void Greet(string name);
}
public class ConsoleGreeter : IGreter
{
    public void Greet(string messagge)
    {
        Console.WriteLine($"LOG: {messagge}");
    }
}
public class UserService
{
    private readonly IGreter _logger;

    public UserService(IGreter logger)
    {
        _logger = logger;
    }
    public void Welcome(string name)
    {
        _logger.Greet($"User: {name} created.");
    }
}
//esercizio 2
public interface IPaymentGateway
{
    void ProcessPayment(decimal amount);
}
public class PaypalGateway : IPaymentGateway
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Pagamento :{amount}");
    }
}
public class StripeGateway : IPaymentGateway
{ 
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Pagamento :{amount}");
    }
}
public class PaymentProcessor
{
    private readonly IPaymentGateway _gateway;
    public PaymentProcessor(IPaymentGateway gateway)
    {
        _gateway = gateway;
    }
    public void Pay(decimal amount)
    {
        _gateway.ProcessPayment(amount);
    }
}
public class Programs
{
    public void Main()
    {
        //esercizio 1
        IGreter logger1 = new ConsoleGreeter();

        UserService userservice = new UserService(logger1);

        userservice.Welcome("alice");

        //esercizio 2
        IPaymentGateway gateway;

        Console.WriteLine("Scegli gateway (paypal/stripe):");
        string scelta = Console.ReadLine();

        if (scelta == "paypal")
            gateway = new PaypalGateway();
        else
            gateway = new StripeGateway();

        PaymentProcessor processor = new PaymentProcessor(gateway);
        processor.Pay(50.0m);
    }
}