using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

	void OnCollisionEnter2D (Collision2D coll){

		if (coll.collider.tag == "Hazard" || coll.collider.tag == "CircleHazard") {
	
			FindObjectOfType<GameController> ().EndGame();

			//rb.AddForce (transform.position, ForceMode2D.Impulse);
			//rb.AddTorque (0.1f, ForceMode2D.Impulse);
		}
	}
}
