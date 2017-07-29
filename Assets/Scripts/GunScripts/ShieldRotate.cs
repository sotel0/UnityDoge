using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldRotate : MonoBehaviour {

	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;

	private int type = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//update its position
		if(Input.GetKeyDown(moveUp)){
			if (type != 1 || type == 0) {
				transform.eulerAngles = new Vector3 (
					transform.eulerAngles.x, 
					transform.eulerAngles.y,
					180);
				type = 1;
			}
		} else if(Input.GetKeyDown(moveDown)){
			if (type != 2 || type == 0) {
				transform.eulerAngles = new Vector3 (
					transform.eulerAngles.x, 
					transform.eulerAngles.y,
					0);
				type = 2;
			}
		} else if(Input.GetKeyDown(moveLeft)){
			if (type != 3 || type == 0) {
				transform.eulerAngles = new Vector3 (
					transform.eulerAngles.x, 
					transform.eulerAngles.y,
					-90);
				type = 3;
			}
		} else if(Input.GetKeyDown(moveRight)){
			if (type != 4 || type == 0) {
				transform.eulerAngles = new Vector3 (
					transform.eulerAngles.x, 
					transform.eulerAngles.y,
					90);
				type = 4;
			}
		}

	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("EnemyBullet")){
			Destroy (col.gameObject);
		}
	}
		
}
