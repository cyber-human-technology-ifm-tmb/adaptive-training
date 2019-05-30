using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsActiveConsolidator : MonoBehaviour {

    public GameObject[] objects;

    public GameObject consolidationObject;

    private int i;
    private bool ok;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        ok = true;
		for (i = 0; i < objects.Length; i++)
        {
            if (!objects[i].activeSelf)
            {
                ok = false;
            }
        }
        consolidationObject.SetActive(ok);
	}
}
