using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationHolder : MonoBehaviour
{

    public static GetAccount AccountData;
    public static bool isReady;
	public static string login_error;

    public IEnumerator Account(string usr, string pass)
    {
        isReady = false;
        string insertInfoURL = "http://impossible.gear.host/test.php";
        WWWForm form = new WWWForm();
        form.AddField("username", usr);
        form.AddField("pass", pass);
        WWW www = new WWW(insertInfoURL, form);
        yield return www;
		login_error = www.text;

        GetAccount Account = new GetAccount();
        AccountData = Account.Download(www);
        PlayerPrefs.SetString("USERNAME", usr);
        PlayerPrefs.SetString("PASSWORD", pass);
        isReady = true;
    }

}
