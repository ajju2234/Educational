using System;
using System.Collections.Generic;

interface IObserver
{
    void Update(string message);
}

class Observer : IObserver
{
    private string name;
    
    public Observer(string name)
    {
        this.name = name;
    }

    public void Update(string message)
    {
        Console.WriteLine(name + " received: " + message);
    }
}

class Subject
{
    private List<IObserver> observers = new List<IObserver>();

    public void Register(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in observers)
        {
            observer.Update(message);
        }
    }
}

class Program
{
    static void Main()
    {
        Subject subject = new Subject();
        IObserver observer1 = new Observer("Observer 1");
        IObserver observer2 = new Observer("Observer 2");

        subject.Register(observer1);
        subject.Register(observer2);

        subject.Notify("Event occurred!");
    }
}
