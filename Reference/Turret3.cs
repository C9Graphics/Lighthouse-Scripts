using UnityEngine;
using System.Collections;

public class Turret3 : MonoBehaviour {
	
	
	public GameObject bullet;
	public GameObject cannonFlash;
	public GameObject heathText;
	
	private GameObject spawnPt;
	
	public float interval = 0.25f;
	public float nextShot = 0.0f;
	
	public int health = 100;
	//public int damage = 1;
	public int minorDamage = 5;
	//public int increasedDamage = 10;
	public int majorDamage = 20;
	
	public bool isActive = false;
	
	// Use this for initialization
	void Start () {
		
		spawnPt = GameObject.Find ("oneSpawn");
		
		cannonFlash.SetActive(false);
		
		PlayerHealth();
		PlayerInput();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		PlayerHealth();
		PlayerInput();
	}
	
	void PlayerInput()
	{
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		
	if (isActive == true)
			
		{
			//StartCoroutine (FlashingCannon());
		
			//if (Input.GetButtonDown ("Fire1")) 
			
			if(Time.time >= nextShot)
		
			{
				nextShot = Time.time + interval;
		
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				
				RaycastHit Hit;
				
				if (Physics.Raycast(ray, out Hit, 4000))
						
					{
								
				        Debug.DrawLine(ray.origin, Hit.point);
						
						GameObject newProjectile = Instantiate (bullet, spawnPt.transform.position, transform.rotation)as GameObject;
							
						cannonFlash.SetActive(true);
								
						newProjectile.transform.LookAt (Hit.point);
								
						newProjectile.rigidbody.AddRelativeForce(Vector3.up + Vector3.forward * 5000);
							
						//Hit.collider.SendMessageUpwards("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
								
					    Destroy (newProjectile, 3);
							
						print("" + Hit.point);
							
						cannonFlash.SetActive(false);
							
					}
			}
			
			if (isActive == false)
			{
				Application.LoadLevel("Space_Defense_Game_Over");
			}
		
			/*if(Input.GetButtonUp ("Fire1"))
				
			{
				cannonFlash.SetActive(false);
	
			}*/
		}
	}
	void PlayerHealth()
	{
		heathText.guiText.text = "" + health;
		
		if (health <= 0)
			{
				isActive = false;
				print ("Game Over");
			}
	}
	
	/*IEnumerator FlashingCannon()
	{
		if (isActive == true)
			{
				yield return new WaitForSeconds (0.01f);
				
				cannonFlash.SetActive(true);
			
				yield return new WaitForSeconds (0.5f);
			
				cannonFlash.SetActive(false);
			
				StartCoroutine (FlashingCannon());
			}
	}*/	
}