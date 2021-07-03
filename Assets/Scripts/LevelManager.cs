using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public void LevelsLoader(string levelName){
		Application.LoadLevel (levelName);
		Brick.BreakableBricksCounter = 0;
	}

	public void Quit(){
		Application.Quit();
	}

	public void LoadNextLevel(){
		Application.LoadLevel (Application.loadedLevel + 1);
		Brick.BreakableBricksCounter = 0;
	}

	public void WinLevel(){
		if (Brick.BreakableBricksCounter<=0){
			LoadNextLevel();
		}
	}
}
