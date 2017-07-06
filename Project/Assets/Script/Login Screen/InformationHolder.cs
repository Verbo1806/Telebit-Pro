using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationHolder : MonoBehaviour {
    public static string[] tokens;
	IEnumerator Start () {
        WWW AccountData = new WWW("http://localhost/TelebidProject/AccountData.php");
        yield return AccountData;
        string AccDataString = AccountData.text;
        print(AccDataString);
        tokens = AccDataString.Split(';');
	}

    public static string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if(value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
    

}
