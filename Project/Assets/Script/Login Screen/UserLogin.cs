using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UserLogin : MonoBehaviour {

    IEnumerator Login()
    {
        InformationHolder acc = new InformationHolder();
        StartCoroutine(acc.Account(GetUsername.Username, GetPassword.Pass));
        yield return new WaitUntil(() => InformationHolder.isReady);
        if (InformationHolder.AccountData.Username != null && InformationHolder.AccountData.Password != null)
            SceneManager.LoadScene(1);
    }

    public void onClick()
    {
        StartCoroutine(Login());
    }    
}
