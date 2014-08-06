using UnityEngine;
using System.Collections;

public class buttonPedestal : MonoBehaviour {
	public bool pressed;

	void Start(){
		pressed = false;
	}

	void OnTriggerStay(Collider target) {
		if (target.name == "player") {
			if(Input.GetKeyDown(KeyCode.Space)){
				pressed = true;
			}
		}
	}
}
