﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        Debug.Log("Loading level: " + levelName);
        SceneManager.LoadScene(levelName);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested.");
        Application.Quit();
    }

    static public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
