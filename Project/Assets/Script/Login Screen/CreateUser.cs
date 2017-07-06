using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateUser : MonoBehaviour {

	public void onclick()
    {
        if (GetEmail.Email != null && GetUsername.Username != null && GetPassword.Pass != null)
        {   
            
            InformationInserter.CreateUser(GetEmail.Email, GetUsername.Username, GetPassword.Pass);

            PlayerPrefs.SetInt("ID", InformationHolder.tokens.Count);
            
            PlayerPrefs.SetString("USERNAME", GetUsername.Username);
            PlayerPrefs.SetString("PASSWORD", GetPassword.Pass);
            SceneManager.LoadScene(1);
        }
    }
}
