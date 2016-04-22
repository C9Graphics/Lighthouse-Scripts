using UnityEngine;
using System.Collections;

public class BullerIgnore1 : MonoBehaviour
{
	public GameObject bullet;
	
	public int damage = 1;
	
	public GameObject enemy;
	private EnemyOne enemyScript;

	// Use this for initialization
	void Start ()
	{
		
		enemy = GameObject.FindWithTag ("enemy");
		enemyScript = enemy.GetComponent<EnemyOne>();
		
		Physics.IgnoreLayerCollision (1, 2, true);
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		Physics.IgnoreLayerCollision (1, 2, true);
	}

	void OnCollisionEnter (Collision other)
	{
		if(other.gameObject.name == "Enemy Weakspot 2")
		{
			other.gameObject.transform.parent.GetComponent<EnemyOne>().armor--;
			print ("Weakspot Hit!");
			//enemyScript.armor -= damage;
			Destroy(other.gameObject);
			
		}
		
		if (other.gameObject.tag == "enemy") 
			{
				//enemyScript.health -= damage;
				Destroy (gameObject);
			}
		
		if (other.gameObject.tag == "Building1") 
			{
				Destroy (gameObject);
			}
	
	}
}