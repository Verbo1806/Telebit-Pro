using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles_maker : MonoBehaviour {

	public bool type; // 0 for normal; 1 for dig;

	public GameObject spike_01;
	public GameObject spike_02;
	public GameObject spike_dig;


	// Use this for initialization
	void Start () {

		int instantiate = Random.Range (0, 2);

		if (instantiate == 1) {

			if (type) {

				Instantiate (spike_dig, gameObject.transform.position, Quaternion.identity);
			}
			else {

				int type = Random.Range (0, 2);

				if (type == 0)
					Instantiate (spike_01, gameObject.transform.position, Quaternion.identity);
				else 
					Instantiate (spike_02, gameObject.transform.position, Quaternion.identity);

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
