using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	private Vector2 velocity;
	public float smoothTimeX;
	public float smoothTimeY;
	private Vector3 offset;
	private GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");	
		offset = transform.position - player.transform.position;
	}
		
	void FixedUpdate(){
		//to make the camera lag behind

//		float posX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothTimeX);
//		float posY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothTimeY);
//		transform.position = new Vector3 (posX, posY, transform.position.z);

	}
	void LateUpdate () 
	{
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		transform.position = player.transform.position + offset;
	}
}
