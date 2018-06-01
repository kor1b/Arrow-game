using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ArrowSprite : MonoBehaviour {

	public GameObject[] arrows;

		void OnEnable () {
		for (int i = 0; i < arrows.Length; i++) {
		
			if (PlayerPrefs.GetString ("Now Arrow") == arrows [i].name) {
				GetComponent<Image> ().sprite = arrows [i].GetComponent<SelectArrows> ().arrowSprite;
				PlayerController.arrowSprite = arrows [i].GetComponent<SelectArrows> ().arrowSprite;

			}
		}
	}

}
