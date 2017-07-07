using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour {
    public GameObject button;
	int coins;
    int speed;
    int doubleJump;
    int fly;
    int death;

    IEnumerator Start()
    {
        yield return InformationHolder.AccountData;
        coins = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Coins:"));
        speed = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Upgrade_Speed:"));
        doubleJump = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Upgrade_DoubleJump:"));
        fly = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Upgrade_Fly:"));
        death = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Upgrade_Death:"));
    }

    void loadInfo()
    {
        
        PlayerPrefs.GetInt("coin", coins);
        PlayerPrefs.GetInt("SPEED", speed);
        PlayerPrefs.GetInt("DOUBLEJUMP", doubleJump);
        PlayerPrefs.GetInt("FLY", fly);
        PlayerPrefs.GetInt("DEATH", death);
    }

    void active()
    {
        switch (button.tag)
        {
            case "Speed":
                if (speed == 1)
                    button.SetActive(false);
                break;
            case "DoubleJump":
                if (doubleJump == 1)
                    button.SetActive(false);
                break;
            case "Fly":
                if (fly == 1)
                    button.SetActive(false);
                break;
            case "Death":
                if (death == 1)
                    button.SetActive(false);
                break;
        }
    }

    void Update() {
        loadInfo();
        active();
	}

    public void ButtonPressed()
    {
        switch(button.tag) {
            case "Speed":
			    if (coins >= 5)
			    coins -= 5;
                speed = 1;
                break;
            case "DoubleJump":
			if (coins >= 5)
				coins -= 5;

                doubleJump = 1;
                break;
            case "Fly":
			if (coins >= 5)
				coins -= 5;

                fly = 1;
                break;
		case "Death":
			if (coins >= 5)
				coins -= 5;
			
            	death = 1;
            	break;
        }

		PlayerPrefs.SetInt ("coin", coins);
		PlayerPrefs.Save ();
    }
}
