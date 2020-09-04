using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hacker : MonoBehaviour
{
	//Game configs
	const string menuHint = "You can type home at any time :)";
	string[] nucleaR = { "antidot3", "fusion", "fission", "reaction", "chemical", "atoms" };
	string[] roseLab = { "reactor", "thermal", "hydraulics", "breeder", "critical", "meltdown" };
	string[] nri = { "transmutation", "spatial-kinetics", "gamma", "exposure", "radiations", "containers" };

	enum Screen {MainMenu, Password};

	Screen currentScreen;

	string pass;

	public int laptop; //variable used to define level

	private void Start()
	{
		laptop = SingletonScript.Instance.Chernobyl;
		Debug.Log("Level detected: " + laptop);
		GameObject.Find("HandD").transform.Find("Dialogue").gameObject.SetActive(false);
		GameObject.Find("HandD").transform.Find("Health Panel").gameObject.SetActive(false);
		ShowMainMenu();
	}

	void ShowMainMenu()
	{
		currentScreen = Screen.MainMenu;
		Terminal.ClearScreen();
		switch(laptop)
		{
			case 2:
				Terminal.WriteLine("Welcome to NucleaR Labs Database...\n\n Which Software you want to access ? \n " +
					" 1. CASMO59 \n  2. Thor 500 \n  3. PARCS");
				break;
			case 3:
				Terminal.WriteLine("Welcome to Rose Lab Pvt. Ltd. Database...\n\n Which Software you want to access ? \n " +
					"1. CASMO59 \n 2. Thor 500 \n  3. PARCS");
				break;
			case 4:
				Terminal.WriteLine("Welcome to Nuclear Research Institute Database...\n\n Which Software you want to access ? \n " +
					"1. CASMO59 \n 2. Thor 500 \n  3. PARCS");
				break;
			default:
				Terminal.WriteLine("In Default !!");
				break;
		}
		
	}

	void OnUserInput(string input)
	{
		if(input == "home" || input == "Home")
		{
			ShowMainMenu();
		}
		else if(input == "exit" || input == "Exit")
		{
			SceneManager.LoadScene(laptop);
		}
		else if(currentScreen == Screen.MainMenu)
		{
			RunMainMenu(input);
		}
		else if(currentScreen == Screen.Password)
		{
			CheckPassword(input);
		}
	}

	void RunMainMenu(string input)
	{
		bool isValidlaptop = (input == "1" || input == "2" || input == "3");
		if(isValidlaptop)
		{
			AskForPassword();
		}
		else if(input == "007")
		{
			Terminal.WriteLine("Please choose a software Mr. Bond !");
		}
		else
		{
			Terminal.WriteLine("Please choose a valid software !");
		}
	}

	void AskForPassword()
	{
		currentScreen = Screen.Password;
		Terminal.ClearScreen();
		SetRandomPassword();
		Terminal.WriteLine("Enter password:  \n Hint: " + pass.Anagram());
		Terminal.WriteLine(menuHint);
	}

	private void SetRandomPassword()
	{
		switch(laptop)
		{
			case 2:
				pass = nucleaR[Random.Range(0, nucleaR.Length)];
				break;
			case 3:
				pass = roseLab[Random.Range(0, roseLab.Length)];
				break;
			case 4:
				pass = nri[Random.Range(0, nri.Length)];
				break;
			default:
				Debug.LogError("Whats that !?");
				break;
		}
	}

	void CheckPassword(string input)
	{
		if(input == pass)
		{
			GameObject.Find("UI").transform.GetChild(3).gameObject.SetActive(false);
			SingletonScript.Instance.collectionNumber++;
			if(SingletonScript.Instance.collectionNumber == 1 && laptop == 2)
			{
				GameObject.Find("Image_Q").GetComponent<Image>().transform.GetChild(0).gameObject.SetActive(true);
				GameObject.Find("HandD").transform.Find("Health Panel").gameObject.SetActive(true);
				SceneManager.LoadScene(laptop);
			}
			else if(SingletonScript.Instance.collectionNumber == 2 && laptop == 3)
			{
				GameObject.Find("Image_Q").GetComponent<Image>().transform.GetChild(1).gameObject.SetActive(true);
				GameObject.Find("HandD").transform.Find("Health Panel").gameObject.SetActive(true);
				SceneManager.LoadScene(laptop);
			}
			else if(SingletonScript.Instance.collectionNumber == 3 && laptop == 4)
			{
				GameObject.Find("Image_Q").GetComponent<Image>().transform.GetChild(2).gameObject.SetActive(true);
				SceneManager.LoadScene(5);
			}
			else
			{
				Debug.LogWarning("All Items Collected !!");
				GameObject.Find("HandD").transform.Find("Health Panel").gameObject.SetActive(true);
				SceneManager.LoadScene(laptop);
			}
		}
		else
		{
			AskForPassword();
		}
	}
}
