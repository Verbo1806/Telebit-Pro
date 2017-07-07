using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckUser : MonoBehaviour {
    private void Update()
    {
        if (InformationHolder.isConnected)
        {
            try
            {
                try
                {
                    if (InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Username:") == PlayerPrefs.GetString("USERNAME", null))
                    {
                        if (InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Password:") == PlayerPrefs.GetString("PASSWORD", null))
                        {
                            SceneManager.LoadScene(1);
                        }
                    }
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Debug.Log(e);
                }
            }
            catch (NullReferenceException e)
            {
                Debug.Log(e);
            }

        }
        else SceneManager.LoadScene(1);
    }    
}
       
