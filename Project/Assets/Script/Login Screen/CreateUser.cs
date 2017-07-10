using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateUser : MonoBehaviour {
    InformationInserter create;

    private void Start()
    {
        create = gameObject.AddComponent<InformationInserter>() as InformationInserter;
    }
    
    IEnumerator Wait()
    {
        Debug.Log("Waiting for www to download...");
        yield return new WaitUntil(() => InformationInserter.isready);
        Debug.Log("Download compleate! :)");

        StartCoroutine(new InformationHolder().Account(GetUsername.Username, GetPassword.Pass));
        yield return new WaitUntil(() => InformationHolder.isReady);

        SceneManager.LoadSceneAsync(1);
    }
        
    public void onclick()
    {   
        if (GetEmail.Email != null && GetUsername.Username != null && GetPassword.Pass != null)
        {
            StartCoroutine(create.CreateUser(GetEmail.Email, GetUsername.Username, GetPassword.Pass));
            StartCoroutine(Wait());
        }
    }
}
