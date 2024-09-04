using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainObject : MonoBehaviour
{
    public float speed = 1;
    public float rotationSpeed = 1;
    public GameObject boundaryObject1;
    public GameObject boundaryObject2;
    // Used Vector3 so that it can be serialized in the inspector
    public Vector3 boundaryScale1 = new Vector3(1.0f, 1.0f, 1.0f);
    public Vector3 boundaryScale2 = new Vector3(0.5f, 2.0f, 1.0f);
    public Color color1 = Color.black;
    public Color color2 = Color.yellow;
    public Material material;

    private IGB283Vector3 point1;
    private IGB283Vector3 point2;
    private bool towardsPoint1 = true;
    private IGB283Vector3 position = new IGB283Vector3(0, 0, 0);
    private IGB283Vector3 scale = new IGB283Vector3(1, 1, 1);
    private float rotation = 0;
    private Mesh mesh;

    private Vector3[] meshVertices = new Vector3[] {
        // Head
        new Vector3(-0.2308f, 0.3077f, 0.0f),  // 0
        new Vector3(-0.1538f, 0.3077f, 0.0f),  // 1
        new Vector3(-0.1538f, 0.5385f, 0.0f),  // 2
        new Vector3(-0.1538f, 0.6923f, 0.0f),  // 3
        new Vector3(-0.0769f, 0.5385f, 0.0f),  // 4
        new Vector3( 0.0769f, 0.5385f, 0.0f),  // 5
        new Vector3( 0.1538f, 0.6923f, 0.0f),  // 6
        new Vector3( 0.1538f, 0.5385f, 0.0f),  // 7
        new Vector3( 0.1538f, 0.3077f, 0.0f),  // 8
        new Vector3( 0.2308f, 0.3077f, 0.0f),  // 9
        // Body
        new Vector3(-0.2308f, -0.2308f, 0.0f), // 10
        new Vector3( 0.0000f, -0.6923f, 0.0f), // 11
        new Vector3( 0.2308f, -0.2308f, 0.0f), // 12
        // Right wing
        new Vector3( 0.3846f, 0.2308f, 0.0f),  // 13
        new Vector3( 0.5385f, 0.3077f, 0.0f),  // 14
        new Vector3( 0.5385f, 0.2308f, 0.0f),  // 15
        new Vector3( 0.3846f, 0.6154f, 0.0f),  // 16
        new Vector3( 0.9231f, 0.3077f, 0.0f),  // 17
        new Vector3( 1.0000f, 0.0769f, 0.0f),  // 18
        new Vector3( 0.9231f, 0.0769f, 0.0f),  // 19
        new Vector3( 0.9231f, -0.2308f, 0.0f), // 20
        new Vector3( 0.5385f, -0.2308f, 0.0f), // 21
        new Vector3( 0.5385f, -0.1538f, 0.0f), // 22
        new Vector3( 0.3846f, -0.1538f, 0.0f), // 23
        new Vector3( 0.2308f, 0.2308f, 0.0f),  // 24
        new Vector3( 0.2308f, -0.1538f, 0.0f), // 25
        // Left wing
        new Vector3(-0.3846f, 0.2308f, 0.0f),  // 26
        new Vector3(-0.5385f, 0.3077f, 0.0f),  // 27
        new Vector3(-0.5385f, 0.2308f, 0.0f),  // 28
        new Vector3(-0.3846f, 0.6154f, 0.0f),  // 29
        new Vector3(-0.9231f, 0.3077f, 0.0f),  // 30
        new Vector3(-1.0000f, 0.0769f, 0.0f),  // 31
        new Vector3(-0.9231f, 0.0769f, 0.0f),  // 32
        new Vector3(-0.9231f, -0.2308f, 0.0f), // 33
        new Vector3(-0.5385f, -0.2308f, 0.0f), // 34
        new Vector3(-0.5385f, -0.1538f, 0.0f), // 35
        new Vector3(-0.3846f, -0.1538f, 0.0f), // 36
        new Vector3(-0.2308f, 0.2308f, 0.0f),  // 37
        new Vector3(-0.2308f, -0.1538f, 0.0f)  // 38
    };

    private Color[] meshColors = new Color[] {
        // Head
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        // Body
        Color.black,
        Color.black,
        Color.black,
        // Right wing
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        // Left wing
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
        Color.black,
    };

    private int[] meshTriangles = new int[] {
        // Head
        0, 1, 2,
        2, 3, 4,
        5, 6, 7,
        7, 8, 9,
        1, 2, 7,
        1, 7, 8,
        // Body
        0, 10, 9,
        10, 9, 12,
        10, 11, 12,
        // Right wing
        24, 9, 13,
        13, 14, 15,
        14, 16, 17,
        14, 17, 21,
        21, 20, 17,
        17, 19, 18,
        19, 18, 20,
        21, 22, 23,
        23, 25, 12,
        24, 25, 15,
        25, 22, 15,
        // Left wing
        0, 37, 26,
        26, 27, 28,
        27, 29, 30,
        30, 31, 32,
        31, 32, 33,
        27, 30, 33,
        27, 33, 34,
        34, 35, 36,
        36, 38, 10,
        28, 35, 37,
        35, 37, 38
    };

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        GetComponent<MeshRenderer>().material = material;

        mesh = GetComponent<MeshFilter>().mesh;

        DrawObject();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateBoundaries();

        Vector3 pathVector = point2 - point1;
        Vector3 pathPositionVector = position - point1;
        float pathRatio = pathPositionVector.magnitude / pathVector.magnitude;

        Matrix3x3 TO = TranslateOrigin();
        Matrix3x3 T = Translate();
        Matrix3x3 S = Scale(pathRatio);
        Matrix3x3 RO = RotateOrigin();
        Matrix3x3 R = Rotate();

        // Orders of transformations -> right to left
        Matrix3x3 transformMatrix = T * R * S * RO * TO;

        Color color = Color.Lerp(color1, color2, pathRatio);

        Vector3[] vertices = meshVertices;
        Color[] colors = meshColors;

        for (int i = 0; i < vertices.Length; i++)
		{
			vertices[i] = transformMatrix.MultiplyPoint(vertices[i]);
            colors[i] = color;
		}
		mesh.vertices = vertices;
        mesh.colors = colors;
		
        DrawObject();
    }

    private void DrawObject()
    {
        mesh.Clear();

        mesh.vertices = meshVertices;
        mesh.colors = meshColors;
        mesh.triangles = meshTriangles;

        mesh.RecalculateBounds();
    }

    private Matrix3x3 TranslateOrigin()
    {
        return IGB283Transform.Translate(-position);
    }

    private Matrix3x3 Translate()
    {
        IGB283Vector3 destinationPoint = towardsPoint1 ? point1 : point2;
        IGB283Vector3 destinationVector = destinationPoint - position;
        IGB283Vector3 directionVector = destinationVector / destinationVector.magnitude;
        IGB283Vector3 deltaPosition = directionVector * speed * Time.deltaTime;

        if (destinationVector.magnitude <= deltaPosition.magnitude)
        {
            // Move to destination
            deltaPosition = destinationVector;
            // Reverse direction
            towardsPoint1 = !towardsPoint1;
        }
        position += deltaPosition;

        return IGB283Transform.Translate(position);
    }

    private Matrix3x3 Scale(float pathRatio)
    {
        IGB283Vector3 nextScale = IGB283Vector3.Lerp(boundaryScale1, boundaryScale2, pathRatio);

        IGB283Vector3 scaleFactor = new IGB283Vector3(nextScale.x / scale.x, nextScale.y / scale.y, 1);
        scale = nextScale;

        return IGB283Transform.Scale(scaleFactor);
    }

    private Matrix3x3 RotateOrigin()
    {
        return IGB283Transform.Rotate(-rotation);
    }

    private Matrix3x3 Rotate()
    {
        float deltaRotation = rotationSpeed * Time.deltaTime;
        rotation += deltaRotation;
        // Normalize the rotation in radians
        rotation %= 2 * Mathf.PI;

        return IGB283Transform.Rotate(rotation);
    }

    private void UpdateBoundaries()
    {
        point1 = boundaryObject1.GetComponent<BoundaryObject>().position;
        point2 = boundaryObject2.GetComponent<BoundaryObject>().position;
    }
}
