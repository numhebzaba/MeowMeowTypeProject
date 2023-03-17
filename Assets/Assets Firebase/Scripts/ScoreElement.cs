using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreElement : MonoBehaviour
{

    public TMP_Text usernameText;
    public TMP_Text WpmText;
    public TMP_Text TimeText;
    public TMP_Text xpText;

    public void NewScoreElement (string _username, int _Wpm, int _Time, int _xp)
    {
        usernameText.text = _username;
        WpmText.text = _Wpm.ToString();
        TimeText.text = _Time.ToString();
        xpText.text = _xp.ToString();
    }

}
