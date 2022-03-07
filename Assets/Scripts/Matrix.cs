public class Matrix 
{
    public int rows;
    public int columns;
    public float[,] elements;
    
    public Matrix(int r,int c, float[,] e)
    {
        rows = r;
        columns = c;
        elements = e;
    }

    public Coordinates AsCoordinates()
    {
        if (rows == 4 && columns == 1)
            return new Coordinates(elements[0, 0], elements[1, 0], elements[2, 0], elements[3, 0]);
        else
            return null;
    }

    public override string ToString()
    {
        string result = "";
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < columns; j++)
            {
                result += elements[i, j].ToString();
                result += "\n";
            }
        }
        return result;
    }

    static public Matrix operator +(Matrix a,Matrix b)
    {
        if (a.rows != b.rows || a.columns != b.columns)
            return null;

        Matrix resultMatrix = a;
        for(int i = 0; i < a.rows; i++)
        {
            for(int j = 0; j < b.columns; j++)
            {
                resultMatrix.elements[i, j] = a.elements[i, j] + b.elements[i, j];
            }
        }

        return resultMatrix;
    }

    static public Matrix operator *(Matrix a,Matrix b)
    {
        if (a.columns != b.rows)
            return null;

        float[,] resultElements = new float[a.rows, b.columns];
        for(int i = 0; i < a.rows; i++)
        {
            for(int j = 0; j < b.columns; j++)
            {
                for(int k = 0; k < a.columns;k++)
                {
                    resultElements[i, j] += a.elements[i, k] * b.elements[k, j];
                }
            }
        }

        Matrix resultMatrix = new Matrix(a.rows, b.columns, resultElements);
        return resultMatrix;
    }

    
}
