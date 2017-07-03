using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {

	public float speed = 0.5f;
	//Vector3 constPos;

	// Use this for initialization
	void Start () {
	
		//constPos.y = gameObject.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {

		/*Vector3 localPos = transform.position;
		localPos.y = constPos.y;
		transform.position = localPos;
*/

		Vector2 offset = new Vector2 ( Time.time * speed, 0);

		GetComponent<Renderer> ().material.mainTextureOffset = offset;
	
	}
}
