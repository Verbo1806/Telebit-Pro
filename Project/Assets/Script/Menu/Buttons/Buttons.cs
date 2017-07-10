using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	// Use this for initialization
	public void Level () {
        SceneManager.LoadScene(3);
    }
	
	// Update is called once per frame
	public void Upgrade () {
        SceneManager.LoadScene(2);
	}
}
