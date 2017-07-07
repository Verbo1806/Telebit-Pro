using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrades : MonoBehaviour
{
    public static int coins;
    public static int speed;
    public static int doubleJump;
    public static int fly;
    public static int death;

    IEnumerator Wait()
    {
        yield return InformationHolder.AccountData;
    }

    void Information()
    {
        try
        {
            try
            {
                Wait();
                coins = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Coins:"));
                speed = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Upgrade_Speed:"));
                doubleJump = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Upgrade_DoubleJump:"));
                fly = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Upgrade_Fly:"));
                death = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Upgrade_Death:"));
            }
            catch (NullReferenceException e)
            {
                Debug.Log(e);
            }
        }
        catch (ArgumentOutOfRangeException e)
        {
            Debug.Log(e);
        }

    }

    void loadInfo()
    {

        PlayerPrefs.GetInt("coin", coins);
        PlayerPrefs.GetInt("SPEED", speed);
        PlayerPrefs.GetInt("DOUBLEJUMP", doubleJump);
        PlayerPrefs.GetInt("FLY", fly);
        PlayerPrefs.GetInt("DEATH", death);
    }

    void Update()
    {
        loadInfo();
        Information();
    }
}
