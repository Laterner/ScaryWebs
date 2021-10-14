using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateAround : MonoBehaviour {

	public Transform target;
	public Vector3 offset;
	public float sensitivity = 3; // чувствительность мышки
	public float limitX = 80; // ограничение вращения по Y
	public float limitY = -10; // ограничение вращения по Y
	public float zoom = 0.25f; // чувствительность при увеличении, колесиком мышки
	public float zoomMax = 10; // макс. увеличение
	public float zoomMin = 3; // мин. увеличение

	[SerializeField] private float X, Y;

	private bool mouseIsPressed;

	void Start () 
	{
		limitX = Mathf.Abs(limitX);
		if(limitX > 90) limitX = 90;
		//offset = new Vector3(offset.x, offset.y, -Mathf.Abs(zoomMax)/2);
		offset = new Vector3(0, 0, -10);
		//transform.position = target.position + offset;
		
		transform.localEulerAngles = new Vector3(90, X, 0);
		//transform.position = offset + target.position;
	}

	void Update ()
	{
		if(Input.GetMouseButtonDown(1)) mouseIsPressed = true; 
		if(Input.GetMouseButtonUp(1)) mouseIsPressed = false;

		if (Input.GetAxis("Mouse ScrollWheel") > 0) offset.z += zoom * sensitivity;
		else if (Input.GetAxis("Mouse ScrollWheel") < 0) offset.z -= zoom * sensitivity;
		offset.z = Mathf.Clamp(offset.z, -Mathf.Abs(zoomMax), -Mathf.Abs(zoomMin));

		if (mouseIsPressed)
        {
			X += Input.GetAxis("Mouse X") * sensitivity;
			Y += Input.GetAxis("Mouse Y") * sensitivity;
			Y = Mathf.Clamp(Y, -limitX, limitY);
			transform.localEulerAngles = new Vector3(-Y, X, 0);
			
		}
		transform.position = transform.localRotation * offset + target.position;
	}
}
//X = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivity;
//Y += Input.GetAxis("Mouse Y") * sensitivity;
//Y = Mathf.Clamp(Y, -limit, limit);
//transform.localEulerAngles = new Vector3(-Y, X, 0);