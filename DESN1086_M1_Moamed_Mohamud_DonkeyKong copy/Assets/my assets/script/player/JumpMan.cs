using UnityEngine;
using System.Collections;

public class JumpMan : MonoBehaviour {

	//  set the what direction JumpMan face.
	 public bool JumpManFaceRight= false;
	public bool gothammerpowerup = false;
	public bool gothammerpowerupendTimer = false;
	// death stuff
	public bool death = false;

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
	// ladder
	public GameObject laddertop = null;
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
		Move1(this.direction);
	}
	
	#endregion MonoBehaviour
	
	
	private Vector3 DetectKeyboardInput ()
	{
				// Set our direction vector to zero.
				// Here we use Vector3.zero, which is equivalent to (0, 0, 0).
				Vector3 movementDirection = Vector3.zero;
				/// press left
				if (Input.GetKey (KeyCode.LeftArrow) && !isClimbing && death== false) {
						Debug.Log ("Jump man is going left and should be play his animation");
						// Add direction vector (-1, 0) to movement direction.
						//transform.localScale = new Vector3 (1,1,1);
						movementDirection += Vector3.left;

						if (gothammerpowerup == false && gothammerpowerupendTimer == false) {
								JUMPMAN.SetBool ("walk", true);
								JUMPMAN.SetBool ("HammeRun", false); 
								JUMPMAN.SetBool ("runwithbreakinghammer", false);
						}
						if (gothammerpowerup == true && gothammerpowerupendTimer == false) {
								JUMPMAN.SetBool ("walk", false);
								JUMPMAN.SetBool ("HammerRun", true);
								JUMPMAN.SetBool ("runwithbreakinghammer", false);
						}

						if (gothammerpowerup == false && gothammerpowerupendTimer == true) {
								JUMPMAN.SetBool ("walk", false);
								JUMPMAN.SetBool ("HammerRun", false);
								JUMPMAN.SetBool ("runwithbreakinghammer", true);
						}
						if (JumpManFaceRight == false) {
								Flip ();
						}
				}
				//// press Up
		if (Input.GetKey (KeyCode.UpArrow) && onladder == true&& death== false) {
						Debug.Log ("you are a winner");
						this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
						transform.Translate (Vector2.up * 0.1f * Time.deltaTime);
						//if (top == false) 
			            //{
							//	JUMPMAN.SetBool ("StartCilmb", true);
							//	isClimbing = true;
						///}
				}
		       //// relase up key
		if (Input.GetKeyUp (KeyCode.UpArrow) && onladder == true&& death== false) { 
						Debug.Log ("you are a loser2");
						JUMPMAN.SetBool ("StartCilmb", false);
				}
	     	//// press down
		if (Input.GetKey (KeyCode.DownArrow) && onladder == true&& death== false) 
					{
						Debug.Log ("you are a loser1");
						this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
				
						///if (top == false) 
			            //{
						//		JUMPMAN.SetBool ("StartCilmb", true);
				             ///isClimbing = true;
						//}
						transform.Translate (-Vector2.up * 0.1f * Time.deltaTime);
						isClimbing = true;
					}	
		//// relase down key
		if(Input.GetKeyUp(KeyCode.DownArrow)&& onladder== true&& death== false)
				
				{  Debug.Log ("you are a loser2");
				JUMPMAN.SetBool("StartCilmb",false);
				}

		//// relase left key
		if (Input.GetKeyUp(KeyCode.LeftArrow)&& death== false)
		{
		JUMPMAN.SetBool("walk",false);
		JUMPMAN.SetBool("HammerRun",false);
		JUMPMAN.SetBool("runwithbreakinghammer",false);
		}
		//// press right key
		if (Input.GetKey(KeyCode.RightArrow)&&!isClimbing&& death== false)
		{
			// Add direction vector (1, 0) to movement direction.
			//transform.localScale = new Vector3 (-1,1,1);
			//Debug.Log("Jump man is going right and should be play his animation");
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

			if(JumpManFaceRight== true)
			{
			Flip();
			}
		}
		//// relase right key
		if (Input.GetKeyUp(KeyCode.RightArrow)&& death== false)
		{
		    JUMPMAN.SetBool("walk",false);
			JUMPMAN.SetBool("HammerRun",false);// when you if runing with the hammer.
			JUMPMAN.SetBool("runwithbreakinghammer",false);// when you if runing with the hammer.
		}
		//// jump
		if (Input.GetKey(KeyCode.Space)&& grounded && gothammerpowerup ==false &&!isClimbing&& death== false)
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
		private void Move1(Vector3 movementDirection)
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

		// Cache the horizontal input.
		float h = Input.GetAxis("Horizontal");

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
			// ... add a force to the player.
		GetComponent<Rigidbody2D>().AddForce(Vector2.right * h * moveForce);

		if(Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Sign(GetComponent<Rigidbody2D>().velocity.x) * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

	   // If the input is moving the player right and the player is facing left...
		if(h > 0 && JumpManFaceRight&& death== false)
			// ... flip the player.
			Flip();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if(h < 0 && !JumpManFaceRight&& death== false)
			// ... flip the player.
			Flip();
	}


	void Flip ()
	{
		// Switch the way the player is labelled as facing.
	    JumpManFaceRight = !JumpManFaceRight;
		//Multiply the player's x local scale by -1.
    	Vector3 theScale = transform.localScale;
		theScale.x *= -1;
	    transform.localScale = theScale;
   }


	void OnCollisionEnter2D(Collision2D other) 	{

				
		if (other.gameObject.tag == "Hammer") 
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
			(other.gameObject.tag == "Barrels"||other.gameObject.tag == "Bluebarriel"||other.gameObject.tag == "Fireguy" &&gothammerpowerup == false && gothammerpowerupendTimer == false) 
			{
			Debug.Log ("you got killed by barrel");
			death=true;
			JUMPMAN.SetBool("fail",true);

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
		yield return new WaitForSeconds (delay);
		gothammerpowerup = false;
		JUMPMAN.SetBool("HammerTimeParty", false);
		StartCoroutine (HammerOct ( Hammerdelay));
	}

	IEnumerator HammerOct (float delay)
	{
		JUMPMAN.SetBool("HammerOut", true);
		gothammerpowerupendTimer = true;
		yield return new WaitForSeconds (delay);
		JUMPMAN.SetBool("HammerOut", false);
		gothammerpowerupendTimer = false;
	}
	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="other">Other.</param>

	void OnTriggerEnter2D(Collider2D other)
	          {
				 
		      if(other.gameObject.tag == "ladder") 
		       {
				       Debug.Log ("ladders!!");
			           JUMPMAN.SetBool("StartCilmb",true);
						JUMPMAN.SetBool("midCilmb",false);
						onladder = true;
						isClimbing = true;
			laddertop.GetComponent<BoxCollider2D> ().enabled = true;
						Debug.Log (onladder);
		        	}
				
		      if (other.gameObject.tag == "ladderTop") 
		          {
					Debug.Log ("No Topladders!! 1");
						JUMPMAN.SetBool ("midCilmb", true);
						onladder = true;
			           isClimbing = true;
						//top = true; 
			     }

				 
				//if (other.gameObject.tag == "AtTheEndLadder")
		           //  {
					//	Debug.Log ("No fin the ladder");
					//	JUMPMAN.SetBool ("finCilmb",true);
						//top = true; 
						//onladder = false;
						//isClimbing = false;
				      // }
		          }
	void OnTriggerStay2D(Collider2D other)
	{

		if (other.gameObject.tag == "AtTheEndLadder" )
		{
			Debug.Log ("No fin the ladder");
			JUMPMAN.SetBool ("finCilmb",true);
		//	top = true; 
			onladder = true;
			isClimbing = false;
		}

		if (other.gameObject.tag == "ladderTop") 
		{
			Debug.Log (" still on Topladders!! 3");
			JUMPMAN.SetBool ("midCilmb", true);
			onladder = true;


		}



	}

	/// <summary>
	/// Raises the trigger exit2 d event.
	///
	/// </summary>
	/// <param name="other">Other.</param>
      void OnTriggerExit2D(Collider2D other)
	      {

		if (other.gameObject.tag == "ladder")
			{
		   Debug.Log ("No ladders!!");
			this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
			JUMPMAN.SetBool("noidkCilmb",false);
			JUMPMAN.SetBool("StartCilmb",false);
			JUMPMAN.SetBool("midCilmb",false);
			onladder = false;
			isClimbing = false;

		    }
	if (other.gameObject.tag == "ladderTop") 
		{
	    	Debug.Log ("No Topladders!!2");
		     this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
			JUMPMAN.SetBool("midCilmb",false);
			JUMPMAN.SetBool("StartCilmb",false);
			//top = false; 

			onladder = false;
			isClimbing = false;
	     }





		if (other.gameObject.tag == "AtTheEndLadder")
		{

			Debug.Log ("you off the fin the ladder");
			JUMPMAN.SetBool("noidkCilmb",true);
			JUMPMAN.SetBool ("finCilmb",false);
			top = true; 
			onladder = false;
			isClimbing = false;
			laddertop.GetComponent<BoxCollider2D> ().enabled = false;
			this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		}
	    }




	  }
	
