using UnityEngine;
using System.Collections;

public class Player_1 : MonoBehaviour {
	
	
	public GameObject cameraTarget;		//FPS Camera
	public GameObject cameraObject;		
	public GameObject guiObject;		//On-Screen Text
	public GameObject grenadeBlue;		//Weapon in Left Hand Blue
	public GameObject grenadeOrange;	//Weapon in Left Hand Orange
	public GameObject grenadePurple;	//Weapon in Left Hand Purple
	public GameObject mainWeapon;		//Weapon in Right Hand
	public GameObject weaponGlow;
	public GameObject weaponBeam;
	public GameObject weaponFull;
	public GameObject weaponTwoThirds;
	public GameObject weaponOneThird;
	public GameObject blueTexture;
	public GameObject orangeTexture;
	public GameObject purpleTexture;
	public GameObject blueAmmoText;
	public GameObject orangeAmmoText;
	public GameObject purpleAmmoText;
	
	public GameObject healthDanger;
	public GameObject healthFull;
	public GameObject healthHit;
	public GameObject healthNone;
	public GameObject healthNine;
	public GameObject healthEight;
	public GameObject healthSeven;
	public GameObject healthSix;
	public GameObject healthFive;
	public GameObject healthFour;
	public GameObject healthThree;
	public GameObject healthTwo;
	public GameObject healthOne;
	
	public Transform leftArm;			//Location for grenade
	
	public int health = 10;				//Health of player
	public float secondaryAmmo = 2;		//Inventory for Element Grenades
	public float speed = 10;			//Speed of player
	public float jumpSpeed = 100;		//Speed of jump
	
	public float minGrenadeSpeed = 8f;	//Minimum speed of grenade thrown
	public float maxGrenadeSpeed = 8f;	//Maximum speed of grenade thrown
	public float grenadeArc = 3;		//Elevation for grenade thrown
	public float grenadeTimer = 4;		//Duration of grenade thrown
	public float blueAmmo = 5;
	public float orangeAmmo = 5;			//Inventory for grenades thrown
	public float purpleAmmo = 5;
	public float grenadeElement = 2;	//Grenade-Type
	public float grenadeEquipped = 1;	//Current Grenade Equipped
	
	public float mainWeaponCharge = 3;	//Wait time for main weapon to charge
	public float grenadeExplosion = 3;
	
	public float minLook = -85;		//Min Rotation Limit
	public float maxLook = 60;		//Max Rotation Limit
	
	private GameObject player;		//Player Referenced
	
	
	private bool inControl = true;		//Player control is active
	private bool isActive = true;		//Main weapon is active
	private bool blueInventory = true;	//Secondary weapon is active
	private bool orangeInventory = true;	
	private bool purpleInventory = true;	
	private bool isOpen = false;
	//private bool isUp = false;
	//private bool isDown = false;
	
	private CharacterController controller;	//Controller input for player
	private Vector3 velocity = Vector3.zero;	//World Velocity
	private Vector3 idealCameraPosition;
	
	

	// Use this for initialization
	void Start () {
		
		player = GameObject.FindWithTag("Player");		//Private reference for player
		
		controller = GetComponent<CharacterController>();	//Activates component for Player Control
		
		idealCameraPosition = cameraObject.transform.localPosition;	//Cache for ideal camera position
		
		//Screen.lockCursor = false;
		
		mainWeapon.light.intensity = 0;		//Weapon Safety
		weaponGlow.light.intensity = 0;
		
		//Weapon GUI Icon
		weaponFull.guiTexture.enabled = true;
		weaponTwoThirds.guiTexture.enabled = true;
		weaponOneThird.guiTexture.enabled= true;
		
		
		weaponBeam.active = false;			//Weapon Material Disabled
		
		//Grenade Scroll Wheel GUI Icon
		blueTexture.guiTexture.enabled = false;
		orangeTexture.guiTexture.enabled = false;
		purpleTexture.guiTexture.enabled = false;
		
		//Health GUI Icon
		healthFull.guiTexture.enabled = true;
		healthDanger.guiTexture.enabled = false;
		healthHit.guiTexture.enabled = false;
		healthNone.guiTexture.enabled = false;
		healthNine.guiTexture.enabled = false;
		healthEight.guiTexture.enabled = false;
		healthSeven.guiTexture.enabled = false;
		healthSix.guiTexture.enabled = false;
		healthFive.guiTexture.enabled = false;
		healthFour.guiTexture.enabled = false;
		healthThree.guiTexture.enabled = false;
		healthTwo.guiTexture.enabled = false;
		healthOne.guiTexture.enabled = false;
		
		//Functions on start
		GrenadeClone();
		PlayerInput ();
		WeaponInput ();
		GrenadeType ();
		HealthStatus ();
	}
	
	// Update is called once per frame
	void Update () {
		
		//Functions checked
		PlayerInput ();
		WeaponInput ();
		GrenadeClone();
		GrenadeType ();
		HealthStatus ();
		
		//Grenade Ammo HUD
		blueAmmoText.guiText.text = "" + blueAmmo;
		orangeAmmoText.guiText.text = "" + orangeAmmo;
		purpleAmmoText.guiText.text = "" + purpleAmmo;
		
		blueAmmoText.guiText.material.color = Color.black;
		orangeAmmoText.guiText.material.color = Color.black;
		purpleAmmoText.guiText.material.color = Color.black;
		
		velocity.y -= 5;		//World Gravity
		
		//Player Physics
		controller.Move (	transform.up * velocity.y * Time.deltaTime +
							transform.forward * velocity.z * Time.deltaTime +
							transform.right * velocity.x * Time.deltaTime		);
	
	}
	
	//Player Input
	void PlayerInput ()
	{
		//World Parameters
		velocity.x = 0;
		velocity.y = 0;
		velocity.z = 0;
		
		//Health Status
		if(health <= 0)
		{
			print ("Game Over");
			inControl = false;
			healthNone.guiTexture.enabled = true;
			print (guiObject);
			guiObject.guiText.text = "Game Over";
			Application.LoadLevel("G_Mendoza_Final_Game_Over");	//Load Game Over Screen
		}
		
		//Player Controls
		if(inControl == true)
		{
			velocity.z = Input.GetAxis ("Vertical") * speed;
			velocity.x = Input.GetAxis ("Horizontal") * speed;
			
			
			/*if(Input.GetKey ("w"))
			{
				velocity.z += speed;
			}
			else
			{
				velocity.z = 0;
			}
			
			if(Input.GetKey ("s"))
			{
				velocity.z -= speed;
			}
			else
			{
				velocity.z = 0;
			}*/
			
			//Mouse Look/View
			transform.Rotate (0, Input.GetAxis ("Mouse X"), 0);
			
			float angle = cameraTarget.transform.eulerAngles.x + Input.GetAxis("Mouse Y");
			
			if(	angle <= -minLook ||
				angle >= 180 - maxLook)
			{
				cameraTarget.transform.Rotate(Input.GetAxis("Mouse Y"), 0, 0);
			}
			
			//Jump
			if(controller.isGrounded)
			{
				if(Input.GetButtonDown("Jump"))		
				{
					velocity.y = jumpSpeed;
				}
				else
				{
					velocity.y = 0;
				}
			}

    		//Grenade Switching (Scroll Wheel)
			if(Input.GetAxis("Mouse ScrollWheel") > 0)
			{
    			if(grenadeElement + 1 >= grenadeEquipped)
				{
					grenadeElement++;
					print(grenadeElement);
				}
				else
				{
					grenadeElement = 0;
				}
			}
			else if(Input.GetAxis("Mouse ScrollWheel") < 0)
			{
    			if(grenadeElement - 1 <= 0)
				{
					grenadeElement--;
					print(grenadeElement);
				}
				else
				{
					grenadeElement = grenadeEquipped;
				}
			}
			
			//Grenade Switching (Number Pad)
			if (Input.GetKey("1"))
				{
				    grenadeElement = 0;
					print(grenadeElement);
				}
				
				if (Input.GetKey("2"))
				{
				    grenadeElement = 1;
					print(grenadeElement);
				}
				
				if (Input.GetKey("3"))
				{
				    grenadeElement = 2;
					print(grenadeElement);
				}

			/*if (Input.GetAxis ("Mouse ScrollWheel"))
			{
				isUp = true;
				isDown = false;
			}
			else if (Input.GetAxis ("Mouse ScrollWheel"))
			{
				isDown = true;
				isUp = false;
			}*/
			
			/*if (isUp == true)
			{
				grenadeElement++;
			}
			if (isDown == true)
			{
				grenadeElement--;
			}*/
		}
		
		
	}
	
	//Weapon Function
	void WeaponInput()
	{
		if (isActive == true)
		{
			//Left-Mouse Button
			if(Input.GetButton("Fire1"))
			{
				mainWeapon.light.intensity = 3;
				
				weaponGlow.light.intensity = 3;
				
				StartCoroutine(WeaponCharge());
				
				StartCoroutine(WeaponHUD());
				
				weaponBeam.active = true;
			}
			else if(Input.GetButtonUp("Fire1"))
			{
				mainWeapon.light.intensity = 0;
				
				weaponGlow.light.intensity = 0;
				
				weaponBeam.active = false;
			}
			
			
		}
		
	}
	
	IEnumerator WeaponCharge()
	{
		//Delay while used
		yield return new WaitForSeconds(mainWeaponCharge);
		
		mainWeapon.light.intensity = 0;		//Weapon is discharged
		
		weaponGlow.light.intensity = 0;
		
		weaponBeam.active = false;			//Material for beam disabled
		
		print ("Recharging...");
		guiObject.guiText.text = "Weapon Recharging";	//Placeholder for battery gui
		
		yield return new WaitForSeconds(mainWeaponCharge);	//Delay while reloading
		
		guiObject.guiText.text = "";
		
	}
	
	IEnumerator WeaponHUD()
	{
		yield return new WaitForSeconds(grenadeEquipped);
		
		weaponFull.guiTexture.enabled = false;
		
		yield return new WaitForSeconds(grenadeEquipped);
		
		weaponTwoThirds.guiTexture.enabled = false;
		
		yield return new WaitForSeconds(grenadeEquipped);
		
		weaponOneThird.guiTexture.enabled= false;
		
		yield return new WaitForSeconds(grenadeEquipped);
		
		weaponOneThird.guiTexture.enabled= true;
		
		yield return new WaitForSeconds(grenadeEquipped);
		
		weaponTwoThirds.guiTexture.enabled = true;
		
		yield return new WaitForSeconds(grenadeEquipped);
		
		weaponFull.guiTexture.enabled = true;
	}
	
	void GrenadeClone()
	{
		if (blueInventory == true)
		{
			//Blue Grenade
			if (grenadeElement == 0)
			{
			//Right-Mouse Button
				if(Input.GetButtonDown("Fire2"))
				{
					GameObject newGrenade = Instantiate (grenadeBlue, leftArm.position, transform.rotation) as GameObject;
					float grenadeSpeed = minGrenadeSpeed;
					newGrenade.rigidbody.velocity = newGrenade.transform.up * grenadeSpeed;
					newGrenade.rigidbody.AddForce(newGrenade.transform.forward * grenadeSpeed * grenadeArc, ForceMode.Impulse);
						Destroy(newGrenade, grenadeTimer);
					
						blueAmmo -= 1;
				}
		//Read on Array to create Grenade blast radius
			}
		}
		if (orangeInventory == true)
		{
			//Orange Grenade
			if (grenadeElement == 1)
			{
			//Right-Mouse Button
				if(Input.GetButtonDown("Fire2"))
				{
					GameObject newGrenade = Instantiate (grenadeOrange, leftArm.position, transform.rotation) as GameObject;
					float grenadeSpeed = minGrenadeSpeed;
					newGrenade.rigidbody.velocity = newGrenade.transform.up * grenadeSpeed;
					newGrenade.rigidbody.AddForce(newGrenade.transform.forward * grenadeSpeed * grenadeArc, ForceMode.Impulse);
						Destroy(newGrenade, grenadeTimer);
						
						orangeAmmo -= 1;
				}
			}
		}
		
		if (purpleInventory == true)
			//Purple Grenade
			if (grenadeElement == 2)
			{
				//Right-Mouse Button
				if(Input.GetButtonDown("Fire2"))
				{	
					GameObject newGrenade = Instantiate (grenadePurple, leftArm.position, transform.rotation) as GameObject;
					float grenadeSpeed = minGrenadeSpeed;
					newGrenade.rigidbody.velocity = newGrenade.transform.up * grenadeSpeed;
					newGrenade.rigidbody.AddForce(newGrenade.transform.forward * grenadeSpeed * grenadeArc, ForceMode.Impulse);
						Destroy(newGrenade, grenadeTimer);
					
						purpleAmmo -= 1;
				}
			}
		
		//Read on Array to create Grenade blast radius
		if (blueAmmo <= 0)
		{
			blueInventory = false;
		}
		if (orangeAmmo <= 0)
		{
			orangeInventory = false;
		}
		if (purpleAmmo <= 0)
		{
			purpleInventory = false;
		}
	}

	
	void GrenadeType()
	{
		//Prevents scroll wheel from going out of range
		
		//Blue Grenade
		if (grenadeElement == 3)	
		{
			grenadeElement = 0;
			StartCoroutine (BlueGrenadeText());
		}
		//Purple Grenade
		if(grenadeElement == -1)
		{
			grenadeElement = 2;
			StartCoroutine (PurpleGrenadeText());
		}
		//Orange Grenade
		if(grenadeElement == -2)
		{
			grenadeElement = 1;
			StartCoroutine (OrangeGrenadeText());
		}
		//Blue Grenade
		if (grenadeElement == 0)
		{
			StartCoroutine (BlueGrenadeText());
		}
		//Orange Grenade
		if (grenadeElement == 1)
		{
			StartCoroutine (OrangeGrenadeText());
		}
		//Purple Grenade
		if (grenadeElement == 2)
		{
				StartCoroutine (PurpleGrenadeText());
		}
	}
	
	
	
	
	IEnumerator BlueGrenadeText()		//Blue Grenade Icon
	{
		blueTexture.guiTexture.enabled = true;
		
		yield return new WaitForSeconds (grenadeEquipped);
		
		blueTexture.guiTexture.enabled = false;
	}
	
	
	IEnumerator OrangeGrenadeText()		//Orange Grenade Icon
	{
		orangeTexture.guiTexture.enabled = true;
		
		yield return new WaitForSeconds (grenadeEquipped);
		
		orangeTexture.guiTexture.enabled = false;
	}
	
	
	IEnumerator PurpleGrenadeText()		//Purple Grenade Icon
	{
		purpleTexture.guiTexture.enabled = true;
		
		yield return new WaitForSeconds (grenadeEquipped);
		
		purpleTexture.guiTexture.enabled = false;
	}
	
	void HealthStatus ()
	{
		if(health <= 3)
		{
			StartCoroutine (HealthDamage());
		}
		if(health <= 10)
		{
			healthFull.guiTexture.enabled = false;
		}
		if (health == 10)
		{
			healthFull.guiTexture.enabled = true;
		}
		if(health <= 9)
		{
			healthNine.guiTexture.enabled = false;
		}
		if(health == 9)
		{
			healthNine.guiTexture.enabled = true;
		}
		if(health <= 8)
		{
			healthEight.guiTexture.enabled = false;
		}
		if(health == 8)
		{
			healthEight.guiTexture.enabled = true;
		}
		if(health <= 7)
		{
			healthSeven.guiTexture.enabled = false;
		}
		if(health == 7)
		{
			healthSeven.guiTexture.enabled = true;
		}
		if(health <= 6)
		{
			healthSix.guiTexture.enabled = false;
		}
		if(health == 6)
		{
			healthSix.guiTexture.enabled = true;
		}
		if(health <= 5)
		{
			healthFive.guiTexture.enabled = false;
		}
		if(health == 5)
		{
			healthFive.guiTexture.enabled = true;
		}
		if(health <= 4)
		{
			healthFour.guiTexture.enabled = false;
		}
		if(health == 4)
		{
			healthFour.guiTexture.enabled = true;
		}
		if(health <= 3)
		{
			healthThree.guiTexture.enabled = false;
		}
		if(health == 3)
		{
			healthThree.guiTexture.enabled = true;
		}
		if(health <= 2)
		{
			healthTwo.guiTexture.enabled = false;
		}
		if(health == 2)
		{
			healthTwo.guiTexture.enabled = true;
		}
		if(health <= 1)
		{
			healthOne.guiTexture.enabled = false;
		}
		if(health == 1)
		{
			healthOne.guiTexture.enabled = true;
		}
	}
	
	IEnumerator HealthDamage()
	{
		healthDanger.guiTexture.enabled = true;
		
		yield return new WaitForSeconds (Random.Range(2f, 5f));
		
		healthDanger.guiTexture.enabled = false;
	}
	
	
	void OnTriggerEnter (Collider other)
	{	
		if (other.tag == "Dungeon")
		{
			
			print ("In Door Trigger");
			
			/*if(Input.GetKey("e"))
			{
				isOpen = true;
				guiObject.guiText.text = "Door Opened!";
				print("Door Opened");		//Placeholder for Door
			}*/
			
			isOpen = true;
			
			if(isOpen == true)
			{
				print ("Door Opening");		//Placeholder for animation
				
				Application.LoadLevel("G_Mendoza_Final_Dungeon");
			}
			
		}
	}
}
