using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationModify : MonoBehaviour {
    static string insertInfoURL = "http://impossible.gear.host/ModifyData.php";
    public static bool sentinfo = false;

    IEnumerator getModifications()
    {
        yield return new WaitUntil(() => InformationHolder.isReady);
    }

    private void Update()
    {
        if (sentinfo)
        {
            sentinfo = false;
            StartCoroutine(InformationHolder.getAccounts());
            StartCoroutine(getModifications());
        }
    }

    static IEnumerator Wait()
    {
        yield return InformationHolder.AccountData;
        
    }

    public static IEnumerator SendInfo(string name, int value)
    {
        WWWForm form = new WWWForm();
        InformationModify.Wait();
        form.AddField("ID", Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "ID:")));
        form.AddField("name", name);
        form.AddField("value", value);
        WWW www = new WWW(insertInfoURL, form);
        yield return www;
        Upgrades.Information();
        Upgrades.loadInfo();
        sentinfo = true;
    }
}
