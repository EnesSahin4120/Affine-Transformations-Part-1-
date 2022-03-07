using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject point;
    public Vector3 directionVector;
    //public Vector3 angle;
    public float rodriguesAngle;

    private bool isPressed;
    private void Start()
    {
        //angle = angle * Mathf.Deg2Rad;
        rodriguesAngle *= Mathf.Deg2Rad;

        Debug.DrawLine(Vector3.zero, point.transform.position, Color.black, Mathf.Infinity);
    }

    private void Update()
    {
        if (!isPressed && Input.GetMouseButtonDown(0))
        {
            isPressed = true;


            //----------------------------  FOR TRANSLATE  -----------------------------

            /*Coordinates position = new Coordinates(point.transform.position, 1);
            point.transform.position = Mathematics.Translate(position,
                                       new Coordinates(new Vector3(directionVector.x, directionVector.y, directionVector.z), 0)).ToVector();*/



            //----------------------------  FOR ROTATE  -----------------------------

            /*Coordinates position = new Coordinates(point.transform.position, 1);
            point.transform.position = Mathematics.Rotate(position, angle.x, false, angle.y, false, angle.z, false).ToVector();*/

            //----------------------------  FOR RODRIGUES ROTATE  -----------------------------

            Coordinates position = new Coordinates(point.transform.position, 1);
            point.transform.position = Mathematics.RodriguesRotate(position, 
                                       new Coordinates(directionVector.x, directionVector.y, directionVector.z), rodriguesAngle, true).ToVector();

            Debug.DrawLine(Vector3.zero, point.transform.position, Color.white, Mathf.Infinity);

        }
    }
}
