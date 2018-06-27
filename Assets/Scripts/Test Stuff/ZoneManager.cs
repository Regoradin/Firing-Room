using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneManager : MonoBehaviour {

    public float zone_width;
  //  [HideInInspector]
    public Vector3 zone_pos;
    //[HideInInspector]
    public Vector3 remainder_pos;

    public bool is_focus = false;
    public ZoneManager focus;

    private Vector3 old_position;
    private bool ignore_move = false;

    public delegate void ZoneChangeHandler(Vector3 new_zone);
    public event ZoneChangeHandler EventZoneChanged;

    private void Start()
    {
        if (is_focus)
        {
            zone_pos = Vector3.zero;
            //this makes sure that the focus gameobject cannot collide with any focusignored objects, keeping space and time consistent
            gameObject.layer = 11;
            foreach(Transform child in transform)
            {
                child.gameObject.layer = 11;
            }
        }

        else
        {
            if (!focus.is_focus)
            {
                Debug.Log(name + " is focusing on " + focus.name + " which is not a focus");
            }
            zone_width = focus.zone_width;

            focus.EventZoneChanged += ZoneChange;

            zone_pos = new Vector3((int)(transform.position.x / zone_width), (int)(transform.position.y / zone_width), (int)(transform.position.z / zone_width));
            
            remainder_pos = transform.position - (zone_pos * zone_width);
            old_position = transform.position;
        }
    }


    private void ZoneChange(Vector3 new_zone)
    {
        //if within one zone of the focus
        if(new_zone.x >= zone_pos.x - 1 && new_zone.x <= zone_pos.x + 1 &&
           new_zone.y >= zone_pos.y - 1 && new_zone.y <= zone_pos.y + 1 &&
           new_zone.z >= zone_pos.z - 1 && new_zone.z <= zone_pos.z + 1)
        {
            gameObject.layer = 0;
            foreach (Transform child in transform)
            {
                child.gameObject.layer = 0;
            }
            

            transform.position = remainder_pos;
            //adjusts for being in neighboring zones
            transform.position = new Vector3(
                transform.position.x + ((zone_pos.x - new_zone.x) * zone_width),
                transform.position.y + ((zone_pos.y - new_zone.y) * zone_width),
                transform.position.z + ((zone_pos.z - new_zone.z) * zone_width));

            ignore_move = true;
        }

        else
        {
            gameObject.layer = 10;
            foreach (Transform child in transform)
            {
                child.gameObject.layer = 10;
            }
        }
    }


    private void FixedUpdate()
    {
        //tracks focus objects moving to a new zone
        if (is_focus)
        {
            Vector3 old_zone_pos = zone_pos;

            if (transform.position.x > zone_width)
            {
                transform.position -= Vector3.right * zone_width;
                zone_pos += Vector3.right;
            }
            if (transform.position.y > zone_width)
            {
                transform.position -= Vector3.up * zone_width;
                zone_pos += Vector3.up;
            }
            if (transform.position.z > zone_width)
            {
                transform.position -= Vector3.forward * zone_width;
                zone_pos += Vector3.forward;
            }

            if (transform.position.x < 0)
            {
                transform.position += Vector3.right * zone_width;
                zone_pos -= Vector3.right;
            }
            if (transform.position.y < 0)
            {
                transform.position += Vector3.up * zone_width;
                zone_pos -= Vector3.up;
            }
            if (transform.position.z < 0)
            {
                transform.position += Vector3.forward * zone_width;
                zone_pos -= Vector3.forward;
            }

            if (old_zone_pos != zone_pos && EventZoneChanged != null)
            {
                EventZoneChanged(zone_pos);
            }
        }
        else
        {
            //maintains accurate location of moving, non-focus objects
            if(transform.position != old_position && !ignore_move)
            {
                Vector3 delta_pos = transform.position - old_position;
                remainder_pos += delta_pos;

            }
            old_position = transform.position;
            ignore_move = false;
        }
    }

}
