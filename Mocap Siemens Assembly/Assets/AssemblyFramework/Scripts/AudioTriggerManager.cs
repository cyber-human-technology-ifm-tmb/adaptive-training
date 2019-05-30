using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTriggerManager : MonoBehaviour {

    public AudioSource audioSource;
    public AudioClip[] sounds;

    private int index;

    public bool play;

    public void PlayNext()
    {
        play = false;
        if (!audioSource.isPlaying)
        {
            if (index < sounds.Length - 1)
            {
                audioSource.clip = sounds[index];
                audioSource.Play();
                index++;
            }
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (play)
        {
            PlayNext();
        }
	}
}
