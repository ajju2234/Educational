using System;

interface ITarget
{
    void Request();
}

class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Specific request from Adaptee");
    }
}

class Adapter : ITarget
{
    private Adaptee adaptee = new Adaptee();
    
    public void Request()
    {
        adaptee.SpecificRequest();
    }
}

class Program
{
    static void Main()
    {
        ITarget target = new Adapter();
        target.Request();
    }
}
