using System;

namespace decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Order ");

            Beverage beverage = new AeroPress();
            Console.WriteLine(beverage.getDescription() + " $" + beverage.Cost());

            Beverage beverage1 = new Chemex();
            beverage1 = new Mocha(beverage1);
            beverage1 = new Milk(beverage1);
            Console.WriteLine(beverage1.getDescription() + " $" + beverage1.Cost());

            Console.ReadKey();
        }
    }

    /// <summary>
    /// abstract component class.
    /// </summary>
    public abstract class Beverage
    {
        public string description = "unkown beverage";

        /// <summary>
        /// Gets beverage description.
        /// </summary>
        /// <returns>String with beverage description.</returns>
        public virtual string getDescription()
        {
            return description;
        }

        /// <summary>
        /// Calculate cost.
        /// </summary>
        /// <returns>Double with the cost.</returns>
        public abstract double Cost();
    }

    /// <summary>
    /// Component override.
    /// </summary>
    public abstract class CondimentDecorator : Beverage
    {
        public abstract override string getDescription();
    }

    /// <summary>
    /// Concrete component Espresso.
    /// </summary>
    public class Espresso : Beverage
    {
        public Espresso()
        {
            description = "Espresso";

        }
        public override double Cost()
        {
            return 25.00;
        }
    }

    /// <summary>
    /// Concrete component French Press.
    /// </summary>
    public class FrenchPress : Beverage
    {
        public FrenchPress()
        {
            description = "French press Coffee";
        }
        public override double Cost()
        {
            return 30.00;
        }
    }

    /// <summary>
    /// Concrete component Aero Press.
    /// </summary>
    public class AeroPress : Beverage
    {
        public AeroPress()
        {
            description = "AeroPress Coffee";
        }
        public override double Cost()
        {
            return 30.00;
        }
    }

    /// <summary>
    /// Concrete component Chemex.
    /// </summary>
    public class Chemex : Beverage
    {
        public Chemex()
        {
            description = "Chemex Coffee";
        }
        public override double Cost()
        {
            return 40.00;
        }
    }

    #region Decorators
    /// <summary>
    /// Mocha decorator.
    /// </summary>
    public class Mocha : CondimentDecorator
    {
        Beverage beverage;
        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override string getDescription()
        {
            return beverage.getDescription() + ", Mocha";
        }
        public override double Cost()
        {
            return beverage.Cost() + 5.00;
        }
    }

    /// <summary>
    /// Milk decorator.
    /// </summary>
    public class Milk : CondimentDecorator
    {
        Beverage beverage;
        public Milk(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override string getDescription()
        {
            return beverage.getDescription() + ", Milk";
        }
        public override double Cost()
        {
            return beverage.Cost() + 5.00;
        }
    }

    /// <summary>
    /// Soy decorator.
    /// </summary>
    public class Soy : CondimentDecorator
    {
        Beverage beverage;
        public Soy(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override string getDescription()
        {
            return beverage.getDescription() + ", Soy";
        }
        public override double Cost()
        {
            return beverage.Cost() + 10.00;
        }
    }

    /// <summary>
    /// Whip decorator.
    /// </summary>
    public class Whip : CondimentDecorator
    {
        Beverage beverage;
        public Whip(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override string getDescription()
        {
            return beverage.getDescription() + ", Whip";
        }
        public override double Cost()
        {
            return beverage.Cost() + 10.00;
        }
    }

    #endregion
}
