using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public SpawnLets spawnLets;
	public PlayerController playerController;
	public ScoreController scoreController;
	public BackgroundController backgroundController;

	public GameObject player;
	public GameObject explosion;
	public GameObject trail;
	public GameObject teachingText;//текст обучения

	[HideInInspector]
	public bool gameHasEnded = false;

	SpriteRenderer playerSprite;

	void Start(){
		backgroundController.ChangeBackground ();
		playerSprite = player.GetComponent<SpriteRenderer> ();
	}

	void Update(){
		if (Input.GetMouseButtonDown(0))//при тапе, уничтожается текст обучения
		Destroy (teachingText);
	}

	public void EndGame(){

		if (gameHasEnded == false) 
			gameHasEnded = true;

			playerController.enabled = false;
			spawnLets.StopSpawn();

		Destroy (teachingText);//уничтожение обучаещего текста

			/*PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + scoreController.coins);
			PlayerPrefs.SetInt ("Score", scoreController.score);
			PlayerPrefs.SetInt ("HighScoreHelper", scoreController.score);

			if (scoreController.score > PlayerPrefs.GetInt ("HighScore", 0)) {
				PlayerPrefs.SetInt ("HighScoreHelper", scoreController.score + 1);
				PlayerPrefs.SetInt ("HighScore", scoreController.score);
			}*/
			
		Destroy (trail);//уничтожаем след игрока
		playerSprite.color = Color.clear;//переводим игрока в режим невидимости
		Instantiate (explosion, player.transform.position, Quaternion.identity);//создаем взрыв
			Destroy (player, 2f);//уничтожаем игрока

	}
}
