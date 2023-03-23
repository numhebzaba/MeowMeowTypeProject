using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserData : MonoBehaviour
{
    public string UserName;
    public string UserEmail;
    public string UserPassword;

    public TMP_Text UserName_text;

    private void Awake()
    {


        UserName = PlayerPrefs.GetString("UserName");
        UserEmail = PlayerPrefs.GetString("UserEmail");
        UserEmail = PlayerPrefs.GetString("UserPassword");


    }

    private void Start()
    {
        UserName_text.text = $"PlayerName : {UserName.ToString()}";

    }

}
