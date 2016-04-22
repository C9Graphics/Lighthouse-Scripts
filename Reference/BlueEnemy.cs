using UnityEngine;
using System.Collections;

public class BlueEnemy : MonoBehaviour {

	public Color hitColor = Color.grey;
	
	public GameObject deathParticle;
	public GameObject healthHit;
	public GameObject grenadePickup;
	
	public float speed = 1;		//Speed of Enemy						
	public int damage = 1;		//Enemy Damage inflicted on Player
	public int health = 3;		//Health of Enemy
	public int armor = 1;		//Armor of Enemy
	
	public bool attackPlayer = false;		//Enemy Attacks Player
	
	public float distance = 10;				//Distance of Enemy from attacking Player
	
	private GameObject player;				//GameObject to reference Player
	
	
	private CharacterController controller;	
	//private Player_1 playerScript;				
	
	private float idle = 0;
	private float grenadeTimer = 3;
	private float armorCharge = 5;
	private float attackDelay = 5;
	private float hitIcon = 1;
	
	private bool isHarmful = false;
	
	private Color originalColor;
	
	// Use this for initialization
	void Start () {
		
		controller = GetComponent<CharacterController>();
		
		//player = GameObject.FindWithTag ("Player");

		
		//playerScript = player.GetComponent<Player_1>();
		
		originalColor = renderer.material.color;
		
		isHarmful = false;
		
		//Player Health Hit GUI Icon
		healthHit.guiTexture.enabled = false;
		
		//Functions
		EnemyInput();
		EnemyHealth();
		EnemyArmor();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//Functions
		EnemyInput();
		EnemyHealth();
		EnemyArmor();
		
	}
	
	
	void EnemyInput()
	{
		if(attackPlayer == true)
		{
			Vector3 pos = player.transform.position;
			
			pos.y = transform.position.y;
			
			transform.LookAt (pos);
			
			
		}
		else if(attackPlayer == false)
		{
			// Idle	
			idle += speed * Time.deltaTime;
			if(idle >= distance)
			{
				transform.Rotate (0, 180, 0);
				idle = 0;
			}
		}	
		
		if(isHarmful == true)
				{
						if(Input.GetButtonDown("Fire1"))
						{
							print (health);
							health -= 1;
						}
						if(Input.GetButtonUp("Fire1"))
						{
							health = health;
							print (health);
						}
				}
		controller.Move(transform.forward * speed * Time.deltaTime +
							transform.up * -0.5f);
	}
	void EnemyHealth()
	{
		if(health <= 0)
		{
			print ("Enemy Killed");
			StartCoroutine (EnemyDeath());
			Instantiate (grenadePickup, transform.position, transform.rotation);
		}
		
		
	}
	
	IEnumerator EnemyDeath()
	{
		Instantiate (deathParticle, transform.position, transform.rotation);
		
		yield return new WaitForSeconds (0.5f);
		
		Destroy(gameObject);
	}
	
	void EnemyArmor()
	{
		if(armor <= 0)
		{
			isHarmful = true;
			renderer.material.color = hitColor;
			
		}
		else if (armor >= 0)
		{
			renderer.material.color = originalColor;
			isHarmful = false;
		}
	}
	
	IEnumerator AttackDelay()
	{
		attackPlayer = false;
		
		yield return new WaitForSeconds (attackDelay);
		
		print("Waited");
		attackPlayer = true;
	}
	
	
	void OnTriggerEnter(Collider other)
	{
		if(other.name == "Player")
		{
			//playerScript.health -= damage;
			//print(playerScript.health);
			StartCoroutine (AttackDelay());
			StartCoroutine (HealthHit());
		}
		if(other.tag == "Detected")
		{
			attackPlayer = true;
			print("Detected!");
		}
		if(other.tag == "Grenade03")
		{
			StartCoroutine (ArmorDamage());
		}
	}
	
	//Health Hit Animation
	IEnumerator HealthHit()
	{
		healthHit.guiTexture.enabled = true;
		print ("Hit!");
		yield return new WaitForSeconds (hitIcon);
		
		healthHit.guiTexture.enabled = false;
	}
	
	IEnumerator ArmorDamage()
	{
		yield return new WaitForSeconds (grenadeTimer);
		
			armor = -1;
			print (armor);
		
		StartCoroutine (ArmorRecharge());
		
		isHarmful = true;
	
	}
	
	IEnumerator ArmorRecharge()
	{
		print ("Armor Recharging");
		yield return new WaitForSeconds (armorCharge);
		
		armor = +1;
		print(armor);
		
		renderer.material.color = originalColor;
		
		isHarmful = false;
	}
}
