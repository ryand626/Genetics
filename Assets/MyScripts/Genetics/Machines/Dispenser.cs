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

	private GameObject displayBunny;

	public buttonPedestal button;
	
	void Start () {
		DNA = gameObject.AddComponent<testDNA>();
		numBunnies = 0;
		
		DNA.P1 = gene;
		DNA.P2 = gene;
		DNA.actual = gene;
		DNA.StartExpress();
		
		renderer.material.color = new Color(DNA.express [4], DNA.express [1], DNA.express [2], renderer.material.color.a);
		makeDisplayBunny ();

	}

	void Update(){
		if (button.pressed == true) {
			button.pressed = false;
			Dispense();
		}
		if (displayBunny != null) {
			displayBunny.transform.position = transform.position;
			displayBunny.transform.Rotate (new Vector3 (0f, 1f, 0f));
		}
	}

	public void makeDisplayBunny(){
		displayBunny = makeBunny ();
		displayBunny.GetComponent<testDNA>().tag = "inventory";
		displayBunny.transform.position = transform.position;
	}


	public void Dispense(){
		GameObject bunny = makeBunny ();
		bunny.GetComponent<testDNA>().tag = "inventory";
		bunny.transform.position = transform.position + Vector3.up * 5;
		bunny.rigidbody.velocity -= Vector3.forward * 10f;
		bunny.name = "DNA" + numBunnies;
		
		penPals.Add(bunny.GetComponent<testDNA>());
		numBunnies++;
	}

	public GameObject makeBunny(){
		GameObject bunny = (GameObject)Instantiate(Resources.Load("Bunny"));
		testDNA newDNA = bunny.AddComponent<testDNA>();
		newDNA.P1 = DNA.P1;
		newDNA.P2 = DNA.P2;
		newDNA.actual = DNA.actual;
		newDNA.basis = DNA.basis;
		newDNA.StartExpress();
		newDNA.expressGenes();
		newDNA.tag = "inventory";
		return bunny;
	}
}
