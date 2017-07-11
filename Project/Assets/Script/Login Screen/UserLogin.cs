using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserLogin : MonoBehaviour {

	public GameObject pop_up;

    IEnumerator Login()
    {
        InformationHolder acc = new InformationHolder();
        StartCoroutine(acc.Account(GetUsername.Username, GetPassword.Pass));
        yield return new WaitUntil(() => InformationHolder.isReady);

		try {
			if (InformationHolder.AccountData.Username != null && InformationHolder.AccountData.Password != null) {
                PlayerPrefs.SetString("PASSWORD", GetPassword.Pass);

                SceneManager.LoadScene (1);
			}
		}
		catch(NullReferenceException) {

			pop_up.SetActive (true);
			pop_up.GetComponentInChildren<Text>().text = "Incorrect Username or Password!";
		}
    }

    public void onClick()
    {
        StartCoroutine(Login());
    }    
}
