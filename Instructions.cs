using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {
	
	public GameObject sailBoatOne;
	public GameObject sailBoatTwo;
	public GameObject sailBoatThree;
	public GameObject sailBoatFour;
	public GameObject sailBoatFive;
	public GameObject sailBoatSix;
	public GameObject sailBoatSeven;
	public GameObject sailBoatEight;
	
	public GameObject fishingBoatOne;
	public GameObject fishingBoatTwo;
	public GameObject fishingBoatThree;
	public GameObject fishingBoatFour;
	public GameObject fishingBoatFive;
	
	private Boat_AI boatAIScriptOne;
	private Boat_AI boatAIScriptTwo;
	private Boat_AI boatAIScriptThree;
	private Boat_AI boatAIScriptFour;
	private Boat_AI boatAIScriptFive;
	private Boat_AI boatAIScriptSix;
	private Boat_AI boatAIScriptSeven;
	private Boat_AI boatAIScriptEight;
	private Boat_AI boatAIScriptNine;
	private Boat_AI boatAIScriptTen;
	private Boat_AI boatAIScriptEleven;
	private Boat_AI boatAIScriptTwelve;
	private Boat_AI boatAIScriptThirteen;
	
	
	public float buttonLength;
	public float buttonHeight;
	
	public GameObject pauseText;
	
	private bool isPaused = false;
	private bool isContinued = false;
	private bool isRestartActive = false;

	// Use this for initialization
	void Start () {
		
		//spawnOne = GameObject.FindWithTag("Spawnpt1");
		//fishingBoatSpawn = GameObject.FindWithTag ("Fishing Boat");
		
		//Script Calling for AI
		boatAIScriptOne = sailBoatOne.GetComponent<Boat_AI>();
		boatAIScriptTwo = sailBoatTwo.GetComponent<Boat_AI>();
		boatAIScriptThree = sailBoatThree.GetComponent<Boat_AI>();
		boatAIScriptFour = sailBoatFour.GetComponent<Boat_AI>();
		boatAIScriptFive = sailBoatFive.GetComponent<Boat_AI>();
		boatAIScriptSix = sailBoatSix.GetComponent<Boat_AI>();
		boatAIScriptSeven = sailBoatSeven.GetComponent<Boat_AI>();
		boatAIScriptEight = sailBoatEight.GetComponent<Boat_AI>();
		boatAIScriptNine = fishingBoatOne.GetComponent<Boat_AI>();
		boatAIScriptTen = fishingBoatTwo.GetComponent<Boat_AI>();
		boatAIScriptEleven = fishingBoatThree.GetComponent<Boat_AI>();
		boatAIScriptTwelve = fishingBoatFour.GetComponent<Boat_AI>();
		boatAIScriptThirteen = fishingBoatFive.GetComponent<Boat_AI>();
		
		//Active Boats
		boatAIScriptOne.isActive = true;
		boatAIScriptTwo.isActive = true;
		boatAIScriptThree.isActive = true;
		boatAIScriptFour.isActive = true;
		boatAIScriptFive.isActive = true;
		boatAIScriptSix.isActive = true;
		boatAIScriptSeven.isActive = true;
		boatAIScriptEight.isActive = true;
		boatAIScriptNine.isActive = true;
		boatAIScriptTen.isActive = true;
		boatAIScriptEleven.isActive = true;
		boatAIScriptTwelve.isActive = true;
		boatAIScriptThirteen.isActive = true;
		
		Time.timeScale = 1.0f;
		
		EscapeInput();
		
		pauseText.guiText.material.color = Color.black;
		
		pauseText.SetActive(false);
		
		StartCoroutine (FishingBoats());
		
		buttonLength =  Screen.width /12;
		buttonHeight =	Screen.width /16;
	
	}
	
	IEnumerator FishingBoats()
	{
		yield return new WaitForSeconds (0);
		
		print("FishingBoats Activated");
		
		sailBoatOne.SetActive(true);
		
		yield return new WaitForSeconds (15);
		
		sailBoatTwo.SetActive(true);
		fishingBoatFour.SetActive (true);
		
		yield return new WaitForSeconds	(10);
		
		sailBoatFour.SetActive(true);
		
		yield return new WaitForSeconds (15);
		
		sailBoatThree.SetActive(true);
		fishingBoatFive.SetActive (true);
		
		yield return new WaitForSeconds (10);
		
		sailBoatFive.SetActive(true);
		
		yield return new WaitForSeconds (15);
		
		sailBoatSix.SetActive(true);
		fishingBoatThree.SetActive (true);
		
		yield return new WaitForSeconds (10);
		
		sailBoatSeven.SetActive(true);
		
		yield return new WaitForSeconds (20);
		
		sailBoatEight.SetActive(true);
		fishingBoatOne.SetActive (true);
		fishingBoatTwo.SetActive (true);
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
		EscapeInput();
		
		pauseText.guiText.material.color = Color.black;
		
		//Active Boats
		boatAIScriptOne.isActive = true;
		boatAIScriptTwo.isActive = true;
		boatAIScriptThree.isActive = true;
		boatAIScriptFour.isActive = true;
		boatAIScriptFive.isActive = true;
		boatAIScriptSix.isActive = true;
		boatAIScriptSeven.isActive = true;
		boatAIScriptEight.isActive = true;
		boatAIScriptNine.isActive = true;
		boatAIScriptTen.isActive = true;
		boatAIScriptEleven.isActive = true;
		boatAIScriptTwelve.isActive = true;
		boatAIScriptThirteen.isActive = true;
		
	
	}
	
void EscapeInput()
	{
	
	if(Input.GetKey("escape"))
		{
			isContinued = false;
			
			if (Time.timeScale == 1.0f)
			{
				isPaused = true;
			}
		}
		
		/*if (Input.GetKeyUp("escape"))
		{
			if (Time.timeScale == 1.0f)
			{
				isPaused = false;
			}
			if(Time.timeScale == 0)
			{
				isContinued = false;
			}
		}*/
			
		if (isPaused == true)
		{
			pauseText.SetActive(true);
			isRestartActive = true;
			  if (Time.timeScale == 1.0f)
				{
                	Time.timeScale = 0;
				}
		}
		
		if (isContinued == true)
		{
			pauseText.SetActive(false);
			isRestartActive = false;
			 if (Time.timeScale == 0)
				{
                	Time.timeScale = 1.0f;
				}
		}
	}
	
	void OnGUI()
	{
		if(isRestartActive == true)
		{
			if(GUI.Button(new Rect(500,500,buttonLength,buttonHeight), "Restart Level"))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			
			if(GUI.Button(new Rect(700,500,buttonLength,buttonHeight), "Resume Game"))
			{
				isContinued = true;
			}
			
			if(GUI.Button(new Rect(900,500,buttonLength,buttonHeight), "Return to Menu"))
			{
				Application.LoadLevel("Lighthouse_Game_Menu2");
			}
		}
	}
}
