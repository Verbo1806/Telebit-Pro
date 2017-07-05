using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour {
    public GameObject button;
	int coins;


	void Update() {

		coins = PlayerPrefs.GetInt ("coin", 0);

		switch(button.tag) {
		case "Speed":
			if (PlayerPrefs.GetInt ("SPEED", 0) == 1)
				button.SetActive (false);
			break;
		case "DoubleJump":
			if (PlayerPrefs.GetInt ("DOUBLEJUMP", 0) == 1)
				button.SetActive (false);
			break;
		case "Fly":
			if (PlayerPrefs.GetInt ("FLY", 0) == 1)
				button.SetActive (false);
			break;
		case "Death":
			if (PlayerPrefs.GetInt ("DEATH", 0) == 1)
				button.SetActive (false);
			break;
		}
	}

    public void ButtonPressed()
    {
        switch(button.tag) {
            case "Speed":
			if (coins >= 5)
			coins -= 5;
			
                PlayerPrefs.SetInt("SPEED", 1);
                break;
            case "DoubleJump":
			if (coins >= 5)
				coins -= 5;
			
                PlayerPrefs.SetInt("DOUBLEJUMP", 1);
                break;
            case "Fly":
			if (coins >= 5)
				coins -= 5;
			
                PlayerPrefs.SetInt("FLY", 1);
                break;
		case "Death":
			if (coins >= 5)
				coins -= 5;
			
            	PlayerPrefs.SetInt("DEATH", 1);
            	break;
        }

		PlayerPrefs.SetInt ("coin", coins);
		PlayerPrefs.Save ();
    }
}
