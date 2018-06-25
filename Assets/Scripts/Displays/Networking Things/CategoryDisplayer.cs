using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CategoryDisplayer : MonoBehaviour {

    public DatalineSelector selector;
    private Dataline previously_selected; //small optimization thing

    public string category;

    private List<BoolDisplay> displays;

    private void Start()
    {
        displays = new List<BoolDisplay>();
        displays.AddRange(GetComponentsInChildren<BoolDisplay>());
    }

    private void Update()
    {
        if (selector.selected_line.categories_enabled.Contains(category))
        {
            foreach (BoolDisplay display in displays)
            {
                display.state = true;
            }
        }
        else
        {
            foreach (BoolDisplay display in displays)
            {
                display.state = false;
            }
        }
        previously_selected = selector.selected_line;
    }

}
