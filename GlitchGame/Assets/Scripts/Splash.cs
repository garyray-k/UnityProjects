using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Splash : MonoBehaviour {
    
    public float splashScreenDelay = 3;
    public Image blackImage;

	// Use this for initialization
	void Start () {
        StartCoroutine(LoadLevelAfterDelay());
        LevelManager.LoadNextLevel();
	}
 
    IEnumerator LoadLevelAfterDelay(){
        for (float i = 0; i <= 1; i += Time.deltaTime / splashScreenDelay) {
            blackImage.color = new Color(0, 0, 0, i);

        }

    }
}
