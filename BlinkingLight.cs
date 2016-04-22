using UnityEngine;
using System.Collections;

public class BlinkingLight : MonoBehaviour {
	
	public GameObject buoyHalo;

	// Use this for initialization
	void Start () {
		
		StartCoroutine (BuoyLight());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
		IEnumerator BuoyLight()
	{
		yield return new WaitForSeconds (0);
		
		buoyHalo.SetActive(false);
		
		yield return new WaitForSeconds (Random.Range(1f,2f));
		
		StartCoroutine (BuoyLightTwo());
	}
	
		IEnumerator BuoyLightTwo()
	{
		yield return new WaitForSeconds (0);
		
		buoyHalo.SetActive(true);
		
		yield return new WaitForSeconds (Random.Range(1f,2f));
		
		StartCoroutine (BuoyLight());
	}
}
