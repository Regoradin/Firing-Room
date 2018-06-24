using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatalineSelector : MonoBehaviour, IIntTaskable {

    public List<Dataline> datalines;
    public List<GameObject> display_objects;

    [HideInInspector]
    public Dataline selected_line;
    private int selected_index = -1;


    public void IntTask(int index)
    {
        if (index >= 0 && index < datalines.Count && index != selected_index)
        {
            try
            {
                foreach (BoolDisplay display in display_objects[selected_index].GetComponentsInChildren<BoolDisplay>())
                {
                    display.state = false;
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {//ignores initial error of selected_index being -1
            }
            selected_index = index;
            selected_line = datalines[index];
            foreach (BoolDisplay display in display_objects[selected_index].GetComponentsInChildren<BoolDisplay>())
            {
                display.state = true;
            }
        }
    }

}
