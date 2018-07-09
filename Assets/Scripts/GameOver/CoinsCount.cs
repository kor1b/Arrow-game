using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCount : MonoBehaviour {

	public ScoreController scoreController;
	public GameController gameController;

	public bool shop;

	int coins; 

	void Start () {

		if (!shop) {//проверка на то, в магазине ли мы

				if (scoreController.score <= 1000)
					coins = 0;

			if (1000 < scoreController.score && scoreController.score <= 3000)
					coins = Random.Range (0, 3);

				if (3000 < scoreController.score && scoreController.score <= 5000)
					coins = Random.Range (3, 5);

				if (scoreController.score > 5000)
					coins = Random.Range (5, 10);

				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + coins);
		}
				GetComponent<Text> ().text = PlayerPrefs.GetInt ("Coins").ToString ();//выводим кол-во монет

	}
}
