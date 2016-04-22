using UnityEngine;
using System.Collections;

public class BoatDelay : MonoBehaviour {

	public GameObject sailBoat;
	
	private Boat_AI boatAIScript;
	
	public bool boatActivate = false;

	// Use this for initialization
	void Start () {
		
		//boat = GameObject.CompareTag("Fishing Boat");
		
		boatAIScript = sailBoat.GetComponent<Boat_AI>();
		
		boatAIScript.isActive = false;
		
		print ("Sailboat Delayed");
		
		StartCoroutine (FishingBoatWait());
	
	}
	
	
	// Update is called once per frame
	void Update () {
		
		if(boatActivate == true)
		{
			boatAIScript.isActive = true;
		}
		
	
	}
	
		IEnumerator FishingBoatWait()
	{	
		yield return new WaitForSeconds (5);
		
		print ("Sailboat Activated");
		boatAIScript.isActive = true;
		boatActivate = true;

	}
}
