using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds_Spawner : MonoBehaviour {

	public GameObject cloud_01;
	public GameObject cloud_02;
	public GameObject cloud_03;
	public GameObject cloud_04;
	public GameObject cloud_05;

	GameObject new_obj;

	float position;

	// Use this for initialization
	void Start () {
		
		InvokeRepeating ("Spawn", 1, 5);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Spawn() {

		int type = Random.Range (0, 5);
		position = Random.Range (0f, 4f);
		float speed;

		if (position < 1)
			speed = -0.05f;
		else if (position < 2)
			speed = -0.045f;
		else if (position < 3)
			speed = -0.04f;
		else
			speed = -0.035f;

		switch (type) {

			case 0:

			new_obj = Instantiate (cloud_01, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - position, gameObject.transform.position.z), Quaternion.identity);
			new_obj.GetComponent<Cloud> ().speed = speed;
				break;

			case 1:

			new_obj = Instantiate (cloud_02, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - position, gameObject.transform.position.z), Quaternion.identity);
			new_obj.GetComponent<Cloud> ().speed = speed;
				break;

			case 2:

			new_obj = Instantiate (cloud_03, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - position, gameObject.transform.position.z), Quaternion.identity);
			new_obj.GetComponent<Cloud> ().speed = speed;
			break;

			case 3:

	
			new_obj = Instantiate (cloud_04, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - position, gameObject.transform.position.z), Quaternion.identity);
			new_obj.GetComponent<Cloud> ().speed = speed;
				break;

			case 4:

			new_obj = Instantiate (cloud_05, new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y - position, gameObject.transform.position.z), Quaternion.identity);
			new_obj.GetComponent<Cloud> ().speed = speed;
				break;
			}
	}

}
