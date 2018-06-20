using System.Collections;
using UnityEngine;

public class ShopBG : MonoBehaviour {

	public GameObject mainMenu;
	public GameObject mainScene;
	public GameObject gameOver;

	void OnEnable(){
		mainMenu.SetActive (false);
		gameOver.SetActive (false);
	}
		
}
