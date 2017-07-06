using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUser : MonoBehaviour {

	public void onclick()
    {
        if (GetEmail.Email != null && GetUsername.Username != null && GetPassword.Pass != null)
        {
            InformationInserter.CreateUser(GetEmail.Email, GetUsername.Username, GetPassword.Pass);
            Application.LoadLevel(1);
        }
    }
}
