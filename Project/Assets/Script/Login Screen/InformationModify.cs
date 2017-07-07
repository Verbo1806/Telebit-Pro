using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationModify : MonoBehaviour {
    static string insertInfoURL = "http://localhost/TelebidProject/ModifyData.php";

    IEnumerator Wait()
    {
        yield return InformationHolder.AccountData;
    }

    public void onClick(string name)
    {
        WWWForm form = new WWWForm();
        form.AddField("ID_cl", Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "ID:")));
        form.AddField("name_cl", name);
        WWW www = new WWW(insertInfoURL, form);
    }
}
