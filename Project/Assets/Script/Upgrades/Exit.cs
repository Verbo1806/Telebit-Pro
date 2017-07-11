using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {
	
	public void Change_Scene() {
	
		SceneManager.LoadScene(1);
	}

	public void Repeat() {

		SceneManager.LoadScene(3);
	}
}
