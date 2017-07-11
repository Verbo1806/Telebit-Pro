using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUI : MonoBehaviour {
    public GameObject Login_Username;
    public GameObject Login_Password;
    public GameObject Login_Button;
    public GameObject Register_Email;
    public GameObject Register_Username;
    public GameObject Register_Password;
    public GameObject Register_Button;
    public GameObject Login_Swap;
    public GameObject Register_Swap;
	public GameObject Pop_Up;

	public void Start() {

		Pop_Up.SetActive (false);
	}


    public void onClick()
    {
        if (Login_Swap.activeSelf)
        {
            Login_Username.SetActive(false);
            Login_Password.SetActive(false);
            Login_Button.SetActive(false);
            Login_Swap.SetActive(false);
            Register_Email.SetActive(true);
            Register_Username.SetActive(true);
            Register_Password.SetActive(true);
            Register_Button.SetActive(true);
            Register_Swap.SetActive(true);
        }
        else
        {
            Login_Username.SetActive(true);
            Login_Password.SetActive(true);
            Login_Button.SetActive(true);
            Login_Swap.SetActive(true);
            Register_Email.SetActive(false);
            Register_Username.SetActive(false);
            Register_Password.SetActive(false);
            Register_Button.SetActive(false);
            Register_Swap.SetActive(false);
        }
    }
}
