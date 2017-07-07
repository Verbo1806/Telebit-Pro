using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserLogin : MonoBehaviour {

    public void onClick()
    {
        for (int counter = 0; counter < InformationHolder.tokens.Count; counter++)
        {
            try
            {
                if (GetUsername.Username == InformationHolder.GetDataValue(InformationHolder.tokens[counter], "Username:"))
                {
                    if (GetPassword.Pass == InformationHolder.GetDataValue(InformationHolder.tokens[counter], "Password:"))
                    {
                        PlayerPrefs.SetInt("ID", counter + 1);
                        PlayerPrefs.SetString("USERNAME", InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Username:"));
                        PlayerPrefs.SetString("PASSWORD", InformationHolder.GetDataValue(InformationHolder.tokens[PlayerPrefs.GetInt("ID") - 1], "Password:"));
                        SceneManager.LoadScene(1);
                    }
                    break;
                }
            }
            catch(ArgumentOutOfRangeException e)
            {
                Debug.Log("Non Existant User");
            }
            
        }
    }
    
}
