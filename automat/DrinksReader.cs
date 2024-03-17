using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;

namespace automat
{
    public class DrinksReader
    {

        public string JFilepath { get; private set; }

        public DrinksReader(string JfilePath)
        {
            JFilepath = JfilePath;
        }

       
        public List<Drink> ReadFile()
        {
            string? json;
            //dynamic Jcont = JsonConvert.DeserializeObject(File.ReadAllText(JFilepath));

            List<Drink> drinks = new List<Drink>();

            using (StreamReader reader = new StreamReader(JFilepath))
            {
                json = reader.ReadToEnd();          
            }
            JObject drinksObject = JObject.Parse(json);

            foreach(var drink in drinksObject)
            {
                string a = ((JProperty)drink.Value.First).Name;
                double b = ((double)drink.Value.First.First);
                drinks.Add(new Drink(a, b));
            }

            return drinks;
        }
    }
}



