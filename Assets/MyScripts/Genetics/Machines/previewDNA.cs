using UnityEngine;
using System.Collections;

public class previewDNA : MonoBehaviour {
	// Bunny information
	public testGene gene;
	private testDNA DNA;
	private GameObject displayBunny;

	// Interface
	public buttonPedestal button;
	public GeneTransfer cable;

	void Start () {
		makeDisplayBunny ();
	}

	void Update () {
		// If the button is pressed, but there is already a bunny inside, eject the bunny and set the color back to the default
		if (button.pressed == true && displayBunny != null) {
			eject();
		}

		// BUNNY!
		if (displayBunny != null) {
			if(DNA == null){
				DNA = displayBunny.GetComponent<testDNA>();
				gene = DNA.actual;
				cable.DNA = DNA;
			}
			displayBunny.transform.position = Vector3.Lerp(displayBunny.transform.position, transform.position, .5f);
			displayBunny.transform.Rotate (new Vector3 (0f, 1f, 0f));
		}
	}

	public void eject(){
		displayBunny = null;
		gene = null;
		cable.DNA = null;
		renderer.material.color = new Color(1,1,1,renderer.material.color.a);
		button.pressed = false;
	}
	
	public void makeDisplayBunny(){
		DNA = new testDNA();
		
		DNA.P1 = gene;
		DNA.P2 = gene;
		DNA.actual = gene;
		DNA.StartExpress();
		displayBunny = makeBunny ();
		displayBunny.GetComponent<testDNA>().tag = "display";
		displayBunny.transform.position = transform.position;

	

		renderer.material.color = new Color(DNA.express [4], DNA.express [1], DNA.express [2], renderer.material.color.a);
		button.pressed = false;
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

	// put bunny in -> press button -> it grabs the gene information 
	void OnTriggerStay(Collider target){
		// Push out anything when a bunny is inside already
		if (displayBunny != null && target.rigidbody != null && target != displayBunny && !target.rigidbody.isKinematic) {
			target.rigidbody.velocity = -5f * (transform.position - target.transform.position);
		}
		// Add bunny when button pressed and the target inside is a bunny (in the inventory, being displayed, or wild)
		if ((target.tag == "inventory" || target.tag == "wild" || target.tag == "display") && displayBunny == null && button.pressed) {
			displayBunny = target.gameObject;
			DNA = target.GetComponent<testDNA>();
			gene = DNA.actual;
			renderer.material.color = new Color(DNA.express [4], DNA.express [1], DNA.express [2], renderer.material.color.a);
			displayBunny.tag = "display";
			cable.DNA = DNA;
			button.pressed = false;

		}
		if(button.pressed == false){
			if(target.tag == "display"){
				target.tag = "wild";
			}
		}

	}
	void OnTriggerExit(Collider target){
		if (target.tag == "display") {
			target.tag = "wild";
		}
	}
}
