using UnityEngine;
using System.Collections;

public class BuoyScript : MonoBehaviour {
	
	public GameObject buoyLight;

	// Use this for initialization
	void Start () {
		
		animation.Stop("Buoy2Anim");
		
		StartCoroutine (BuoyLight());
		
		StartCoroutine (BuoyAnimation());
	}
	
	// Update is called once per frame
	void Update () {
		
		//StartCoroutine (BuoyLight());
	
	}
	
	
		IEnumerator BuoyAnimation()
	{
		yield return new WaitForSeconds (Random.Range(0f,1f));
		
		animation.Play("Buoy2Anim");
	}
	
		IEnumerator BuoyLight()
	{
		yield return new WaitForSeconds (0);
		
		buoyLight.light.enabled = false;
		
		yield return new WaitForSeconds (Random.Range(1f,2f));
		
		StartCoroutine (BuoyLightTwo());
	}
	
		IEnumerator BuoyLightTwo()
	{
		yield return new WaitForSeconds (0);
		
		buoyLight.light.enabled = true;
		
		yield return new WaitForSeconds (Random.Range(1f,2f));
		
		StartCoroutine (BuoyLight());
	}
}
