using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repetition : MonoBehaviour {

    public GameObject currentConnector;
    public GameObject prevConnectionObject;
    public GameObject preConnectionObject2;

    // Use this for initialization
    public void repeat()
    {
        Debug.Log("Reptition: updateTaskNo " + updateTaskNo.number + " ; currentTaskNo " + timeStamps.currentTaskNo);
        updateTaskNo.number -= 1;
        timeStamps.currentTaskNo -= 2;
        Debug.Log("Repetition: updateTaskNo " + updateTaskNo.number + " ; currentTaskNo " + timeStamps.currentTaskNo);
        getObjects();
    }

    //transform.position only works if objects hits table or any other object. Otherwise y-axis keeps changing, and object moves away
    void getObjects()
    {

        if (updateTaskNo.number == 1)
        {
            currentConnector = GameObject.Find("1. PlateConnector");
            currentConnector.GetComponent<ConnectorController>().HelpObject.SetActive(true);
            currentConnector.GetComponent<ConnectorController>().ConnectionObject.SetActive(true);
            currentConnector.GetComponent<ConnectorController>().ReplacementObject.SetActive(false);
            prevConnectionObject = GameObject.Find("1. Plate Part");
            prevConnectionObject.transform.position = new Vector3(4.122f, 2.211892f, 1.20989f);
            //currentConnector.GetComponent<ConnectorController>().WaitForActivation = null;
            //reactivate situation of beginning, with connector equals false
        }
        //currentConnector[updateTaskNo.number - 1].GetComponent<ConnectorController>().HelpObject.SetActive(true);
        //currentConnector[updateTaskNo.number - 1].GetComponent<ConnectorController>().ConnectionObject.SetActive(true);
        //currentConnector[updateTaskNo.number - 1].GetComponent<ConnectorController>().ReplacementObject.SetActive(false);
        //prevConnectionObject = GameObject.Find(currentConnector[updateTaskNo.number - 1].GetComponent<ConnectorController>().ConnectionObject.name);
        //prevConnectionObject.transform.position = new Vector3(3.8f, 2, 1);

        if (updateTaskNo.number == 2)
        {
            Debug.Log("Repetition: Reactivate objects of second task");
            currentConnector = GameObject.Find("2. Plate");
            currentConnector.GetComponent<ConnectorController>().HelpObject.SetActive(true);
            GameObject.Find("3. ClipOverThing Connector").GetComponent<ConnectorController>().HelpObject.SetActive(false);
            GameObject.Find("2. First Screw").SetActive(true);
            GameObject.Find("2. Second Screw").SetActive(true);
            //currentConnector.GetComponent<ConnectorController>().ReplacementObject.SetActive(false);
            GameObject.Find("2. First Screw").transform.position = new Vector3(4.1f, 2.211892f, 1.20989f);
            GameObject.Find("2. Second Screw").transform.position = new Vector3(4.1f, 2.211892f, 1.20989f);
            //GameObject.Find("2. Second Screw").GetComponent<Rigidbody>().useGravity = true;
        }

        if (updateTaskNo.number == 3)
        {
            currentConnector = GameObject.Find("3. ClipOverThing Connector");
            currentConnector.GetComponent<ConnectorController>().HelpObject.SetActive(true);
            currentConnector.GetComponent<ConnectorController>().ConnectionObject.SetActive(true);
            currentConnector.GetComponent<ConnectorController>().ReplacementObject.SetActive(false);
            prevConnectionObject = GameObject.Find("3. ClipOverThing Part");
            prevConnectionObject.transform.position = new Vector3(3.8f, 2, 1);
        }


    }
}
