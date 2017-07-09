using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckUser : MonoBehaviour {
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);

        if (InformationHolder.isConnected)
        {

            if (InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Username:") == PlayerPrefs.GetString("USERNAME", null))
            {
                if (InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Password:") == PlayerPrefs.GetString("PASSWORD", null))
                {
                    SceneManager.LoadScene(1);
                }
            }
        }
        else SceneManager.LoadScene(1);
    }

    private void Start()
    {
        StartCoroutine(Wait());
        
    }    
}
       
