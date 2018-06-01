using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailController : MonoBehaviour {

	public GameObject arrow;
	ParticleSystem ps;

	void Start(){
		ps = GetComponent<ParticleSystem> (); 
	}

	void Update () {
		var emission = ps.emission;
		var main = ps.main;
		if (arrow.GetComponent<PlayerController> ().speed == 0) {
			main.simulationSpeed = 3.5f;
			main.startSpeed = 3;
			emission.rateOverTime = 4;
		} else {
			main.startSpeed = 1;
			emission.rateOverTime = 2;
		}
	}
}
