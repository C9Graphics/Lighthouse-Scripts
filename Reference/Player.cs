using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	//public GameObject camera;
	//public GameObject healthText;
	//public GameObject lampPost;
	//public GameObject walkingGroup;
	//public AnimationClip walkingAnim;
	//public GameObject car1;
	
	//public GameObject carSpawn;
	
	//public int health = 10;				//Health of player
	//public int damage = 1;

	//public int carCount = 5;
	
	public float speed = 15;			//Speed of player
	public float timeAdd = 10;
	private float healthBarlenght;
	
	private GameObject player;		//Player Referenced
	
	private CharacterController controller;	//Controller input for player
	private Vector3 velocity = Vector3.zero;	//World Velocity
	
	private bool inControl = true;		//Player control is active
	

	// Use this for initialization
	void Start () {
		
		player = GameObject.FindWithTag("Player");		//Private reference for player
		
		controller = GetComponent<CharacterController>();	//Activates component for Player Control
	
		//camera.SetActive (true);
		//lampPost.SetActive (false);
		
		PlayerInput ();
		HUD();
		
			
		//StartCoroutine (GameClock());
	}
	
	// Update is called once per frame
	void Update () {
		

		
		PlayerInput ();
		HUD();
		
		
		//StartCoroutine (CarTraffic());
		//StartCoroutine (GameClock());
		
		//World Gravity
		
		
		//Player Physics
		controller.Move (	transform.up * velocity.y * Time.deltaTime +
							transform.forward * velocity.z * Time.deltaTime +
							transform.right * velocity.x * Time.deltaTime		);
	
	}
	
		
	
	/*IEnumerator CarTraffic()
	{
		yield return new WaitForSeconds (3);
	
		Instantiate (car1, carSpawn.transform.position, carSpawn.transform.rotation);
		
		StartCoroutine (CarTraffic2());
		
		yield return new WaitForSeconds (6);
		
		Destroy (gameObject);
	}*/
	
	/*IEnumerator CarTraffic2()
	{
		yield return new WaitForSeconds (3);
		
		Instantiate (car1, carSpawn.transform.position, carSpawn.transform.rotation);
		
		Destroy (gameObject);
		
	}*/
	
	/*IEnumerator CarTraffic3()
	{
		int i = 0;
		
		while(i < carCount)
		{
			i++;
		}
		
		 GameObject newCar= Instantiate (car1, carSpawn.position, transform.rotation)as GameObject;
		
		carArray[i] = newCar;
		
		Destroy (gameObject);
		
		Destroy (newCar);
	}*/
	
	

	/*IEnumerator GameClock()
	{
		yield return new WaitForSeconds (10);
		
		timer = 10;
		
		yield return new WaitForSeconds (10);
		
		timer = 20;
		
		yield return new WaitForSeconds (10);
		
		timer = 30;	
		
		yield return new WaitForSeconds (10);
		
		timer = 40;		
		
		yield return new WaitForSeconds (10);
		
		timer = 50;
		
		yield return new WaitForSeconds (10);
		
		timer = 60;
	}*/
	
	void PlayerInput ()
	{
		//World Parameters

		
		//Health Status
		/*if(health <= 0)
		{
			print ("Game Over");
			inControl = false;
			
			StartCoroutine(EndGame());
		}*/
		
		if(inControl == true)
		{
			velocity.z = Input.GetAxisRaw ("Vertical") * Time.deltaTime * speed;
			
			if (Input.GetKeyUp("a"))
			{
				transform.Translate (0,0,0);
			}
			if (Input.GetKeyUp("w"))
			{
				transform.Translate (0,0,0);
			}
			if (Input.GetKeyUp("s"))
			{
				transform.Translate (0,0,0);
			}
			if (Input.GetKeyUp("d"))
			{
				transform.Translate (0,0,0);
			}
			
			velocity.x = Input.GetAxisRaw ("Horizontal") * Time.deltaTime * speed;
		}
			
		}
	
	
	IEnumerator EndGame()
	{
		yield return new WaitForSeconds (0.1f);
		
		//healthText.guiText.text = "0";
		
		yield return new WaitForSeconds (8);
		
		//Application.LoadLevel ("Rainfall_Level_Game_Over");
	}
	
	
	//Instantiate timer float+10 every 10-30 seconds
	//When timer float is at 8:00 "Game Over"
	//Random Range optional
	void HUD ()
	{
		//
		//healthText.guiText.text = "" + health;
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		
		if(other.tag == "Enemy")
		{
			//health -= damage;
		}
		if(other.tag == "Flashing")
		{
			StartCoroutine (PostFlashing());
			//animation.Play("Group_Anim");
		}
		if(other.tag == "LevelStream1")
		{
			Application.LoadLevel ("Rainfall_Level_Two");
		}
		
		if(other.tag == "LevelStream2")
		{
			Application.LoadLevel ("Rainfall_Level_Three");
		}
		
		if(other.tag == "LevelStream3")
		{
			Application.LoadLevel ("Rainfall_Level_Four");
		}
		
		if(other.tag =="LevelEnd")
		{
			Application.LoadLevel ("Rainfall_Level_End");
		}
	}


	
	IEnumerator PostFlashing()
	{
		yield return new WaitForSeconds (0.1f);
		
		//lampPost.SetActive (true);

		yield return new WaitForSeconds (0.1f);
		
		//lampPost.SetActive (false);
		
		yield return new WaitForSeconds (0.1f);
		
		StartCoroutine (PostFlashing2());
	}
	
	IEnumerator PostFlashing2()
	{
		yield return new WaitForSeconds (0.1f);
		
		//lampPost.SetActive (true);

		yield return new WaitForSeconds (0.1f);
		
		//lampPost.SetActive (false);
		
		yield return new WaitForSeconds (0.1f);
		
		StartCoroutine (PostFlashing());
	}
	
	
}