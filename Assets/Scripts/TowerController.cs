using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TowerController : NetworkBehaviour, ITriggerTaskable {

    private NetworkAnimator anim;
    public Rigidbody rocket_rb;

    private void Start()
    {
        anim = GetComponent<NetworkAnimator>();
        rocket_rb.isKinematic = true;
    }

    public void TriggerTask()
    {
        anim.SetTrigger("Release");
        rocket_rb.isKinematic = false;
    }

}
