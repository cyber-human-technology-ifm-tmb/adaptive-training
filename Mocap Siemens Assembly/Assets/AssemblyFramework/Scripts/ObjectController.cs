using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour {

    public string ConnectionID;

    public bool IdLocked = false;
    public List<string> AcceptedIDs;
    public bool needsActivator;

    private string originalID;

    public string neededID;

	// Use this for initialization
	void Start () {

        originalID = ConnectionID;

	}
	
	// Update is called once per frame
	void Update () {
	
	
	}

    public bool Activate(string ID)
    {
        print("trying to activate");

        if (!needsActivator)
        {
            print("activationFaliled");
            return false;
        } else if ((IdLocked && AcceptedIDs.Contains(ID)) ||  (!IdLocked))
        {
            print("Activation successful");
            ConnectionID = neededID;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DeActivate()
    {
        ConnectionID = originalID;
    }

    public void Connect()
        // Used for when the gameobject is connected to a part
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        ActivatorController ac = other.gameObject.GetComponent<ActivatorController>();

        if (ac != null)
        {
            Activate(ac.ActivationID);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ActivatorController ac = other.gameObject.GetComponent<ActivatorController>();

        if (ac != null)
        {
            if (AcceptedIDs.Contains(ac.ActivationID))
            {
                DeActivate();
            }
        }
    }
}
