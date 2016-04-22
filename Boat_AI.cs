using UnityEngine;
using System.Collections;

public class Boat_AI : MonoBehaviour {
	
	//public Color lightColor = Color.black;
	
	//public Transform buoyOne;
	//public GameObject boatLight;
	public GameObject boatSplash;
	
	public Transform killZTransform1;
	public Transform returnPath;
	//private Transform buoyTarget;

	private float idle = 0;
	public float speed = 20;
	private float distance = 100;	
	
	private GameObject player;
	public GameObject closeBuoy;
	
	public AudioClip wave;
	public AudioClip crash;
	
	private CharacterController controller;
	
	private Transform myTransform;
	
	//public bool isFollowing = true;
	private bool isCrashing = true;
	private bool isCrashed = false;
	private bool isSinking = false;
	public bool isActive = false;
	private bool isSearching = false;
	
	private LightHouse lighthouseScript;	
	
	private Vector3 velocity = Vector3.zero;
	
	//private Color originalColor;
	
	void Awake()
	{
		myTransform = transform;
	}
	
	// Use this for initialization
	void Start () {
		
		controller = GetComponent<CharacterController>();
		
		player = GameObject.FindWithTag ("Player");
		
		//buoyTarget = GameObject.FindGameObjectsWithTag ("Buoy");

		lighthouseScript = player.GetComponent<LightHouse>();
		
		//originalColor = renderer.material.color;
		//boatLight.renderer.material.color = originalColor;
		
		//Functions
		BoatInput();
		BoatHealth();
		BuoySearching();
	
		//BoatLighting();
		
		StartCoroutine (LevelTitle());
		
	}
	
	IEnumerator LevelTitle()
	{
		yield return new WaitForSeconds (5);
		isActive = false;
		print ("Boats Activated");
	}
	
	// Update is called once per frame
	void Update () {
		
		
		//Functions
		BoatInput();
		BoatHealth();
		BuoySearching();
	
		
		//Pause Function
		//if(Input.GetKey("escape"))
			//UnityEditor.EditorApplication.isPaused = true;
	}
	
	void BoatInput()
	{
		//World Parameters
		velocity.x = 0;
		velocity.y = 0; 
		velocity.z = 0; 
		
		if( isActive == true)
		{
	/*	if (isFollowing == true)
		{
			//transform.LookAt(buoyOne.transform);
		}*/
		//Search Mechanic
		//Vector3 pos = player.transform.position;	
		//pos.y = transform.position.y;
		//transform.LookAt (pos);
		
		
		// Idle	
		/*else if(isFollowing == false)
		{
			idle += speed * Time.deltaTime;
			if(idle >= distance)
			{
				transform.Rotate (0, 180, 0);
				idle = 0;
			}
		}*/
		
		controller.Move(transform.forward * speed * Time.deltaTime);
		if (isSinking == true)
			{
				controller.Move(-transform.up * speed * Time.deltaTime);
			}
		//rigidbody.AddForce(Vector3.forward * speed * Time.deltaTime);
		
		//isFollowing = true;
		}
	}
	
	void OnControllerColliderHit(ControllerColliderHit collision)
	{
		if(isCrashing == true)
		{
			if(collision.gameObject.name == "Bouy_v02 1")
			{
				audio.clip = crash;
				audio.Play();
				print("sink");
				lighthouseScript.curDangerHealth += 1;
				isCrashing = false;
				StartCoroutine (BoatSink());
			}
			if(collision.gameObject.name == "Bouy_v02")
			{
				audio.clip = crash;
				audio.Play();
				print("sink");
				lighthouseScript.curDangerHealth += 1;
				isCrashing = false;
				StartCoroutine (BoatSink());
			}
			if(collision.gameObject.name == "Tanker_v02")
			{
				audio.clip = crash;
				audio.Play();
				print("sink");
				lighthouseScript.curDangerHealth += 1;
				isCrashing = false;
				StartCoroutine (BoatSink());
			}
		}
	}
	
	IEnumerator BoatSink()
	{
			yield return new WaitForSeconds(0);
			isSinking = true;
			yield return new WaitForSeconds (1);
			isActive = false;
			isCrashed = true;
			print ("Buoy Touched" + lighthouseScript.curDangerHealth);
	}
	
	void BoatHealth()
	{
		if (isCrashed == true)
		{
			StartCoroutine (BoatDeath());
		}
		else if (isCrashed == false) 
		{
			//isFollowing = true;
		}
		/*if (isSinking = true)
		{
			controller.Move(-transform.up * speed * Time.deltaTime);
		}*/
	}
	
		GameObject BuoySearch()
		{
			GameObject[]buoyTarget;
			buoyTarget = GameObject.FindGameObjectsWithTag ("Buoy");
			GameObject closest = null;
			float distance = Mathf.Infinity;
			Vector3 position = transform.position;
				foreach (GameObject buoy in buoyTarget)
				{
					Vector3 diff = buoy.transform.position - position;
					float curDistance = diff.sqrMagnitude;
						if (curDistance < distance)
						{
							closest = buoy;
							distance = curDistance;
						}
					}
				
				return closest;
		}
	
	void BuoySearching()
	{
		print(BuoySearch().name);
	}
	
	IEnumerator BoatDeath()
	{
		yield return new WaitForSeconds (1);
		
		Destroy (gameObject);
	}
	
	/*void BoatLighting()
	{
		StartCoroutine(BoatLightAnim());
	}
	
	IEnumerator BoatLightAnim()
	{
		yield return new WaitForSeconds (0);
		
		boatLight.light.enabled = false;
		
		//boatLight.renderer.material.color = lightColor;
		
		yield return new WaitForSeconds (1);
		
		StartCoroutine (BoatLightAnimTwo());
	}
	
	IEnumerator BoatLightAnimTwo()
	{
		yield return new WaitForSeconds (0);
		
		boatLight.light.enabled = true;
		
		//boatLight.renderer.material.color = originalColor;
		
		yield return new WaitForSeconds (1);
		
		StartCoroutine (BoatLightAnim());
	}*/
	
	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "KillZ")
		{
			transform.LookAt (killZTransform1);
			lighthouseScript.curDockingPoints += 1;
			//lighthouseScript.isLocked = true;
			print ("Boat Docked!" + lighthouseScript.curDockingPoints);
			StartCoroutine (BoatDocked());
		}
		
		if(other.tag == "KillZInstructions")
		{
			transform.LookAt (killZTransform1);
			StartCoroutine (BoatDocked());
		}
		
		if(other.tag == "Wave")
		{
			audio.clip = wave;
			audio.Play();
			transform.LookAt (BuoySearch().transform);
			isSearching = true;
		}
		if(other.tag == "Close Buoy")
		{
			closeBuoy.audio.Play();
		}
		if(other.tag == "ReturnZ")
		{
			transform.LookAt (returnPath);
		}
		/*if(other.tag == "Buoy")
		{
			controller.Move(-transform.up * speed * Time.deltaTime);
			isActive = false;
			isCrashed = true;
			print ("Buoy Touched");
			lighthouseScript.dangerHealth -= 1;
			boatSplash.transform.Translate(0, 5,0);
		}
		
		/*if(other.tag == "Boat")
		{
			isActive = false;
			isCrashed = true;
			print ("Boat Touched");
		}*/
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.tag == "Close Buoy")
		{
			closeBuoy.audio.Stop();
		}
	}
	
	IEnumerator BoatDocked()
	{
		yield return new WaitForSeconds (5);
		
		Destroy (gameObject);
	}
}
 