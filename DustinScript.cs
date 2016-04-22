using UnityEngine;
using System.Collections;

public class DustinScript : MonoBehaviour {
	
	public GameObject sandPlane;
	
	public float speed = 5;
	
	private CharacterController controller;
	
	private Vector3 velocity = Vector3.zero;
	
	private GameObject player;		//Player Referenced
	
	private bool inControl = true;


	// Use this for initialization
	void Start () {
		
		controller = GetComponent<CharacterController>();
		
		player = GameObject.FindWithTag("Player");		//Private reference for player

	}
	
	// Update is called once per frame
	void Update () {
		
		//Player Controls
		if(inControl == true)
		{
		velocity.z = Input.GetAxis ("Vertical") * speed;
		velocity.x = Input.GetAxis ("Horizontal") * speed;
		}
		
		controller.Move (	transform.up * velocity.y * Time.deltaTime +
							transform.forward * velocity.z * Time.deltaTime +
							transform.right * velocity.x * Time.deltaTime		);
	
	}
	
	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Doorway1")
			{
				//Enable animation in game
				//animation.Play("walk");
        		//animation.Play("walk", PlayMode.StopAll);
			}
		if(other.name == "Doorway")
			{
				//Moves the GameObject based on speed
				//controller.Move(Transform.up * speeed * Time deltaTime
			}
		if(other.gameObject.name == "Doorway")
			{
				//sandPlane.rigidbody.velocity = transform.up * speed;
			
				StartCoroutine (SandTimer());
			}
	}
	
	IEnumerator SandTimer()
	{
		yield return new WaitForSeconds (0);	//Setup to preference (Delay/Instant)
		
		sandPlane.rigidbody.velocity = transform.up * speed;
		
		yield return new WaitForSeconds (2);	//Setup to preference (Delay/Instant)
		
		sandPlane.rigidbody.velocity = Vector3.zero;
		
	}
}
