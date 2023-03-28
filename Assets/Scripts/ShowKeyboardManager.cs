using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShowKeyboardManager : MonoBehaviour
{
    [SerializeField] public List<SwitchKeyboardClass> SwitchesList = new List<SwitchKeyboardClass>();
    public Material[] materials;
    private void Start()
    {
        AddEngLetterlist();
    }
    public void ShowAverageAccuracyButton()
    {
        foreach(var Switches in SwitchesList)
        {
            if(Switches.AverageAccuracy <=100 && Switches.AverageAccuracy > 75)
            {
                Switches.materialSwitch.GetComponent<Renderer>().material = materials[0];
            }else if (Switches.AverageAccuracy <= 75 && Switches.AverageAccuracy > 50)
            {
                Switches.materialSwitch.GetComponent<Renderer>().material = materials[1];
            }
            else if (Switches.AverageAccuracy <= 50 && Switches.AverageAccuracy > 25)
            {
                Switches.materialSwitch.GetComponent<Renderer>().material = materials[2];
            }
            else if (Switches.AverageAccuracy <= 25 && Switches.AverageAccuracy > 0)
            {
                Switches.materialSwitch.GetComponent<Renderer>().material = materials[3];
            }
            else 
            {
                Switches.materialSwitch.GetComponent<Renderer>().material = materials[5];
            }
        }
    }
    private void AddEngLetterlist()
    {
        SwitchesList.Add(new SwitchKeyboardClass("a"));
        SwitchesList.Add(new SwitchKeyboardClass("b"));
        SwitchesList.Add(new SwitchKeyboardClass("c"));
        SwitchesList.Add(new SwitchKeyboardClass("d"));
        SwitchesList.Add(new SwitchKeyboardClass("e"));
        SwitchesList.Add(new SwitchKeyboardClass("f"));
        SwitchesList.Add(new SwitchKeyboardClass("g"));
        SwitchesList.Add(new SwitchKeyboardClass("h"));
        SwitchesList.Add(new SwitchKeyboardClass("i"));
        SwitchesList.Add(new SwitchKeyboardClass("j"));
        SwitchesList.Add(new SwitchKeyboardClass("k"));
        SwitchesList.Add(new SwitchKeyboardClass("l"));
        SwitchesList.Add(new SwitchKeyboardClass("m"));
        SwitchesList.Add(new SwitchKeyboardClass("n"));
        SwitchesList.Add(new SwitchKeyboardClass("o"));
        SwitchesList.Add(new SwitchKeyboardClass("p"));
        SwitchesList.Add(new SwitchKeyboardClass("q"));
        SwitchesList.Add(new SwitchKeyboardClass("r"));
        SwitchesList.Add(new SwitchKeyboardClass("s"));
        SwitchesList.Add(new SwitchKeyboardClass("t"));
        SwitchesList.Add(new SwitchKeyboardClass("u"));
        SwitchesList.Add(new SwitchKeyboardClass("v"));
        SwitchesList.Add(new SwitchKeyboardClass("w"));
        SwitchesList.Add(new SwitchKeyboardClass("x"));
        SwitchesList.Add(new SwitchKeyboardClass("y"));
        SwitchesList.Add(new SwitchKeyboardClass("z"));
    }
}



