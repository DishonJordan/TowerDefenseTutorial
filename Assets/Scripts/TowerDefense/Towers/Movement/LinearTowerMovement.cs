using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearTowerMovement : MonoBehaviour
{
    //The position designating the start position of the turret's movement.
    public Transform start_position;
    //The position designating the end position of the turret's movement.
    public Transform end_position;
    //The speed that the turret oscillates.
    public float speed;

    float initial_time;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = start_position.position;
        initial_time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(start_position.position, end_position.position, Mathf.PingPong((Time.time - initial_time) * speed, 1.0f));
    }
}
