using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearTowerMovement : MonoBehaviour
{
    //Tower movement speed
    public float speed;

    //Defines that part of the traversal we are on
    int segment;

    //Holds an ordered set of points to be traversed 
    public Vector3[] points = new Vector3[2];

    // Start is called before the first frame update
    void Start()
    {
        //Initializing the segments, start position
        segment = 1;
        transform.position = points[0];
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.MoveTowards(transform.position, points[segment], Time.deltaTime * speed);
        if (transform.position == points[segment])
            segment = (segment == 1) ? 0 : segment + 1;
    }
}
