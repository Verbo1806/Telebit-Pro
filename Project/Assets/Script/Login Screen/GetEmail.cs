using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetEmail : MonoBehaviour {
    public static string Email = null;
	public static bool email_error = false;

    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;
        
    }

    private void SubmitName(string arg0)
    {

		if (arg0.Contains ("@")) {
			Email = arg0;
			email_error = false;
		}
		else {
			Email = null;
			email_error = true;
		}
    }
}
