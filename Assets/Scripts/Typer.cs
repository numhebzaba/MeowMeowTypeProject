using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class Typer : MonoBehaviour
{
    public WordList wordList = null;
    public TMP_Text wordOutput = null;
    public TMP_Text nextWordOutput = null;
    public TMP_Text wordTotalUI = null;
    public TMP_Text TimeSpent = null;
    public TMP_Text WordPerminuteText = null;

    public TMP_Text A_count = null;
    public TMP_Text A_error = null;

    public GameObject SummaryUI;
    public TMP_Text [] data = null;

    bool IsGameFinish = false;


    public float accuracy = 0;
    public int wordTotal = 0;
    public int allTypedEntries = 0;
    public int unCorrectedError = 0;
    public int wordPerMinute = 0;
    public TimeSpan delayTimeSpan = new TimeSpan(0, 0, 0);
    public int TimeInMinute;

    private string remainWord = string.Empty;
    private string currentWord = string.Empty;
    private string nextWord = string.Empty;
    public List<ListLetters> DataLetterList = new List<ListLetters>();

    public animationStateControllerByType animationStateController;
    public Animator BGanimator;


    LoopBg loopBg_1, loopBg_2, loopBg_3, loopBg_4;
    public GameObject loopBgArray_1, loopBgArray_2, loopBgArray_3, loopBgArray_4;

    private void Awake()
    {
        loopBg_1 = loopBgArray_1.GetComponent<LoopBg>();
        loopBg_2 = loopBgArray_2.GetComponent<LoopBg>();
        loopBg_3 = loopBgArray_3.GetComponent<LoopBg>();
        loopBg_4 = loopBgArray_4.GetComponent<LoopBg>();
    }
    void Start()
    {
        // BGanimator = GetComponent<Animator>();
        BGanimator.speed  = 0;
        SummaryUI.SetActive(false);
        SetCurrentWord();
        AddEngLetterlist();
    }


    private void SetCurrentWord()
    {
        currentWord = wordList.getWord();
        SetRemainWord(currentWord);
        nextWord = wordList.getNextWord();
        SetNextRemainWord(nextWord);
    }
    private void SetRemainWord(string newString)
    {
        remainWord = newString;
        wordOutput.text = remainWord;
    }
    private void SetNextRemainWord(string newString)
    {
        nextWord = newString;
        nextWordOutput.text = nextWord;
    }
    void Update()
    {   
        CheckInput();

        if (!wordList.IsWordLeft() && IsWordComplete())
        {
            SummaryUI.SetActive(true);
            delayTimeSpan = delayTimeSpan;
            if(IsGameFinish == false)
            {
                ShowDataLetter();
                IsGameFinish = true;
            }
        }

        else
            delayTimeSpan += TimeSpan.FromSeconds(Time.deltaTime);

        TimeSpent.text = delayTimeSpan.ToString();
        wordTotalUI.text = "word :" + wordTotal.ToString();
        
        int TimeInIntValue = int.Parse(delayTimeSpan.Minutes.ToString());
        if (TimeInIntValue <= 0)
            TimeInIntValue = 1;
        if ((allTypedEntries / 5) <= unCorrectedError)
            wordPerMinute = 0;
        else
            wordPerMinute = (((allTypedEntries / 5) - unCorrectedError))/TimeInIntValue;
        WordPerminuteText.text = "WPM :"+wordPerMinute.ToString();


    }

    public void ShowDataLetter()
    {
        int i = 0;
        foreach (var item in DataLetterList){
            data[i].text = item.GetAllData.ToString();
            Debug.Log(item.GetAllData);
            i++;
        }
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            string keyPressed = Input.inputString;

            if (keyPressed.Length == 1)
                EnterLetter(keyPressed);
            allTypedEntries++;
        }
    }

    private void CheckLetter(string keyinput)
    {
        foreach (var letter in DataLetterList)
        {
            if(keyinput.ToLower() == letter.getName)
            {
                letter.UpdateData();
            }
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            loopBg_1.IsMove = true;
            loopBg_2.IsMove = true;
            loopBg_3.IsMove = true;
            loopBg_4.IsMove = true;

            CheckLetter(typedLetter);
            RemoveLetter();
            BGanimator.speed = 1; //play background animation//
            animationStateController.animator.SetBool(animationStateController.isSittingHash, false);
            animationStateController.animator.SetBool(animationStateController.isWalkingHash, true);

            if (IsWordComplete())
            {
                wordTotal = wordTotal + 1;
                SetCurrentWord();
            }
            return;
        }
        IsFalse(typedLetter);

    }

    public void IsFalse(string keyinput)
    {
        BGanimator.speed = 0; //Pause background animation//
        animationStateController.animator.SetBool(animationStateController.isSittingHash, true);


        foreach (var letter in DataLetterList)
        {
            //string temp = remainWord.ToLower();
            if (remainWord.Substring(0,1) == letter.getName)
            {
                letter.UpdateWrongLetterData();
            }
        }
        loopBg_1.IsMove = false;
        loopBg_2.IsMove = false;
        loopBg_3.IsMove = false;
        loopBg_4.IsMove = false;

        unCorrectedError++;
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainWord.IndexOf(letter)==0;
    }
    private void RemoveLetter()
    {
        string newString = remainWord.Remove(0,1);
        SetRemainWord(newString);
    }
    private bool IsWordComplete()
    {
        return remainWord.Length == 0;
    }

    

    private void AddEngLetterlist()
    {
        DataLetterList.Add(new ListLetters("a", 0, 0, 0));
        DataLetterList.Add(new ListLetters("b", 0, 0, 0));
        DataLetterList.Add(new ListLetters("c", 0, 0, 0));
        DataLetterList.Add(new ListLetters("d", 0, 0, 0));
        DataLetterList.Add(new ListLetters("e", 0, 0, 0));
        DataLetterList.Add(new ListLetters("f", 0, 0, 0));
        DataLetterList.Add(new ListLetters("g", 0, 0, 0));
        DataLetterList.Add(new ListLetters("h", 0, 0, 0));
        DataLetterList.Add(new ListLetters("i", 0, 0, 0));
        DataLetterList.Add(new ListLetters("j", 0, 0, 0));
        DataLetterList.Add(new ListLetters("k", 0, 0, 0));
        DataLetterList.Add(new ListLetters("l", 0, 0, 0));
        DataLetterList.Add(new ListLetters("m", 0, 0, 0));
        DataLetterList.Add(new ListLetters("n", 0, 0, 0));
        DataLetterList.Add(new ListLetters("o", 0, 0, 0));
        DataLetterList.Add(new ListLetters("p", 0, 0, 0));
        DataLetterList.Add(new ListLetters("q", 0, 0, 0));
        DataLetterList.Add(new ListLetters("r", 0, 0, 0));
        DataLetterList.Add(new ListLetters("s", 0, 0, 0));
        DataLetterList.Add(new ListLetters("t", 0, 0, 0));
        DataLetterList.Add(new ListLetters("u", 0, 0, 0));
        DataLetterList.Add(new ListLetters("v", 0, 0, 0));
        DataLetterList.Add(new ListLetters("w", 0, 0, 0));
        DataLetterList.Add(new ListLetters("x", 0, 0, 0));
        DataLetterList.Add(new ListLetters("y", 0, 0, 0));
        DataLetterList.Add(new ListLetters("z", 0, 0, 0));
    }
}
