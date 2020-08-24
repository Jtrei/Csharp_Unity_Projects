using System.Threading;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // game state, defaults to 0
    int level;
    string password;
    enum Screen { MainMenu, Password, Win};
    Screen currentScreen;

    string[] levelOnePW = {"horse", "jacob", "apple", "password", "gato"};
    string[] levelTwoPW = {"Password1", "horseshoe", "bacterium", "centipede", "fantastic"};
    string[] levelThreePW = {"meningiococcemia", "europauniversalis", "Password123!p", "xylophonetic", "thoracentesis"};

    // Start is called before the first frame update
    void Start() { // void is return value, not returning anything = void
        ShowMainMenu("3l3t33 h@kur");
    }

    void ShowMainMenu(string name){
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine($"Hello {name}");
        Terminal.WriteLine("Terminal accessed...");
        Terminal.WriteLine("Access TOP SECRET files of:");
        Terminal.WriteLine("Coffee shop (1) - Easy");
        Terminal.WriteLine("Bank        (2) - Intermediate");
        Terminal.WriteLine("NSA         (3) - Hard");
        Terminal.WriteLine("Enter selection: ");
    }


    void OnUserInput(string input)
	{
        if (input == "menu"){
            ShowMainMenu("3l3t33 h@kur");
        }
        else if (currentScreen == Screen.MainMenu){
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password){
            CheckPassword(input);
        }
	}

    void RunMainMenu(string input){

        bool isValidInput = (input == "1" || input == "2" || input == "3");
        if (isValidInput) {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "007"){
            Terminal.WriteLine("Hello Mr. Bond");
        }
        else {
            Terminal.WriteLine("Please select a valid level");
        }
    }

    void StartGame(){
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        switch(level) {
            case 1: 
                password = levelOnePW[Random.Range(0, levelOnePW.Length)];
                break;
            case 2: 
                password = levelTwoPW[Random.Range(0, levelTwoPW.Length)];
                break;
            case 3: 
                password = levelThreePW[Random.Range(0, levelThreePW.Length)];
                break;
            default:
                Terminal.WriteLine("Error, this option should be unreachable");
                break;
        }
        Terminal.WriteLine($"Enter the password: Hint({password.Anagram()})");

    }

    void CheckPassword(string input){
        if (input == password) {
            DisplayWinScreen();
        }
        else {
            Terminal.WriteLine("Wrong password");
        }
    }

    void DisplayWinScreen(){
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        
    }

    void ShowLevelReward(){
        switch(level) {
            case 1:
                Terminal.WriteLine("Congrats, you can now get a free cup of coffee.");
                break;
            case 2:
                Terminal.WriteLine("Wow, you'll be rich in now time if you just forward your bank information to nigerian_prince@money.net");
                break;
            case 3:
                Terminal.WriteLine("You might want to work for the NSA after this.");
                break;
            default:
                Terminal.WriteLine("What the...");
                break;
        }
        
    }

    // Update is called once per frame
    void Update(){
        
    }
}
