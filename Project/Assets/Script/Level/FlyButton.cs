using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyButton : MonoBehaviour {

    public GameObject self;

    private void Start()
    {
        if (PlayerPrefs.GetInt("FLY", 0) == 1)
            self.SetActive(true);
        else self.SetActive(false);
    }

    public void onClick()
    {
        self.SetActive(false);
        Character_Movement.running = false;
        Character_Movement.flying = true;
    }
}
