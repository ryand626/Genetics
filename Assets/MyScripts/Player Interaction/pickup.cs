using UnityEngine;
using System.Collections;

public class pickup : MonoBehaviour {
	//Capture Bool

	public bool Active;
	public GameObject bun;
	
	void Start(){
		Active = false;
	}
	
	void Update(){
		// Deactivate hold if not holding anything
		if (Active && !playerVars.holding) {
			Active = false;
		}
		if(Input.GetKeyDown(KeyCode.Space)){
			if(Active){
				Active = false;
				playerVars.setHolding(false);
				bun = null;
			}else{
				Active = true;
			}
		}
		if(Active){
			renderer.material.color = Color.green;	
		}else{
			renderer.material.color = Color.red;
		}
		if (playerVars.holding) {
			renderer.material.color = Color.clear;	
		} else {
			//Active = false;
			bun = null;
		}

		if (playerVars.holding == true) {
			if (bun != null){
				bun.transform.position = transform.position;
			}
		}

	}

	// An object enters the pick up area in front of the player
	void OnTriggerEnter(Collider target){
		// If the player performs the pickup action and is not already holding something
		if(Active && !playerVars.holding){
			// Pick up the wild bunny and mark it as in your inventory
			if(target.tag == "wild"){
				target.tag = "inventory";
				playerVars.setHolding(true);
				bun = target.gameObject;
			}
		}
	}

	// An object remains in front of the player
	void OnTriggerStay(Collider target){
		// If the player isn't holding something and activtes the pickup action
		// pick up a bunny and put it in your inventory
		if(Active && !playerVars.holding){
			if(target.tag == "wild"){
				target.tag = "inventory";

				playerVars.setHolding(true);
				//bun = target;
				bun = target.gameObject;
			}
		}
		// If the bunny is already in your inventory
		if(target.tag == "inventory"){
			target.rigidbody.velocity = Vector3.zero;

			//target.transform.position = transform.position;
			// Scramble its DNA
			if(Input.GetKeyDown(KeyCode.O)){
				testDNA scramblee = target.GetComponent<testDNA>();
				foreach(gene g in scramblee.actual.genes) {
					g.T1 = Random.Range(0f, 1f) > .5f;
					g.T2 = Random.Range(0f, 1f) > .5f;
					g.trait1 = Random.Range(0f, 1f);
					g.trait2 = Random.Range(0f, 1f);
				}
			}
		}
		// If the hold is deactivated, set the velocity on the bunny to zero and reset tag and isholding bool
		if(!Active){
			if(target.tag == "inventory"){
				target.tag = "wild";
				target.rigidbody.velocity = Vector3.zero;
				//HaveOne = false;
				playerVars.setHolding(false);
				//bun = null;
				//bun = null;
			}
		}
	}

	// An item leaves the players grasp
	void OnTriggerExit(Collider target){
		if(target.tag == "inventory"){
			target.tag = "wild";
			//HaveOne = false;
			playerVars.setHolding(false);
			//bun = null;
			//bun = null;
		}
	}
	
	
	
}
