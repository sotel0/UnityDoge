using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls2 : MonoBehaviour {

	public Camera camera;

	public float speed = 10f;
	public int health = 100;
	public GameObject PlayerBullet;
	public GameObject Nose;
	public float fireRate = 0.1f;
	public float nextFire = 0.0f;
	public float bulletSpeed = 12f;

	private Rigidbody2D rb2D;

	void Start(){
		rb2D = GetComponent<Rigidbody2D>();
	}
		
	void Update(){
		
		//fire the bullet, nextFire is for fireRate
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			fire ();
		}
	}

	void FixedUpdate () {

		//rotate player to look at mouse position

		//create a vector from mouse position to player
		Vector3 MouseVector =  camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;

		//get the angle that is the tan(y/x)
		float angle = Mathf.Rad2Deg * Mathf.Atan2(MouseVector.y, MouseVector.x);

		//get the quaternion needed for that angle rotation
		Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);

		//rotate the transform using Lerp
		transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * 300);
		//rotate another 90 to adjust
		transform.Rotate(0, 0, -90);

		//movement
		if (Input.GetButton ("Jump")) {
			//rb2D.AddForce (transform.up*speed);
			rb2D.velocity = transform.up * speed;
		} else {
			rb2D.velocity = Vector2.zero;
		}
	}


	void fire(){
		Vector2 bulletPos = Nose.transform.position;
		var bullet = (GameObject)Instantiate (PlayerBullet, bulletPos, Quaternion.identity);

		bullet.GetComponent<Rigidbody2D>().velocity = Nose.transform.up * bulletSpeed;

		Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());

		Destroy (bullet, 2.0f);
	}


}