using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorpseButton : MonoBehaviour {

	Rigidbody2D Player_rb;

	public GameObject Corpse;
	public GameObject Player;
	protected Vector3 myposition;
	public Transform warpTarget_default;
	public static Transform warpTarget_current;

	public Transform warpTarget_firstkill;
	int first_kill;


	public bool kill_lock = false;
	public static bool kill_button_pressed = false;

	void Start() {

		Player_rb = Player.GetComponent<Rigidbody2D>();
		warpTarget_current = warpTarget_default;
		first_kill = PlayerPrefs.GetInt("DEATH", 0);
	}

	public void killMe()
	{
		kill_button_pressed = true;
		Player_rb.AddForce(new Vector2(0, Character_Movement.jumpHeight - 350), ForceMode2D.Impulse);

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

		kill_button_pressed = false;
		yield return new WaitForSeconds(1);
		kill_lock = false;
	}
}