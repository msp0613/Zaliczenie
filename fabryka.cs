using System;
using System.Collections;

namespace Fabryka
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    class Pizza
    {
        public String dought;
        public String sauce;
        public String name;
        public ArrayList toppings;

        public Pizza(String dought, String sauce, String name)
        {
            this.dought = dought;
            this.sauce = sauce;
            this.name = name;
        }
        public void box() { }
        public void bake() { }
        public override string ToString()
        {
            return $"Name: {name}\nDough: {dought}\nSauce: {sauce}\nToppings: {string.Join(", ", toppings.ToArray())}";
        }
        public string GetName()
        {
            return name;
        }

        public void Cut()
        {
            Console.WriteLine($"Cutting {name} into diagonal slices.");
        }

        public void Prepare()
        {
            Console.WriteLine($"Preparing {name}...");
            Console.WriteLine("Adding sauce and toppings...");
        }
    }
    class PizzaFactory
    {
        public Pizza CreatePizza(string type, string dough, string sauce)
        {
            switch (type.ToLower())
            {
                case "pepperoni":
                    return new PepperoniPizza(dough, sauce);
                case "vegetable":
                    return new VeggePizza(dough, sauce);
                case "cheese":
                    return new CheesePizza(dough, sauce);
                case "kebab":
                    return new KebabPizza(dough, sauce);
                default:
                    throw new ArgumentException("Invalid pizza type.");
            }
        }
    }

    class PepperoniPizza : Pizza
    {
        public PepperoniPizza(string dough, string sauce) : base(dough, sauce, "Pepperoni Pizza")
        {
            
        }
    }

    class VeggePizza : Pizza
    {
        public VeggePizza(string dough, string sauce) : base(dough, sauce, "Vegetable Pizza")
        {
            this.dought = dought;
            this.sauce = sauce;
        }
    }

    class CheesePizza : Pizza
    {
        public CheesePizza(string dough, string sauce) : base(dough, sauce, "Cheese Pizza")
        {
            this.dought = dought;
            this.sauce = sauce;
        }
    }

    class KebabPizza : Pizza
    {
        public KebabPizza(string dough, string sauce) : base(dough, sauce, "Kebab Pizza")
        {
            this.dought = dought;
            this.sauce = sauce;
        }
    }
    class PizzaStore
    {
        private PizzaFactory pizzaFactory;

        public PizzaStore(PizzaFactory factory)
        {
            pizzaFactory = factory;
        }

        public Pizza OrderPizza(string type, string dough, string sauce)
        {
            Pizza pizza = pizzaFactory.CreatePizza(type, dough, sauce);

            pizza.Prepare();
            pizza.Cut();

            return pizza;
        }
    }
    class PizzaTest
    {
        public PizzaTest()
        {
        }

        static void Main(string[] args)
        {
            PizzaFactory pizzaFactory = new PizzaFactory();
            PizzaStore pizzaStore = new PizzaStore(pizzaFactory);

            // Zamówienie pizzy
            Pizza pepperoniPizza = pizzaStore.OrderPizza("pepperoni", "Thin crust", "Tomato");
            Console.WriteLine("Pepperoni Pizza details:\n" + pepperoniPizza.ToString());

            Pizza veggePizza = pizzaStore.OrderPizza("vegetable", "Thick crust", "Tomato");
            Console.WriteLine("Vegetable Pizza details:\n" + veggePizza.ToString());
        }
    }
}
