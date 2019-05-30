using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectorControllerInstructions : MonoBehaviour {
    public GameObject[] connectionPoints;

    public GameObject ConnectionObject;
    public GameObject ReplacementObject;
    public GameObject LastInstructions;
    public GameObject NextInstructions;
    public AudioClip ConnectClip;
    public GameObject[] WaitForActivation;

    private bool connect;
    private bool activated = false;
   	private AudioSource connectSound;

    private void Update()
    {
    	if (connect) {
    		return;
    	}

    	connect = true;
        for (int i = 0; i < connectionPoints.Length; i++)
        {
            ConnectionPoint connection = connectionPoints[i].GetComponent<ConnectionPoint>();
            if (connection != null && connection.connected == false)
            {
            	connect = false;
            }
        }

        for (int i=0; i<WaitForActivation.Length; i++) 
	    {	
	    	//print(i);
	        PlaceController placeController = WaitForActivation[i].GetComponent<PlaceController>();
	        if (placeController != null && !placeController.activated) 
        	{
				connect = false;
		  	}
        }

        if(connect){
        	if(NextInstructions != null && LastInstructions != null){
	        	NextInstructions.SetActive(true);
        		Destroy(LastInstructions);
        	}
        }

        // ActivationReciever ar = null;
        // if (ConnectionObject)
        // {
        //     ar = ConnectionObject.GetComponent<ActivationReciever>();
        // }
        // if (needsActivator && (ar != null))
        // {
        //     if (ar.activated)
        //     {
        //         activated = true;
        //     }
        // }
        if (connect) {
        	Connect();        	
        }
    }

    void Connect()
    {
    	print("Connect");
    	print(ConnectionObject);
        Destroy(ConnectionObject);
        ReplacementObject.SetActive(true);
        connectSound.clip = ConnectClip;
        connectSound.Play(0);
    }
}