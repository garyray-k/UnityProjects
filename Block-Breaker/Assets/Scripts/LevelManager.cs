using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
	private void Start()
	{
        if (SceneManager.GetActiveScene().name != "Start") {
            if (SceneManager.GetActiveScene().name != "Lose")
            {
                if (SceneManager.GetActiveScene().name != "Win")
                {
                    Cursor.visible = false;
                }
                else
                {
                    Cursor.visible = true;
                }
            } else {
                Cursor.visible = true;
            }
        } else {
            Cursor.visible = true;
        }
	}

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

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BrickDestroyed()
    {
        if (Brick.numOfBlocks <= 1)
        {
            LoadNextLevel();
        }
    }
}
