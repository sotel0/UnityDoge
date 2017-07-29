﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDestroyBullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col){
		if(col.gameObject.CompareTag("EnemyBullet")){
			Destroy (col.gameObject);
		}
	}
}
