using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour {

    private Camera engines;
    private Camera guidance;
    private Camera network;
    private Camera systems;

    private void Start()
    {
        engines = GameObject.FindGameObjectWithTag("Engines").GetComponent<Camera>();
        guidance = GameObject.FindGameObjectWithTag("Guidance").GetComponent<Camera>();
        network = GameObject.FindGameObjectWithTag("Network").GetComponent<Camera>();
        systems = GameObject.FindGameObjectWithTag("Systems").GetComponent<Camera>();

        engines.enabled = true;
        guidance.enabled = false;
        network.enabled = false;
        systems.enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            engines.enabled = true;
            guidance.enabled = false;
            network.enabled = false;
            systems.enabled = false;
        }
        if (Input.GetKeyDown("2"))
        {
            engines.enabled = false;
            guidance.enabled = true;
            network.enabled = false;
            systems.enabled = false;
        }
        if (Input.GetKeyDown("3"))
        {
            engines.enabled = false;
            guidance.enabled = false;
            network.enabled = true;
            systems.enabled = false;
        }
        if (Input.GetKeyDown("4"))
        {
            engines.enabled = false;
            guidance.enabled = false;
            network.enabled = false;
            systems.enabled = true;
        }
    }
}
