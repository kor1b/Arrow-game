using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour {

	public GameController gameController;
	public Buttons buttons;

	Animator anim;

	public GameObject score;

	bool animShowed;//показывалась ли уже анимация появления gameover

	void Start(){
		animShowed = false;
		PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + score.GetComponent<ScoreController>().coins);
	}

	void OnEnable () {
		anim = GetComponent<Animator> ();
	}
		
	void Update () {
		if (gameController.gameHasEnded) {
			if (animShowed == false) {//появление gameover
				//Destroy(score, 1);
				anim.SetTrigger ("GameOver");
				animShowed = true;
			}

			PlayerPrefs.SetString ("ReloadKey", "Zero");
			if (buttons.reloadPressed == true)
				PlayerPrefs.SetString ("ReloadKey", "Reload");
		}
	}
}
