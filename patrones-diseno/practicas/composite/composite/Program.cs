using System;
using System.Collections.Generic;

/// <summary>
/// Generic component.
/// </summary>
abstract class Component
{
    public abstract string Operation();

    public abstract int Count();

    public virtual bool IsComposite()
    {
        return true;
    }
}

/// <summary>
/// IceCream class.
/// </summary>
class IceCream : Component
{
    private string flavor;
    private int price;

    public IceCream(string flavor, int price)
    {
        this.flavor = flavor;
        this.price = price;
    }

    public override string Operation()
    {
        return flavor;
    }

    /// <summary>
    /// Ice cream price.
    /// </summary>
    /// <returns></returns>
    public override int Count()
    {
        return price;
    }

    public override bool IsComposite()
    {
        return false;
    }
}

class Box : Component
{
    private string size;

    public List<Component> components = new List<Component>();

    public Box(string size)
    {
        this.size = size;
    }

    /// <summary>
    /// Add component.
    /// </summary>
    /// <param name="component">New component.</param>
    public void Add(Component component)
    {
        components.Add(component);
    }

    /// <summary>
    /// Remove components.
    /// </summary>
    /// <param name="component">Component to remove.</param>
    public void Remove(Component component)
    {
        components.Remove(component);
    }

    public override string Operation()
    {
        string box = size + "(";

        int c = 0;

        foreach (Component componente in components)
        {
            box += componente.Operation();

            if (c != (components.Count - 1))
            {
                box += " + ";
            }

            c++;
        }

        return box + ")";
    }

    /// <summary>
    /// Get price.
    /// </summary>
    /// <returns></returns>
    public override int Count()
    {
        // total
        int total = 0;

        // foreach counter
        int c = 0;

        // recursive sum prices 
        foreach (Component componente in components)
        {
            total += componente.Count();

            c++;
        }

        return total;
    }
}

class Program
{
    static void Main(string[] args)
    {
        IceCream lemon = new IceCream("lemon", 5);
        IceCream vanilla = new IceCream("vanilla", 7);
        IceCream chocolate = new IceCream("chocolate", 10);

        Box big = new Box("order");

        Box median = new Box("chocolate box");
        Box small_1 = new Box("lemon box");
        Box small_2 = new Box("vanilla box");

        small_1.Add(lemon);
        small_1.Add(lemon);
        small_2.Add(vanilla);

        median.Add(chocolate);

        median.Add(small_1);
        median.Add(small_2);

        big.Add(median);

        // show results
        Console.WriteLine(big.Operation());

        // total price
        Console.WriteLine("total price: " + big.Count().ToString());

        // lemon box
        Console.WriteLine("lemon box price: " + small_1.Count().ToString());

        // lemon price
        Console.WriteLine("ice cream lemon price: " + lemon.Count().ToString());

        Console.ReadKey();
    }
}

