using UnityEngine;
using System.Collections;

public class Donkeykong : MonoBehaviour {

	[SerializeField] private Transform Barrelspawn= null;
	[SerializeField] private GameObject barrelPrefab = null;
	[SerializeField] private GameObject bluebarrelPrefab = null;
	Animator monkeybut ;
	int dice;
	//public Transform sert;


	// Use this for initialization



	void Start () 
	{
		StartCoroutine (barrelMonkey (3));
	}

	IEnumerator barrelMonkey (float delay)
	{
		while(true)
		{
			yield return new WaitForSeconds (1);
			monkeybut.SetBool ("DonkeyBarrelsroll", true);
		}
	}
	 void Awake ()
	{
		// Check whether references have been set in the Inspector.

		if (this.barrelPrefab == null) { Debug.LogError("Projectile prefab not set."); }
		if (this.Barrelspawn == null) { Debug.LogError("Projectile spawn point not set."); }

		monkeybut = this.gameObject.GetComponent<Animator> ();

		//sert= Barrelspawn.GetComponent<Transform> ();
	}
	// Update is called once per frame
	void Update () 
	{
	
	}






	private void firebarrel ()
	{

	{ 


			dice= Random.Range(1,8);
			Debug.Log( "dice roll"+dice);
			if (dice > 3|| dice < 5){
			// Instantiate a projectile.
			GameObject barrelSpirte= Instantiate(this.barrelPrefab) as GameObject;
			
			// Match the projectile's position and orientation to its spawner transform, 
			// so it can travel in the correct direction.
        	barrelSpirte.transform.rotation= this.Barrelspawn.transform.rotation;
		    barrelSpirte.transform.position = this.Barrelspawn.transform.position;
			}
			if (dice < 2){
				Debug.Log (" roll the blueberry");
				// Instantiate a projectile.
				GameObject BlueBarrelSpirte= Instantiate(this.bluebarrelPrefab) as GameObject;
				
				// Match the projectile's position and orientation to its spawner transform, 
				// so it can travel in the correct direction.
				BlueBarrelSpirte.transform.rotation= this.Barrelspawn.transform.rotation;
				BlueBarrelSpirte.transform.position = this.Barrelspawn.transform.position;

			}
			if (dice > 5)
			{
				monkeybut.SetBool ("DonkeyBarrelsroll", false);
				
				monkeybut.SetBool("ShowOff",true);
				StartCoroutine (monkeyshow(2));

		   
			}
        }
       }

	IEnumerator monkeyshow (float delay)
	{
		monkeybut.SetBool ("DonkeyBarrelsroll", false);
		monkeybut.SetBool("ShowOff",true);	
		yield return new WaitForSeconds (1);
		monkeybut.SetBool("ShowOff",false);	
		monkeybut.SetBool ("DonkeyBarrelsroll", true);
	}
	
	
}