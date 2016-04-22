using UnityEngine;
using System.Collections;

public class End : MonoBehaviour {

	public bool isFunctional = true;
	
	public GameObject endText1;
	public GameObject endText2;
	public GameObject endText3;

	// Use this for initialization
	void Start () {
		
		//TitleInput();
		
		//StartCoroutine(EndText());
		
		endText1.SetActive (true);
		endText2.SetActive (true);
		endText3.SetActive (true);

	}
	
	// Update is called once per frame
	void Update () {
	
		//TitleInput();
		
	}
	
	void OnGUI ()
	{
		if(isFunctional == true)
		{
			  if(GUI.Button(new Rect(750,50,110,60), "Return to Menu"))
			{
				Application.LoadLevel("Space_Defense_Menu");
			}
		}
	}
	
	/*IEnumerator EndText()
	{
		yield return new WaitForSeconds(10);
		
		endText1.SetActive (true);
		endText2.SetActive (true);
		endText3.SetActive (true);
	}*/
}
