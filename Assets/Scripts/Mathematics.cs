using UnityEngine;

public class Mathematics : MonoBehaviour
{
    static public Coordinates Translate(Coordinates pos, Coordinates vector)
    {
        float[,] translateElements =
        {
            {1, 0, 0, vector.x },
            {0, 1, 0, vector.y },
            {0, 0, 1, vector.z },
            {0, 0, 0, 1 }
        };
        Matrix translateMatrix = new Matrix(4, 4, translateElements);
        Matrix positionMatrix = new Matrix(4, 1, pos.AsMatrixElements());

        Matrix resultMatrix = translateMatrix * positionMatrix;
        Coordinates resultCoordinates = resultMatrix.AsCoordinates();

        return resultCoordinates;
    }

    static public Coordinates Rotate(Coordinates position, float xAngle, bool clockwiseX,
                                                           float yAngle, bool clockwiseY,
                                                           float zAngle, bool clockwiseZ)
    {
        if (clockwiseX)
        {
            xAngle = 2 * Mathf.PI - xAngle;
        }
        if (clockwiseY)
        {
            yAngle = 2 * Mathf.PI - yAngle;
        }
        if (clockwiseZ)
        {
            zAngle = 2 * Mathf.PI - zAngle;
        }

        float[,] xValues = { { 1, 0, 0, 0},
                             { 0, Mathf.Cos(xAngle), -Mathf.Sin(xAngle), 0},
                             { 0, Mathf.Sin(xAngle), Mathf.Cos(xAngle), 0},
                             { 0, 0, 0, 1}
        };
        Matrix xMatrix = new Matrix(4, 4, xValues);

        float[,] yValues = { { Mathf.Cos(yAngle), 0, Mathf.Sin(yAngle), 0 },
                             { 0, 1, 0, 0 },
                             { -Mathf.Sin(yAngle), 0, Mathf.Cos(yAngle), 0 },
                             { 0, 0, 0, 1} 
        };
        Matrix yMatrix = new Matrix(4, 4, yValues);

        float[,] zValues = { { Mathf.Cos(zAngle), -Mathf.Sin(zAngle), 0, 0 },
                             { Mathf.Sin(zAngle), Mathf.Cos(zAngle), 0, 0 },
                             { 0, 0, 1, 0 },
                             { 0, 0, 0, 1 } 
        };
        Matrix zMatrix = new Matrix(4, 4, zValues);
        Matrix posMatrix = new Matrix(4, 1, position.AsMatrixElements());

        Matrix resultMatrix = xMatrix * yMatrix * zMatrix * posMatrix;
        Coordinates resultCoordinates = resultMatrix.AsCoordinates();

        return resultCoordinates;
    }

    static public Coordinates RodriguesRotate(Coordinates position, Coordinates direction, float angle, bool clockwise)
    {
        if (clockwise)
        {
            angle = 2 * Mathf.PI - angle;
        }

        float dirX = direction.x, dirY = direction.y, dirZ = direction.z;
        float ca = Mathf.Cos(angle), sa = Mathf.Sin(angle);
        float t = 1 - ca;

        float[,] rodriguesElements = { { ca + (dirX * dirX * t), (dirX * dirY * t) - (dirZ * sa), (dirX * dirZ * t) + (dirY * sa), 0 },
            { (dirX * dirY * t) + (dirZ * sa) , ca + (dirY * dirY * t), (dirY * dirZ * t) - (dirX * sa), 0 },
            { (dirX * dirZ * t) - (dirY * sa) , (dirZ * dirY * t) + (dirX * sa) , ca + (dirZ * dirZ * t), 0 },
            { 0, 0, 0, 1 }
        };

        Matrix rodriguesMatrix = new Matrix(4, 4, rodriguesElements);
        Matrix posMatrix = new Matrix(4, 1, position.AsMatrixElements());

        Matrix resultMatrix = rodriguesMatrix * posMatrix;
        Coordinates resultCoordinates = resultMatrix.AsCoordinates();

        return resultCoordinates;
    }
}
