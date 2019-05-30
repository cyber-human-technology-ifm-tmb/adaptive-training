using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatorController : MonoBehaviour {

    public string ActivationID;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        print("Activator Collision");
        ObjectController objectController = collision.gameObject.GetComponent<ObjectController>();
        if (objectController != null)
        {
            objectController.Activate(ActivationID);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        ObjectController objectController = collision.gameObject.GetComponent<ObjectController>();
        if (objectController != null)
        {
            objectController.DeActivate();
        }
    }

}
