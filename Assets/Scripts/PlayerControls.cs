﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour {

	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;
	public float speed = 5f;

	public GameObject PlayerBullet;
	public GameObject Nose;
	public float fireRate = 0.1f;
	public float nextFire = 0.0f;
	public float bulletSpeed = 12f;

	private Vector2 bulletPos;



	private Rigidbody2D rb2D;

	void Start(){
		rb2D = GetComponent<Rigidbody2D>();
	}


	void Update(){
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			fire ();
		}
			
	}

	void FixedUpdate () {

		if (Input.GetKey (moveUp) && Input.GetKey (moveRight)) {
			rb2D.velocity = new Vector2 (speed, speed);
			rb2D.MoveRotation (-45f);

		} else if (Input.GetKey (moveUp) && Input.GetKey (moveLeft)) {
			rb2D.velocity = new Vector2 (-speed, speed);
			rb2D.MoveRotation (45f);

		} else if (Input.GetKey (moveDown) && Input.GetKey (moveRight)) {
			rb2D.velocity = new Vector2 (speed, -speed);
			rb2D.MoveRotation (-135f);

		} else if (Input.GetKey (moveDown) && Input.GetKey (moveLeft)) {
			rb2D.velocity = new Vector2 (-speed, -speed);
			rb2D.MoveRotation (135f);

		} else if (Input.GetKey (moveUp)) {
			rb2D.velocity = new Vector2 (0, speed);
			rb2D.MoveRotation (0f);

		} else if (Input.GetKey (moveDown)) {
			rb2D.velocity = new Vector2 (0, -speed);
			rb2D.MoveRotation (180f);

		} else if (Input.GetKey (moveLeft)) {
			rb2D.velocity = new Vector2 (-speed, 0);
			rb2D.MoveRotation (90f);

		} else if (Input.GetKey (moveRight)) {
			rb2D.velocity = new Vector2 (speed, 0);
			rb2D.MoveRotation (-90f);

		} else {
			rb2D.velocity = Vector2.zero;
		}
			
	}

	void fire(){
		bulletPos = Nose.transform.position;
		var bullet = (GameObject)Instantiate (PlayerBullet, bulletPos, Quaternion.identity);
		bullet.GetComponent<Rigidbody2D>().velocity = Nose.transform.up * bulletSpeed;
		Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
		//bullet.GetComponent<BulletScript>().velocityB = Nose.transform.up * bulletSpeed;
		Destroy (bullet, 2.0f);
	}
}