using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCoverController : MonoBehaviour {

    private bool covered = true;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Covered", covered);
    }

    private void OnMouseDown()
    {
        covered = !covered;
        anim.SetBool("Covered", covered);
    }
}
