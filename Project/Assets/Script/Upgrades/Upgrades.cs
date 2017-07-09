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
    public static int time;

    static IEnumerator Wait()
    {
        yield return InformationHolder.AccountData;
    }

    public static void Information()
    {
        try
        {
            try
            {
                InformationHolder.getAccounts();
                time = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Upgrade_Time:"));
                coins = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Coins:"));
                speed = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Upgrade_Speed:"));
                doubleJump = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Upgrade_DoubleJump:"));
                fly = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Upgrade_Fly:"));
                death = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Upgrade_Death:"));
                Debug.Log("Time : " + time);
                Debug.Log("Coins : " + coins);
                Debug.Log("Speed : " + speed);
                Debug.Log("DoubleJump : " + doubleJump);
                Debug.Log("Fly : " + fly);
                Debug.Log("Death : " + death);
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

    public static void loadInfo()
    {

        PlayerPrefs.SetInt("coin", coins);
        PlayerPrefs.SetInt("SPEED", speed);
        PlayerPrefs.SetInt("DOUBLEJUMP", doubleJump);
        PlayerPrefs.SetInt("FLY", fly);
        PlayerPrefs.SetInt("DEATH", death);
        PlayerPrefs.SetInt("timer_upgrade", time);
    }

    void Start()
    {
        Information();
        loadInfo();
    }
}
