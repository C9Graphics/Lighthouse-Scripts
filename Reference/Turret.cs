using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	
	//public Transform sky;
	
	// Use this for initialization
	void Start () {
	
	
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 mousePos = Input.mousePosition;

		//Vector3 forward = transform.forward * 10f;

		Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 50));

		transform.LookAt(worldPoint);
				
	}
}
