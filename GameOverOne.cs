using UnityEngine;
using System.Collections;

public class GameOverOne : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(250,500,150,75), "Return to Menu"))
		{
			//Screen.showCursor = true;
			Application.LoadLevel("Lighthouse_Game_Menu2");
		}
		
		if(GUI.Button(new Rect(450,500,150,75), "Restart Level"))
		{
			//Screen.showCursor = true;
			Application.LoadLevel("Lighthouse_Game_Level1_2");
		}
	}
}
