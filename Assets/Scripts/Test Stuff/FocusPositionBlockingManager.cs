using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusPositionBlockingManager : MonoBehaviour {

    //important note, this is actually half of the width because of negative numbers
    public float zone_width;

    public Vector3 zone_pos;

    public delegate void ZoneChangeHandler(Vector3 new_zone);
    public event ZoneChangeHandler EventZoneChanged;

    private void Start()
    {
        zone_pos = Vector3.zero;
    }

    private void FixedUpdate()
    {
        Vector3 old_zone_pos = zone_pos;

        if(transform.position.x > zone_width)
        {
            transform.position -= Vector3.right * zone_width;
            zone_pos += Vector3.right;
        }
        if (transform.position.y > zone_width)
        {
            transform.position -= Vector3.up * zone_width;
            zone_pos += Vector3.up;
        }
        if(transform.position.z > zone_width)
        {
            transform.position -= Vector3.forward * zone_width;
            zone_pos += Vector3.forward;
        }

        if (transform.position.x < -zone_width)
        {
            transform.position += Vector3.right * zone_width;
            zone_pos -= Vector3.right;
        }
        if (transform.position.y < -zone_width)
        {
            transform.position += Vector3.up * zone_width;
            zone_pos -= Vector3.up;
        }
        if (transform.position.z < -zone_width)
        {
            transform.position += Vector3.forward * zone_width;
            zone_pos -= Vector3.forward;
        }

        if(old_zone_pos != zone_pos && EventZoneChanged != null)
        {
            EventZoneChanged(zone_pos);
        }
    }

}
