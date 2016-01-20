using UnityEngine;
using System.Collections;

public class BlueBarrel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public float speed = 8;
	void Update()
	{  
		blueBarrelMovement ();
		
	}
	
	void blueBarrelMovement() 
	{
		this.gameObject.transform.Rotate(new Vector3(0, 0 ,this.speed));
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.tag == "MoveColliderA")
		{Debug.Log ("barrels go lelf");
			this.speed = -speed;
			transform.localScale = new Vector3 (-1,1,1);
		}
		if (other.gameObject.tag == "MoveColliderB")
		{
			Debug.Log ("barrels go right");
			this.gameObject.transform.Rotate(new Vector3(0, 0 ,this.speed));
			this.speed = -(speed);
			transform.localScale = new Vector3 (1,1,1);
			
		}
			
	}

}
