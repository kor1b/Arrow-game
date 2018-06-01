using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	void Start () {

		GetComponent<Text> ().text = PlayerPrefs.GetInt ("Score").ToString ();

	}
}
