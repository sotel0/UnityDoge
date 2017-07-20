using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerS : MonoBehaviour {

	public Text gameOverText;
	public Text restartText;
	private int score;

	public GameObject player;
	private PlayerControls2 pc2;
	private bool restart;


	void Start () { 
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		pc2 = player.GetComponent<PlayerControls2>();
	}
	

	void Update () {
		
		if (pc2.health == 0) {
			GameOver ();
		}
			

		if (restart) {
			if(Input.GetKeyDown(KeyCode.R)){
				int scene = SceneManager.GetActiveScene ().buildIndex;
				SceneManager.LoadScene( scene, LoadSceneMode.Single);
			}

		}

	}

	IEnumerator SpawnWaves(){

		while (true) {
			
		}

	}

	public void GameOver(){
		gameOverText.text = "Game Over";
		restartText.text = "Press 'R' to Restart";
		restart = true;

	}
}
