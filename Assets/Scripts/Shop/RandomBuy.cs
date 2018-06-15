using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBuy : MonoBehaviour {

	public List<GameObject> closeArrows;//некупленные скины
	public GameObject[] allArrows;
	public Button back;
	public Image selectSprite;
	public Image previewArrowSprite;

	bool buttonPressed = false;
	public int removeNum;

	public int price;

	GameObject previousRandGO;
	GameObject randGO;

	Animator anim;

	void CheckMoney(){
		//если достаточно денег, то запускаем анимацию
		if (PlayerPrefs.GetInt ("Coins") >= price)
			anim.enabled = true;
		//если НЕ достаточно денег, то выключаем анимацию
		else
			anim.enabled = false;
	}

	void OnEnable(){
		anim = GetComponent<Animator> ();
		CheckMoney ();
	}

	void Start () {
		PlayerPrefs.SetInt ("Coins", 0);

		for (int i = 1; i < allArrows.Length; i++) {
			if (PlayerPrefs.GetString(allArrows [i].name) != "Open")
				closeArrows.Add (allArrows[i]);
		}
	}
		
	public void OnMouseUpAsButton(){

		if (PlayerPrefs.GetInt ("Coins") >= price) {
			anim.enabled = false;//выключение анимации 
			buttonPressed = true;
			StartCoroutine (TimeBtwRandom ());

			for (int k = 0; k < allArrows.Length; k++) {
				//allArrows [k].GetComponent<SelectArrows> ().UnSelect ();
				allArrows [k].GetComponent<Button> ().interactable = false;
			}
			gameObject.GetComponent<Button> ().interactable = false;
			back.GetComponent<Button> ().interactable = false;

			PlayerPrefs.SetInt ("BuyArrowCount", 1);
			removeNum = Random.Range (0, closeArrows.Count);
			PlayerPrefs.SetString (closeArrows [removeNum].name, "Open");
			Debug.Log (closeArrows [removeNum].name);

			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - price);
		} 
	}

	IEnumerator TimeBtwRandom(){
		
			if (buttonPressed) { 
				if (closeArrows.Count > 1) {
					//Анимация выбора случайного скина
					randGO = closeArrows [Random.Range (0, closeArrows.Count)];
					for (int i = 0; i < 20; i++) {

					//цикл, чтобы повторно не выбирался скин
						previousRandGO = randGO;
						while (randGO == previousRandGO) {
							randGO = closeArrows [Random.Range (0, closeArrows.Count)];
						}

					selectSprite.transform.position = randGO.transform.transform.position;
						//randGO.GetComponent<Image> ().sprite = randGO.GetComponent<SelectArrows> ().randomChooseImage;

						yield return new WaitForSeconds (0.2f);//время между выбором следующего скина

						/*for (int k = 0; k < closeArrows.Count; k++) {
							closeArrows [k].GetComponent<SelectArrows> ().UnSelect ();
						}*/
					}
				} //else if (closeArrows.Count == 1)
					//closeArrows [0].GetComponent<Image> ().sprite = closeArrows [0].GetComponent<SelectArrows> ().startImage;

			selectSprite.transform.position = closeArrows [removeNum].transform.position;

				//Мигание окончательно выбранного скина
				for (int j = 0; j < 3; j++) {
					//closeArrows [removeNum].GetComponent<Image> ().sprite = closeArrows [removeNum].GetComponent<SelectArrows> ().randomChooseImage;
				selectSprite.GetComponent<RectTransform>().localScale = Vector2.Lerp (new Vector2 (0.8f, 0.8f), Vector2.zero, 5f);	
				yield return new WaitForSeconds (0.1f);//время между морганием
					//closeArrows [removeNum].GetComponent<Image> ().sprite = closeArrows [removeNum].GetComponent<SelectArrows> ().startImage;
				selectSprite.GetComponent<RectTransform>().localScale = Vector2.Lerp (Vector2.zero, new Vector2 (0.8f, 0.8f), 5f);	
				yield return new WaitForSeconds (0.1f);//время между морганием
				}

				//closeArrows [removeNum].GetComponent<Image> ().sprite = closeArrows [removeNum].GetComponent<SelectArrows> ().clickImage;

				PlayerPrefs.SetString ("Now Arrow", closeArrows[removeNum].name);

			    previewArrowSprite.GetComponent<Image> ().sprite = closeArrows [removeNum].GetComponent<SelectArrows> ().arrowSprite;
			    closeArrows [removeNum].GetComponent<Image> ().sprite = closeArrows [removeNum].GetComponent<SelectArrows> ().unlockedArrowSprite;

				closeArrows.Remove (closeArrows[removeNum]);
				buttonPressed = false;

				for (int k = 0; k < allArrows.Length; k++) {
					allArrows [k].GetComponent<Button> ().interactable = true;
				}
				gameObject.GetComponent<Button> ().interactable = true;
				back.GetComponent<Button> ().interactable = true;

			if (closeArrows.Count < 1)//если не осталось скинов, то кнопка рандома пропадает
				Destroy (gameObject);
			}

		CheckMoney ();

		}
	
	}

