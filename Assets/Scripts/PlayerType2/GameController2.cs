using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController2 : MonoBehaviour {

	public Text gameOverText;
	public Text restartText;
	private int score;

	public float spawnRate = 3f;
	public float spawnTime = 3f;
	public GameObject spawnBorder;
	public GameObject enemy1;

	public GameObject PlayerBullet;
	public GameObject player;
	private PlayerControls2 pc2;
	private bool restart;

	void Start () { 
		pc2 = player.GetComponent<PlayerControls2>();
		restart = false;

		//Game text does not appear yet
		restartText.text = "";
		gameOverText.text = "";
	
		//start waves
		SpawnWaves ();
	
	}
	

	void Update () {

		//check to restart
		if (restart) {
			if(Input.GetKeyDown(KeyCode.R)){
				int scene = SceneManager.GetActiveScene ().buildIndex;
				SceneManager.LoadScene( scene, LoadSceneMode.Single);
			}

		}

		//check if game is over
		if (!restart && pc2.health <= 0) {
			GameOver ();
		}
			

	}

	//coroutine to spawn enemies
	void SpawnWaves(){
		StartCoroutine (Wave1 ());
	}

	 IEnumerator Wave1() {
		//spawn area
		Bounds b = spawnBorder.GetComponent<MeshRenderer> ().bounds;
		bool spawned;

		//spawn 5 enemies
		for (int i = 0; i < 4; i++){
			spawned = false;

			//while loop to try till enemy spawns away from player
			while (!spawned && !restart) {

				//if there is no player stop
				if (GameObject.FindGameObjectWithTag ("Player") == null) {
					break;
				}

				//random position
				Vector2 pos = new Vector2 (Random.Range (b.min.x, b.max.x), Random.Range (b.min.y, b.max.y));
				var enemy = (GameObject)Instantiate (enemy1, pos, Quaternion.identity);

				//check if near player
				if (Vector3.Distance (enemy.transform.position, player.transform.position) < 15) {
					Destroy (enemy);
				} else {
					
					//spawned and wait
					spawned = true;
					yield return new WaitForSeconds(5f);
				}
					
			}
		}
	}
	public void Explode(){ //make bullets fly in random directions and death


		Vector2 bulletPos = player.transform.position;
		float angle = 0f;

		//repeat for 33 bullets
		for (int i = 0; i < 32; i++){ 

		//create bullet
		var bullet = (GameObject)Instantiate (PlayerBullet, bulletPos, Quaternion.identity);
		Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
		
		//get vector at different angle
		Vector2 v = Quaternion.AngleAxis (angle, Vector3.forward)*Vector2.one;
		bullet.GetComponent<Rigidbody2D>().velocity = v * 25f;

		Destroy (bullet, 2.0f);
		angle += 45f;
		}

		//remove camera, and destroy player
		GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow2>().enabled = false;
		Destroy (player);
	}

	public void GameOver(){
		restart = true;
		Explode ();
		gameOverText.text = "Game Over";
		restartText.text = "Press 'R' to Restart";


	}
}
