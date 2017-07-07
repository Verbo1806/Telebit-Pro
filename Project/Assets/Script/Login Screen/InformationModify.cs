using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationModify : MonoBehaviour {
    static string insertInfoURL = "http://localhost/TelebidProject/ModifyData.php";

    static IEnumerator Wait()
    {
        yield return InformationHolder.AccountData;
    }

    public static void SendInfo(string name, int value)
    {
        WWWForm form = new WWWForm();
        Debug.Log(Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "ID:")) + name + " : " + value);
        InformationModify.Wait();
        form.AddField("ID", Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "ID:")));
        form.AddField("name", name);
        form.AddField("value", value);
        WWW www = new WWW(insertInfoURL, form);
    }
}
