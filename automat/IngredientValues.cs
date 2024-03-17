using System.Collections.Generic;

namespace automat;

public class IngredientValues
{
    public string Ingredient { get; set; }
    public double Value { get; set; }

    public IngredientValues(string ingrident, double value)
    {
        this.Ingredient = ingrident;
        this.Value = value;
    }

}

