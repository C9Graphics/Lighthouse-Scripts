using UnityEngine;
using System.Collections;

public class LighthouseInstructions : MonoBehaviour {
	
		public GameObject light;

	// Use this for initialization
	void Start () {
		
		//Functions
		LighthouseMovement();
		LightHouseInput();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//Functions
		LighthouseMovement();
		LightHouseInput();
	
	}
	
	void LighthouseMovement()
	{
		Vector3 mousePos = Input.mousePosition;

		//Vector3 forward = transform.forward * 10f;

		Vector3 worldPoint = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, 0, 10));

		transform.LookAt(worldPoint);
	}
	
	void LightHouseInput()
	{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				
			RaycastHit Hit;
				
			if (Physics.Raycast(ray, out Hit, 1500))
						
				{	
					Debug.DrawLine(ray.origin, Hit.point);	
					
					light.transform.LookAt (Hit.point);
				
						if(Hit.collider.gameObject)
						{
							//Interesting Mechanic (Do not use)
							if(Hit.collider.CompareTag ("Boat"))
							{
									Vector3 pos = Hit.point;
									pos.y = Hit.collider.transform.position.y;
									Hit.collider.transform.LookAt (pos);
							}
						
							if(Hit.collider.CompareTag ("Fishing Boat"))
							{
									Vector3 pos = Hit.point;
									pos.y = Hit.collider.transform.position.y;
									Hit.collider.transform.LookAt (pos);
							}	
						}	
				}
	}
}
