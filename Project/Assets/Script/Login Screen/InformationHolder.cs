using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InformationHolder : MonoBehaviour {
    public static WWW AccountData;
    public static List<string> tokens;
    public static bool isConnected = true;
    public static bool isReady = false;

    public static IEnumerator getAccounts()
    {
        AccountData = new WWW("http://impossible.gear.host/AccountData.php");
        yield return AccountData;
        isReady = true;
        Debug.Log(isReady);
        string AccDataString = AccountData.text;
        if (AccDataString.Contains("Connection failed"))
            isConnected = false;
        else
            tokens = AccDataString.Split(';').ToList<string>();
    }

	void Start () {
        tokens = new List<string>();
        StartCoroutine(getAccounts());
	}

    public static string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if(value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
    

}
