using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadKey : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject mainScene;
	public GameObject shopBG;
	public ScreenFader screenFader;

	/*void Start(){ ///!!!!!!!!!!!!!! Одноразово включить перед запуском игры

		PlayerPrefs.SetString ("ReloadKey", "Zero");

	}*/


	void Start () {
		if (PlayerPrefs.GetString ("ReloadKey") == "Reload" && shopBG.activeSelf == false) {
			//screenFader.fadeState = ScreenFader.FadeState.In;
			mainMenu.SetActive (false);
			mainScene.SetActive (true);
			screenFader.fadeState = ScreenFader.FadeState.Out;
		}
	}
}
