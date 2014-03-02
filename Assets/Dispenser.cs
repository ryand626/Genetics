using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dispenser : MonoBehaviour {
	public testGene gene;
	public List<testDNA> penPals = new List<testDNA>();
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

	}
	
	public void Dispense(){
		print ("DISPENSE CALLED");
		GameObject bunny = (GameObject)Instantiate(Resources.Load("Bunny"));
		testDNA newDNA = bunny.AddComponent<testDNA>();
		newDNA.P1 = DNA.P1;
		newDNA.P2 = DNA.P2;
		newDNA.actual = DNA.actual;
		newDNA.basis = DNA.basis;
		newDNA.StartExpress();
		newDNA.expressGenes();
		newDNA.transform.position = transform.position + Vector3.up * 5;
		newDNA.rigidbody.velocity += Vector3.forward * 10f;
		newDNA.name = "DNA" + numBunnies;
		newDNA.tag = "inventory";
		
		penPals.Add(newDNA);
		numBunnies++;
	}
}
