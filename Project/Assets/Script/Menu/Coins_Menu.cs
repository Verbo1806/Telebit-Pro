using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Coins_Menu : MonoBehaviour {

	public Text coins_text;
    
    void Update()
    {
            coins_text.text = "" + InformationHolder.AccountData.Coins;      
    }
}