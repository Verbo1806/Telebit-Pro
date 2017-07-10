using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public static void loadInfo()
    {

        PlayerPrefs.SetInt("coin", InformationHolder.AccountData.Coins);
        PlayerPrefs.SetInt("SPEED", InformationHolder.AccountData.Upgrade_Speed);
        PlayerPrefs.SetInt("DOUBLEJUMP", InformationHolder.AccountData.Upgrade_DoubleJump);
        PlayerPrefs.SetInt("FLY", InformationHolder.AccountData.Upgrade_Fly);
        PlayerPrefs.SetInt("DEATH", InformationHolder.AccountData.Upgrade_Death);
        PlayerPrefs.SetInt("timer_upgrade", InformationHolder.AccountData.Upgrade_Time);
    }

    void Update()
    {
        loadInfo();
    }
}
