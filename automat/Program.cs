using System;
using System.Collections.Generic;


namespace automat
{

    public class Program
    {
        static void Main(string[] args)
        {
            
            Storage storage = new Storage(@"resources.json");
            storage.readJfile();
            storage.ViewStorage();

            DrinksReader drinksReader = new DrinksReader(@"drinks.json");
            List<Drink> drinks = drinksReader.ReadFile();

            Machine machine = new Machine(drinks);
            
            bool ask = true;
            while (ask)
            {
                machine.Menu();
                int user_choice = machine.ChooseDrink();

                var payment = Payment.PaywWithCard(drinks[user_choice - 1].Cost);

                var drinkState = false;

                if (payment)
                {
                    Console.WriteLine("The payment was succesful!");
                    drinkState = machine.MakeDrink(user_choice, storage);
                    if (drinkState)
                    {
                        Console.WriteLine("Enjoy your: " + drinks[user_choice - 1].Name);
                    }
                    else if (!drinkState)
                    {
                        Console.WriteLine($"{drinks[user_choice - 1].Name} could not be made due to the lack of ingredients, please chhose anither drink!");
                        Console.WriteLine("your payment has been refunded");
                    }
                }
                else if(!payment)
                {
                    Console.WriteLine("The payment did not go through");
                }

                bool wow;
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Would you like to order another drink? type 'Yes' or 'No'");
                    string anotherDrink = Console.ReadLine().ToLower();
                    if (anotherDrink == "yes")
                    {
                        ask = true;
                        wow = false;
                    }
                    else if (anotherDrink == "no")
                    {
                        return;
                    }
                    else
                    {
                        Console.WriteLine("False input!");
                        wow = true;
                    }

                } while (wow);
            }

            Console.ReadLine();
        }
    }
}



