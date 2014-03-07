using UnityEngine;
using System.Collections;

public class GuiStuff : MonoBehaviour {
	public GUIText gui;
	// Use this for initialization
	void Start () {
		gui.text="Hello There!  \n Today You will be breeding bunnies! \n If you understand: press '>'";
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Period)){
			gui.text="button pressed, well done";
		}
	}
}
