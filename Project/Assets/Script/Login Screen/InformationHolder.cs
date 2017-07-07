using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InformationHolder : MonoBehaviour {
    public static WWW AccountData;
    public static List<string> tokens;
	IEnumerator Start () {
        tokens = new List<string>();
        AccountData = new WWW("http://localhost/TelebidProject/AccountData.php");
        yield return AccountData;
        string AccDataString = AccountData.text;
        tokens = AccDataString.Split(';').ToList<string>();
        
	}

    public static string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if(value.Contains("|")) value = value.Remove(value.IndexOf("|"));
        return value;
    }
    

}
