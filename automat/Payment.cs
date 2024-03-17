namespace automat
{
    public class Payment
    {
        public static bool PaywWithCard(double drinkCost)
        {
            Console.WriteLine("Your drink is going to cost you " + drinkCost);
            Console.WriteLine("This machine only takes card, Please insert the card by typing 'Insert'");
            try
            {

                string insert = Console.ReadLine().ToLower();
                if (insert == "insert")
                {
                    return true;
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("an error accoured: " + ex.Message);
                return false;
            }

            return false;
        }
    }
}



