using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircunferenceRange : MonoBehaviour {

    [SerializeField]
    float r = 5, a = 45;

    [SerializeField]
    GameObject targetPoint;

    [SerializeField]
    LayerMask hitMasking;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity, hitMasking))
        {
            Vector3 currentPoint = hit.point;

            if (Input.GetMouseButtonDown(0))
            {
                currentPoint.y += transform.localScale.y / 2;

                transform.position = currentPoint;
            }


            float theta = Mathf.Atan2(hit.point.z - transform.position.z, hit.point.x - transform.position.x);
            Vector3 edge = new Vector3(r * Mathf.Cos(theta), transform.position.y, r * Mathf.Sin(theta));
            Debug.DrawLine(transform.position, transform.position + edge);
            float dist = EuclidianDistance(transform.position, currentPoint);
            if (dist <= r)
            {
                currentPoint = hit.point;
                currentPoint.y += targetPoint.transform.localScale.y / 2;

                targetPoint.transform.position = currentPoint;
            } else {
                targetPoint.transform.position = transform.position +  edge;
            }

        }


    }

    float EuclidianDistance(Vector3 pointA, Vector3 pointB)
    {
        return Mathf.Sqrt(Mathf.Pow(pointA.x - pointB.x, 2) + Mathf.Pow(pointA.y - pointB.y, 2) + Mathf.Pow(pointA.z - pointB.z, 2));
    }

    float Yc (Vector3 Center, Vector3 Point, float Xc)
    {
        return ((Center.x * Point.y) + (Center.y * Xc) + (Point.y * Xc) - (Center.y * Point.x)) / (Point.x - Center.x);
    }
}
