using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public static int numOfBlocks = 0;
    public Sprite[] hitSprite;
    public AudioClip crack;
    public GameObject smoke;

    int timesHit;
    LevelManager levelManager;
    Camera cam;

	// Use this for initialization
	void Start () {
        timesHit = 0;
        levelManager = FindObjectOfType<LevelManager>();
        cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject[] getBlockCount;
        getBlockCount = GameObject.FindGameObjectsWithTag("Breakable");
        numOfBlocks = getBlockCount.Length;
	}

    void OnCollisionExit2D(Collision2D collision)
    {
        bool isBreakable = (this.tag == "Breakable");
        if (isBreakable) {
            HandleHits();
        }
        Debug.Log("There are " + numOfBlocks + " blocks left.");
    }

    void HandleHits () {
        print("Brick hit!");
        timesHit++;
        int maxhits = 0;
        maxhits = hitSprite.Length + 1;
        if (timesHit >= maxhits)
        {
            AudioSource.PlayClipAtPoint(crack, this.cam.transform.position, 0.8f);
            SmokePuff();
            Destroy(gameObject);
            levelManager.BrickDestroyed();
        }
        else
        {
            LoadSprites();
        }
    }

    void SmokePuff () {
        var localSmoke = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
        ParticleSystem.MainModule main = localSmoke.GetComponent<ParticleSystem>().main;
        main.startColor = GetComponent<SpriteRenderer>().color;
    }
    

    void LoadSprites () {
        int spriteIndex = timesHit - 1;
        if (hitSprite[spriteIndex] != null) {
            this.GetComponent<SpriteRenderer>().sprite = hitSprite[spriteIndex];    
        } else {
            Debug.LogError("No Sprite for block.");
        }
    }

	void SimulateWin () {
        levelManager.LoadNextLevel();
    }
}
