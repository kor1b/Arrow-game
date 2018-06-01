using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsPlus : MonoBehaviour {

	public ScoreController scoreController;

	void Start(){

		PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + scoreController.coins);
	}
}
