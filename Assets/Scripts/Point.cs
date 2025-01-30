using UnityEngine;

public class Point
{
    public Vector3 position;
    public Vector3 normal;

    public Point()
    {
        position = Vector3.zero;
        normal = Vector3.up;
    }

    public Point(Vector3 position)
    {
        this.position = position;
        normal = Vector3.up;
    }
}
