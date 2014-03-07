using UnityEngine;
using System.Collections;

public class MovementControl : MonoBehaviour {
	public float PlayerSpeed;

	void Awake () {
		PlayerSpeed = 3f;
		StartCoroutine(loop());
	}

	// Game Loop
	IEnumerator loop(){
		while(true){
			Move();
			yield return null;
		}
	}

	// Move the player via the WASD keys at speed PlayerSpeed
	void Move () {
		if(Input.GetKey(KeyCode.W)){
			transform.Translate(Vector3.forward * Time.smoothDeltaTime * PlayerSpeed,Space.World);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(-Vector3.forward * Time.smoothDeltaTime * PlayerSpeed, Space.World);
			
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Translate(Vector3.left * Time.smoothDeltaTime * PlayerSpeed, Space.World);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Translate(-Vector3.left * Time.smoothDeltaTime * PlayerSpeed,Space.World);
		}
	}
}
