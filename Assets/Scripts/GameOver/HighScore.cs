using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {


	void Start(){

		if (PlayerPrefs.GetInt ("HighScoreHelper") - PlayerPrefs.GetInt ("HighScore") == 1) {
			GetComponent<Text> ().text = "NEW HIGH SCORE";
			GetComponent<Animator> ().enabled = true;
		}
		else 
			GetComponent<Text> ().text = "HIGH SCORE: " + PlayerPrefs.GetInt ("HighScore").ToString ();

	}
}
