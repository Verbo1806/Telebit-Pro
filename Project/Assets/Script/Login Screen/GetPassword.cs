using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPassword : MonoBehaviour {
    public static string Pass = null;

    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;

    }

    private void SubmitName(string arg0)
    {

        Pass = arg0;
    }
}
