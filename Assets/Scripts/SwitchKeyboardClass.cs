using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class SwitchKeyboardClass
{
    [SerializeField] public string nameSwitch;
    [SerializeField] public GameObject Switch;

    [SerializeField] public float AverageAccuracy;
    [SerializeField] public float AverageSpeed;


    public SwitchKeyboardClass(string nameSwitchValue)
    {
        this.nameSwitch = nameSwitchValue;
    }
}
