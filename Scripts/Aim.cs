using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

    [SerializeField]
    float magnitude = 3, aimRange = 0, shotAngle = 0, offset = 1, offset2 = 0;
    [SerializeField, Range(0.5f, 2)]
    float sideRange = 1;
    Vector3 direction,direction2, origin, origin2, direction3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        shotAngle = Mathf.Clamp(shotAngle, -aimRange / 2, aimRange / 2);

        direction = new Vector3(transform.localPosition.x + (Mathf.Cos((-transform.eulerAngles.y + (aimRange/2)) * Mathf.Deg2Rad)), 0, transform.localPosition.z + (Mathf.Sin((-transform.eulerAngles.y + (aimRange/2)) * Mathf.Deg2Rad))) * magnitude;
        direction2 = new Vector3(transform.localPosition.x + (Mathf.Cos((-transform.eulerAngles.y - (aimRange/2)) * Mathf.Deg2Rad)), 0, transform.localPosition.z + (Mathf.Sin((-transform.eulerAngles.y - (aimRange/2)) * Mathf.Deg2Rad))) * magnitude;
        direction3 = new Vector3(transform.localPosition.x + (Mathf.Cos((-transform.eulerAngles.y + shotAngle) * Mathf.Deg2Rad)), 0, transform.localPosition.z + (Mathf.Sin((-transform.eulerAngles.y + shotAngle) * Mathf.Deg2Rad))) * magnitude;

        origin = new Vector3(transform.localPosition.x + Mathf.Cos((-transform.eulerAngles.y) * Mathf.Deg2Rad), 0, transform.localPosition.z + Mathf.Sin((-transform.eulerAngles.y) * Mathf.Deg2Rad)) * offset;
        origin2 = new Vector3(transform.localPosition.x + Mathf.Cos((-transform.eulerAngles.y) * Mathf.Deg2Rad), 0, transform.localPosition.z + Mathf.Sin((-transform.eulerAngles.y) * Mathf.Deg2Rad)) * offset;

        Debug.DrawLine(transform.position + origin, transform.position + direction);
        Debug.DrawLine(transform.position + origin2, transform.position + direction2);

        Debug.DrawLine(transform.position, transform.position + direction3);
    }
}