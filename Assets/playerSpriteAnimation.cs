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
						|| Input.GetKey (KeyCode.A)
						|| Input.GetKey (KeyCode.S)
						|| Input.GetKey (KeyCode.D));
		anim.SetInteger ("direction", playerVars.direction);
	}
}
