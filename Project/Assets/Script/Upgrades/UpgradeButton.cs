using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour {
    public GameObject button;

    IEnumerator ReloadInfo()
    {
        StartCoroutine(new InformationHolder().Account(InformationHolder.AccountData.Username, InformationHolder.AccountData.Password));
        yield return new WaitUntil(() => InformationHolder.isReady);
    }

    void active()
    {
        switch (button.tag)
        {
            case "Speed":
                if (InformationHolder.AccountData.Upgrade_Speed == 1)
                    button.SetActive(false);
                break;
            case "DoubleJump":
                if (InformationHolder.AccountData.Upgrade_DoubleJump == 1)
                    button.SetActive(false);
                break;
            case "Fly":
                if (InformationHolder.AccountData.Upgrade_Fly == 1)
                    button.SetActive(false);
                break;
            case "Death":
                if (InformationHolder.AccountData.Upgrade_Death == 1)
                    button.SetActive(false);
                break;
        }
    }

    void Update() {
        active();
	}


    IEnumerator Speed()
    {
        if (InformationHolder.AccountData.Coins >= 5)
        {
            StartCoroutine(new InformationModify().SendInfo("Coins", InformationHolder.AccountData.Coins - 5));
            yield return new WaitUntil(() => InformationModify.sentinfo);
            StartCoroutine(new InformationModify().SendInfo("Upgrade_Speed", 1));
            yield return new WaitUntil(() => InformationModify.sentinfo);
        }
    }
    IEnumerator Fly()
    {
        if (InformationHolder.AccountData.Coins >= 5)
        {
            StartCoroutine(new InformationModify().SendInfo("Coins", InformationHolder.AccountData.Coins - 5));
            yield return new WaitUntil(() => InformationModify.sentinfo);
            StartCoroutine(new InformationModify().SendInfo("Upgrade_Fly", 1));
            yield return new WaitUntil(() => InformationModify.sentinfo);
        }
    }
    IEnumerator DoubleJump()
    {
        if (InformationHolder.AccountData.Coins >= 5)
        {
            StartCoroutine(new InformationModify().SendInfo("Coins", InformationHolder.AccountData.Coins - 5));
            yield return new WaitUntil(() => InformationModify.sentinfo);
            StartCoroutine(new InformationModify().SendInfo("Upgrade_DoubleJump", 1));
            yield return new WaitUntil(() => InformationModify.sentinfo);
        }
    }
    IEnumerator Death()
    {
        if (InformationHolder.AccountData.Coins >= 5)
        {
            StartCoroutine(new InformationModify().SendInfo("Coins", InformationHolder.AccountData.Coins - 5));
            yield return new WaitUntil(() => InformationModify.sentinfo);
            StartCoroutine(new InformationModify(). SendInfo("Upgrade_Death", 1));
            yield return new WaitUntil(() => InformationModify.sentinfo);
        }
    }
    public void ButtonPressed()
    {
        switch(button.tag) {
            case "Speed":
                StartCoroutine(Speed());
                break;
            case "DoubleJump":
                StartCoroutine(DoubleJump());
                break;
            case "Fly":
                StartCoroutine(Fly());
                break;
            case "Death":
                StartCoroutine(Death());
                break;
        }
        ReloadInfo();
    }

}
