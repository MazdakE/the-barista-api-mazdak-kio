using System;
using System.Collections.Generic;
using System.Linq;

namespace The_barista
{
    public class Program
    {
        public static void Main()
        {
            //IFluentEspresso espresso = new FluentEspresso()
            //    .AddHotWater(20)
            //    .AddGrindedBeans()
            //    .AddCoffeeBeans(new Beans(4, "Arabica"))
            //    .AddMilk();

            //IFluentEspresso cappuccino = new FluentEspresso()
            //    .AddCoffeeBeans(new Beans(4, "Arabica"))
            //    .AddMilk()
            //    .AddMilkFoam();


            IBeverage macchiato = new FluentEspresso()
                .AddCoffeeBeans(new Beans(4, "Arabica"))
                .ToBeverage();

            Console.WriteLine();
        }
    }

    public interface IBeverage
    {
        public string Name { get; }
        List<string> Ingredients { get; }
        string CupType { get; }

    }

    public interface IFluentEspresso
    {
        IFluentEspresso AddHotWater(int percent);
        IFluentEspresso AddMilk();
        IFluentEspresso AddMilkFoam();
        IFluentEspresso AddCoffeeBeans(Beans beans);
        IFluentEspresso AddGrindedBeans();
        IBeverage ToBeverage();

    }


    public class FluentEspresso : IFluentEspresso
    {
        public string CupType => "Medium";

        public List<string> Ingredients { get; }


        public FluentEspresso()
        {
            Ingredients = new List<string>();
        }

        public IFluentEspresso AddCoffeeBeans(Beans beans)
        {

            Ingredients.Add("Coffee Beans");

            return this;
        }

        public IFluentEspresso AddMilkFoam()
        {
            Ingredients.Add("Milk Foam");

            return this;
        }

        public IFluentEspresso AddGrindedBeans()
        {
            Ingredients.Add("Grinded Beans");

            return this;
        }

        public IFluentEspresso AddHotWater(int percent)
        {
            Ingredients.Add("Water");

            return this;
        }

        public IFluentEspresso AddMilk()
        {
            Ingredients.Add("Milk");

            return this;
        }

        public IBeverage ToBeverage()
        {
            var drinks = new List<IBeverage>()
            {
                new Americano(),
                new Latte(),
                new Cappucino(),
                new Macchiato(),
                new Mocha(),
                new Espresso()
            };

            // Ser till så att drinkens lista med ingredienser matchar med de angivna listans ingredienser.
            var desiredDrink = drinks.FirstOrDefault(d => Enumerable.SequenceEqual(d.Ingredients.OrderBy(i => i), this.Ingredients.OrderBy(i => i)));

            // Tänk ifall drinken är null eller har andra ingredienser som vi inte har en klass av som ex. Espresso, Latte, ...? 
            Console.WriteLine(desiredDrink.Name);
            return desiredDrink;

        }
    }

    public class Americano : IBeverage
    {
        public List<string> Ingredients { get; private set; }
        public string Name { get; private set; }

        private string _name = "Americano";

        public Americano()
        {
            Name = _name;
            Ingredients = new List<string>() { "Water", "Coffee Beans" };
        }

        public string CupType => throw new NotImplementedException();
    }


    public class Latte : IBeverage
    {
        public List<string> Ingredients { get; private set; }
        public string Name { get; private set; }

        private string _name = "Latte";

        public Latte()
        {
            Name = _name;
            Ingredients = new List<string>() { "Milk", "Coffee Beans" };
        }

        public string CupType => throw new NotImplementedException();
    }

    public class Cappucino : IBeverage
    {
        public List<string> Ingredients { get; private set; }
        public string Name { get; private set; }

        private string _name = "Cappucino";

        public Cappucino()
        {
            Name = _name;
            Ingredients = new List<string>() { "Milk", "Coffee Beans", "Milk Foam" };
        }

        public string CupType => throw new NotImplementedException();
    }


    public class Macchiato : IBeverage
    {
        public List<string> Ingredients { get; private set; }
        public string Name { get; private set; }

        private string _name = "Macchiato";


        public Macchiato()
        {
            Name = _name;
            Ingredients = new List<string>() { "Coffee Beans", "Milk Foam" };
        }

        public string CupType => throw new NotImplementedException();
    }


    // Name saknas för vi måste lägga till choloate Syrup i IFluentEspresso...
    public class Mocha : IBeverage
    {
        public List<string> Ingredients { get; private set; }
        public string Name { get; private set; }

        public Mocha()
        {
            Ingredients = new List<string>() { "Coffee Beans", "Chocolate Syrup", "Milk Foam" };
        }

        public string CupType => throw new NotImplementedException();

    }

    public class Espresso : IBeverage
    {
        public List<string> Ingredients { get; private set; }
        public string Name { get; private set; }

        private string _name = "Espresso";

        public Espresso()
        {
            Name = _name;
            Ingredients = new List<string>() { "Coffee Beans" };
        }

        public string CupType => throw new NotImplementedException();

    }


    public class Other : IBeverage
    {
        public List<string> Ingredients => throw new NotImplementedException();

        public string CupType => throw new NotImplementedException();

        public string Name => throw new NotImplementedException();
    }

    public class Beans
    {
        public int _amountInG;
        public string _sort;
        public Beans(int amountInG, string sort)
        {
            this._amountInG = amountInG;
            this._sort = sort;
        }
    }
}
