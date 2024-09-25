using System;

interface IStrategy
{
    int Execute(int a, int b);
}

class AddStrategy : IStrategy
{
    public int Execute(int a, int b)
    {
        return a + b;
    }
}

class MultiplyStrategy : IStrategy
{
    public int Execute(int a, int b)
    {
        return a * b;
    }
}

class Context
{
    private IStrategy strategy;
    
    public Context(IStrategy strategy)
    {
        this.strategy = strategy;
    }

    public int ExecuteStrategy(int a, int b)
    {
        return strategy.Execute(a, b);
    }
}

class Program
{
    static void Main()
    {
        Context context = new Context(new AddStrategy());
        Console.WriteLine(context.ExecuteStrategy(5, 10));

        context = new Context(new MultiplyStrategy());
        Console.WriteLine(context.ExecuteStrategy(5, 10));
    }
}
