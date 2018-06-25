using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialstoButton : MonoBehaviour {

    public Button button;

    public List<Dial> dials;

    private void Update()
    {
        Vector3Button vector_button = button as Vector3Button;
        IntButton int_button = button as IntButton;

        if (vector_button != null)
        {
            vector_button.vector = new Vector3(dials[0].Value, dials[1].Value, dials[2].Value);
        }
        if (int_button != null)
        {
            int_button.value = int.Parse(dials[0].Value.ToString() + dials[1].Value.ToString() + dials[2].Value.ToString());
        }
    }

}