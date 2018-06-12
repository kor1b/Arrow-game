using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	public Text scoreText;
	public GameController gameController;
	public int score;
	public int coins;

	void Update () {

		if (gameController.gameHasEnded == false)
		score++;
		scoreText.text = score.ToString ();

		if (gameController.gameHasEnded == false) {
		
			if (score <= 1000)
				coins = 0;

			if (1000 < score && score <= 3000)
				coins = Random.Range (0, 3);

			if (3000 < score && score <= 5000)
				coins = Random.Range (3, 5);

			if (score > 5000)
				coins = Random.Range (5, 10);
	}
	}
}
