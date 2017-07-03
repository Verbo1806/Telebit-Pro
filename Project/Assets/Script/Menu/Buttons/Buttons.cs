using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

	// Use this for initialization
	public void Level () {

		Application.LoadLevel (3);
	}
	
	// Update is called once per frame
	public void Upgrade () {

		Application.LoadLevel (2);
	}
}
