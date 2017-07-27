using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour {


	void Start(){

	}

	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		//if the collision is with enemy
		if (collision.gameObject.CompareTag ("Enemy")) {
			//and the enemy has this script
			if (collision.gameObject.GetComponent<Square> () != null) {
				//decrease its health
				collision.gameObject.GetComponent<Square> ().health -= 10;

				//make enemy flash
				collision.gameObject.GetComponent<Flasher> ().startFlash ();
			}
		}
	}

}
