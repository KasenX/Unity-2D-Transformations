using UnityEngine;

public class IGB283Vector3 
{
    private readonly float[] components = new float[3];

    public float x
    {
        get => components[0];
        set => components[0] = value;
    }
    public float y
    {
        get => components[1];
        set => components[1] = value;
    }
    public float z
    {
        get => components[2];
        set => components[2] = value;
    }

    public IGB283Vector3()
    {
        components[0] = 0;
        components[1] = 0;
        components[2] = 0;
    }

    public IGB283Vector3(float x, float y, float z)
    {
        components[0] = x;
        components[1] = y;
        components[2] = z;
    }

    public float this[int key]
    {
        get => components[key];
        set => components[key] = value;
    }

    public float magnitude
    {
        get => Mathf.Sqrt(x * x + y * y + z * z);
    }

    // Implicit conversion from Vector3 to Vector
    public static implicit operator IGB283Vector3(Vector3 v)
    {
        return new IGB283Vector3(v.x, v.y, v.z);
    }

    // Implicit conversion from Vector to Vector3
    public static implicit operator Vector3(IGB283Vector3 v)
    {
        return new Vector3(v.x, v.y, v.z);
    }

    public static IGB283Vector3 operator *(IGB283Vector3 v, float scalar)
    {
        return new IGB283Vector3(v.x * scalar, v.y * scalar, v.z * scalar);
    }

    public static IGB283Vector3 operator *(float scalar, IGB283Vector3 v)
    {
        return new IGB283Vector3(v.x * scalar, v.y * scalar, v.z * scalar);
    }

    public static IGB283Vector3 operator /(IGB283Vector3 v, float scalar)
    {
        return new IGB283Vector3(v.x / scalar, v.y / scalar, v.z / scalar);
    }

    public static IGB283Vector3 operator +(IGB283Vector3 v1, IGB283Vector3 v2)
    {
        return new IGB283Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
    }

    public static IGB283Vector3 operator -(IGB283Vector3 v)
    {
        return new IGB283Vector3(-v.x, -v.y, -v.z);
    }

    public static IGB283Vector3 operator -(IGB283Vector3 v1, IGB283Vector3 v2)
    {
        return new IGB283Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
    }

    public static IGB283Vector3 Lerp(IGB283Vector3 a, IGB283Vector3 b, float t)
    {
        return a + (b - a) * t;
    }

    public override string ToString()
    {
        return $"({x}, {y}, {z})";
    }
}
