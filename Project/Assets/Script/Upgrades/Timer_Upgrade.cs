using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer_Upgrade : MonoBehaviour {


	public int have_timer;
	int coins;
	public Sprite full_bar;
	public Sprite five_bar;
	public Sprite ten_bar;
	public Sprite fifteen_bar;
	public Sprite empty_bar;

	public Text percent;

	void Start () {

        have_timer = InformationHolder.AccountData.Upgrade_Time;
		coins = InformationHolder.AccountData.Coins;
	}

	void Update () {

		if (have_timer == 0) {
			gameObject.GetComponent<Image> ().sprite = empty_bar;
			percent.text = "0%";
		} else if (have_timer == 1) {
			gameObject.GetComponent<Image> ().sprite = five_bar;
			percent.text = "5%";
		} else if (have_timer == 2) {
			gameObject.GetComponent<Image> ().sprite = ten_bar;
			percent.text = "10%";
		} else if (have_timer == 3) {
			gameObject.GetComponent<Image> ().sprite = fifteen_bar;
			percent.text = "15%";
		} else {
			gameObject.GetComponent<Image> ().sprite = full_bar;
			percent.text = "20%";
		}
	}

    IEnumerator UpgradeTime()
    {
        if (coins >= 10 && have_timer < 4)
        {
            Debug.Log("In");
            have_timer++;
            StartCoroutine(new InformationModify().SendInfo("Upgrade_Time", have_timer));
            yield return new WaitUntil(() => InformationModify.sentinfo);
            coins -= 1;
            StartCoroutine(new InformationModify().SendInfo("Coins", coins));
            yield return new WaitUntil(() => InformationModify.sentinfo);
            StartCoroutine(new InformationHolder().Account(InformationHolder.AccountData.Username, PlayerPrefs.GetString("PASSWORD", null)));
            yield return new WaitUntil(() => InformationHolder.isReady);
            Debug.Log("out");
        }
    }

	public void Timer () {
        StartCoroutine(UpgradeTime());
	}
}
