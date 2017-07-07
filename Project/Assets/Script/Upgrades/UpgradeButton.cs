using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour {
    public GameObject button;

    IEnumerator Wait()
    {
        yield return InformationHolder.AccountData;
    }

   
    void active()
    {
        switch (button.tag)
        {
            case "Speed":
                if (Upgrades.speed == 1)
                    button.SetActive(false);
                break;
            case "DoubleJump":
                if (Upgrades.doubleJump == 1)
                    button.SetActive(false);
                break;
            case "Fly":
                if (Upgrades.fly == 1)
                    button.SetActive(false);
                break;
            case "Death":
                if (Upgrades.death == 1)
                    button.SetActive(false);
                break;
        }
    }

    void Update() {
        active();
	}

    public void ButtonPressed()
    {
        switch(button.tag) {
            case "Speed":
                if (Upgrades.coins >= 5)
                {
                    Upgrades.coins -= 5;
                    Upgrades.speed = 1;
                }
                break;
            case "DoubleJump":
                if (Upgrades.coins >= 5)
                {
                    Upgrades.coins -= 5;
                    Upgrades.doubleJump = 1;
                }
                break;
            case "Fly":
                if (Upgrades.coins >= 5)
                {
                    Upgrades.coins -= 5;
                    Upgrades.fly = 1;
                }
                break;
            case "Death":
                if (Upgrades.coins >= 5)
                {

                    Upgrades.coins -= 5;
                    Upgrades.death = 1;
                }
                break;
        }
        Wait();
        InformationModify.SendInfo("Upgrade_Speed", Upgrades.speed);
        InformationModify.SendInfo("Upgrade_DoubleJump", Upgrades.doubleJump);
        InformationModify.SendInfo("Upgrade_Fly", Upgrades.fly);
        InformationModify.SendInfo("Upgrade_Death", Upgrades.death);
        InformationModify.SendInfo("Coins", Upgrades.coins);

    }
}
