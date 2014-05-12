using UnityEngine;
using System.Collections;

public class playerSpriteAnimation : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("moveButtonPressed", Input.GetKey (KeyCode.W) 
						|| Input.GetKeyDown (KeyCode.A)
						|| Input.GetKeyDown (KeyCode.S)
						|| Input.GetKeyDown (KeyCode.D));
		anim.SetInteger ("direction", playerVars.direction);
	}
}
