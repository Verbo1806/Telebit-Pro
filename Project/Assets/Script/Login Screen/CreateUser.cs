using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateUser : MonoBehaviour {
    InformationInserter create;
	public GameObject pop_up;


    private void Start()
    {

        create = gameObject.AddComponent<InformationInserter>() as InformationInserter;
    }
    
    IEnumerator Wait()
    {
        Debug.Log("Waiting for www to download...");
        yield return new WaitUntil(() => InformationInserter.isready);

		if (InformationInserter.reg_error.Contains ("Username")) {		

			pop_up.SetActive (true);
			pop_up.GetComponentInChildren<Text>().text = "This Username already exists!";
		}
		else if(InformationInserter.reg_error.Contains("Email")) {

			pop_up.SetActive (true);
			pop_up.GetComponentInChildren<Text>().text = "This Email already exists!";
		}
		else {
			Debug.Log("Download complete! :)");

        StartCoroutine(new InformationHolder().Account(GetUsername.Username, GetPassword.Pass));
        yield return new WaitUntil(() => InformationHolder.isReady);

        SceneManager.LoadSceneAsync(1);
		}
    }
        
    public void onclick()
    {   
		if (GetEmail.Email != null && GetUsername.Username != null && GetPassword.Pass != null) {
			StartCoroutine (create.CreateUser (GetEmail.Email, GetUsername.Username, GetPassword.Pass));
			StartCoroutine (Wait ());
		} else if (GetEmail.email_error == true) {
			
			pop_up.SetActive (true);
			pop_up.GetComponentInChildren<Text>().text = "Incorrect Email!";
		}
    }

	public void pop_up_click() 
	{

		pop_up.SetActive (false);
	}
}
