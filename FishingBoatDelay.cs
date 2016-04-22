using UnityEngine;
using System.Collections;

public class FishingBoatDelay : MonoBehaviour {
	
	public GameObject boat;
	
	private Boat_AI boatAIScript;
	
	public bool fishingBoatActivate = false;

	// Use this for initialization
	void Start () {
		
		//boat = GameObject.CompareTag("Fishing Boat");
		
		boatAIScript = boat.GetComponent<Boat_AI>();
		
		boatAIScript.isActive = false;
		
		StartCoroutine (FishingBoatWait());
	
	}
	

	
	// Update is called once per frame
	void Update () {
		
		if(fishingBoatActivate == true)
		{
			boatAIScript.isActive = true;
		}
	
	}
	
		IEnumerator FishingBoatWait()
	{	
		yield return new WaitForSeconds (10);
		
		fishingBoatActivate = true;

	}
}
