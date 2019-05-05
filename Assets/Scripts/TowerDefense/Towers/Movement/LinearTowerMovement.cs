using UnityEngine;

public class LinearTowerMovement : MonoBehaviour
{
    public float speed;
    private int currentPath;
    public Vector3[] orderedPoints = new Vector3[2];

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
            if (currentPath == 1)
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
