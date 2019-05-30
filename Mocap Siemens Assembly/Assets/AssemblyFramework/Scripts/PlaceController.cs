using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceController : MonoBehaviour {
    public string PlaceID;
    public GameObject replacementObject;
    public GameObject[] WaitForActivation;
    public GameObject LastInstructions;
    public GameObject NextInstructions;
    public ActivationController activator;
    public float offset;
    
    [HideInInspector]
    public bool attached;
    public bool activated;
    private bool updateInstructions = true;
    private bool activationHelper;
    private int activationCounter = 0;

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
                //replacementObject.transform.Translate(0, 0, -0.02f);
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
                activationHelper = true;
                if(WaitForActivation.Length>2){
                    PlaceController helperController1 = WaitForActivation[0].GetComponent<PlaceController>();
                    PlaceController helperController2 = WaitForActivation[1].GetComponent<PlaceController>();
                    PlaceController helperController3 = WaitForActivation[2].GetComponent<PlaceController>();
                    if(!helperController1.activated && (helperController2.activated ^ helperController3.activated)){
                       activationHelper = false;
                    }
                }

                if(activationHelper)
                {
                    replacementObject.transform.Translate(0, 0, offset);
                    activated = true;
                    print("Activated " + collision.gameObject.name);
                    activationController.Activate();    

                    for (int i=0; i<WaitForActivation.Length; i++) 
                    {   
                        //print(i);

                        PlaceController placeController = WaitForActivation[i].GetComponent<PlaceController>();
                        if (placeController != null && !placeController.activated) 
                        {
                            updateInstructions = false;              
                        }
                    }

                    if(updateInstructions){
                        NextInstructions.SetActive(true);
                        Destroy(LastInstructions);  
                    }
                }

                /*PlaceController helperController = WaitForActivation[0].GetComponent<PlaceController>();
                activationCounter = 0;
                for (int i=0; i<WaitForActivation.Length; i++) 
                {   
                    //print(i);

                    PlaceController placeController = WaitForActivation[i].GetComponent<PlaceController>();
                    if (placeController != null && placeController.activated){
                        activationCounter = activationCounter + 1;
                    }
                }

                //replacementObject.transform.Translate(0, 0, 0.02f);
                if( (activationCounter % 2)==0 || helperController.activated){
                    print(helperController.activated);
                    print(activationCounter);
                    replacementObject.transform.Translate(0, 0, offset);
                    activated = true;
                    print("Activated " + collision.gameObject.name);
                    activationController.Activate();    

                    for (int i=0; i<WaitForActivation.Length; i++) 
                    {   
                        //print(i);

                        PlaceController placeController = WaitForActivation[i].GetComponent<PlaceController>();
                        if (placeController != null && !placeController.activated) 
                        {
                            updateInstructions = false;              
                        }
                    }

                    if(updateInstructions){
                        NextInstructions.SetActive(true);
                        Destroy(LastInstructions);  
                    }
                }*/
            }
        }
    }
}
