using UnityEngine;
using System.Collections;

public class previewDNA : MonoBehaviour {
	// Debug
	public bool testBool;

	// Bunny inormation
	public testGene gene;
	private testDNA DNA;
	private GameObject displayBunny;

	// Interface
	public buttonPedestal button;
	public GeneTransfer cable;


	// Use this for initialization
	void Start () {
		testBool = false;
		makeDisplayBunny ();
	}

	void Update () {
		if (Input.GetKeyDown (KeyCode.G)) {
			print ("boop");
			testBool = !testBool;
		}

		// If the player presses the button while there is a bunny inside make it take the bunny in
//		if (testBool == true && gene != null && displayBunny == null) {
//			print("Bunny?");
//			makeDisplayBunny ();
//		}

		// If the button is pressed, but there is already a bunny inside, eject the bunny and set the color back to the default
		if (testBool == true && displayBunny != null) {
			print("no more bunny");
			displayBunny.rigidbody.velocity = new Vector3(3f,5f,6f);
			displayBunny = null;
			gene = null;
		//	cable.DNA = null;
			renderer.material.color = new Color(1,1,1,renderer.material.color.a);
			testBool = false;
		}

		// BUNNY!
		if (displayBunny != null) {
			displayBunny.transform.position = transform.position;
			displayBunny.transform.Rotate (new Vector3 (0f, 1f, 0f));
		}
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
		cable.DNA = DNA;

		renderer.material.color = new Color(DNA.express [4], DNA.express [1], DNA.express [2], renderer.material.color.a);
		testBool = false;
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
//		if (displayBunny == null) {
//			if (target.gameObject.GetComponent<testDNA> () != null) {
//				gene = target.gameObject.GetComponent <testDNA> ().actual;
//			}
//		}

		if (target.rigidbody != null && target != displayBunny && !target.rigidbody.isKinematic) {
			target.rigidbody.velocity = -5f * (transform.position - target.transform.position);
		}

		if (target.tag == "inventory" && displayBunny == null) {
			displayBunny = target.gameObject;
			DNA = target.GetComponent<testDNA>();
			gene = DNA.actual;
			renderer.material.color = new Color(DNA.express [4], DNA.express [1], DNA.express [2], renderer.material.color.a);
			displayBunny.tag = "display";
			cable.DNA = DNA;
			testBool = false;

		}

	}
	void OnTriggerExit(Collider target){
		if (target.tag == "display") {
			target.tag = "wild";
		}
	}
}
