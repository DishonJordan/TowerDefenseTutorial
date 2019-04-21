using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTowerMovement : MonoBehaviour
{
    //The position designating the start position of the turret's movement.
    public Transform start_position;
    //The position designating the middle position of the turret's movement.
    public Transform middle_position;
    //The position designating the end position of the turret's movement.
    public Transform end_position;
    //The speed that the turret oscillates.
    public float speed;
    //Controls which segment/direction the turret is traveling
    // 0 - start->mid
    // 1 - mid->end
    // 2 - end->mid
    // 3 - mid->start
    int segment;

    // Start is called before the first frame update
    void Start()
    {
        segment = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (segment) {
            case 0:
                transform.position = Vector3.Lerp(start_position.position, middle_position.position, Mathf.PingPong(Time.time * speed, 1.0f));
                segment = (Math.Abs(Vector3.Distance(transform.position,middle_position.position)) < 0.2f) ? 1 : 0;
                break;
            case 1:
                transform.position = Vector3.Lerp(middle_position.position, end_position.position, Mathf.PingPong(Time.time * speed, 1.0f));
                segment = (Math.Abs(Vector3.Distance(transform.position, end_position.position)) < 0.2f) ? 2 : 1;
                break;
            case 2:
                transform.position = Vector3.Lerp(end_position.position, middle_position.position, Mathf.PingPong(Time.time * speed, 1.0f));
                segment = (Math.Abs(Vector3.Distance(transform.position, middle_position.position)) < 0.2f) ? 3 : 2;
                break;
            case 3:
                transform.position = Vector3.Lerp(middle_position.position, start_position.position, Mathf.PingPong(Time.time * speed, 1.0f));
                segment = (Math.Abs(Vector3.Distance(transform.position, start_position.position)) < 0.2f) ? 0 : 3;
                break;
            default:
                break;

        }
        Debug.Log(segment);
    }
}
