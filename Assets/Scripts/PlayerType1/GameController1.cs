using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController1 : MonoBehaviour {

	public Text gameOverText;
	public Text restartText;
	private int score;

	public float spawnRate = 3f;
	public float spawnTime = 3f;
	public GameObject spawnBorder;
	public GameObject enemy1;

	public GameObject player;
	private PlayerControls1 pc1;
	private bool restart;
	private float nextSpawn;


	void Start () { 
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		pc1 = player.GetComponent<PlayerControls1>();

		SpawnWaves ();
		//check not to spawn at same spot as player
		//spawn multiple times
	}


	void Update () {

		if (pc1.health == 0) {
			GameOver ();
		}


		if (restart) {
			if(Input.GetKeyDown(KeyCode.R)){
				int scene = SceneManager.GetActiveScene ().buildIndex;
				SceneManager.LoadScene( scene, LoadSceneMode.Single);
			}

		}

	}

	void SpawnWaves(){
		StartCoroutine (Wave1 ());
	}

	IEnumerator Wave1() {
		Bounds b = spawnBorder.GetComponent<MeshRenderer> ().bounds;
		bool spawned;
		//nextSpawn = Time.time + spawnRate;

		for (int i = 0; i < 4; i++){
			spawned = false;

			while (!spawned) {
				Vector2 pos = new Vector2 (Random.Range (b.min.x, b.max.x), Random.Range (b.min.y, b.max.y));
				var enemy = (GameObject)Instantiate (enemy1, pos, Quaternion.identity);
				yield return new WaitForSeconds(5f);
				spawned = true;
			}
		}
	}

	public void GameOver(){
		gameOverText.text = "Game Over";
		restartText.text = "Press 'R' to Restart";
		restart = true;

	}
}
