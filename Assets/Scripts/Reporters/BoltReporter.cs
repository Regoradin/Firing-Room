using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltReporter : Reporter {

    public List<BoolDisplay> displays;
    public Bolt bolt;
    public string category;
    public float size;

    protected override void Report()
    {
        network.AddData(new BoolData(displays, bolt.armed, category, size));
    }

}
