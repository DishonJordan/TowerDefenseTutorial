using UnityEngine;

public class MultiPointMovement : MonoBehaviour
{

    public float speed;
    private int currentPath;
    public Vector3[] orderedPoints = new Vector3[4];

    void Start()
    {
        currentPath = 1;
        transform.position = orderedPoints[0];
    }
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, orderedPoints[currentPath], Time.deltaTime * speed);
        if (transform.position == orderedPoints[currentPath])
        {
            if (currentPath == 3)
            {
                currentPath = 0;
            }
            else
            {
                currentPath++;
            }
        }
    }
}
