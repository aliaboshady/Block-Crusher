using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {
	void OnTriggerEnter2D(/*Collider2D ball*/){
		Application.LoadLevel ("Lose Screen");
		Brick.BreakableBricksCounter = 0;
	}
}
