using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseButton : MonoBehaviour {
	public GameObject Corpse;
	public GameObject Player;
	protected Vector3 myposition;
	public Transform warpTarget_default;
	public static Transform warpTarget_current;

	public Transform warpTarget_firstkill;
	int first_kill;


	public bool kill_lock = false;

	void Start() {

		warpTarget_current = warpTarget_default;
		first_kill = PlayerPrefs.GetInt("DEATH", 0);
	}

	public void killMe()
	{

		if (!kill_lock) {

			myposition = Player.transform.position;
			Instantiate (Corpse, myposition, Quaternion.identity);

			if (first_kill == 0) {

				Player.transform.position = warpTarget_current.position;
			} else if (first_kill == 1){

				Player.transform.position = warpTarget_firstkill.position;
				first_kill = 0;
				PlayerPrefs.SetInt ("DEATH", 0);
				PlayerPrefs.Save ();
			}

			kill_lock = true;

			StartCoroutine (Wait ());
		}
	}

	IEnumerator Wait () {

		yield return new WaitForSeconds(2);
		kill_lock = false;
	}
}