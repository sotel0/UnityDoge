using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flasher : MonoBehaviour {

	private Color pain;
	private Color normalColor;

	void Start(){
		//original color
		normalColor = gameObject.GetComponent<Renderer> ().material.color;

		//flashing color and reduce alpha
		pain = Color.red;
		pain.a -= .5f;
	}

	public void startFlash(){
		StartCoroutine (Flash());
	}

	public IEnumerator Flash() {

		//alternate between colors
		for (int i = 0; i < 2; i++){
			GetComponent<Renderer> ().material.color = pain;
			yield return new WaitForSeconds(.1f);
			GetComponent<Renderer> ().material.color = normalColor; 
			yield return new WaitForSeconds(.1f);
		}
	}
}
