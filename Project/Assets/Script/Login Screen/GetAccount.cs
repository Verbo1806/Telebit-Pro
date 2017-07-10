using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GetAccount{


    public int ID;
    public string Email;
    public string Username;
    public string Password;
    public int Coins;
    public int Upgrade_Speed;
    public int Upgrade_Time;
    public int Upgrade_DoubleJump;
    public int Upgrade_Death;
    public int Upgrade_Fly;


    public GetAccount Download(WWW www)
    {
        string text = www.text.Substring(1, www.text.Length - 2);
        return JsonUtility.FromJson<GetAccount>(text);
    }
}
