using UnityEngine;
using System.Collections;
public class Pauline : MonoBehaviour {
	public float delayofFreakout = 22;
	public float delayofCallout = 21;
	public Animator animPauline;
	public GameObject helprefabs= null;
	// Use this for initialization
	void Start () {
		animPauline=this.gameObject.GetComponent<Animator> ();
		StartCoroutine (Freakout (delayofFreakout));
		helprefabs.GetComponent<SpriteRenderer> ().enabled = false;
		//StartCoroutine (CallOut (delayofCallout));

	}
	IEnumerator Freakout(float delay)
	{
				while (true) {
						yield return new WaitForSeconds (delay);
						animPauline.SetTrigger ("panicpauline");
						helprefabs.GetComponent<SpriteRenderer> ().enabled = true;
						yield return new WaitForSeconds (2);
			        helprefabs.GetComponent<SpriteRenderer> ().enabled = false;
			       yield return new WaitForSeconds (delay);
				}
				
		}
	//IEnumerator CallOut(float delay1)
	//{
		//while (true)
		//{
			//yield return new WaitForSeconds (delay1);
			//helprefabs.GetComponent<SpriteRenderer> ().enabled = true;
			//yield return new WaitForSeconds (1);
			//helprefabs.GetComponent<SpriteRenderer> ().enabled = false;
		//}
	//}



	// Update is called once per frame
	void Update () {
	
	}
}   
