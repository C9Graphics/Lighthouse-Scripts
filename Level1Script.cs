using UnityEngine;
using System.Collections;

public class Level1Script : MonoBehaviour {
	
	public float buttonLength;
	public float buttonHeight;
	
	public GameObject pauseText;
	public GameObject boatOne;
	
	private Boat_AI boatAIScriptOne;
	
	public bool levelFailed = false;
	public bool levelCompleted = false;
	
	private bool isPaused = false;
	private bool isContinued = false;
	private bool isRestartActive = false;

	// Use this for initialization
	void Start () {
		
		boatAIScriptOne = boatOne.GetComponent<Boat_AI>();
		
		Time.timeScale = 1.0f;
		
		EscapeInput();
		
		pauseText.guiText.material.color = Color.black;
		
		boatOne.SetActive(true);
		boatAIScriptOne.isActive = true;
		pauseText.SetActive(false);
		
		buttonLength =  Screen.width /12;
		buttonHeight =	Screen.width /16;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		boatAIScriptOne.isActive = true;
		
		EscapeInput();
		
		pauseText.guiText.material.color = Color.black;
		
		/*if(Input.GetKey("escape"))
		{
			UnityEditor.EditorApplication.isPaused = true;
		}*/
		
		if (levelFailed == true)
		{
			Application.LoadLevel("Lighthouse_Game_Game_Over");
		}
		
		if (levelCompleted == true)
		{
			StartCoroutine (EndLevel());
			//Application.LoadLevel("Lighthouse_Game_Level1_2");	
		}
	}
	
	IEnumerator EndLevel()
	{
		yield return new WaitForSeconds (10);
		
		Application.LoadLevel("Lighthouse_Game_Level1_2");	
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
