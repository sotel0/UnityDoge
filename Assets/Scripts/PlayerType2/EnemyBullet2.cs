using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		//if the collision is with player
		if (other.gameObject.CompareTag ("Player")) {
			//damage player
			PlayerControls2 player = other.gameObject.GetComponent<PlayerControls2>();

			//make player's texture flash red
			other.gameObject.GetComponent<Flasher>().startFlash();

			//damage player
			player.takeDamage(10);


			//destroy bullet
			Destroy (gameObject);
		}
		if (other.gameObject.CompareTag("Wall")){
			Destroy (gameObject);
		}
	}

}
