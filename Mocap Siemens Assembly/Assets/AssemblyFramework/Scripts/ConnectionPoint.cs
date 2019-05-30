using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionPoint : MonoBehaviour
{
    public string ConnectionID;

    [HideInInspector]
    public bool connected = false;

    //as soon as grapping object, fire this method
    private void OnTriggerStay(Collider other)
    {
        //get connecttion points of grapped object
        ConnectionPoint connection = other.GetComponent<ConnectionPoint>();
        if(connection != null)
        {
            //set connected = true if connection points IDs of object are the same as the connectionPoints ID of the connector
            if(connection.ConnectionID == ConnectionID)
            {
                Debug.Log("ConnectionPoint OnTriggerStayset connected to true");
                connected = true;
                //GameObject.Find("1. PlateConnector").GetComponent<ConnectorController>().repetition = false;
                //updateTaskNo.number += 1;
            }
        }
    }

    //when releasing object or colliding objects that should collide, set connected equals false
    private void OnTriggerExit(Collider other)
    {
        ConnectionPoint connection = other.GetComponent<ConnectionPoint>();
        if (connection != null)
        {
            if (connection.ConnectionID == ConnectionID && connected)
            {
                Debug.Log("ConnectionPoint OnTriggerExit set connected to false");
                connected = false;
                if (updateTaskNo.number == 1)
                {
                    GameObject.Find("1. PlateConnector").GetComponent<ConnectorController>().connect = false;
                }

                if (updateTaskNo.number == 2)
                {
                    GameObject.Find("2. Plate").GetComponent<ConnectorController>().connect = false;
                }

                if (updateTaskNo.number == 3)
                {
                    GameObject.Find("3. ClipOverThing Connector").GetComponent<ConnectorController>().connect = false;
                }
                

            }
        }
    }
}
