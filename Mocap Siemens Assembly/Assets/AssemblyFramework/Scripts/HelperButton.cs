using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperButton : MonoBehaviour
{
public static bool isOn = true;

    private void OnTriggerStay(Collider other)
    {
		HelperButton.isOn = true;
    }

    private void OnTriggerExit(Collider other)
    {
     
    }
}
