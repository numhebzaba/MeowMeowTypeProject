using System.Collections;
using UnityEngine;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class UpLoadData : MonoBehaviour
{
    //Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;
    public DatabaseReference DBreference;

    public UserData userData;
    public Typer typer;

    [Header("UserData")]
    public Transform scoreboardContent;
    public GameObject scoreElement;

    public GameObject HistoryUI;
    public bool IsHistoryUIActive = false;


    void Awake()
    {
        //Check that all of the necessary dependencies for Firebase are present on the system
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                //If they are avalible Initialize Firebase
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    private void InitializeFirebase()
    {
        Debug.Log("Setting up Firebase Auth");
        //Set the authentication instance object
        auth = FirebaseAuth.DefaultInstance;
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;
    }
    private void Start()
    {
        StartCoroutine(Login(userData.UserEmail, userData.UserPassword));

    }
    public void UploadDataButton()
    {
        StartCoroutine(UpdateDate(typer.wordPerMinute, typer.delayTimeSpan.ToString(@"hh\:mm\:ss")));

    }
    private IEnumerator Login(string _email, string _password)
    {
        //Call the Firebase auth signin function passing the email and password
        var LoginTask = auth.SignInWithEmailAndPasswordAsync(_email, _password);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => LoginTask.IsCompleted);

        User = LoginTask.Result;

        yield return new WaitForSeconds(2);

        StartCoroutine(UpdateUsernameAuth(userData.UserName));

        //StartCoroutine(UpdateUsernameDatabase(userData.UserName));



    }
    private IEnumerator UpdateUsernameAuth(string _username)
    {
        //Create a user profile and set the username
        UserProfile profile = new UserProfile { DisplayName = _username };

        //Call the Firebase auth update user profile function passing the profile with the username
        var ProfileTask = User.UpdateUserProfileAsync(profile);
        //Wait until the task completes
        yield return new WaitUntil(predicate: () => ProfileTask.IsCompleted);

        if (ProfileTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {ProfileTask.Exception}");
        }
        else
        {
            //Auth username is now updated
        }
    }

    private IEnumerator UpdateDate(int _Wpm, string _Time)
    {

        string Date_StringValue = typer.aDate.ToString("dd:MM:yyyy hh:mm tt");
        //Set the currently logged in user Date
        Debug.Log(Date_StringValue);
        
        Debug.Log(typer.aDate.ToString("MM/dd/yyyy hh:mm tt"));
        var DBTask2 = DBreference.Child("users").Child(User.UserId).Child("HistoryPlay").Child(Date_StringValue).Child("Date").SetValueAsync(Date_StringValue);


        yield return new WaitUntil(predicate: () => DBTask2.IsCompleted);

        if (DBTask2.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask2.Exception}");
        }
        else
        {
            //Date is now updated
        }

        StartCoroutine(UpdateUsernameDatabase(userData.UserName, Date_StringValue));

        StartCoroutine(UpdateWpm(_Wpm, Date_StringValue));
        StartCoroutine(UpdateTime(_Time, Date_StringValue));

        foreach (var item in typer.DataLetterList)
        {
            StartCoroutine(UpdateLetterCorrectTypedData(item.getName, item.GetCorrect, Date_StringValue));
            StartCoroutine(UpdateLetterInCorrectTypedData(item.getName, item.GetWrongData, Date_StringValue));
            StartCoroutine(UpdateLetterAccuracyTypedData(item.getName, item.GetAccuracy, Date_StringValue));
            StartCoroutine(UpdateLetterSpeedTypedData(item.getName, item.GetSpeed, Date_StringValue));
            
        }
    }
    private IEnumerator UpdateUsernameDatabase(string _username, string _Date)
    {
        //Set the currently logged in user username in the database
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("HistoryPlay").Child(_Date).Child("Username").SetValueAsync(_username);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Database username is now updated
        }
    }
    private IEnumerator UpdateWpm(int _Wpm, string _Date)
    {
        //Set the currently logged in user Wpm
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("HistoryPlay").Child(_Date).Child("Wpm").SetValueAsync(_Wpm);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Wpms are now updated
        }
    }
    private IEnumerator UpdateTime(string _Time, string _Date)
    {
        //Set the currently logged in user Time
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("HistoryPlay").Child(_Date).Child("Time").SetValueAsync(_Time);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Time is now updated
        }
    }
    private IEnumerator UpdateLetterCorrectTypedData( string letter, int Correct, string _Date)
    {
        //Set the currently logged in user Time
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("HistoryPlay").Child(_Date).Child("Letters").Child(letter).Child("Correct").SetValueAsync(Correct);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Time is now updated
        }
    }
    private IEnumerator UpdateLetterInCorrectTypedData(string letter, int Incorrect,  string _Date)
    {
        //Set the currently logged in user Time
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("HistoryPlay").Child(_Date).Child("Letters").Child(letter).Child("Incorrect").SetValueAsync(Incorrect);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Time is now updated
        }
    }
    private IEnumerator UpdateLetterAccuracyTypedData(string letter, float accuracy, string _Date)
    {
        //Set the currently logged in user Time
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("HistoryPlay").Child(_Date).Child("Letters").Child(letter).Child("Accuracy").SetValueAsync(accuracy);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Time is now updated
        }
    }
    private IEnumerator UpdateLetterSpeedTypedData(string letter, float Speed, string _Date)
    {
        //Set the currently logged in user Time
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("HistoryPlay").Child(_Date).Child("Letters").Child(letter).Child("Speed").SetValueAsync(Speed);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Time is now updated
        }
    }
    public void HistoryButton()
    {
        IsHistoryUIActive = !IsHistoryUIActive;
        if (IsHistoryUIActive)
        {
            StartCoroutine(LoadScoreboardData());
            HistoryUI.SetActive(true);

        }else
            HistoryUI.SetActive(false);

    }
    private IEnumerator LoadScoreboardData()
    {
        //Get all the users data ordered by Wpms amount
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("HistoryPlay").GetValueAsync();
        //var DBTask = DBreference.Child("users").OrderByChild("kills").GetValueAsync();

        //var DBTask = DBreference.Child("users").Child(User.UserId).GetValueAsync();


        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }
        else
        {
            //Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;

            //Destroy any existing scoreboard elements
            foreach (Transform child in scoreboardContent.transform)
            {
                Destroy(child.gameObject);
            }

            //Loop through every users UID
            foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
            {
                string username = childSnapshot.Child("Username").Value.ToString();
                int Wpm = int.Parse(childSnapshot.Child("Wpm").Value.ToString());
                string Time = childSnapshot.Child("Time").Value.ToString();
                string Date = childSnapshot.Child("Date").Value.ToString();
                Debug.Log(username);
                Debug.Log(Wpm);
                Debug.Log(Time);
                Debug.Log(Date);
                //Instantiate new scoreboard elements
                GameObject scoreboardElement = Instantiate(scoreElement, scoreboardContent);
                scoreboardElement.GetComponent<ScoreElement>().NewScoreElement(username, Wpm, Time, Date);
            }

            //Go to scoareboard screen
            //UIManager.instance.ScoreboardScreen();
        }
    }
}
