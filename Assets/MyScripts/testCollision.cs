using UnityEngine;
using System.Collections;

public class testCollision : MonoBehaviour {
	//Capture Bool
	public bool HaveOne;
	public bool Active;
	public Collider bun;
	
	void Start(){
		HaveOne = false;
		Active = false;
		//transform.position = transform.parent.position + 6 * Vector3.forward;
	}
	
	void Update(){

		if(Input.GetKeyDown(KeyCode.LeftShift)){
			if(Active){
				HaveOne = false;
				Active = false;
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

	}
	
	void OnTriggerEnter(Collider target){
		print ("COLLIDE" +" active "+ Active +" haveone: "+ HaveOne);
		if(Active && !HaveOne){
			if(target.tag == "wild"){
				target.tag = "inventory";
				HaveOne = true;

			}
			
		}
	}
	void OnTriggerStay(Collider target){

		if(Active && !HaveOne){
			print ("collidddd");
			if(target.tag == "wild"){
				target.tag = "inventory";
				HaveOne = true;
				bun = target;
				

			}
			
		}
		if(target.tag == "inventory"){
			//TODO: FIX THIS
			target.transform.position = transform.position;
			// ARMS
			//transform.parent.FindChild("LArm").Rotate(5,0,0);
			//transform.parent.FindChild("RArm").Rotate(-5,0,0);


			//DELETE?
			//target.rigidbody.velocity = (Mathf.Pow(Vector3.Distance(transform.position,target.transform.position),2)*(transform.position-target.transform.position));
			
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
			//ARMS
			//transform.parent.FindChild("LArm").rotation = new Quaternion(0,0,0,0);
			//transform.parent.FindChild("RArm").rotation = new Quaternion(0,0,0,0);
			
			if(target.tag == "inventory"){
				target.tag = "wild";
				target.rigidbody.velocity = Vector3.zero;
				HaveOne = false;
				bun = null;
			}
		}
	}
	
	void OnTriggerExit(Collider target){
		print ("EXIT");
		if(target.tag == "inventory"){
			target.tag = "wild";
			target.rigidbody.velocity = Vector3.zero;
			HaveOne = false;
			bun = null;
		}
	}

	
	
}
