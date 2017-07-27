using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : MonoBehaviour {

	public GameObject EnemyBullet1;
	public int health = 100;
	public float turnSpeed = 150f;
	public int rotateAngle = 39;
	public float bulletSpeed = 8f;
	public float fireRate = 1f;
	private float nextFire = 0.0f;
	private int rAngle1;
	private int rAngle2;


	void Start () {
		//the angle the square rotates back and forth from
		rAngle1 = rotateAngle;
		rAngle2 = rotateAngle;
	}

	void Update () {
		
		//fire bullets at consistent interval
		if (Time.time > nextFire) {
			
			nextFire = Time.time + fireRate;
			fire ();
		}

		//health maintenance
		if (health <= 0){
			Destroy (gameObject);
		}


		//Rotate the object back and forth
		if (rAngle1 != 0) {
			transform.Rotate (Vector3.forward, turnSpeed * Time.deltaTime);
			rAngle1 -= 1;
		} else {
			transform.Rotate (-Vector3.forward, turnSpeed * Time.deltaTime);
			rAngle2 -= 1;
			if (rAngle2 == 0){
				rAngle1 = rotateAngle;
				rAngle2 = rotateAngle;
			}
		}
	}

	void fire(){
		//fire bullets

		if (GameObject.FindGameObjectWithTag ("Player") != null) {
			Vector2 bulletPos = transform.position;
			var bullet = (GameObject)Instantiate (EnemyBullet1, bulletPos, Quaternion.identity);

			GameObject player = GameObject.FindGameObjectWithTag ("Player");
		
			Vector3 direction = (player.transform.position - transform.position);
			direction.Normalize ();
			bullet.GetComponent<Rigidbody2D> ().velocity = direction * bulletSpeed;
			Destroy (bullet, 7.0f);

		}
	}
		
}
