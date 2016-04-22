using UnityEngine;
using System.Collections;

public class DustinFireScript : MonoBehaviour {
	
	/*public GameObject Reference
	 public GameObject fireOneLeft;
	public GameObject fireOneRight;
	public GameObject fireTwoLeft;
	public GameObject fireTwoRight;
	public GameObject fireThreeLeft;
	public GameObject fireThreeRight;
	public GameObject fireFourLeft;
	public GameObject fireFourRight;*/
	
	public ParticleSystem fireParticleOneLeft;
	public ParticleSystem fireParticleOneRight;
	public ParticleSystem fireParticleTwoLeft;
	public ParticleSystem fireParticleTwoRight;
	public ParticleSystem fireParticleThreeLeft;
	public ParticleSystem fireParticleThreeRight;
	
	public float fireDelay = 1;  //int (0.5f)
	
	public bool fireAnim = false;
	
	/*
	//public float speed = 15;			//Speed of player
	//public float timeAdd = 10;
	//private float healthBarlenght;
	
	//private GameObject player;		//Player Referenced
	
	//private CharacterController controller;	//Controller input for player
	//private Vector3 velocity = Vector3.zero;	//World Velocity

	//private bool inControl = true;		//Player control is active
	*/

	// Use this for initialization
	void Start () {
		
		
		//player = GameObject.FindWithTag("Player");		//Private reference for player
		
		//controller = GetComponent<CharacterController>();	//Activates component for Player Control
	
		/*//GameObject Reference
		fireOneLeft.SetActive(false);
		fireOneRight.SetActive(false);
		fireTwoLeft.SetActive(false);
		fireTwoRight.SetActive(false);
		fireThreeLeft.SetActive(false);
		fireThreeRight.SetActive(false);
		fireFourLeft.SetActive(false);
		fireFourRight.SetActive(false);*/
		
		fireParticleOneLeft.Stop();
		fireParticleOneRight.Stop();
		fireParticleTwoLeft.Stop();
		fireParticleTwoRight.Stop();
		fireParticleThreeLeft.Stop();
		fireParticleThreeRight.Stop();
		
		fireAnim = false;
		
		//Function
		//FireInput();
		//PlayerInput();
	}
	
	// Update is called once per frame
	void Update () {
		
		//Function
		//FireInput();
		//PlayerInput();
		
		/*if (fireAnim = true)
		{
			StartCoroutine(StartFire());
		}*/
		
		/*//Player Physics
		controller.Move (	transform.up * velocity.y * Time.deltaTime +
							transform.forward * velocity.z * Time.deltaTime +
							transform.right * velocity.x * Time.deltaTime		);
		*/
	
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "FireTrigger")
		{
			StartCoroutine(StartFire());
		}
	}
	
	/*void PlayerInput()
	{
	
		//World Parameters
		
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
			
		}*/
	
	/*void FireInput()
	{
		if (fireAnim = true)
		{
			StartCoroutine(StartFire());
		}
	}*/
	
	IEnumerator StartFire()
	{
		yield return new WaitForSeconds(fireDelay);
		//
		//fireOneLeft.SetActive(true);
		//fireOneRight.SetActive(true);
		
		fireParticleOneLeft.Play();
		fireParticleOneRight.Play();
		
		yield return new WaitForSeconds(fireDelay);
		//
		//fireTwoLeft.SetActive(true);
		//fireTwoRight.SetActive(true);
		
		fireParticleTwoLeft.Play();
		fireParticleTwoRight.Play();
		
		yield return new WaitForSeconds(fireDelay);
		//
		//fireThreeLeft.SetActive(true);
		//fireThreeRight.SetActive(true);
		
		fireParticleThreeLeft.Play();
		fireParticleThreeRight.Play();
		
		
		yield return new WaitForSeconds(fireDelay);
		//
		//fireFourRight.SetActive(true);
		//fireFourRight.SetActive(true);

	}
}
