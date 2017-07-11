using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckUser : MonoBehaviour {
    
    IEnumerator Wait()
    {
            StartCoroutine(new InformationHolder().Account(PlayerPrefs.GetString("USERNAME", null), PlayerPrefs.GetString("PASSWORD", null)));
            yield return new WaitUntil(() => InformationHolder.isReady);
            if (InformationHolder.AccountData.Username != null && InformationHolder.AccountData.Password != null)
            SceneManager.LoadScene(1);
    }

    private void Start()
    {
        StartCoroutine(Wait());
    }    
}
       
