using UnityEngine;
using System.Collections;
public class CameraFollowCursor : MonoBehaviour {
	float midpointX;
	float midpointY;

	// if you place the target object in unity more than 6 camera will do nothing
	public float limit = 6 ;

	public Camera cam;

	public Transform target;

	void Update () 
	{
		midpointX = transform.position.x + target.transform.position.x / 2;
		midpointY = transform.position.y + target.transform.position.y / 2;
		if (target.position.x <= limit & target.position.y <= limit) 
		{
			cam.transform.position = new Vector3 (midpointX,midpointY,-10);
		}
	}
}