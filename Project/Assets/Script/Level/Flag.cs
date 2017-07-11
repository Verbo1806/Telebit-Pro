using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour {

	public Text succeed;
	int coins;
	public int wait_seconds;
	public Text timer;
	int game_num;

	static public int stop_timer;


	// Use this for initialization
	void Start () {
	
		stop_timer = 0;
		succeed.enabled = false;
		coins = PlayerPrefs.GetInt("coin");
		game_num = PlayerPrefs.GetInt("game_num");
	}

	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.tag == "Finish") {

			stop_timer = 1;
			succeed.enabled = true;	
			game_num++;
			PlayerPrefs.SetInt("game_num", game_num);
			coins += 10;
			if (coins > 999)
				coins = 999;
            
			StartCoroutine(Change_Scene());
		}
	}

	IEnumerator Change_Scene () {
        StartCoroutine(new InformationModify().SendInfo("Coins", coins));
        yield return new WaitUntil(() => InformationModify.sentinfo);
        StartCoroutine(new InformationHolder().Account(InformationHolder.AccountData.Username, PlayerPrefs.GetString("PASSWORD", null)));
        yield return new WaitUntil(() => InformationHolder.isReady);
		SceneManager.LoadScene(1);
	}
}
