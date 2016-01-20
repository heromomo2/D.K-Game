using UnityEngine;
using System.Collections;

public class ReturnToMainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	public void Return()
	{
		if (Input.GetMouseButtonDown(1)||Input.GetMouseButtonDown(0)) 
		        {
						Application.LoadLevel ("MainMenu");
				}
	}
	// Update is called once per frame
	void Update ()
	{
		Return ();
	}
}
