using System.Collections.Generic;
namespace automat;


public class Drink
{
    public string Name { get; private set; }
    public double Cost { get; private set; }

    public Drink(string name, double cost)
    {
        Name = name;
        Cost = cost;
    }

}

