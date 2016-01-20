using UnityEngine;
using System.Collections;

public class filp : MonoBehaviour {
	private bool facingleft;
	public float speed;
	void filpagimp()
	{
		facingleft = !facingleft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
