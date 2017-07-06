using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	
	public void Change_Scene() {
	
		Application.LoadLevel(1);
	}

	public void Repeat() {

		Application.LoadLevel(3);
	}
}
