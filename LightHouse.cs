using UnityEngine;
using System.Collections;

public class LightHouse : MonoBehaviour {
	
	public GameObject light;
	public GameObject camera;
	//public GameObject boatSpawnOne;
	//public GameObject boatSpawnTwo;
	//public GameObject buoyLight;
	
	public AudioClip musicOne;
	public AudioClip musicTwo;
	
	public float healthBarLength;
	
	//Danger Ints
	public int curDangerHealth = 0;
	public int maxDangerHealth = 3;
	
	//Docking Ints
	public int curDockingPoints = 0;
	public int maxDockingPoints = 3;
	
	//public ParticleSystem deathFog;
	
	//Fog Clear
	public ParticleSystem startFog;
	public ParticleSystem endFog;
	public ParticleSystem fogClearOne;
	public ParticleSystem fogClearTwo;
	public ParticleSystem fogClearThree;
	public ParticleSystem fogClearFour;
	public ParticleSystem fogClearFive;
	public ParticleSystem fogClearSix;
	public ParticleSystem fogClearSeven;
	
	public bool isActive = true;
	public bool isLocked = false;
	public bool nextLevel = false;
	public bool failedLevel = false;
	//public bool respawnBoats = false;
	
	//private Boat_AI boatAIScriptOne;
	//private Boat_AI boatAIScriptTwo;
	private Level1Script level1Script;
	private Level2Script level2Script;
	private Level3Script level3Script;
	private Level4Script level4Script;
	private Level5Script level5Script;
	private Level6Script level6Script;
	private Level7Script level7Script;
	private Level8Script level8Script;
	private Level9Script level9Script;
	private Level10Script level10Script;
	
	private GameObject player;
	
	void Awake()
	{
		//deathFog.enableEmission = false;
		startFog.Play();
		endFog.Stop();
	}
	
	// Use this for initialization
	void Start () {
		
		//Private GameObjects
		player = GameObject.FindWithTag ("Player");
		
		//boatAIScriptOne = boatSpawnOne.GetComponent<Boat_AI>();
		//boatAIScriptTwo = boatSpawnTwo.GetComponent<Boat_AI>();
		level1Script = player.GetComponent<Level1Script>();
		level2Script = player.GetComponent<Level2Script>();
		level3Script = player.GetComponent<Level3Script>();
		level4Script = player.GetComponent<Level4Script>();
		level5Script = player.GetComponent<Level5Script>();
		level6Script = player.GetComponent<Level6Script>();
		level7Script = player.GetComponent<Level7Script>();
		level8Script = player.GetComponent<Level8Script>();
		level9Script = player.GetComponent<Level9Script>();
		level10Script = player.GetComponent<Level10Script>();
		
		Screen.showCursor = false;		//Disable Mouse Cursor
		
		healthBarLength = Screen.width /3;
		
		//particleFog.enableEmission = false;
		//deathFog.SetActive (false);
		//deathFog.enableEmission = false;
		
		//Coroutines
		//StartCoroutine (BuoyLight());
		
		//Functions
		LighthouseMovement();
		LightHouseInput();
		HealthandPoints();
		
		StartCoroutine (LevelTitle());
	}
	
	IEnumerator LevelTitle()
	{
		yield return new WaitForSeconds (0);
		print ("Start Fog stopped");
		startFog.Stop();
		yield return new WaitForSeconds (6);
		isActive = true;
		isLocked = true;
		print ("Lighthouse Activated");
	}
	
	// Update is called once per frame
	void Update () {
	
		//Screen.showCursor = false;
		
		//Functions
		LighthouseMovement();
		LightHouseInput();
		HealthandPoints();
		
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
		if (isActive == true)
			
		{
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				
			RaycastHit Hit;
				
			if (Physics.Raycast(ray, out Hit, 1500))
						
				{	
					Debug.DrawLine(ray.origin, Hit.point);	
					
					light.transform.LookAt (Hit.point);
					light.light.intensity = 4;
					if (isLocked == true)
					{
						if(Hit.collider.gameObject)
						{
							//Interesting Mechanic (Do not use)
							if(Hit.collider.CompareTag ("Boat"))
							{
									light.light.intensity = 8;
									Vector3 pos = Hit.point;
									pos.y = Hit.collider.transform.position.y;
									Hit.collider.transform.LookAt (pos);
									//Hit.collider.GetComponent<Boat_AI>().isFollowing = false;
									//Hit.collider.transform.LookAt (Hit.point);
							}
						
							if(Hit.collider.CompareTag ("Fishing Boat"))
							{
									light.light.intensity = 8;
									Vector3 pos = Hit.point;
									pos.y = Hit.collider.transform.position.y;
									Hit.collider.transform.LookAt (pos);
									//Hit.collider.GetComponent<Boat_AI>().isFollowing = false;
									//Hit.collider.transform.LookAt (Hit.point);
							}
							//Rotate Boat
							//Hit.collider.gameObject.transform.Rotate(0, 90, 0);
						
							//Look at Lighthouse.
							//Vector3 pos = Hit.point;
							//pos.y = Hit.collider.transform.position.y;
							//Hit.collider.transform.LookAt (pos);	
						}	
						
						//Works
						/*if ( Hit.collider.gameObject.renderer )
						{
							Hit.collider.gameObject.renderer.material.color = Color.red;
						}*/

					}
				}
			}
	
		if(isActive == false)
		{
			StartCoroutine (EndGame());
		}
	}
	
		//IEnumerator BuoyLight()
	/*{
		yield return new WaitForSeconds (0);
		
		buoyLight.light.enabled = false;
		
		yield return new WaitForSeconds (1);
		
		StartCoroutine (BuoyLightTwo());
	}
	
	//IEnumerator BuoyLightTwo()
	{
		yield return new WaitForSeconds (0);
		
		buoyLight.light.enabled = true;
		
		yield return new WaitForSeconds (1);
		
		StartCoroutine (BuoyLight());
	}*/
	
	
	void HealthandPoints ()
	{	
		if (nextLevel == true)
		{
			StartCoroutine (LevelCompleted());
			
			/*//Level Script Bools
			level1Script.levelCompleted = true;
			level2Script.levelCompleted = true;
			level3Script.levelCompleted = true;
			level4Script.levelCompleted = true;
			level5Script.levelCompleted = true;*/
			
			//Fog Clears
			//fogClearOne.enableEmission = false;
			//fogClearTwo.enableEmission = false;
			//fogClearThree.enableEmission = false;
			//fogClearFour.enableEmission = false;
			//fogClearFive.enableEmission = false;
			//fogClearSix.enableEmission = false;
			//fogClearSeven.enableEmission = false;
			
			/*if(GUI.Button(new Rect(1,500,120,60), "Return to Menu"))
			{
				Screen.showCursor = true;
				Application.LoadLevel("Lighthouse_Game_Menu");
			}*/
		}
		
		if(failedLevel == true)
		{
			level1Script.levelFailed = true;
			level2Script.levelFailed = true;
			level3Script.levelFailed = true;
			level4Script.levelFailed = true;
			level5Script.levelFailed = true;
			level6Script.levelFailed = true;
			level7Script.levelFailed = true;
			level8Script.levelFailed = true;
			level9Script.levelFailed = true;
			level10Script.levelFailed = true;
		}
		
		//Health
		if (curDangerHealth == maxDangerHealth)
		{
			//deathFog.enableEmission = true;
			//deathFog.SetActive (true);
			isActive = false;
		}
		
		//Docking Points
		if(curDockingPoints == maxDockingPoints)
		{
			nextLevel = true;
		}
		/*if (curDockingPoints == 4 && curDangerHealth == 3)
		{
			print ("Spawn 2 new boats!");
			respawnBoats = true;
			
			
		}*/
		
		/*if(respawnBoats == true)
		{
			boatSpawnOne.SetActive(true);
			boatAIScriptOne.isActive = true;
			
			boatSpawnTwo.SetActive(true);
			boatAIScriptTwo.isActive = true;
		}
		else
		{
			
		}*/
	}
	
	IEnumerator LevelCompleted ()
	{
		yield return new WaitForSeconds(3);
		
		endFog.Play();
		level1Script.levelCompleted = true;
		level2Script.levelCompleted = true;
		level3Script.levelCompleted = true;
		level4Script.levelCompleted = true;
		level5Script.levelCompleted = true;
		level6Script.levelCompleted = true;
		level7Script.levelCompleted = true;
		level8Script.levelCompleted = true;
		level9Script.levelCompleted = true;
		level10Script.levelCompleted = true;
	}
	
	IEnumerator EndGame()
	{
		yield return new WaitForSeconds (0.25f);
		
		print("light flicker");
		light.light.intensity = 0;
		
		yield return new WaitForSeconds (0.25f);
		
		light.light.intensity = 8;
		
		yield return new WaitForSeconds (0.25f);
		
		light.light.intensity = 0;
		
		yield return new WaitForSeconds (0.25f);
		
		light.light.intensity = 4;
		
		yield return new WaitForSeconds (0.25f);
		
		light.light.intensity = 0;
		
		yield return new WaitForSeconds (0.25f);
		
		light.light.intensity = 2;
		
		yield return new WaitForSeconds (0.25f);
		
		light.light.intensity = 0;
		
		yield return new WaitForSeconds (0.25f);
		
		light.light.intensity = 2;
		
		yield return new WaitForSeconds (0.25f);
		
		light.light.intensity = 0;
		
		//Flicker
		yield return new WaitForSeconds (0.1f);
		
		light.light.intensity = 2;
		
		yield return new WaitForSeconds (0.1f);
		
		light.light.intensity = 0;
		
		yield return new WaitForSeconds (0.1f);
		
		light.light.intensity = 2;
		
		yield return new WaitForSeconds (0.1f);
		
		light.light.intensity = 0;
		
		yield return new WaitForSeconds (0.1f);
		
		light.light.intensity = 2;
		
		yield return new WaitForSeconds (0.1f);
		
		light.light.intensity = 0;
		
		yield return new WaitForSeconds (0.1f);
		
		light.light.intensity = 2;
		
		yield return new WaitForSeconds (0.1f);
		
		light.light.intensity = 0;
		
		yield return new WaitForSeconds (0.1f);
		
		light.light.intensity = 2;
		
		yield return new WaitForSeconds (0.1f);
		
		light.light.intensity = 0;
		
		StartCoroutine (LightBroken());
	}
	
	IEnumerator LightBroken()
	{
		yield return new WaitForSeconds (0.1f);
		
		light.light.intensity = 0;
		
		yield return new WaitForSeconds (2);
		//Application.LoadLevel("Lighthouse_Game_Game_Over");
		failedLevel = true;
	}
	
	void OnGUI()
	{
		
		//Docked Boats Bar
		GUI.Box (new Rect(10,10, healthBarLength, 20), curDockingPoints + "/" + maxDockingPoints + "" + "Boats Docked");
		GUI.Box (new Rect(10,40, healthBarLength, 20), curDangerHealth + "/" + maxDangerHealth + "" + "Boats Crashed");   
	}
}
