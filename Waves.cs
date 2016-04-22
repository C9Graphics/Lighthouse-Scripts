using UnityEngine;
using System.Collections;

public class Waves : MonoBehaviour {
	
	public ParticleSystem waves;
	public GameObject wavesTrigger;
	
	public bool triggerActive = false;
	
	// Use this for initialization
	void Start () {
					
		StartCoroutine (WaveStart());
	}
	
	// Update is called once per frame
	void Update () {
		
		if (triggerActive == true)
		{
			wavesTrigger.SetActive (true);
		}
		else
		{
			wavesTrigger.SetActive (false);
		}
	
	}
	
	IEnumerator WaveStart()
	{
		yield return new WaitForSeconds (4);
		
		waves.Play();
		triggerActive = true;
		
		yield return new WaitForSeconds (4);
		
		waves.Stop();
		triggerActive = false;
		StartCoroutine (WaveStartTwo());
	}
	
	IEnumerator WaveStartTwo()
	{
		yield return new WaitForSeconds (4);
		
		waves.Play();
		triggerActive = true;
		
		yield return new WaitForSeconds (4);
		
		waves.Stop();
		triggerActive = false;
		StartCoroutine (WaveStart());
	}
}
