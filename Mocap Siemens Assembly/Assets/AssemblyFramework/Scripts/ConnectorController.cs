using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ConnectorController : MonoBehaviour {    
    public GameObject[] connectionPoints;
    GameObject prevConnectionObject;
    //public GameObject activator;
    //public static bool helpOn=true;
    public GameObject currentObject;
    public GameObject prevReplacementObject;
    public GameObject prevHelpObject;
    public GameObject ConnectionObject;
    public GameObject ReplacementObject;
    public  GameObject HelpObject;
    public AudioClip ConnectClip;
    public GameObject[] WaitForActivation;
    public bool updateInstructions;
    public GameObject LastInstructions;
    public GameObject NextInstructions;
    public static int helper = 0;

    public GameObject ScrewHelp;

    public bool connect;
    private bool activated;
    private AudioSource connectSound;
    private bool helpTaskNo = true;


    private void Update()
    {
        Debug.Log("1. connect " + connect);

        if (connect)
        {
            return;
        }


        //set connect true
        connect = true;
        bool helpOn = true;
        Debug.Log("3.connect " + connect);


        //repetition activates this

       
            for (int i = 0; i < WaitForActivation.Length; i++)
            {
                Debug.Log("Wait for activation loop");
                PlaceController placeController = WaitForActivation[i].GetComponent<PlaceController>();
                if (placeController != null && !placeController.activated)
                {
                    connect = false;
                    Debug.Log("Wait for activation connect set to false");
                    if (ScrewHelp && helpOn) // change this bit for activation of screw hints
                    {
                        ScrewHelp.SetActive(true);
                        Renderer[] screw_renderers = ScrewHelp.GetComponentsInChildren<Renderer>();
                        //foreach (Renderer r in screw_renderers)
                        //{
                        //r.material.SetColor("_Color", new Color(0, 1.0f, 1.0f));
                        //}
                    }
                }
            }
        

        if (connect)
        {
            
            if (ScrewHelp)
            {
                ScrewHelp.SetActive(false);
                // update head-up display with current sub-task number if drilling of screws completed
                if (helpTaskNo == true)
                {
                    updateTaskNo.number += 1;
                    helpTaskNo = false;
                } 
         
                
                // hier muss taskNo um 1 hochgezaehlt werden - work around?
            }
           
            //activate help
            if (helpOn) // change this bit for activation of hints
            {
                HelpObject.SetActive(true);
                Renderer[] renderers = HelpObject.GetComponentsInChildren<Renderer>();
                //foreach (Renderer r in renderers)
                //{
                    //Color color = Color.green;
                    //color.a = 0.01f;
                    //r.material.SetColor("_Color", new Color(0, 1.0f, 1.0f));
                    //r.material.SetColor("_Color", color);

                //}
                Collider[] colChildren = HelpObject.GetComponentsInChildren<Collider>();
                foreach (Collider c in colChildren)
                {
                    c.enabled = false;
                }
            }
           
        }



        //set connect false as long as objects are not connected
        for (int i = 0; i < connectionPoints.Length; i++)
        {
            Debug.Log("ConnectionPoint Loop");
            ConnectionPoint connection = connectionPoints[i].GetComponent<ConnectionPoint>();
            if (connection != null && connection.connected == false)
            {
                //Debug.Log("ConnectionPoint Loop set connect false");
                connect = false;
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
            Debug.Log("Call connect function");
            Connect();          
        }
    }

    void Connect()
    {
        Debug.Log("Connect");
        //deactivate Connection&Helper Object
        ConnectionObject.SetActive(false);
        HelpObject.SetActive(false);
        ReplacementObject.SetActive(true);
        helper = 1;
        updateTaskNo.number += 1;     
        //Destroy(ConnectionObject);
        //Destroy(HelpObject);
        //HelperButton.isOn = false;
        //ReplacementObject.SetActive(true);
        //helper = 1;

        //if (updateInstructions){
        //    NextInstructions.SetActive(true);
        //    Destroy(LastInstructions);
        //}
        //update head-up display sub-task number if the sub-task is completed 
        //updateTaskNo.number += 1;
        //connectSound.clip = ConnectClip;
        //connectSound.Play(0);
    }    

}