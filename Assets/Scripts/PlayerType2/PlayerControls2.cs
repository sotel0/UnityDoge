using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls2 : MonoBehaviour {

	private Camera camera1;

	public float speed = 10f;
	public int health = 100;
	public Slider healthSlider;

	private Gun gunType;



	private Rigidbody2D rb2D;

	void Start(){
		gunType =  GameObject.Find ("BasicGun").GetComponent<BasicGun>();
		camera1 = Camera.main;
		rb2D = GetComponent<Rigidbody2D>();


	}
		
	void Update(){

		//fire the bullet, nextFire is for fireRate
		if (Input.GetButton ("Fire1")) {
			gunType.fire ();
		}
	}

	void FixedUpdate () {

		//rotate player to look at mouse position

		//create a vector from mouse position to player
		Vector3 MouseVector =  camera1.ScreenToWorldPoint(Input.mousePosition) - transform.position;

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
		
//
//	void fire(){
//		//instantiate bullet
//		Vector2 bulletPos = Nose.transform.position;
//		var bullet = (GameObject)Instantiate (PlayerBullet, bulletPos, Quaternion.identity);
//
//		//add velocity in the up direction
//		bullet.GetComponent<Rigidbody2D>().velocity = Nose.transform.up * bulletSpeed;
//
//		//ignore collision with player
//		Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
//
//		//destroy bullet after 2 seconds
//		Destroy (bullet, 2.0f);
//	}
//
	//remove health and update slider
	public void takeDamage(int damage){
		health -= damage;
		healthSlider.value = health;
	}


}