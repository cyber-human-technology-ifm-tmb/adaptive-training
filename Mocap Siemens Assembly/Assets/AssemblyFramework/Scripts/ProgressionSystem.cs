using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class ProgressionSystem : MonoBehaviour {

    public GameObject[] gameObjects;
    public UnityEvent[] OnProgress;

    private int currentObjectIndex;

	// Use this for initialization
	void Start () {
        currentObjectIndex = 0;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (gameObjects[currentObjectIndex].activeSelf)
        {
            OnProgress[currentObjectIndex].Invoke();
            if (currentObjectIndex < gameObjects.Length - 1)
            {
                currentObjectIndex++;
            }
        }
	}
}
