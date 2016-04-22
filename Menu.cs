using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public GameObject titleGui;
	public GameObject guiObject;
	//public GameObject buoyLight;
	
	public float menuButtonLength;
	public float menuButtonHeight;

	// Use this for initialization
	void Start () {
		
		Time.timeScale = 1.0f;
		
		//buoyLight.light.enabled = true;
		
		titleGui.SetActive(true);
		
		//StartCoroutine (GameTitle());
		//StartCoroutine (BuoyLight());
		
		Screen.showCursor = true;
	
		menuButtonLength = Screen.width/12;
		menuButtonHeight = Screen.width/16;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		Screen.showCursor = true;
		
	
	}
	
	/*IEnumerator GameTitle()
	{
		yield return new WaitForSeconds (11);
		
		titleGui.SetActive(true);
	}*/
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(250,650,menuButtonLength,menuButtonHeight), "Instructions"))
		{
			//Screen.showCursor = true;
			Application.LoadLevel("Lighthouse_Game_Instructions2");
		}
		
		if(GUI.Button(new Rect(450,650,menuButtonLength,menuButtonHeight), "Begin Game"))
		//Screen.width/2-50,Screen.height/2-25,100,50
		{
			//Screen.showCursor = true;
			Application.LoadLevel("Lighthouse_Game_Level1");
		}
		if(GUI.Button(new Rect(650,650,menuButtonLength,menuButtonHeight), "Credits"))
		{
			Screen.showCursor = true;
			Application.LoadLevel("Lighthouse_Game_Credits");
		}
	}
	
	/*IEnumerator BuoyLight()
	{
		yield return new WaitForSeconds (0);
		
		buoyLight.light.enabled = false;
		
		yield return new WaitForSeconds (1);
		
		StartCoroutine (BuoyLightTwo());
	}
	
	IEnumerator BuoyLightTwo()
	{
		yield return new WaitForSeconds (0);
		
		buoyLight.light.enabled = true;
		
		yield return new WaitForSeconds (1);
		
		StartCoroutine (BuoyLight());
	}*/
}
