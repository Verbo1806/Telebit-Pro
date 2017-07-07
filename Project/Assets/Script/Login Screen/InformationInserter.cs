using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformationInserter : MonoBehaviour {
    public string inputEmail;
    public string inputUsername;
    public string inputPassword;


    static string insertInfoURL = "http://localhost/TelebidProject/InsertData.php";
    
    public static void CreateUser(string email, string username, string password)
    {
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
    }
}
