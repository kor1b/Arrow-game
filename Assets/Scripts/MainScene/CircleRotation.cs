using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRotation : MonoBehaviour {

	public float speed;

	void Update() {

		transform.Rotate (new Vector3 (0, 0, 90) * Time.deltaTime * -speed);

	}

	public void StartRotation (){

		GetComponent<CircleRotation>().enabled = true;

	}
}
