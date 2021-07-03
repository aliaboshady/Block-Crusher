using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusic : MonoBehaviour {
	static BackGroundMusic instance = null;

	void Start () {
		if (instance != null) {
			Destroy (gameObject);
		} 
		else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
}
