using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectArrows : MonoBehaviour {

	public Sprite arrowSprite;

	public string nowArrow;

	public int price;

	public GameObject selectIcons;

	public Sprite clickImage;//проверить используется ли
	public Sprite startImage;//проверить используется ли
	public Sprite randomChooseImage;//проверить используется ли
	public Sprite unlockedArrowSprite;//спрайт разблокированного скина
	public Image selectSprite;//объект выделения
	public bool click;//отслеживание нажатие на скин

	public GameObject buyButton;
	public GameObject iconsArray;
	public GameObject whichArrow;
	public GameObject mainArrow, menuArrow;
	public GameObject shopPreviewArrow;
	public GameObject[] arrows;

	public float selectSpeed;//скорость, с которой перемещается объект выделения

	//перемещение объекта выделения через OnGUI
	void OnGUI(){

		if (click == true) {
			selectSprite.transform.position = Vector3.Lerp (selectSprite.transform.position, gameObject.transform.position, selectSpeed);
			iconsArray.GetComponent<IconsArray> ().InteractebleOff ();
		}

		if (Vector2.Distance (selectSprite.transform.position, gameObject.transform.position) < 1) {
			click = false;
			iconsArray.GetComponent<IconsArray> ().InteractebleOn ();
		}
	}

	void OnEnable(){
		click = false;
		iconsArray.GetComponent<IconsArray> ().InteractebleOn ();
	}

	void Start(){ 


		if (PlayerPrefs.GetString ("Arrow") != "Open")
			PlayerPrefs.SetString ("Arrow", "Open");
	}
		
	/*public void UnSelect(){

		GetComponent<Image> ().sprite = startImage;
	
	}*/

	void Update(){

		//if (click == false) {
		//	selectSprite.transform.position = startGO.transform.position;
		//}

		//перемещение объекта выделения через апдейт
		/*if (click == true) {

			selectSprite.transform.position = Vector3.Lerp (selectSprite.transform.position, gameObject.transform.position, Time.deltaTime * selectSpeed);
			iconsArray.GetComponent<IconsArray> ().InteractebleOff ();
		}

		if (Vector2.Distance (selectSprite.transform.position, gameObject.transform.position) < 2) {
			click = false;
			iconsArray.GetComponent<IconsArray> ().InteractebleOn ();
		}*/
	}

	public void OnMouseUpAsButton(){
		click = true;

		iconsArray.GetComponent<IconsArray> ().arrowName = gameObject.name;

		PlayerPrefs.SetInt ("Price", price);//для кнопки buy

		//selectIcons.GetComponent<IconsArray> ().DeleteColors();
		if (PlayerPrefs.GetString (gameObject.name) != "Close") {
			PlayerPrefs.SetString ("Now Arrow", gameObject.name);
			shopPreviewArrow.GetComponent<Image>().sprite = GetComponent<SelectArrows> ().arrowSprite;
		}
		//GetComponent<Image> ().sprite = clickImage;

		/*if (PlayerPrefs.GetString (gameObject.name) == "Open") {//buyButton;
			PlayerPrefs.SetString ("Now Arrow", gameObject.name);
			buyButton.SetActive (false);
		}
		else
			buyButton.SetActive (true);*/
	}
}
