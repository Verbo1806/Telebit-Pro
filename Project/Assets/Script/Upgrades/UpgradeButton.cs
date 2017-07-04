using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour {
    public GameObject button;
    public void ButtonPressed()
    {
        switch(button.tag) {
            case "Speed":
                PlayerPrefs.SetInt("SPEED", 1);
                break;
            case "DoubleJump":
                PlayerPrefs.SetInt("DOUBLEJUMP", 1);
                break;
            case "Fly":
                PlayerPrefs.SetInt("FLY", 1);
                break;
            case "Death":
                PlayerPrefs.SetInt("DEATH", 1);
                break;
        }
    }
}
