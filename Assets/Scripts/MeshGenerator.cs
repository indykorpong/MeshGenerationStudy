using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class MeshGenerator : MonoBehaviour
{
    public int width = 10;
    public int height = 10;

    private readonly List<Point> points = new();
    private readonly List<int> triangles = new();

    private Mesh mesh;

    void OnEnable()
    {
        mesh = new() { name = "Procedural Mesh" };
        GetComponent<MeshFilter>().mesh = mesh;

        GenerateStarterMesh();
    }

    void GenerateStarterMesh()
    {
        for (int y = 0; y < height + 1; y++)
        {
            for (int x = 0; x < width + 1; x++)
            {
                points.Add(new Point());
            }
        }

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                int i = y * (width + 1) + x;
                int j = i + width + 1;
                int k = i + 1;
                triangles.Add(i);
                triangles.Add(j);
                triangles.Add(k);

                int l = j + 1;
                triangles.Add(j);
                triangles.Add(l);
                triangles.Add(k);

                points[i].position = new Vector3(x, 0, y);
                points[j].position = new Vector3(x, 0, y + 1);
                points[k].position = new Vector3(x + 1, 0, y);
                points[l].position = new Vector3(x + 1, 0, y + 1);
            }
        }

        mesh.vertices = points.Select((p) => p.position).ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.normals = points.Select((p) => p.normal).ToArray();
    }
}
