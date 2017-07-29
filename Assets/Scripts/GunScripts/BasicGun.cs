using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGun : Gun {

	public float fireRate = 0.2f;
	public float nextFire = 0.0f;
	public float bulletSpeed = 25f;
	// Use this for initialization

	public override void fire(){
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;

			//instantiate bullet
			Vector2 bulletPos = Nose.transform.position;
			var bullet = (GameObject)Instantiate (PlayerBullet, bulletPos, Quaternion.identity);

			//add velocity in the up direction
			bullet.GetComponent<Rigidbody2D>().velocity = Nose.transform.up * bulletSpeed;

			//ignore collision with player
			Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());

			//destroy bullet after 2 seconds
			Destroy (bullet, 2.0f);
		}

	}

	void Start () {
		
	}


	// Update is called once per frame
	void Update () {
		
	}
}
