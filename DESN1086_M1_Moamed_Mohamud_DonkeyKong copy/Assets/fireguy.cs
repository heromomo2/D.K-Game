using UnityEngine;
using System.Collections;

public class fireguy : MonoBehaviour {
	Animator Fireanime;
	public bool fireguyfaceRight= false;
	public float speed = 1;
	public float bew= 5;
	int dice2;
	[SerializeField] private Vector3 direction;
	int buringdice;





	void Update ()
	{


	 fireguymove();
			
	
	}


	void fireguymove()
	{
		dice2= Random.Range(0,10);
		if ( dice2 > 5)
		{

		Debug.Log("the fire guy moving left");
		this.gameObject.transform.Translate (Vector3.right* Time.deltaTime* speed);
		if(fireguyfaceRight== true)
		{
			Flip();
		}
		}

		if (dice2 <0)
		{
			Debug.Log("the fire guy moving right");
			this.gameObject.transform.Translate (Vector3.right* Time.deltaTime* -speed);
			if (fireguyfaceRight == false) {
				Flip ();
			}
		}
	}
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		fireguyfaceRight = !fireguyfaceRight;
		//Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.tag == "MoveColliderA")
		{Debug.Log (" fire guy touch MoveColliderA");
			this.gameObject.transform.Translate (Vector3.left* Time.deltaTime* speed);
		}
		if (other.gameObject.tag == "MoveColliderB")
		{
			Debug.Log ("fire guy touch MoveColliderB");

			this.gameObject.transform.Translate (Vector3.right* Time.deltaTime* speed);
		}
		
	}
	
	
}



