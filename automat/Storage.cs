using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace automat;



public class Storage
{
    public string FilePath {get; private set; }

    public Storage(string filePath)
    {
        FilePath = filePath;
    }

    private List<IngredientValues> machineStorage = new List<IngredientValues>();
    private List<string> ingredients = new List<string>();

    public void readJfile()
    {
        string ingredient1 = "Coffee";
        string ingredient2 = "Sugar";
        string ingredient3 = "Chocolate";
        string ingredient4 = "Oranges";
        string ingredient5 = "Apples";

        ingredients.Add(ingredient1);
        ingredients.Add(ingredient2);
        ingredients.Add(ingredient3);
        ingredients.Add(ingredient4);
        ingredients.Add(ingredient5);

        dynamic Jcont = JsonConvert.DeserializeObject(File.ReadAllText(FilePath));


        for (int i = 0; i < ingredients.Count - 1; i++)
        {
            JToken token = Jcont.SelectToken(ingredients[i]);

            string tokenstring = token.ToString();
            double tokendouble = Double.Parse(tokenstring);
            IngredientValues resource = new IngredientValues(ingredients[i], tokendouble);

            machineStorage.Add(resource);
        }
    }


    public void ViewStorage()
    {
        Console.WriteLine("Current Machine Storage: ");
        foreach (var item in machineStorage)
        {
            Console.WriteLine($"- {item.Ingredient} , Quantity: {item.Value}%.");
        }
    }


    public bool ReduceIngredientValue(string ingredientname, double reductionvalue)
    {
        IngredientValues ingredient = null;

        foreach (var item in machineStorage)
        {
            if (item.Ingredient == ingredientname)
            {
                ingredient = item;
                break;
            }
        }
        if (ingredient != null)
        {
            ingredient.Value -= reductionvalue;

            if (ingredient.Value < 0)
            {
               ingredient.Value += reductionvalue;
               return false;
            }
            return true;
        }
        else
        {
                return false;
        }
    }
}

