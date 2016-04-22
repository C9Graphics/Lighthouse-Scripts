using UnityEngine;
using System.Collections;

public class GameOverTen : MonoBehaviour {

	public float menuButtonLength;
	public float menuButtonHeight;
	
	public GameObject gameOverText;
	
	private bool isOver = false;


	// Use this for initialization
	void Start () {
		
		Screen.showCursor = true;
		
		menuButtonLength = Screen.width/10;
		menuButtonHeight = Screen.width/14;
		
		StartCoroutine (TankerGameOver());
	
	}
	
	IEnumerator TankerGameOver()
	{
		yield return new WaitForSeconds (17);
		
		gameOverText.SetActive(true);
		isOver = true;
	}
	
	// Update is called once per frame
	void Update () {
		
		Screen.showCursor = true;
	
	}
	
	void OnGUI()
	{ if(isOver = true)
			{
			if(GUI.Button(new Rect(400,600,menuButtonLength,menuButtonHeight), "Return to Menu"))
			{
				//Screen.showCursor = true;
				Application.LoadLevel("Lighthouse_Game_Menu2");
			}
			
			if(GUI.Button(new Rect(600,600,menuButtonLength,menuButtonHeight), "Restart Level"))
			{
				//Screen.showCursor = true;
				Application.LoadLevel("Lighthouse_Game_Level10");
			}
		}
	}
}
