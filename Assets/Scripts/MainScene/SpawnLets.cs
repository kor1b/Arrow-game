using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLets : MonoBehaviour {

	public GameObject[] lets;
	public float[] spawnTime;
	public List<GameObject> letsArr;
    GameObject let;
	GameObject newRandlet;


	void Start () {
		
		newRandlet = lets [Random.Range (0, lets.Length)];

		InvokeRepeating ("Spawn", 2f, spawnTime [Random.Range (0, spawnTime.Length)]);//при изменении времени старта спавна - Healt()
	}

	void Spawn () {

		GameObject hazard = Instantiate (newRandlet, newRandlet.transform.position, newRandlet.transform.rotation) as GameObject;
		letsArr.Add (hazard);

			let = newRandlet;

			while (newRandlet == let)
				newRandlet = lets [Random.Range (0, lets.Length)];

	}

	public void StopSpawn(){
		CancelInvoke ();

	}
}
