using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionBlockingManger : MonoBehaviour {

    private float zone_width;
    private Vector3 zone_pos;
    private Vector3 remainder_pos;

    public FocusPositionBlockingManager focus;

    private void Start()
    {
        zone_width = focus.zone_width;

        focus.EventZoneChanged += ZoneChange;

        zone_pos = new Vector3((int)(transform.position.x / zone_width), (int)(transform.position.y / zone_width), (int)(transform.position.z / zone_width));
        remainder_pos = transform.position - (zone_pos * zone_width);
    }


    private void ZoneChange(Vector3 new_zone)
    {
        if(new_zone.x >= zone_pos.x - 1 && new_zone.x <= zone_pos.x + 1 &&
           new_zone.y >= zone_pos.y - 1 && new_zone.y <= zone_pos.y + 1 &&
           new_zone.z >= zone_pos.z - 1 && new_zone.z <= zone_pos.z + 1)
        {
            gameObject.SetActive(true);

            transform.position = remainder_pos;
            //adjusts for being in neighboring zones
            transform.position = new Vector3(
                transform.position.x + ((zone_pos.x - new_zone.x) * zone_width),
                transform.position.y + ((zone_pos.y - new_zone.y) * zone_width),
                transform.position.z + ((zone_pos.z - new_zone.z) * zone_width));
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
}
