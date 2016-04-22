using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {
	
	public GameObject buoyLight;
	
	public float menuButtonLength;
	public float menuButtonHeight;

	// Use this for initialization
	void Start () {
		
		Screen.showCursor = true;
		
		menuButtonLength = Screen.width/10;
		menuButtonHeight = Screen.width/14;
		
		StartCoroutine (BuoyLight());
	
	}
	
	// Update is called once per frame
	void Update () {
		
		Screen.showCursor = true;
	
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(450,650,menuButtonLength,menuButtonHeight), "Return to Menu"))
		{
			Application.LoadLevel("Lighthouse_Game_Menu2");
		}
	}
	
	IEnumerator BuoyLight()
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
	}
}
