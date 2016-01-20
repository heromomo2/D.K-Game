using UnityEngine;
using System.Collections;

public class oil : MonoBehaviour {
	[SerializeField] private Transform  FireGuyspawn= null;
	[SerializeField] private GameObject FireGuyPrefab = null;
	bool firealreadyon = false;
	Animator oily;
	// Use this for initialization
	void Start () {
	
	}
	void Awake()
	{
		oily = this.gameObject.GetComponent<Animator> ();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.tag == "Bluebarriel")
		{
			Debug.Log ("oil is on fire");

			Destroy (other.gameObject);
			StartCoroutine (releashthefireguy(4));
				
		}
		if (other.gameObject.tag == "Barrels")
		{
			Destroy (other.gameObject);
			

			
		}

		}

	IEnumerator releashthefireguy(float delay)
	{
		yield return new WaitForSeconds (delay);
		if(firealreadyon == false){
		Debug.Log ("fire should be on");
			oily.SetTrigger("fireon");
			SummonFireGuy();
			yield return new WaitForSeconds (delay);
			oily.SetBool("fireguy",true);

			firealreadyon = true;
		}

		if (firealreadyon == true)
		{
			oily.SetBool("fireguy",false);
			SummonFireGuy();
			yield return new WaitForSeconds (5);
			oily.SetBool("fireguy",true);
		}



	}


	void SummonFireGuy()
	{
		GameObject FireGuy= Instantiate(this.FireGuyPrefab) as GameObject;
		
		// Match the projectile's position and orientation to its spawner transform, 
		// so it can travel in the correct direction.
		//FireGuy.transform.rotation= this.FireGuyspawn.transform.rotation;
		FireGuy.transform.position = this.FireGuyspawn.transform.position;

	}


}






