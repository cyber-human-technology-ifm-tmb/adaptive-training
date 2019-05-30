using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateTaskNo : MonoBehaviour {

    public static Text taskNo;
    public static int number = 1;


	// Use this for initialization
	void Start () {
        taskNo = GameObject.Find("taskNo").GetComponent<Text>();
        taskNo.text = number.ToString();
        //taskNo = GameObject.Find("taskNo").GetComponent<Text>();
        //taskNo.text = number.ToString();

    }

    void Update()
    {
        taskNo = GameObject.Find("taskNo").GetComponent<Text>();
        taskNo.text = number.ToString();
    }

    // Update is called once per frame
}
