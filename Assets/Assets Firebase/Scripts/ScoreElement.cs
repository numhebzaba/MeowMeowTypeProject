using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreElement : MonoBehaviour
{

    public TMP_Text usernameText;
    public TMP_Text WpmText;
    public TMP_Text TimeText;
    public TMP_Text DateText;

    public void NewScoreElement (string _username, int _Wpm, string _Time, string _Date)
    {
        usernameText.text = _username;
        WpmText.text = _Wpm.ToString();
        TimeText.text = _Time.ToString();
        DateText.text = _Date.ToString();
    }

}
