using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	[HideInInspector]
	public Rigidbody2D rb;

	public float speed;
	public float maxSpeed;
	public float speedStartPosition;

	public Vector2 leftMaxPos;
	public Vector2 rightMaxPos;
	public float minDistance = 0.1f;
	public bool enterTheGate;
	bool direction = true;

	//public int score;
	//public Text scoreText;

	public static Sprite arrowSprite;
	public Sprite standartSprite;

	public GameController gameController;

	void Start () {

		//score = 0;
		enterTheGate = false;

		rb = GetComponent<Rigidbody2D> ();

		GetComponent<SpriteRenderer> ().sprite = arrowSprite;

		if (PlayerPrefs.GetInt ("BuyArrowCount") != 1)
			GetComponent<SpriteRenderer> ().sprite = standartSprite;

	}
		
	void FixedUpdate () {

		PlayerPrefs.SetString ("ReloadKey", "Zero");

		if (rb.position.y != -2.5f) 
			rb.position = Vector2.MoveTowards (transform.position, new Vector2 (0, -2.5f), Time.deltaTime * speedStartPosition);
		
		else {

		if (direction){
			rb.position = Vector2.MoveTowards (rb.position, rightMaxPos, Time.deltaTime * speed);
			if (Vector2.Distance (rb.position, rightMaxPos) < minDistance)
			direction =! direction;
	}

		if (!direction) {
			rb.position = Vector2.MoveTowards (rb.position, leftMaxPos, Time.deltaTime * speed);
			if (Vector2.Distance (rb.position, leftMaxPos) < minDistance)
				direction =! direction;
		}
	}
	}

	void OnTriggerExit2D (Collider2D gate){
		if (gate.gameObject.CompareTag ("Gate")) {
			enterTheGate = true;
			//score++;
			//if (gameController.gameHasEnded == true)
				//score--;
			//scoreText.text = "" + score.ToString ();
		}
	}
}
