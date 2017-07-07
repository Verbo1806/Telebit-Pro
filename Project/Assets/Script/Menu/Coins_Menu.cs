using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Coins_Menu : MonoBehaviour {

	public Text coins_text;
	int coins;
    
    void Update()
    {
        try{
            coins = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Coins:"));
            coins_text.text = "" + coins;
            Debug.Log(coins);
        }catch(ArgumentOutOfRangeException e)
        {

        }
       
    }
}