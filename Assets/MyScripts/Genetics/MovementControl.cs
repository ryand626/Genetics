using UnityEngine;
using System.Collections;

public class MovementControl : MonoBehaviour {
	public float PlayerSpeed;
	private int direction;
	private Transform sphere;

	void Awake () {
		sphere = transform.FindChild ("Interact Sphere");
		direction = playerVars.direction;
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
		if (direction != playerVars.direction) {
			updatePickupBox();
			direction = playerVars.direction;
		}
		if(Input.GetKey(KeyCode.W)){
			transform.Translate(Vector3.forward * Time.smoothDeltaTime * PlayerSpeed,Space.World);
			playerVars.setDirection(0);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(-Vector3.forward * Time.smoothDeltaTime * PlayerSpeed, Space.World);
			playerVars.setDirection(3);
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Translate(Vector3.left * Time.smoothDeltaTime * PlayerSpeed, Space.World);
			playerVars.setDirection(2);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Translate(-Vector3.left * Time.smoothDeltaTime * PlayerSpeed,Space.World);
			playerVars.setDirection(1);
		}
	}

	void updatePickupBox () {
		int directionInt = playerVars.direction;
		float direction = directionInt * 1f;
		sphere.position = transform.position;
		sphere.rotation = new Quaternion (direction, direction, 0f, 0f);
	}
}
