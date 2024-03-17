using System.Collections.Generic;

namespace automat
{
    public class Machine
    {
        List<Drink> drinks = new List<Drink>();
        public Machine(List<Drink> drinkOptionsList)
        {
            this.drinks = drinkOptionsList;
        }

        public void Menu()
        {
            int a = 1;
            Console.WriteLine("------------------");
            foreach (var item in drinks)
            {
                Console.WriteLine($"{a}: {item.Name}, ${item.Cost}.");
                a++;
            }
            Console.WriteLine("------------------");
        }

        public int ChooseDrink()
        {
            int userInput;
            do
            {
                Console.WriteLine("Enter the corespording number of the drink you would like to order: ");

                string inputstring = Console.ReadLine();

                if (int.TryParse(inputstring, out userInput))
                {
                    if (userInput >= 0 && userInput <= 5)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("invalid input. Please enter a valid number!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a integer!");
                }
            } while (true);

            return userInput;
        }
        
        public bool MakeDrink(int drinkchoice, Storage storage)
        {
            bool successful = false;
            bool ingredient1 = true;
            bool ingredient2 = true;
            if(drinkchoice == 1)
            {
                ingredient1 = storage.ReduceIngredientValue("Coffee", 70);
                ingredient2 = storage.ReduceIngredientValue("Sugar", 40);
            }
            else if(drinkchoice == 2){
                ingredient1 = storage.ReduceIngredientValue("Coffee", 32);
                ingredient2 = storage.ReduceIngredientValue("Sugar", 40);
            }
            else if (drinkchoice == 3)
            {
                ingredient1 = storage.ReduceIngredientValue("Coffee", 50);
            }
            else if (drinkchoice == 4)
            {
                ingredient1 = storage.ReduceIngredientValue("Chocolate", 50);
                ingredient2 = storage.ReduceIngredientValue("Sugar",60);
            }
            else if (drinkchoice == 5)
            {
                ingredient1 = storage.ReduceIngredientValue("Oranges", 10);
            }

            if(ingredient1 && ingredient2)
            {
                successful = true;
            }

            return successful;
        }
    }

}



