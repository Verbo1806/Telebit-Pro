﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Timer : MonoBehaviour {

	public Text failed;
	public int wait_seconds = 2;
	int game_num;

	float timeLeft;
	double time;
	public Text timer;

	// Use this for initialization
	void Start () {
	
		timeLeft = Level_maker.level_time;
		failed.enabled = false;
		game_num = PlayerPrefs.GetInt("game_num");
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		timeLeft -= Time.deltaTime;
		time = System.Math.Round(timeLeft,2);
		timer.text = time.ToString();

		if ( timeLeft < 0) {

			failed.enabled = true;
			timer.text = "---";
			StartCoroutine(Change_Scene());
		}

		if (Flag.stop_timer == 1) {

			timer.text = "---";
		}
	}

	IEnumerator Change_Scene () {
		
		yield return new WaitForSeconds(wait_seconds);
		game_num++;
		PlayerPrefs.SetInt("game_num", game_num);
		PlayerPrefs.Save();
		SceneManager.LoadScene(1);
	}
}
