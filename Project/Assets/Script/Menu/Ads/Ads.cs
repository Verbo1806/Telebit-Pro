using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{

	public int coins;
	public GameObject button;

	void Update() {

        coins = Convert.ToInt32(InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Coins:"));
    }

	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
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
            InformationModify.SendInfo("Coins", coins);
			PlayerPrefs.SetInt ("coin", coins);
			PlayerPrefs.Save ();
            
			Destroy(button);

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