using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameManager : MonoBehaviour
{
    public GameObject[] UIArray;
    public int UI_Index;

    public void ClearScreen() //Turn off all screens
    {
        foreach(var UI in UIArray)
        {
            UI.SetActive(false);
        }
    }
    public void showUI(int UI_Index)
    {
        UIArray[UI_Index].SetActive(true);
    }
}
