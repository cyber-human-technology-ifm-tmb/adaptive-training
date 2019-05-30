using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceControllerStar : MonoBehaviour {
    public string PlaceID;
    public GameObject replacementObject;
    public ActivationController activator;
    public float offset;
    public GameObject[] WaitForActivation;

    [HideInInspector]
    public bool attached;
    public bool activated;
    private bool connect;

    private void OnTriggerStay(Collider collision)
    {
        ObjectController objectController = collision.gameObject.GetComponent<ObjectController>();
        if (objectController != null)
        {
            if (objectController.ConnectionID == PlaceID)
            {
                objectController.Connect();
                replacementObject.SetActive(true);
                attached = true;
                replacementObject.transform.Translate(0, 0, -offset);
            }
            else
            {
                print("IDs Don't match - " + objectController.ConnectionID + ", " + PlaceID);
            }
        }
        else
        {
            ActivationController activationController = collision.gameObject.GetComponent<ActivationController>();
            if(activationController != null && activationController == activator && !activated)
            {

                // Get controller diagonally to current controller (set on position 0)
                PlaceController placeControllerHelper = WaitForActivation[1].GetComponent<PlaceController>();

                connect = true;
                for (int i=1; i<WaitForActivation.Length; i++) 
                {   
                    PlaceController placeController = WaitForActivation[i].GetComponent<PlaceController>();

                    if(placeController != null && placeController.activated && !placeControllerHelper.activated)
                    {
                        connect = true;
                    }
                }

                if(connect)
                {
                    replacementObject.transform.Translate(0, 0, offset);
                    activated = true;
                    print("Activated " + collision.gameObject.name);
                    activationController.Activate();
                }

            }
        }
    }

}
