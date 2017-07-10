using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationModify : MonoBehaviour {
    static string insertInfoURL = "http://impossible.gear.host/ModifyData.php";
    public static bool sentinfo = false;
    
    
    

    public IEnumerator SendInfo(string name, int value)
    {
        WWWForm form = new WWWForm();
        form.AddField("ID", InformationHolder.AccountData.ID);
        form.AddField("name", name);
        form.AddField("value", value);
        WWW www = new WWW(insertInfoURL, form);
        yield return www;
        InformationHolder acc = new InformationHolder();
        StartCoroutine(new InformationHolder().Account(InformationHolder.AccountData.Username, PlayerPrefs.GetString("PASSWORD", null)));
        sentinfo = true;
    }
}
