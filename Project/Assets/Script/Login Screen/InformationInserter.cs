using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InformationInserter : MonoBehaviour {
    
    static string insertInfoURL = "http://impossible.gear.host/InsertData.php";

    public static bool isready;
    
    public IEnumerator CreateUser(string email, string username, string password)
    {
        isready = false;
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("username", username);
        form.AddField("pass", password);
        form.AddField("coins", 0);
        form.AddField("speed", 0);
        form.AddField("time", 0);
        form.AddField("doublejump", 0);
        form.AddField("death", 0);
        form.AddField("fly", 0);
        WWW www = new WWW(insertInfoURL, form);
        yield return www;
        isready = true;
        if (!string.IsNullOrEmpty(www.error))
        {
            print("Error wwwing: " + www.error);
        }
        else
        {
            // show the highscores
            Debug.Log(www.text);
        }
    }
}
