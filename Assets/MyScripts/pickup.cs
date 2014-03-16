using UnityEngine;
using System.Collections;

public class pickup : MonoBehaviour {
	//Capture Bool
	public bool HaveOne;
	public bool Active;
	//public Collider bun;
	public GameObject bun;
	
	void Start(){
		HaveOne = false;
		Active = false;
	}
	
	void Update(){
		
		if(Input.GetKeyDown(KeyCode.Space)){
			if(Active){
				HaveOne = false;
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
		if(HaveOne){
			renderer.material.color = Color.clear;	
		}

		if (playerVars.holding == true) {
			if (bun != null){
				bun.transform.position = transform.position;
			}
		}

	}
	
	void OnTriggerEnter(Collider target){
		if(Active && !HaveOne){
			if(target.tag == "wild"){
				target.tag = "inventory";
				HaveOne = true;
			}
		}
	}
	void OnTriggerStay(Collider target){
		if(Active && !HaveOne){
			if(target.tag == "wild"){
				target.tag = "inventory";
				HaveOne = true;
				playerVars.setHolding(true);
				//bun = target;
				bun = target.gameObject;
			}
		}
		if(target.tag == "inventory"){

			//target.transform.position = transform.position;

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
		if(!Active){
			if(target.tag == "inventory"){
				target.tag = "wild";
				target.rigidbody.velocity = Vector3.zero;
				HaveOne = false;
				//bun = null;
				//bun = null;
			}
		}
	}
	
	void OnTriggerExit(Collider target){
		if(target.tag == "inventory"){
			target.tag = "wild";
			target.rigidbody.velocity = Vector3.zero;
			HaveOne = false;
			//bun = null;
			//bun = null;
		}
	}
	
	
	
}
