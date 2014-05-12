// CameraMovement.cs
// Created by: Ryan Dougherty
// Last updated:2/26/2014

// This script lets the camera follow a 3D player from one side, giving the
// player a margin of movement without the camera following it

// Inspiration for this code came from 2D side scrollers, code is based on
// http://unity3d.com/learn/tutorials/modules/beginner/2d/2d-overview

using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	// Margin, outside of which the camera moves
	public float horizontalMargin;
	public float verticalMargin;

	// How fast the camera catches up with the player
	public float smoothx;
	public float smoothz;

	// Player reference
	public GameObject player;

	// Distance of camera from player
	public float distance;
	
	// Initialize variables
	void Awake () {
		playerVars.setFocus (player);
		//player

		smoothx = 1f;
		smoothz = 1f;

		distance = 14f;

		horizontalMargin = .5f;
		verticalMargin = .25f;
	
		StartCoroutine(loop());
	}


	// Loop continuously updating the camera position
	IEnumerator loop(){
		while (true){
			followMe();
			yield return null;
		}
	}

	//follow the player
	void followMe(){
		player = playerVars.focusPoint;
		// Set new coordinates to old posistion
		float newX = transform.position.x;
		float newZ = transform.position.z;

		// If the player is outside the margin, move the new coordinates to catch up with the player position
		if(checkZ()){
			newZ = Mathf.Lerp(transform.position.z, player.transform.position.z - distance, smoothz * Time.smoothDeltaTime);
		}
		if(checkX()){
			newX = Mathf.Lerp(transform.position.x, player.transform.position.x, smoothx * Time.smoothDeltaTime);
		}

		// Update player position with new coordinates
		transform.position = new Vector3(newX,transform.position.y,newZ);
	}

	// Check z bound
	bool checkZ(){
		return Mathf.Abs(transform.position.z - player.transform.position.z + distance) > verticalMargin;
	}
	// Check x bound
	bool checkX(){
		return Mathf.Abs(transform.position.x - player.transform.position.x) > horizontalMargin;
	}
}
