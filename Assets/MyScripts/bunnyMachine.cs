using UnityEngine;
using System.Collections;

public class bunnyMachine : MonoBehaviour {
	public bool Locked;
	public testDNA P1;
	public testDNA P2;
	public pickup sphere;
	Color startColor;
	
	void Start () {
		P1 = null;
		P2 = null;
		Locked = false;
		startColor = renderer.material.color;
	}
	
	void Update () {
		transform.Rotate(0,.5f,0);
		if(P1 != null && P2 != null){
			Locked = true;	
		}
		if(Locked){
			if(Input.GetMouseButtonDown(0)){
				babyTime();	
			}
		}
	}
	
	public void babyTime(){
		renderer.material.color = startColor;
		moodMusic genes = gameObject.AddComponent<moodMusic>();
		genes.bunnyTemplate = (GameObject)Instantiate(Resources.Load("Bunny"));
		genes.P1 = P1;
		genes.P2 = P2;
		genes.ActivateBabyProcess();
		Destroy(genes);
		Locked = false;
		P1 = null;
		P2 = null;
	}
	
	void OnTriggerEnter(Collider target){
		if(target.transform.tag == "inventory"){
			if(P1 == null){
				P1 = target.gameObject.GetComponent<testDNA>();
				
				//sphere.HaveOne = false;
				playerVars.setHolding(false);
				sphere.Active = false;
				
				target.transform.tag = "Parent";
				
				renderer.material.color = Color.gray;
				target.rigidbody.velocity = Vector3.zero;
			}else if(P2 == null){
				P2 = target.gameObject.GetComponent<testDNA>();	

				playerVars.setHolding(false);
				//sphere.HaveOne = false;
				sphere.Active = false;
				
				target.transform.tag = "Parent";
				target.rigidbody.velocity = Vector3.zero;	
				
				renderer.material.color = Color.yellow;
				
			}
		}
	}
	
	void OnTriggerStay(Collider target){
		if(!Locked){
			if(target.transform.tag == "In Machine"){
				target.rigidbody.AddForce(Vector3.up * 60f);	
			}
			
		}
		if(target.transform.tag == "Parent"){
			print(target.name);
			target.rigidbody.AddForce(Vector3.up * 60f);	
		}
	}
	
	void OnTriggerExit(Collider target) {
		if(target.transform.tag == "In Machine"){
			target.rigidbody.AddForce(Vector3.forward * -900f);
			target.transform.tag = "wild";	
		}
		if(target.transform.tag == "Parent"){
			target.rigidbody.AddForce(Vector3.forward * -900f);
			target.transform.tag = "wild";
		}
	}
}
