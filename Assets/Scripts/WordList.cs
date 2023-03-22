using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WordList : MonoBehaviour
{
    private List<string> wordList = new List<string>()
    {
        "Test","Word","DdDAa","Cat",//"Meow" ,"Zip","Steam","Stain","Uninterested","Uneven"
        //,"Trot","Charge","Young","Synonymous","Eminent","Stereotyped","Lunch","Daily","Wilderness"
        //,"Yard","Dance","Deep","Allow","Lace","Colossal","Boiling","Porter","Like","Fire","Tough"
        //,"Dull","Kick","Stitch","Press","Houses","Look","Overt","Little","Step","Invite"
        //,"Courageous","Murky","Invent","Clover","Arrive","Colossal","Whistle","Guard","Troubled","Easy"
        //,"Momentous","Sneeze","Serious","Abashed","Heavy","General","Cent","Slip","Opposite"
        //,"Loose","Harbor","Rhetorical","Gabby","Stomach","Mountainous","Cool","Elderly","Treatment","Plant","Pickle"
        //,"Broad","Cushion","Grape","Hum","Turkey","Level","Learned","Knowledgeable","Frame"
        //,"Wine","Thin","Simple","Telling","Horse","Ladybug","Abstracted","Hapless","Scarecrow","Tie","Cut"
        //,"Absorbing","Different","Toad","Post","Horse","Understood","Complete","Phobic","Distinct","Worm","Functional"
    };
    private List<string> workingWords = new List<string>();

    private void Awake()
    {
        workingWords.AddRange(wordList);
        shuffle(workingWords);
        //ConvertToLower(workingWords);
        
    }
    private void shuffle(List<string> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            string temporary = list[i];

            list[i] = list[random];
            list[random] = temporary;
        }
    }
   
    private void ConvertToLower(List<string> list)
    {
        for(int i = 0; i< list.Count;i++)
            list[i] = list[i].ToLower();
    }
    public string getWord()
    {
        string newWord = string.Empty;

        if(workingWords.Count != 0)
        {
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        }

        return newWord;
    }
    public string getNextWord()
    {
        string newWord = string.Empty;

        if (workingWords.Count >= 1)
        {
            newWord = workingWords[workingWords.Count - 1];
        }
        return newWord;
    }
    public bool IsWordLeft()
    {
        if (workingWords.Count == 0) 
        {
            return false;
        }
        return true;
    }
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
