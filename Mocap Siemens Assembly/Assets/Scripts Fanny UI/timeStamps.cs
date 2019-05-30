using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

// this class measures time needed for each of the 15 subtasks. It fires as soon as the number of the headup-display fires. At the end it shows an overview of the needed time for each subtask

public class timeStamps : MonoBehaviour {

    private UnityEvent[] subtaskListener = new UnityEvent[15];
    public Button triggerButton;
    public static int currentTaskNo = 1;
    public Text taskNo;
    public Text finish_task;
    public repetition ccontroller;

    private float[] subtask_start;
    private float task1TimeStamp;
    public float task2TimeStamp;
    public float task3TimeStamp;
    public float task4TimeStamp;
    public float task5TimeStamp;
    public float task6TimeStamp;
    public float task7TimeStamp;
    public float task8TimeStamp;
    public float task9TimeStamp;
    public float task10TimeStamp;
    public float task11TimeStamp;
    public float task12TimeStamp;
    public float task13TimeStamp;
    public float task14TimeStamp;
    public float task15TimeStamp;
    public float endTimeStamp;
    public static float[] taskTotal = new float[15];
    public string[] subtaskNo;
    bool repeat1 = false;

    // Use this for initialization
    void Start () {

        //create and activate Events = Listeners

        Debug.Log("HALLO");
        for (int i = 0; i < 15; i ++) {
            subtaskListener[i] = new UnityEvent();
            taskTotal[i] = new float();
        }
        subtaskListener[0].AddListener(subTask1Time);
        subtaskListener[1].AddListener(subTask2Time);
        subtaskListener[2].AddListener(subTask3Time);
        subtaskListener[3].AddListener(subTask4Time);
        subtaskListener[4].AddListener(subTask5Time);
        subtaskListener[5].AddListener(subTask6Time);
        subtaskListener[6].AddListener(subTask7Time);
        subtaskListener[7].AddListener(subTask8Time);
        subtaskListener[8].AddListener(subTask9Time);
        subtaskListener[9].AddListener(subTask10Time);
        subtaskListener[10].AddListener(subTask11Time);
        subtaskListener[11].AddListener(subTask12Time);
        subtaskListener[12].AddListener(subTask13Time);
        subtaskListener[13].AddListener(subTask14Time);
        subtaskListener[14].AddListener(subTask15Time);
    }
	
	// Update is called once per frame
     void Update () {
        //based on the current number shown on the headup display the according method, e.g. subTask1Time is fired, to fire the first time stamp as soon as the number on the head up display changes

        if (updateTaskNo.number == currentTaskNo && subtaskListener[currentTaskNo-1] != null)
        {
            Debug.Log("timestamps: updateTaskNo " + updateTaskNo.number + " ; currentTaskNo " + timeStamps.currentTaskNo);
            currentTaskNo++;
            Debug.Log("timestamps: updateTaskNo " + updateTaskNo.number + " ; currentTaskNo " + timeStamps.currentTaskNo);
            subtaskListener[updateTaskNo.number- 1].Invoke();
        }

        // if last subtask is completed show an overview of needed time
        if (updateTaskNo.number == 15 && ConnectorController.helper == 1)
        {
            ConnectorController.helper = 0;
            // begin to measure time
            endTimeStamp = Time.time;
            taskTotal[14] = endTimeStamp - task15TimeStamp;
            // deactivate counter head-up display
            taskNo.enabled = false;
            // activate finisher display
            finish_task.text = ("Your Performance: \r\n' " + "Task 1 " + taskTotal[0] + "\r\n Task 2: " + taskTotal[1] + "\r\n Task 3: " + taskTotal[2] + "\r\n Task 4: " + taskTotal[3] + "\r\n Task 5: " + taskTotal[4]);
            //triggerButton = GameObject.Find("TriggerButton").GetComponent<Button>();
            triggerButton.onClick.Invoke();
            //SendToGoogle send = new SendToGoogle();
            //send.Send();

            Debug.Log("Time for 1. task " + taskTotal[0]);
            Debug.Log("Time for 2. task " + taskTotal[1]);
            Debug.Log("Time for 3. task " + taskTotal[2]);
            Debug.Log("Time for 4. task " + taskTotal[3]);
            Debug.Log("Time for 5. task " + taskTotal[4]);
            Debug.Log("Time for 6. task " + taskTotal[5]);
            Debug.Log("Time for 7. task " + taskTotal[6]);
            Debug.Log("Time for 8. task " + taskTotal[7]);
            Debug.Log("Time for 9. task " + taskTotal[8]);
            Debug.Log("Time for 10. task " + taskTotal[9]);
            Debug.Log("Time for 11. task " + taskTotal[10]);
            Debug.Log("Time for 12. task " + taskTotal[11]);
            Debug.Log("Time for 13. task " + taskTotal[12]);
            Debug.Log("Time for 14. task " + taskTotal[13]);
            Debug.Log("Time for 15. task " + taskTotal[14]);

        }
    }


    void subTask1Time()
    {
        //Output message
        Debug.Log("Do 1 stuff");
        //fire first time stamp, first subtask begins
        task1TimeStamp = Time.time;
        //remove listener that this method is fired only once per change of number of the headup display
        subtaskListener[0].RemoveListener(subTask1Time);

    }
    void subTask2Time()
    {
        //Output message
        Debug.Log("Do 2 stuff");
        //fire timestamp 2, second subtask begins
        task2TimeStamp = Time.time;
        //total time needed for subtask 1 is equals timestamp beginning subtask two minus timestamp beginning subtask 1
        taskTotal[0] = task2TimeStamp - task1TimeStamp;
        Debug.Log("Time for first task " + taskTotal[0]);
        //check for repetition
        if (timeStamps.taskTotal[0] > 10 && repeat1 != true) //do not enter if statement, if task 2 should be repeated / only enter if task 1 should be repeated
        {
            subtaskListener[0].AddListener(subTask1Time);
            ccontroller = new repetition(); //not allowed because its a monobehaviour class
            ccontroller.repeat();
        }
        else
        {
            Debug.Log("Move from 2. to 3rd task");
            subtaskListener[1].RemoveListener(subTask2Time);
            repeat1 = true; // repeat1 tells that task no 1 should not be repeated next time
            Debug.Log("bool repeat1 is set to true");
        }
    }

    void subTask3Time()
    {
        //Output message
        Debug.Log("Do 3 stuff");
        task3TimeStamp = Time.time;
        taskTotal[1] = task3TimeStamp - task2TimeStamp;
        Debug.Log("Time for second task " + taskTotal[1]);
        if (timeStamps.taskTotal[1] > 10)
        {
            subtaskListener[1].AddListener(subTask2Time);
            ccontroller = new repetition();
            ccontroller.repeat();
        }
        else
        {
            Debug.Log("Move from 3. to 4th task");
            subtaskListener[2].RemoveListener(subTask3Time);
        }
        
    }
    void subTask4Time()
    {
        //Output message
        Debug.Log("Do 4 stuff");
        task4TimeStamp = Time.time;
        taskTotal[2] = task4TimeStamp - task2TimeStamp;
        Debug.Log("Time for third task " + taskTotal[2]);
        subtaskListener[3].RemoveListener(subTask4Time);
    }

    void subTask5Time()
    {
        //Output message
        Debug.Log("Do 5 stuff");
        task5TimeStamp = Time.time;
        taskTotal[3] = task5TimeStamp - task4TimeStamp;
        Debug.Log("Time for fourth task " + taskTotal[3]);
        subtaskListener[4].RemoveListener(subTask5Time);
    }

    void subTask6Time()
    {
        //Output message
        Debug.Log("Do 6 stuff");
        task6TimeStamp = Time.time;
        taskTotal[4] = task6TimeStamp - task5TimeStamp;
        Debug.Log("Time for fifth task " + taskTotal[4]);
        subtaskListener[5].RemoveListener(subTask6Time);
    }

    void subTask7Time()
    {
        //Output message
        Debug.Log("Do 7 stuff");
        task7TimeStamp = Time.time;
        taskTotal[5] = task7TimeStamp - task6TimeStamp;
        Debug.Log("Time for sixth task " + taskTotal[5]);
        subtaskListener[6].RemoveListener(subTask7Time);
    }

    void subTask8Time()
    {
        //Output message
        Debug.Log("Do 8 stuff");
        task8TimeStamp = Time.time;
        taskTotal[6] = task8TimeStamp - task7TimeStamp;
        Debug.Log("Time for seventh task " + taskTotal[6]);
        subtaskListener[7].RemoveListener(subTask8Time);
    }

    void subTask9Time()
    {
        //Output message
        Debug.Log("Do 9 stuff");
        task9TimeStamp = Time.time;
        taskTotal[7] = task9TimeStamp - task8TimeStamp;
        Debug.Log("Time for eighth task " + taskTotal[7]);
        subtaskListener[8].RemoveListener(subTask9Time);
    }

    void subTask10Time()
    {
        //Output message
        Debug.Log("Do 10 stuff");
        task10TimeStamp = Time.time;
        taskTotal[8] = task10TimeStamp - task9TimeStamp;
        Debug.Log("Time for 9 task " + taskTotal[8]);
        subtaskListener[9].RemoveListener(subTask10Time);
    }

    void subTask11Time()
    {
        //Output message
        Debug.Log("Do 11 stuff");
        task11TimeStamp = Time.time;
        taskTotal[9] = task11TimeStamp - task10TimeStamp;
        Debug.Log("Time for 10 task " + taskTotal[9]);
        subtaskListener[10].RemoveListener(subTask11Time);
    }

    void subTask12Time()
    {
        //Output message
        Debug.Log("Do 12 stuff");
        task12TimeStamp = Time.time;
        taskTotal[10] = task12TimeStamp - task11TimeStamp;
        Debug.Log("Time for 11 task " + taskTotal[10]);
        subtaskListener[11].RemoveListener(subTask12Time);
    }

    void subTask13Time()
    {
        //Output message
        Debug.Log("Do 13 stuff");
        task13TimeStamp = Time.time;
        taskTotal[11] = task13TimeStamp - task12TimeStamp;
        Debug.Log("Time for 12 task " + taskTotal[11]);
        subtaskListener[12].RemoveListener(subTask13Time);
    }

    void subTask14Time()
    {
        //Output message
        Debug.Log("Do 14 stuff");
        task14TimeStamp = Time.time;
        taskTotal[12] = task14TimeStamp - task13TimeStamp;
        Debug.Log("Time for 13 task " + taskTotal[12]);
        subtaskListener[13].RemoveListener(subTask14Time);
    }

    void subTask15Time()
    {
        //Output message
        Debug.Log("Do 15 stuff");
        task15TimeStamp = Time.time;
        taskTotal[13] = task15TimeStamp - task14TimeStamp;
        Debug.Log("Time for 14 task " + taskTotal[13]);
        subtaskListener[14].RemoveListener(subTask15Time);
    }

    //public void repeat()
    //{
    //    ConnectorController.currentObject.SetActive(false);
    //    ConnectorController.ConnectionObject.SetActive(false);
    //    ConnectorController.HelpObject.SetActive(false);
    //    ConnectorController.prevConnectionObject.SetActive(true);
    //    ConnectorController.prevHelpObject.SetActive(true);
    //    ConnectorController.prevReplacementObject.SetActive(false);
    //}
}
