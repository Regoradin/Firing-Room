using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCSFuelReporter : Reporter {

    public RCSFuel rcs_fuel;
    public List<FloatDisplay> displays;
    public string category;
    public float size;

    protected override void Report()
    {
        float fuel_level = rcs_fuel.Fuel / rcs_fuel.max_fuel;
        network.AddData(new FloatData(displays, fuel_level, category, size));
    }

}
