using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class howtoplayScript : MonoBehaviour {

	public GameObject leftarrow = null;
	public GameObject Rightarrow = null;
	public GameObject Uparrow = null;
	public GameObject Downarrow = null;
	public GameObject jumpbutton = null;
	public Text pages = null;
	private Text ui;
	int pag= 1;

	void Start()
	{
		ui = GetComponent<Text> ();
		pages.GetComponent< Text > ();
	}
	
	// Update is called once per frame
	void Update () 
	{

				if (Input.GetKeyDown (KeyCode.RightArrow)) {
						pag++; 
				}
				if (Input.GetKeyDown (KeyCode.LeftArrow)) {
						pag--; 
				}
				if (pag == 1) {
						ui.text = "Press the  right  and left arrow to move  jumpman right to left on the screen.";
						leftarrow.GetComponent<SpriteRenderer> ().enabled = true;
						Rightarrow.GetComponent<SpriteRenderer> ().enabled = true;
						Uparrow.GetComponent<SpriteRenderer> ().enabled = false;
						Downarrow.GetComponent<SpriteRenderer> ().enabled = false;
						jumpbutton.GetComponent<SpriteRenderer> ().enabled = false;
			pages.text = "Press rigtharrow for next pages 1/4";


		
				}
				if (pag == 2) {
						ui.text = " Press the up and down arrows to move Jumpman on ladders.";
						leftarrow.GetComponent<SpriteRenderer> ().enabled = false;
						Rightarrow.GetComponent<SpriteRenderer> ().enabled = false;
						Uparrow.GetComponent<SpriteRenderer> ().enabled = true;
						Downarrow.GetComponent<SpriteRenderer> ().enabled = true;
						jumpbutton.GetComponent<SpriteRenderer> ().enabled = false;
			pages.text = "rightarrow nextpage 2/4 leftarrow previouspage ";
				}
				if (pag == 3) {
						ui.text = " Press the space bar to jump. ";
						leftarrow.GetComponent<SpriteRenderer> ().enabled = false;
						Rightarrow.GetComponent<SpriteRenderer> ().enabled = false;
						Uparrow.GetComponent<SpriteRenderer> ().enabled = false;
						Downarrow.GetComponent<SpriteRenderer> ().enabled = false;
						jumpbutton.GetComponent<SpriteRenderer> ().enabled = true;
			     pages.text = "rightarrow nextpage 3/4 leftarrow previouspage ";
				}
		if (pag == 4) {
			ui.text = " Avoid  the barrels and fire guys because they will kill you. Use the hamemer to destory your enemies. You can find on them screen. Your goal is to rescue the laday from donky kong ";
			leftarrow.GetComponent<SpriteRenderer> ().enabled = false;
			Rightarrow.GetComponent<SpriteRenderer> ().enabled = false;
			Uparrow.GetComponent<SpriteRenderer> ().enabled = false;
			Downarrow.GetComponent<SpriteRenderer> ().enabled = false;
			jumpbutton.GetComponent<SpriteRenderer> ().enabled = false;
			pages.text = "            4/4 leftarrow previouspage ";
		}
		
		if (pag >4) 
		{
			pag= 4;
				}
		if (pag < 1) 
		{
			pag=1;
		}
		}
	}


