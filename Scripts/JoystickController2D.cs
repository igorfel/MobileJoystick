using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickController2D : MonoBehaviour {

    [SerializeField]
    float radius = 55, weight = 1;

    [SerializeField]
    Transform Joystick = null;

    Vector3 edge;

    public float Horizontal { get { return NormalizeCornerValues(Joystick.position.x, transform.position.x, radius); } }
    public float Vertical { get { return NormalizeCornerValues(Joystick.position.y, transform.position.y, radius); } }

    /// <summary>
    /// Normalize the joystick output to -1 and 1
    /// </summary>
    /// <param name="a">Current position</param>
    /// <param name="_center">Joystick center</param>
    /// <param name="_radius">Joystick radius</param>
    /// <returns></returns>
    float NormalizeCornerValues(float a, float _center, float _radius)
    {
        return ((2 * (a - (_center - _radius))) / ((_center + radius) - (_center - _radius))) - 1;
    }

    /// <summary>
    /// Applies the gravity that pulls the joystick back to the center
    /// </summary>
    public void CenterRecall()
    {
        Vector3 diff = transform.position - Joystick.position;

        if(EuclidianDistance(transform.position, Joystick.position) > 0.1f)
        {
            Joystick.position += diff.normalized * Time.deltaTime;
            InvokeRepeating("CenterRecall", 0, weight);
        }
        else if(IsInvoking("CenterRecall"))
        {
            Joystick.position = transform.position;
            CancelInvoke("CenterRecall");
        }
    }

    public void FollowMouse()
    {
        if (IsInvoking("CenterRecall"))
        {
            CancelInvoke("CenterRecall");
        }

        Vector3 currentPoint = Input.mousePosition;
        float theta = Mathf.Atan2(currentPoint.y - transform.position.y, currentPoint.x - transform.position.x);
        edge = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta));
#if UNITY_EDITOR
        Debug.DrawLine(transform.position, transform.position + edge);
#endif
        if (EuclidianDistance(transform.position, currentPoint) > radius)
        {
            Joystick.transform.position = transform.position + edge;
        }
        else
        {
            Joystick.transform.position = currentPoint;
        }
    }

    float EuclidianDistance(Vector3 pointA, Vector3 pointB)
    {
        return Mathf.Sqrt(Mathf.Pow(pointA.x - pointB.x, 2) + Mathf.Pow(pointA.y - pointB.y, 2));
    }
}
