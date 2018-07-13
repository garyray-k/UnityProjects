using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    
    static MusicPlayer instance = null;

    public AudioClip[] levelAudioClipIndex;

    AudioSource music;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        music = GetComponent<AudioSource>();
        music.clip = levelAudioClipIndex[0];
        music.Play();
    }

    void OnLevelWasLoaded(int level) {
        AudioClip levelAudioClip = levelAudioClipIndex[level];
        if (levelAudioClip && (music.clip != levelAudioClip)) {
            music.Stop();
            music.clip = levelAudioClip;
            music.loop = true;
            music.Play();
        }
    }

}
