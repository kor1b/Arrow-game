using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour {

	public void Reset(){

		PlayerPrefs.DeleteKey ("Score");
		PlayerPrefs.DeleteKey ("HighScore");

	}
}
