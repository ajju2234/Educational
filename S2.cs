using System;

interface IComponent
{
    string Operation();
}

class ConcreteComponent : IComponent
{
    public string Operation()
    {
        return "Component";
    }
}

class Decorator : IComponent
{
    protected IComponent component;
    
    public Decorator(IComponent component)
    {
        this.component = component;
    }

    public virtual string Operation()
    {
        return component.Operation();
    }
}

class ConcreteDecorator : Decorator
{
    public ConcreteDecorator(IComponent component) : base(component) { }

    public override string Operation()
    {
        return base.Operation() + " with Decorator";
    }
}

class Program
{
    static void Main()
    {
        IComponent component = new ConcreteComponent();
        Console.WriteLine(component.Operation());

        IComponent decorated = new ConcreteDecorator(component);
        Console.WriteLine(decorated.Operation());
    }
}
