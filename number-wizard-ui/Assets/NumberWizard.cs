using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {
    int max;
    int min;
    int guess;
    public int maxGuessAllowed = 5;

    public Text text;

	// Use this for initialization
	void Start () {
        StartGame();	
	}
	
    void StartGame () {
        max = 1000;
        min = 1;
        guess = Random.Range(1, 1001);

        text.text = guess.ToString();
    }

    public void GuessHigher () {
        min = guess;
        NextGuess();
    }

    public void GuessLower () {
        max = guess;
        NextGuess();
    }

    void NextGuess () {
        guess = Random.Range(min, max + 1);
        maxGuessAllowed -= 1;
        text.text = guess.ToString();
        if (maxGuessAllowed <= 0) {
            SceneManager.LoadScene("Win");
        }
    }
}
