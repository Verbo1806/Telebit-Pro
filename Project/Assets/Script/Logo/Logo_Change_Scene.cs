using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Logo_Change_Scene : MonoBehaviour {

	public int seconds = 3;
	// Use this for initialization
	void Start () {

		StartCoroutine(Change_Scene());
	}

	IEnumerator Change_Scene () {

		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene(4);
	}
}
