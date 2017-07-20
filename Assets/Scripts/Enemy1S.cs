using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1S : MonoBehaviour {

	public GameObject EnemyBullet1;
	public int health = 100;
	public float turnSpeed = 150f;
	public int rotateCount = 39;
	public int bulletSpeed = 1;
	public float fireRate = 1f;
	private float nextFire = 0.0f;
	private int rCount1;
	private int rCount2;


	void Start () {
		rCount1 = rotateCount;
		rCount2 = rotateCount;
	}

	void Update () {
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			fire ();
		}

		//health maintenance
		if (health <= 0){
			Destroy (gameObject);
		}


		//Rotate the object back and forth
		if (rCount1 != 0) {
			transform.Rotate (Vector3.forward, turnSpeed * Time.deltaTime);
			rCount1 -= 1;
		} else {
			transform.Rotate (-Vector3.forward, turnSpeed * Time.deltaTime);
			rCount2 -= 1;
			if (rCount2 == 0){
				rCount1 = rotateCount;
				rCount2 = rotateCount;
			}
		}
	}

	void FixedUpdate(){

	}

	void fire(){
		Vector2 bulletPos = transform.position;
		var bullet = (GameObject)Instantiate (EnemyBullet1, bulletPos, Quaternion.identity);
		bullet.GetComponent<Renderer>().material.color = new Color(Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f),1);

		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		bullet.GetComponent<Rigidbody2D>().velocity = (player.transform.position - transform.position)* bulletSpeed;

		Destroy (bullet, 2.0f);
	}
		
}
