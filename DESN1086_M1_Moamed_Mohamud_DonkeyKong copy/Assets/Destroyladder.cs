using UnityEngine;
using System.Collections;

public class Destroyladder : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}


	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.gameObject.tag == "ladder") 
		{
			Destroy (other.gameObject);
		}

	}
	// Update is called once per frame
	void Update () {
	
	}
}
