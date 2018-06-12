using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconsArray : MonoBehaviour {

	public Button[] arrowsIcons;
	public string arrowName;
	public GameObject buyButton;
	public Image selectSprite;//объект выделения
	public Image previewArrowSprite;//спрайт показа скина 

	void OnEnable(){

		//PlayerPrefs.SetInt ("HighScore", 0);//обнуление highscore

		/*PlayerPrefs.SetString (arrowsIcons[0].name, "Open");
			PlayerPrefs.SetString ("Arrow (1)", "Close");
			PlayerPrefs.SetString ("Arrow (2)", "Close");
		PlayerPrefs.SetString (arrowsIcons[3].name, "Close");
			PlayerPrefs.SetString ("Arrow (4)", "Close");
			PlayerPrefs.SetString ("Arrow (5)", "Close");
			PlayerPrefs.SetString ("Arrow (6)", "Close");
			PlayerPrefs.SetString ("Arrow (7)", "Close");
			PlayerPrefs.SetString ("Arrow (8)", "Close");

		PlayerPrefs.SetInt ("Coins", 10000);
		PlayerPrefs.SetInt ("BuyArrowCount", 0);
        PlayerPrefs.SetString ("Now Arrow", "Arrow"); //нужно зайти в магазин, чтобы поменялась стрелка в главном меню
*/

		//buyButton.SetActive (false);

		//при клике по некупленному скину и выходе из магазина + повторном входе в него выбирается последний выбранный купленный скин
		/*for (int j = 0; j < arrowsIcons.Length; j++) {
			//arrowsIcons[j].GetComponent<Image>().sprite = arrowsIcons[j].GetComponent<SelectArrows>().startImage;
			if (PlayerPrefs.GetString ("Now Arrow") == arrowsIcons [j].name)
				//arrowsIcons [j].GetComponent<Image> ().sprite =  arrowsIcons[j].GetComponent<SelectArrows>().clickImage;
				selectSprite.transform.position = arrowsIcons[j].transform.position;

			}*/
		
		//если не куплено ни одного скина
		/*for (int k = 1; k < arrowsIcons.Length; k++) {
			
			if (PlayerPrefs.GetInt ("BuyArrowCount") != 1) {
				selectSprite.transform.position = arrowsIcons [0].transform.position;
				//arrowsIcons [k].GetComponent<Image> ().sprite = arrowsIcons [k].GetComponent<SelectArrows> ().startImage;
				//arrowsIcons [0].GetComponent<Image> ().sprite = arrowsIcons [0].GetComponent<SelectArrows> ().clickImage;
			}

	}*/

		for (int k = 1; k < arrowsIcons.Length; k++) {
			if (PlayerPrefs.GetString (arrowsIcons [k].name) == "Open")
				arrowsIcons [k].GetComponent<Image> ().sprite = arrowsIcons [k].GetComponent<SelectArrows> ().unlockedArrowSprite;
		} 
	}

	/*public void DeleteColors () {

		for (int i = 0; i < arrowsIcons.Length; i++) {

			arrowsIcons[i].GetComponent<SelectArrows>().UnSelect();
		
		}
	}*/

	public void InteractebleOn(){
		for (int i = 0; i < arrowsIcons.Length; i++) {
			arrowsIcons [i].GetComponent<Button> ().interactable = true;
		}
	}


	public void InteractebleOff(){
		for (int i = 0; i < arrowsIcons.Length; i++) {
			arrowsIcons [i].GetComponent<Button> ().interactable = false;
		}
	}
}
