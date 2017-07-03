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

	public Image bar;

	void Start () {

		have_timer = PlayerPrefs.GetInt("timer_upgrade");
		coins = PlayerPrefs.GetInt("coin");
	}

	void Update () {

		if (have_timer == 0) {
			bar.GetComponent<Image> ().sprite = empty_bar;
			percent.text = "0%";
		} else if (have_timer == 1) {
			bar.GetComponent<Image> ().sprite = five_bar;
			percent.text = "5%";
		} else if (have_timer == 2) {
			bar.GetComponent<Image> ().sprite = ten_bar;
			percent.text = "10%";
		} else if (have_timer == 3) {
			bar.GetComponent<Image> ().sprite = fifteen_bar;
			percent.text = "15%";
		} else {
			bar.GetComponent<Image> ().sprite = full_bar;
			percent.text = "20%";
		}
	}

	public void Timer () {

		if (coins >= 10 && have_timer < 4) {
			have_timer++;
			PlayerPrefs.SetInt("timer_upgrade", have_timer);
			PlayerPrefs.Save();
			coins -= 1;
			PlayerPrefs.SetInt("coin", coins);
			PlayerPrefs.Save();
		}
	}
}
