using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseButton : MonoBehaviour {
	public GameObject Corpse;
	public GameObject Player;
	protected Vector3 myposition;
	public Transform warpTarget_default;
	public static Transform warpTarget_current;


	public bool kill_lock = false;

	void Start() {

		warpTarget_current = warpTarget_default;
	}
	
	public void killMe()
	{

		if (!kill_lock) {
			
			myposition = Player.transform.position;
			Instantiate (Corpse, myposition, Quaternion.identity);
			Player.transform.position = warpTarget_current.position;
			warpTarget_current = warpTarget_default;
			kill_lock = true;

			StartCoroutine (Wait ());
		}
	}

	IEnumerator Wait () {

		yield return new WaitForSeconds(2);
		kill_lock = false;
	}
}