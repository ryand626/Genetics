using UnityEngine;
using System.Collections;

public class MovementControl : MonoBehaviour {
	public float PlayerSpeed;
	private int direction;
	private Transform sphere;

	void Awake () {
		sphere = transform.FindChild("player Sprite").FindChild ("Interact Sphere");
		direction = playerVars.direction;
		PlayerSpeed = 3f;
		StartCoroutine(loop());
	}

	// Game Loop
	IEnumerator loop(){
		while(true){
			if(playerVars.canMove){
				Move();
			}
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
		switch(playerVars.direction){
		case 0:
			sphere.position = transform.FindChild("player Sprite").FindChild("front").position;
			sphere.rotation = transform.FindChild("player Sprite").FindChild("front").rotation;
			break;
		case 1:
			sphere.position = transform.FindChild("player Sprite").FindChild("right").position;
			sphere.rotation = transform.FindChild("player Sprite").FindChild("right").rotation;
			break;
		case 2:
			sphere.position = transform.FindChild("player Sprite").FindChild("left").position;
			sphere.rotation = transform.FindChild("player Sprite").FindChild("left").rotation;
			break;
		case 3:
			sphere.position = transform.FindChild("player Sprite").FindChild("back").position;
			sphere.rotation = transform.FindChild("player Sprite").FindChild("back").rotation;
			break;
		default:
			break;
		}
	}
}
