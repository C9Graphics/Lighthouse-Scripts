using UnityEngine;
using System.Collections;

public class BlueGrenade : MonoBehaviour {
	
	public GameObject blueParticle;
	public float grenadeTimer = 3;
	public float blastRadius = 3;
	public float explosionForce = 1;
	
	//private GameObject enemy;
	//private OrgEnemy enemyScript;

	// Use this for initialization
	void Start () {
		
		//enemy = GameObject.FindWithTag ("OrgEnemy");
		
		//enemyScript = enemy.GetComponent<OrgEnemy>();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		StartCoroutine (GrenadeExplosion());
	
	}
	
	IEnumerator GrenadeExplosion()
	{
		yield return new WaitForSeconds (grenadeTimer);
		
		//Grenade Blast Array
		Collider[] hits = Physics.OverlapSphere(transform.position, blastRadius);
		
		int i = 0;
		
		while(i < hits.Length)
		{
			
			if(hits[i].rigidbody && hits[i] != collider)
			
			{
				
				hits[i].rigidbody.AddExplosionForce(explosionForce, transform.position, blastRadius, 0, ForceMode.Impulse);
				
				/*if(GameObject.FindWithTag ("OrgEnemy"))
				{
					enemyScript.armor -= explosionForce;
				}*/
				
				
				
			}
			
			i++;
			
		}
		
		GameObject newBlueGrenadeBlast = Instantiate (blueParticle, transform.position, transform.rotation) as GameObject;
		
		yield return new WaitForSeconds (0.5f);
		
		Destroy (gameObject);
		
		Destroy (newBlueGrenadeBlast);

	}
}
