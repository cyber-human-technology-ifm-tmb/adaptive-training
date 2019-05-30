using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationController : MonoBehaviour {

    [HideInInspector]
	public string ActivationId;

	public AudioClip clip;
    private AudioSource source;

	// Use this for initialization
	// void Start () {
	// 	// AudioSource source = GetComponent<AudioSource>();
	// 	source.Play();
	// }
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Activate () {
		//source.clip = clip;
		//source.Play();
	}
}
