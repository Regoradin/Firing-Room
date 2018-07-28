using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCSReporter : Reporter {

    public RCS rcs;
    public List<BoolDisplay> maneuvering_displays;
    public string category;
    public float size;

    protected override void Report()
    {
        network.AddData(new BoolData(maneuvering_displays, rcs.Is_maneuvering, category, size));
    }

}
