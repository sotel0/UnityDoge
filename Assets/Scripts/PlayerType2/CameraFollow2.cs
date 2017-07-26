using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour {

	private Vector2 velocity;
	public float smoothTimeX;
	public float smoothTimeY;
	private Vector3 offset;
	private GameObject player;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");	
		offset = transform.position - player.transform.position;
	}
		
	void LateUpdate () 
	{
		// Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
		transform.position = player.transform.position + offset;
	}
}
