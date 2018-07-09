using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

	public GameObject gameOver;
	public GameObject[] gradients;
	public BackgroundController backgroundController;

	void Start(){

		backgroundController.ChangeBackground ();
		/*for (int i = 0; i < gradients.Length; i++) {
			gradients [i].SetActive (false);
		}
		gradients [Random.Range (0, gradients.Length)].SetActive (true);*/
	}

	void OnEnabled () {

		gameOver.SetActive (false);
	}
	}

