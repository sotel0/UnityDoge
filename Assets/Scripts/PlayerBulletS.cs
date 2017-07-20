using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletS : MonoBehaviour {


	void Start(){

	}

	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision){
		//if the collision is with enemy
		if (collision.gameObject.CompareTag ("Enemy")) {
			//and the enemy has this script
			if (collision.gameObject.GetComponent<Enemy1S> () != null) {
				//decrease its health
				collision.gameObject.GetComponent<Enemy1S> ().health -= 10;
			}
		}
	}

}
