using UnityEngine;
using System.Collections;

public class EnemyOne : MonoBehaviour {
	
	//public GameObject armorWeakspot1;
	//public GameObject armorWeakspot2;
	public GameObject weakspotLight;
	public GameObject deathParticle;
	
	public float speed = 10;
	
	public int minorDamage = 5;
	
	public bool attackPlayer = false;
	
	public float rotationSpeed = 10;	
	
	private float damagePoints= 0;
	private int pointsGiven = 1;
	
	private GameObject player;
	private GameObject buildingOne;
	private GameObject buildingTwo;
	
	private Transform myTransform;
	private Transform target;
	
	//private ParticleSystem particlesystem;
	
	public int armor = 2;
	
	private CharacterController controller;
	
	private Turret3 turretScript;
	//private Level1 levelOneScript;
	
	private bool isSearchingOne = true;
	private bool isSearchingTwo = false;
	private bool isDead = false;
	private bool isProtected = true;
	
	private Vector3 velocity = Vector3.zero;
	
	void Awake()
	{
		myTransform = transform;
	}

	// Use this for initialization
	void Start () {
		
		//particlesystem = (ParticleSystem)deathParticle.GetComponent("ParticleSystem");
		controller = GetComponent<CharacterController>();
		
		player = GameObject.FindWithTag ("Player");
		buildingOne = GameObject.FindWithTag("Building1");
		buildingTwo = GameObject.FindWithTag("Building2");
		
		turretScript = FindObjectOfType(typeof(Turret3))as Turret3;//player.GetComponent<Turret3>();
		//levelOneScript = FindObjectOfType(typeof(Level1))as Level1;
		
		EnemyInput();
		
		//target = buildingOne.transform;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(damagePoints == 0)
		{
			isSearchingOne = true;
		}
		EnemyInput();
		EnemyHealth();
		print (""+damagePoints);
	}
	
	void EnemyInput()
	{	
		//Look at target
		//myTransform.rotation = Quaternion.Slerp(myTransform.rotation, Quaternion.LookRotation(target.position, myTransform.position), rotationSpeed*Time.deltaTime);
				
		//Debug.DrawRay(transform.position, buildingOne.transform.position, Color.yellow);
		
		//controller.Move(myTransform.position += myTransform.forward * speed * Time.deltaTime);
			
		controller.Move(transform.forward * speed * Time.deltaTime);
		
		if(damagePoints == 30)
			{
				isSearchingOne = false;
				Destroy (buildingOne);
			}
			
		if(isSearchingOne == true)
			{
				transform.LookAt(buildingOne.transform);
			}
		else if(isSearchingOne == false)
			{
				isSearchingTwo = true;
				
			}
		if (isSearchingTwo == true)
			{
				transform.LookAt(buildingTwo.transform);
			}
		
		//controller.Move(transform.forward * speed * Time.deltaTime);
	}
	
	void EnemyHealth() {
		
		if (armor == 2)
			{
				isProtected = true;
				print ("protected");
			}
		
		if (armor == 0)
			{
				isProtected = false;
				print ("Not Protected");
				
			}
		
		if (isProtected == false)
			{
				StartCoroutine (Death());
			}
		
	}
	
	
	IEnumerator Death()
	{	
		
		
		
		if (isDead == false)
			
		{
			
			
		
		yield return new WaitForSeconds (0.5f);
		
		GameObject newDeathParticle = Instantiate (deathParticle, transform.position, transform.rotation) as GameObject;
		
		yield return new WaitForSeconds (2);
		
		Destroy (newDeathParticle);
		
		//levelOneScript.points += pointsGiven;
			
		Destroy (gameObject);
			
		isDead = true;
		
		}
	}
	
	void OnCollisionEnter (Collision other)
	{
		
		//if(other.gameObject.name == "Bullet2 1")
			//{
				//Destroy(gameObject);
			//}
		
		/*if(other.gameObject.CompareTag("enemy1"))
			{
				Vector3 pos = buildingOne.transform.position;
			
				pos.z = transform.position.z;
			
				transform.LookAt (pos);	
			}*/
		
		/*if(other.gameObject.tag == "Building1")
			{
					print("Touching Building");
			
					turretScript.health -= minorDamage;		//When Building1 *touched* Player health is damaged
			}*/
	}

	
	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Building1")
			{
				//turretScript.health -= minorDamage;		//When Building1 *touched* Player health is damaged
				StartCoroutine (BuildingDamage());
				print("Touching Building");
			}
	}
	
	IEnumerator BuildingDamage ()
	{
		yield return new WaitForSeconds (2);
		
		turretScript.health -= minorDamage;		//When Building1 *touched* Player health is damaged
		
		damagePoints += minorDamage;
		
		yield return new WaitForSeconds (1);
		
		StartCoroutine (BuildingDamage2());
	}
	
	IEnumerator BuildingDamage2 ()
	{
		yield return new WaitForSeconds (1);
		
		turretScript.health -= minorDamage;		//When Building1 *touched* Player health is damaged
		
		damagePoints += minorDamage;
		
		yield return new WaitForSeconds (1);
		
		StartCoroutine (BuildingDamage());
	}

}