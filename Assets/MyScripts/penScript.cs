using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class penScript : MonoBehaviour {
	public testGene gene;
	private List<testDNA> penPals = new List<testDNA>();
	private int numBunnies;
	
	private testDNA DNA;
	private PlayerMovement move;
	private GameObject targetBunny;
	
	void Start () {
		DNA = gameObject.AddComponent<testDNA>();
		numBunnies = 0;
		 
		DNA.P1 = gene;
		DNA.P2 = gene;
		DNA.actual = gene;
		DNA.StartExpress();
		
		renderer.material.color = new Color(DNA.express [4], DNA.express [1], DNA.express [2], DNA.express [3]);
		makeBunny();
	}
	
	void OnCollisionStay(Collision target){
		if(target.transform.tag == "Player") {
			move = target.transform.GetComponent<PlayerMovement>();
			if(move.avatar.transform.FindChild("Interact Sphere").transform.GetComponent<testCollision>().bun != null){
				if(Input.GetMouseButtonDown(2)){
					DNA = move.avatar.transform.FindChild("Interact Sphere").GetComponent<testCollision>().bun.GetComponent<testDNA>();
					renderer.material.color = new Color(DNA.express [4], DNA.express [1], DNA.express [2], DNA.express [3]);
				}
			}
			if(Input.GetMouseButtonDown(0)){
				makeBunny();
			}
		}
		if(target.transform.tag == "inventory"){
			if(Input.GetMouseButtonDown(2)){
				DNA = target.gameObject.GetComponent<testDNA>();
				renderer.material.color = new Color(DNA.express [4], DNA.express [1], DNA.express [2], DNA.express [3]);
			}
		}
	}
	
	void makeBunny(){
		//testDNA newDNA = GameObject.CreatePrimitive (PrimitiveType.Sphere).AddComponent<testDNA> ();
		GameObject bunny = (GameObject)Instantiate(Resources.Load("Bunny"));
		testDNA newDNA = bunny.AddComponent<testDNA>();
		//newDNA = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<bunny_behavior>();
		newDNA.P1 = DNA.P1;
		newDNA.P2 = DNA.P2;
		newDNA.actual = DNA.actual;
		newDNA.basis = DNA.basis;
		newDNA.StartExpress();
		newDNA.expressGenes();
		newDNA.transform.position = transform.position + Vector3.up * 5;
		newDNA.name = "DNA" + numBunnies;
		//newDNA.tag = "inventory";
		
		penPals.Add(newDNA);
		numBunnies++;
	}
}
