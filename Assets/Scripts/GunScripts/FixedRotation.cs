using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotation : MonoBehaviour {
	Quaternion rotation;
	int type = 0;
	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;

	void Awake()
	{
		rotation = transform.rotation;
	}
	void LateUpdate()
	{
		transform.rotation = rotation;


		//update its position
		if(Input.GetKeyDown(moveUp)){
			if (type != 1 || type == 0) {
				transform.eulerAngles = new Vector3 (
					transform.eulerAngles.x, 
					transform.eulerAngles.y,
					180);
				type = 1;
				rotation = transform.rotation;
			}
		} else if(Input.GetKeyDown(moveDown)){
			if (type != 2 || type == 0) {
				transform.eulerAngles = new Vector3 (
					transform.eulerAngles.x, 
					transform.eulerAngles.y,
					0);
				type = 2;
				rotation = transform.rotation;
			}
		} else if(Input.GetKeyDown(moveLeft)){
			if (type != 3 || type == 0) {
				transform.eulerAngles = new Vector3 (
					transform.eulerAngles.x, 
					transform.eulerAngles.y,
					-90);
				type = 3;
				rotation = transform.rotation;
			}
		} else if(Input.GetKeyDown(moveRight)){
			if (type != 4 || type == 0) {
				transform.eulerAngles = new Vector3 (
					transform.eulerAngles.x, 
					transform.eulerAngles.y,
					90);
				type = 4;
				rotation = transform.rotation;
			}
		}

	}
}
