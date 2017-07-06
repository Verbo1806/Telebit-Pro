using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornsInstaKill : MonoBehaviour {
	
	public GameObject Corpse;
	public GameObject Player;
	protected Vector3 myposition;

	bool collide;

	void Start () {

		collide = false;
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnCollisionEnter2D(Collision2D col)
	{

		if (!collide) {

			collide = true;
			myposition = Player.transform.position;
			Instantiate (Corpse, myposition, Quaternion.identity);
			Player.transform.position = CorpseButton.warpTarget_current.position;
			StartCoroutine(Example());
		}
	}

	IEnumerator Example() {

		yield return new WaitForSeconds(2);
		collide = false;
	}

}