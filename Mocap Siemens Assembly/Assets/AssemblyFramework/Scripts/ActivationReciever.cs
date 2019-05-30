using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationReciever : MonoBehaviour {

    public GameObject Activator;

    [HideInInspector]
    public bool activated = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Activator)
        {
            activated = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == Activator)
        {
            activated = false;
        }
    }
}
