using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Accounts : MonoBehaviour {


    IEnumerator ChangeUser()
    {
        Debug.Log(1);
        InformationHolder acc = new InformationHolder();
        StartCoroutine(acc.Account("", ""));
        yield return new WaitUntil(() => InformationHolder.isReady);
        SceneManager.LoadScene(4);
        Debug.Log(2);
    }

	public void onClick()
    {

        Debug.Log("Clicked");
        StartCoroutine(ChangeUser());
    }
}
