using UnityEngine;
using System.Collections;

public class opp : MonoBehaviour {
	
	//  set the what direction JumpMan face.
	public bool JumpManFaceRight= false;
	public bool gothammerpowerup = false;
	public bool gothammerpowerupendTimer = false;
	/// <summary>
	/// //cilmbing stuff
	/// </summary>
	///
	public bool top = false;
	public bool onladder= false;
	public bool isClimbing = false;
	public bool Cilmbing1= false;
	// the JumpMan groundChecksysterm.
	public Transform groundCheck;
	public float  groundCheckRadius;
	public LayerMask WhatisGround;
	private bool  grounded;
	// filp  stuff
	public float moveForce = 10f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 5f;				// The fastest the player can travel in the x axis.
	public float Hammerdelay = 6;
	public Animator Jump;
	public Animator JUMPMAN;
	void Awake ()
	{
		JUMPMAN = this.gameObject.GetComponent<Animator> ();
		Jump=this.gameObject.GetComponent<Animator> ();
		Debug.Log ("the getcomponent for the Animator should be working");
		JUMPMAN.SetBool("walk",false);
		
	}
	
	
	
	[SerializeField] private float speed = 1;
	[SerializeField] private float jumphigh = 15;
	[SerializeField] private Vector3 direction;
	
	public float SpeedPerFrame
	{
		get { return this.speed * Time.deltaTime; }
	}
	
	
	#region MonoBehaviour
	
	void Update ()
	{
		// Determine in which direction the player is moving.
		this.direction = DetectKeyboardInput();
		
		// Move the player in that direction.
		Move (this.direction);
	}
	
	#endregion MonoBehaviour
	
	
	private Vector3 DetectKeyboardInput ()
	{
		// Set our direction vector to zero.
		// Here we use Vector3.zero, which is equivalent to (0, 0, 0).
		Vector3 movementDirection = Vector3.zero;
		
		
		
		//JUMPMAN= GetComponent<Animator>();
		
		if (Input.GetKey (KeyCode.LeftArrow)&&!isClimbing) 
		{
			Debug.Log ("Jump man is going left and should be play his animation");
			// Add direction vector (-1, 0) to movement direction.
			//transform.localScale = new Vector3 (1,1,1);
			movementDirection += Vector3.left;
			
			if (gothammerpowerup == false&& gothammerpowerupendTimer == false) 
			{
				JUMPMAN.SetBool ("walk", true);
				JUMPMAN.SetBool ("HammeRun", false); 
				JUMPMAN.SetBool("runwithbreakinghammer",false);
				
			}
			if (gothammerpowerup == true && gothammerpowerupendTimer == false)
			{
				JUMPMAN.SetBool ("walk", false);
				JUMPMAN.SetBool ("HammerRun", true);
				JUMPMAN.SetBool("runwithbreakinghammer",false);
			}
			
			if (gothammerpowerup ==false&& gothammerpowerupendTimer == true)
			{
				JUMPMAN.SetBool("walk",false);
				JUMPMAN.SetBool("HammerRun",false);
				JUMPMAN.SetBool("runwithbreakinghammer",true);
			}
			if (JumpManFaceRight == false) {
				
				Flip ();
			}
		}
		//////////
		if (Input.GetKey(KeyCode.UpArrow)&& onladder== true)
			
		{   Debug.Log ("you are a winner");
			
			this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
			transform.Translate (Vector2.up * 0.1f* Time.deltaTime);
		}
		/*if(top == false) 
			{
			JUMPMAN.SetBool("StartCilmb",true);
			}
				isClimbing = true;
			}
			if (Input.GetKeyUp(KeyCode.UpArrow)&& onladder== true)
			
			{  Debug.Log ("you are a loser2");
			
			JUMPMAN.SetBool("StartCilmb",false);
			
		     }
			if (Input.GetKey(KeyCode.DownArrow)&& onladder== true)

			{  Debug.Log ("you are a loser1");

				this.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
			/*if(top == false) 
			{
			    JUMPMAN.SetBool("StartCilmb",true);
			}
				transform.Translate (-Vector2.up * 0.1f * Time.deltaTime);
				isClimbing = true;
				
			}
		if (Input.GetKeyUp(KeyCode.DownArrow)&& onladder== true)
			
		{  Debug.Log ("you are a loser2");

			JUMPMAN.SetBool("StartCilmb",false);
				
		}*/
		///////
		
		if (Input.GetKeyUp(KeyCode.LeftArrow))
		{
			
			JUMPMAN.SetBool("walk",false);
			JUMPMAN.SetBool("HammerRun",false);
			JUMPMAN.SetBool("runwithbreakinghammer",false);
			//if (Cilmbing1= true)
			//{
			
			//}
		}
		if (Input.GetKey(KeyCode.RightArrow)&&!isClimbing)
		{
			// Add direction vector (1, 0) to movement direction.
			//transform.localScale = new Vector3 (-1,1,1);
			Debug.Log("Jump man is going right and should be play his animation");
			movementDirection += Vector3.right;
			if (gothammerpowerup ==false&& gothammerpowerupendTimer == false)
			{
				JUMPMAN.SetBool("walk",true);
				JUMPMAN.SetBool("HammerRun",false);
				JUMPMAN.SetBool("runwithbreakinghammer",false);
				
			}
			if (gothammerpowerup ==true&& gothammerpowerupendTimer == false)
			{
				JUMPMAN.SetBool("walk",false);
				JUMPMAN.SetBool("HammerRun",true);
				JUMPMAN.SetBool("runwithbreakinghammer",false);
			}
			if (gothammerpowerup ==false && gothammerpowerupendTimer == true)
			{
				JUMPMAN.SetBool("walk",false);
				JUMPMAN.SetBool("HammerRun",true);
				JUMPMAN.SetBool("runwithbreakinghammer",true);
			}
			
			if (JumpManFaceRight== true)
			{
				
				Flip();
			}
		}
		
		if (Input.GetKeyUp(KeyCode.RightArrow))
		{
			
			JUMPMAN.SetBool("walk",false);
			JUMPMAN.SetBool("HammerRun",false);
			JUMPMAN.SetBool("runwithbreakinghammer",false);
		}
		
		if (Input.GetKey(KeyCode.Space)&& grounded && gothammerpowerup ==false &&!isClimbing)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(0,this.jumphigh);
			Jump.SetTrigger("Jump");
		}
		// Return the resulting movement direction, based on the keyboard input.
		return movementDirection;
	}
	
	/// <summary>
	/// Move this object towards the specified movement direction.
	/// </summary>
	/// <param name="movementDirection">Movement direction.</param>
	private void Move (Vector3 movementDirection)
	{
		// Move my game object in the specified direction.
		// The amount by which this object moves this frame is added to the object's current position using Translate().
		// The amount of movement is provided by the SpeedPerFrame property.
		// The direction of movement is provided by the movementDirection parameter.
		// Since movementDirection is a Vector3, we need to typecast it to a Vector3, because Translate() requires
		// a Vector3 object type.
		this.gameObject.transform.Translate(movementDirection * this.SpeedPerFrame); 
	}
	void FixedUpdate()
	{
		
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, WhatisGround);
		/*
		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");


		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
		rigidbody2D.AddForce(Vector2.right * h * moveForce);

		//if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

	   // If the input is moving the player right and the player is facing left...
		if(h > 0 && JumpManFaceRight)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && !JumpManFaceRight)
			// ... flip the player.
			Flip();
*/
	}
	
	
	void Flip ()
	{
		// Switch the way the player is labelled as facing.
		JumpManFaceRight = !JumpManFaceRight;
		
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	
	
	void OnCollisionEnter2D(Collision2D other) 
	{
		//Destroy (other.gameObject);
		if 
			(other.gameObject.tag == "Hammer") 
		{
			Debug.Log ("you got the hammer");
			
			Debug.Log("Jump man's hammer animation should  playing");
			// Add direction vector (-1, 0) to movement direction.
			Destroy (other.gameObject);
			StartCoroutine (Crazyhammer (Hammerdelay));
			
			
			
		}
		if 
			(other.gameObject.tag == "Barrels"&&gothammerpowerup == true) 
		{
			Debug.Log ("you killed the Barrels 2");
			
			Destroy (other.gameObject);
		}
		
		if 
			(other.gameObject.tag == "Barrels"&&  gothammerpowerupendTimer == true) 
		{
			Debug.Log ("you killed the Barrels3");
			
			Destroy (other.gameObject);
			
			
			
		}
		
	}
	
	
	IEnumerator Crazyhammer (float delay)
	{
		Debug.Log( "it the hammer animation should be working");
		JUMPMAN.SetBool("HammerTimeParty", true);
		gothammerpowerup = true;
		yield return new WaitForSeconds (5);
		gothammerpowerup = false;
		JUMPMAN.SetBool("HammerTimeParty", false);
		StartCoroutine (HammerOct ( Hammerdelay));
	}
	
	IEnumerator HammerOct (float delay)
	{
		JUMPMAN.SetBool("HammerOut", true);
		gothammerpowerupendTimer = true;
		yield return new WaitForSeconds (5);
		JUMPMAN.SetBool("HammerOut", false);
		gothammerpowerupendTimer = false;
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if 
			(other.gameObject.tag == "ladder") 
		{ Debug.Log ("ladders!!");
			//JUMPMAN.SetBool("midCilmb",false);
			onladder= true;
			isClimbing = true;
			//Debug.Log (onladder);
		}
		/*if 
		(other.gameObject.tag == "ladderTop") 
		{ Debug.Log ("No Topladders!! 1");
        JUMPMAN.SetBool("midCilmb",true);
			onladder= true;		
			top = true; 
			
		}

		if 
			(other.gameObject.tag == "AtTheEndLadder") 
		{ Debug.Log ("No fin the ladder");
			JUMPMAN.SetTrigger("finCilmb");

			//onladder= true;		
			//top = true; 
			onladder = false;
			isClimbing = false;
		}*/
		
	}
	void OnTriggerExit2D(Collider2D other)
	{
		
		if (other.gameObject.tag == "ladder") {
			Debug.Log ("No ladders!!");
			this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
			//JUMPMAN.SetBool("StartCilmb",false);
			//JUMPMAN.SetBool("midCilmb",false);
			onladder = false;
			isClimbing = false;
		}
		/*if (other.gameObject.tag == "ladderTop") 
		{
	    	Debug.Log ("No Topladders!!2");
		 this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
			//JUMPMAN.SetBool("midCilmb",false);
			//JUMPMAN.SetBool("StartCilmb",false);
			//top = false; 
			onladder = false;
			isClimbing = false;
		}*/
	}
}
