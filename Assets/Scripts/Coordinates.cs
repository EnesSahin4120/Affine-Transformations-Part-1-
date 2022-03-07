using UnityEngine;

public class Coordinates : MonoBehaviour
{
    public float x;
    public float y;
    public float z;
    public float w;

    public Coordinates(float _x, float _y, float _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }

    public Coordinates(float _x, float _y, float _z,float _w)
    {
        x = _x;
        y = _y;
        z = _z;
        w = _w;
    }

    public Coordinates(Vector3 vectorPosition,float _w)
    {
        x = vectorPosition.x;
        y = vectorPosition.y;
        z = vectorPosition.z;
        w = _w;
    }

    public float[,] AsMatrixElements()
    {
        float[,] values = { { x }, { y }, { z }, { w } };
        return values;
    }

    public Coordinates(Vector3 vectorPosition)
    {
        x = vectorPosition.x;
        y = vectorPosition.y;
        z = vectorPosition.z;
    }

    static public Coordinates operator +(Coordinates a, Coordinates b)
    {
        Coordinates c = new Coordinates(a.x + b.x, a.y + b.y, a.z + b.z);
        return c;
    }

    static public Coordinates operator -(Coordinates a, Coordinates b)
    {
        Coordinates c = new Coordinates(a.x - b.x, a.y - b.y, a.z - b.z);
        return c;
    }

    public Vector3 ToVector()
    {
        return new Vector3(x, y, z);
    }

    public override string ToString()
    {
        return "(" + x + "," + y + "," + z + ")";
    }
}
