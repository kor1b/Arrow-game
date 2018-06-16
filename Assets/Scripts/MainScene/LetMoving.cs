using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetMoving : MonoBehaviour {

	//[HideInInspector]
	public float letSpeed;

	public float maxLetSpeed;//скорость при геймплее с удержанием
	public float minLetSpeed;
	public float fastMoveSpeed = 8f;//скорость при геймплее с тапом
	public float lerpSpeed = 2f;
	public bool tap;
	PlayerController playerController;
	SpawnLets spawnLets;
	GameController gameController;
	GameObject player;

	void OnEnable(){

		tap = false;

		player = GameObject.FindWithTag ("Player");
		GameObject spawner = GameObject.FindWithTag ("Spawner");
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");


		if (player != null)
			playerController = player.GetComponent<PlayerController> ();

		if (spawner != null)
			spawnLets = spawner.GetComponent<SpawnLets> ();

		if (gameControllerObject != null)
			gameController = gameControllerObject.GetComponent<GameController> ();
	}
		
	void Update () {
		
		//minLetSpeed = PlayerPrefs.GetFloat ("MinLetSpeed");
		//maxLetSpeed = PlayerPrefs.GetFloat ("MaxLetSpeed");

		//заменить maxLetSpeed на minLetSpeed + 2f

		//при проигрыше выставляет альфа-канал препятствий на 0
		if (gameController.gameHasEnded) {
			for (int i = 0; i < spawnLets.letsArr.Count; i++) {
				
				if (spawnLets.letsArr [i].GetComponent<SpriteRenderer> ())
					spawnLets.letsArr [i].GetComponent<SpriteRenderer> ().color = 
						Color.Lerp (spawnLets.letsArr [i].GetComponent<SpriteRenderer> ().color, Color.clear, Time.deltaTime * lerpSpeed);
				
				foreach (Transform child in transform) {

					if (child.GetComponent<SpriteRenderer> ()) {
						child.GetComponent<SpriteRenderer> ().color = 
						Color.Lerp (child.GetComponent<SpriteRenderer> ().color, Color.clear, Time.deltaTime * lerpSpeed);
					} 

				}
			}
		}

		transform.position = Vector2.MoveTowards (transform.position, new Vector2 (transform.position.x, -10), Time.deltaTime * letSpeed);

		if (transform.position.y == -10) {
			spawnLets.letsArr.Remove (gameObject);
			Destroy (gameObject);
		}

		//геймплей с удерживанием
		/*if (Input.GetMouseButton(0)) {
			
				playerController.speed = 0f;
				letSpeed = maxLetSpeed;
			}  
	*/
		//геймплей с тапом

		if (Input.GetMouseButtonDown (0) && gameController.gameHasEnded == false) {
				
				tap = true;
				playerController.speed = 0f;
				letSpeed = fastMoveSpeed;
		}

		//замедление после ускорения
		for (int i = 0; i < spawnLets.letsArr.Count; i++) {
			if (spawnLets.letsArr [0].transform.position.y > -3.25f && spawnLets.letsArr [0].transform.position.y < -2f
			   && spawnLets.letsArr [i].GetComponent<LetMoving> ().letSpeed > 2) {

				if (Vector2.Distance (player.transform.position, spawnLets.letsArr [0].transform.position) < 1f)  
					spawnLets.letsArr [i].GetComponent<LetMoving> ().letSpeed -= 0.3f;
				else
				spawnLets.letsArr [i].GetComponent<LetMoving> ().letSpeed -= 0.5f;
			}
		}
			
		if (gameController.gameHasEnded == false) {
			if (spawnLets.letsArr [0].transform.position.y < -3.5f) {

				for (int i = 0; i < spawnLets.letsArr.Count; i++) {
					spawnLets.letsArr [i].GetComponent<LetMoving> ().tap = false;
					playerController.speed = playerController.maxSpeed;
					 
					if (spawnLets.letsArr.Count > 1)
						spawnLets.letsArr.RemoveAt (0);
				}
			}
		}
			
			if (tap == false) {
			    letSpeed = minLetSpeed;
			}
		
		//PlayerPrefs.SetFloat ("MinLetSpeed", minLetSpeed + 0.001f);
		//PlayerPrefs.SetFloat ("MaxLetSpeed", maxLetSpeed + 0.001f);


	}
}

