using UnityEngine;
using System.Collections;

public class GameOverMenu : MonoBehaviour {
	
	public GameObject titleGui;
	public GameObject guiObject;

	// Use this for initialization
	void Start () {
		
		titleGui.SetActive(false);
		
		StartCoroutine (GameTitle());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator GameTitle()
	{
		yield return new WaitForSeconds (3);
		
		titleGui.SetActive(true);
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(400,200,100,50), "Play Again"))
		{
			Application.LoadLevel("Rainfall_Level_Intro2");
		}
		
		if(GUI.Button(new Rect(400,300,100,50), "Main Menu"))
		{
			Application.LoadLevel("Rainfall_Level_Menu");
		}
	}
}
