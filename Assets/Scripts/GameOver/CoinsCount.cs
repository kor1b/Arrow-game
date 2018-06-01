using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsCount : MonoBehaviour {

	void Update () {

		GetComponent<Text> ().text = PlayerPrefs.GetInt ("Coins").ToString ();

	}
}
