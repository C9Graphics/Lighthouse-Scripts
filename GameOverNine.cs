using UnityEngine;
using System.Collections;

public class GameOverNine : MonoBehaviour {

	public float menuButtonLength;
	public float menuButtonHeight;

	// Use this for initialization
	void Start () {
		
		Screen.showCursor = true;
		
		menuButtonLength = Screen.width/10;
		menuButtonHeight = Screen.width/14;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Screen.showCursor = true;
	
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(400,600,menuButtonLength,menuButtonHeight), "Return to Menu"))
		{
			//Screen.showCursor = true;
			Application.LoadLevel("Lighthouse_Game_Menu2");
		}
		
		if(GUI.Button(new Rect(600,600,menuButtonLength,menuButtonHeight), "Restart Level"))
		{
			//Screen.showCursor = true;
			Application.LoadLevel("Lighthouse_Game_Level9");
		}
	}
}
