using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{

	public int coins;
	public GameObject button;

	void Update() {

        coins = InformationHolder.AccountData.Coins;
    }

	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}

    IEnumerator Modify()
    {
        StartCoroutine(new InformationModify().SendInfo("Coins", coins));
        yield return new WaitUntil(() => InformationModify.sentinfo);
        StartCoroutine(new InformationHolder().Account(InformationHolder.AccountData.Username, PlayerPrefs.GetString("PASSWORD", null)));
        yield return new WaitUntil(() => InformationHolder.isReady);

        Debug.Log("The ad was successfully shown.");

        Destroy(button);
    }

	private void HandleShowResult(ShowResult result)
	{
		switch (result)
		{
		case ShowResult.Finished:
			Debug.Log ("The ad was successfully shown.");
			coins += 10;
			if (coins > 999)
				coins = 999;
            StartCoroutine(Modify());

			break;
		case ShowResult.Skipped:
			Debug.Log("The ad was skipped before reaching the end.");
			break;
		case ShowResult.Failed:
			Debug.LogError("The ad failed to be shown.");
			break;
		}
	}
}