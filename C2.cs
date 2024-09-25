using System;

class Singleton
{
    private static Singleton instance;

    private Singleton() { }

    public static Singleton GetInstance()
    {
        if (instance == null)
        {
            instance = new Singleton();
        }
        return instance;
    }

    public void ShowMessage()
    {
        Console.WriteLine("Singleton instance");
    }
}

class Program
{
    static void Main()
    {
        Singleton instance1 = Singleton.GetInstance();
        instance1.ShowMessage();

        Singleton instance2 = Singleton.GetInstance();
        instance2.ShowMessage();
    }
}
