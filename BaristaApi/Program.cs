using System;
using System.Collections.Generic;

namespace The_barista
{
    public class Program
    {
        public static void Main()
        {
            IFluentEspresso espresso = new FluentEspresso()
                .AddHotWater(20)
                .AddGrindedBeans()
                .AddCoffeeBeans(new Beans(4, "Arabica"))
                .AddMilk();

            IFluentEspresso cappuccino = new FluentEspresso()
                .AddCoffeeBeans(new Beans(4, "Arabica"))
                .AddMilk()
                .AddFoamMilk();

            IBeverage americano = new Americano().ToBeverage();


            //foreach (var ingredient in espresso.Ingredients)
            //{
            //    Console.WriteLine(ingredient);
            //}
        }
    }

    public interface IBeverage
    {
        List<string> Ingredients { get; }
        string CupType { get; }
        IBeverage ToBeverage();
    }

    public interface IFluentEspresso
    {
        IFluentEspresso AddHotWater(int percent);
        IFluentEspresso AddMilk();
        IFluentEspresso AddFoamMilk();
        IFluentEspresso AddCoffeeBeans(Beans beans);
        IFluentEspresso AddGrindedBeans();

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

            Ingredients.Add("Coffee Beans Added!");

            return this;
        }

        public IFluentEspresso AddFoamMilk()
        {
            Ingredients.Add("Milk Foam Added!");

            return this;
        }

        public IFluentEspresso AddGrindedBeans()
        {
            Ingredients.Add("Grinded Beans Added!");

            return this;
        }

        public IFluentEspresso AddHotWater(int percent)
        {
            Ingredients.Add("Hot Water Added!");

            return this;
        }

        public IFluentEspresso AddMilk()
        {
            Ingredients.Add("Milk Added!");

            return this;
        }

        public IFluentEspresso ToBeverage(IBeverage beverage)
        {

            if (beverage.Ingredients.Count == Ingredients.Count)
            {
                foreach (var ingredient in beverage.Ingredients)
                {
                    if (Ingredients.Contains(ingredient))
                    {

                    }
                }
            }

            if (Ingredients.Contains("Coffee Beans Added!") &&
                Ingredients.Contains("Milk Added!") &&
                Ingredients.Contains("Milk Foam Added!"))
            {
                Console.WriteLine("Your beverage is Cappuccino");
            }
            else if (Ingredients.Contains("Milk Added!") && Ingredients.Contains("Coffee Beans Added!"))
            {
                Console.WriteLine("Your beverage is Espresso");
            }

            return this;
        }
    }


    public class Americano : IBeverage
    {
        public List<string> Ingredients { get; }

        public Americano()
        {
            Ingredients = new List<string>() { "Water", "Epresso" };
        }

        public string CupType => throw new NotImplementedException();

        public IBeverage ToBeverage()
        {
            if (Ingredients.Contains("Water"))
            {
                Console.WriteLine("Your beverage is Americano");
            }
            return this;
        }
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
