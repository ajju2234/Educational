using System;

interface IProduct
{
    string GetName();
}

class ProductA : IProduct
{
    public string GetName()
    {
        return "Product A";
    }
}

class ProductB : IProduct
{
    public string GetName()
    {
        return "Product B";
    }
}

class ProductFactory
{
    public static IProduct CreateProduct(string type)
    {
        if (type == "A") return new ProductA();
        if (type == "B") return new ProductB();
        return null;
    }
}

class Program
{
    static void Main()
    {
        IProduct productA = ProductFactory.CreateProduct("A");
        Console.WriteLine(productA.GetName());

        IProduct productB = ProductFactory.CreateProduct("B");
        Console.WriteLine(productB.GetName());
    }
}
