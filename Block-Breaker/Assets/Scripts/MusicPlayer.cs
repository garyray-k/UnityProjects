﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    
    static MusicPlayer instance = null;

	void Awake()
	{
        //Debug.Log("Music player Awake " + GetInstanceID());
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

	}

}
