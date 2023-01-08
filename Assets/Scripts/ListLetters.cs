using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListLetters
{
    private string name;
    private float TimeAverage;
    private float NewTime;
    private int Correct;
    private int Incorrect;
    private float accuracy;
    private float Count;

    public ListLetters(string name, float TimeAverage, float NewTime, float Count)
    {
        this.name = name;
        this.TimeAverage = TimeAverage;
        this.NewTime = NewTime;
        this.Correct = 0;
        this.Incorrect = 0;
        this.Count = Count;
    }

    public string GetAllData
    {
        get { return this.name + " Correct: " + this.Correct + " Incorrect: " + this.Incorrect + " Accuracy: " + (this.Correct/ this.Count)*100 + "%"; }
    }

    public string getName
    {
        get { return name; }
    }

    public float getCount
    {
        get { return Count; }
    }

    public int GetWrongData
    {
        get { return Incorrect; }
    }

    public float GetAccuracy
    {
        get { return accuracy; }
    }

    public void UpdateWrongLetterData()
    {
        this.Incorrect += 1;
        this.Count += 1;

    }

    public void UpdateData()
    {
        this.Correct += 1;
        this.Count += 1;
    }
    

}
