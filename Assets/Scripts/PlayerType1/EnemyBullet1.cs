using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet1 : MonoBehaviour {

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
			PlayerControls1 player = other.gameObject.GetComponent<PlayerControls1>();

			//make player's texture flash red
			player.startFlash();

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
