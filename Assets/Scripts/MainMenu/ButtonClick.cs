using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonClick : EventTrigger{

	public void OnDown(){
		transform.localScale = new Vector2 (0.95f, 0.95f);
	}

	public void OnUp(){
		transform.localScale = new Vector2 (1, 1);
	}
}
