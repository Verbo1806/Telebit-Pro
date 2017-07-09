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
            
            coins_text.text = "" + Upgrades.coins;
        }catch(ArgumentOutOfRangeException e)
        {

        }
       
    }
}