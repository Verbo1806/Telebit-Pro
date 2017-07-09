using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Accounts : MonoBehaviour {

	public void onClick()
    {
        PlayerPrefs.SetInt("ID", -1);
        PlayerPrefs.SetString("USERNAME", null);
        PlayerPrefs.SetString("PASSWORD", null);
        SceneManager.LoadScene(4);
    }
}
