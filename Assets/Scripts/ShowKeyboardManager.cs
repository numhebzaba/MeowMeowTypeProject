using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowKeyboardManager : MonoBehaviour
{
    public Camera MainCamera;
    public bool IsShowKeyboard = false;
    public Camera KeyboardCamera;
    [SerializeField] public List<SwitchKeyboardClass> SwitchesList = new List<SwitchKeyboardClass>();
    public Material[] materials;

    public void ShowAverageAccuracyButton()
    {
        IsShowKeyboard = !IsShowKeyboard;
        MainCamera.enabled = !IsShowKeyboard;
        foreach(var Switches in SwitchesList)
        {
            if(Switches.AverageAccuracy <=100 && Switches.AverageAccuracy > 75)
            {
                Switches.Switch.GetComponent<Renderer>().material = materials[0];
            }else if (Switches.AverageAccuracy <= 75 && Switches.AverageAccuracy > 50)
            {
                Switches.Switch.GetComponent<Renderer>().material = materials[1];
            }
            else if (Switches.AverageAccuracy <= 50 && Switches.AverageAccuracy > 25)
            {
                Switches.Switch.GetComponent<Renderer>().material = materials[2];
            }
            else if (Switches.AverageAccuracy <= 25 && Switches.AverageAccuracy > 0)
            {
                Switches.Switch.GetComponent<Renderer>().material = materials[3];
            }
            else 
            {
                Switches.Switch.GetComponent<Renderer>().material = materials[4];
            }
        }
    }
    
}



