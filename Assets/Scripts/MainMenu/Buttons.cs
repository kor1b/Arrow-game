using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

	public GameObject shopBG;
	public GameObject mainMenu;
	public GameObject mainScene;
	public GameObject settings;
	public GameObject gameOver;

	public GameController gameController;
	public IconsArray iconsArray;

	public ScreenFader screenFader;

	public bool reloadPressed;

	GameObject arrow;

	void Awake(){
		arrow = GameObject.Find ("Arrow");
		if (arrow == null)
			return;

	}
		
	public void OnMouseUpAsButton(){

		switch (gameObject.name) {

		case "PlayGame":
			StartCoroutine (Play ());
			break;

		case "Shop":
			shopBG.SetActive (true);
			break;

		case "GameOverShop":
			shopBG.SetActive (true);
			PlayerPrefs.SetString ("FromGameOver", "True");

			break;

		case "Back":
			shopBG.SetActive (false);
			settings.SetActive (false);
			if (PlayerPrefs.GetString ("FromGameOver") == "True") {
				gameOver.SetActive (true);

			} else
				mainMenu.SetActive (true);
			
			PlayerPrefs.SetString ("FromGameOver", "False");

			iconsArray.selectSprite.transform.position = iconsArray.previewArrowSprite.transform.position;
			//при выходе из магазина спрайт выбора остается на последнем выбранном и купленном скине
			/*for (int j = 0; j < iconsArray.arrowsIcons.Length; j++) {
				iconsArray.arrowsIcons[j].GetComponent<SelectArrows> ().click = false;
				if (PlayerPrefs.GetString ("Now Arrow") == iconsArray.arrowsIcons [j].name) {
					iconsArray.selectSprite.transform.position = iconsArray.arrowsIcons [j].transform.position;
				}
			}*/
			break;

		case "Reload":
			reloadPressed = true;
			screenFader.fadeState = ScreenFader.FadeState.In;
			PlayerPrefs.SetString ("ReloadKey", "Reload");
			SceneManager.LoadScene ("Main");
			break;

		case "Home":
			PlayerPrefs.SetString ("ReloadKey", "Zero");
			gameOver.SetActive (false);
			mainScene.SetActive (false);
			mainMenu.SetActive (true);
			break;

		case "Settings":
			settings.SetActive (true);
			mainMenu.SetActive (false);
			break;
		}
	}

	IEnumerator Play(){

		arrow.GetComponent<Animator> ().enabled = true;

		//screenFader.fadeState = ScreenFader.FadeState.In;
		yield return new WaitForSeconds (1f);
		PlayerPrefs.SetString ("ReloadKey", "Reload");
		//mainMenu.SetActive (false);  включение игры через отключение панелей, необходимо разобраться с анимацией полета иконки стрелки после 
		//mainScene.SetActive (true);  нажатия клавиши play
		//arrow.GetComponent<Animator> ().enabled = false;
		SceneManager.LoadScene ("Main");

	}
}
