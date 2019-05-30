using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class SendToGoogle : MonoBehaviour {

    public static string[] time = new string[15];
    [SerializeField]
    private static string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSfSTXp7Z0U9a7rcIWChSAMtG9T1cPsWNqXuC_phOfpMQdd3tg/formResponse";
	// Use this for initialization

    IEnumerator Post(string[] time)
    {
        WWWForm form = new WWWForm();

        form.AddField("entry.1792407811", time[0]);
        form.AddField("entry.1282080761", time[1]);
        form.AddField("entry.1721149895", time[2]);
        form.AddField("entry.1440512528", time[3]);
        form.AddField("entry.1396265791", time[4]);
        form.AddField("entry.893618040", time[5]);
        form.AddField("entry.1570768370", time[6]);
        form.AddField("entry.364057549", time[7]);
        form.AddField("entry.649311311", time[8]);
        form.AddField("entry.2140784730", time[9]);
        form.AddField("entry.1991463888", time[10]);
        form.AddField("entry.768604856", time[11]);
        form.AddField("entry.315468442", time[12]);
        form.AddField("entry.452223188", time[13]);
        form.AddField("entry.159923023", time[14]);
        byte[] rawData = form.data;
        WWW www = new WWW(BASE_URL, rawData);
        yield return www;

    }

    public void Send()
    {
        for (int i = 0; i < 15; i++)
        {
            time[i] = timeStamps.taskTotal[i].ToString();
        }
        StartCoroutine(Post(time));
    }
}
