using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {
	public static int BreakableBricksCounter = 0;
	private int HitCounter;
	private LevelManager LevelManager;
	public Sprite[] hitSprites;
	public AudioClip crackSound;
	public GameObject SmokeEffect;

	void Start () {
		if (gameObject.tag == "Breakable") {
			BreakableBricksCounter++;
		}
		HitCounter = 0;
		LevelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnCollisionEnter2D(Collision2D ball){
		AudioSource.PlayClipAtPoint (crackSound, transform.position);
		if (gameObject.tag == "Breakable") {
			BlockDestroy ();
		}
	}

	void Win(){
		LevelManager.LoadNextLevel ();
	}

	void LoadSprite(){
		int spriteIndex = HitCounter - 1;
//		if (hitSprites[spriteIndex]){
//			
//		}
		gameObject.GetComponent<SpriteRenderer>().sprite = hitSprites [spriteIndex];
	}

	void BlockDestroy(){
		HitCounter++;
		int MaxHits = hitSprites.Length + 1;

		if (HitCounter == MaxHits){
			LoadSmoke ();
			BreakableBricksCounter--;
			Destroy (gameObject);
			LevelManager.WinLevel ();
		} 
		else {
			LoadSprite ();
		}
	}

	void LoadSmoke(){
		GameObject SmokePuff = Instantiate (SmokeEffect, transform.position, Quaternion.identity);
		SmokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer> ().color;
	}
}
