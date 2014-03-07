using UnityEngine;
using System.Collections;

public class testDNA : MonoBehaviour
{
	
	public testGene basis;
	public testGene P1;
	public testGene P2;
	public testGene actual;
	public float[] express = new float[20];
	private Rigidbody myPhysics;	
	// Use this for initialization
	void Awake ()
	{
		if (basis == null) {
			basis = new GameObject (name + "_Basis").AddComponent<testGene> ();
		}
		actual = (testGene)Instantiate (basis);
		actual.InitGenes ();
		if (P1 != null && P2 != null) {
			DoExpressionFlow ();
		}
	}
	
	//NOW UNUSED
	public static testDNA Create (string newName, testGene P1, testGene P2)
	{
		testDNA newDNA = GameObject.CreatePrimitive (PrimitiveType.Sphere).AddComponent<testDNA> ();
		//newDNA.renderer.
		//newDNA = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<bunny_behavior>();
		newDNA.name = newName;
		newDNA.P1 = P1;
		newDNA.P2 = P2;
		newDNA.DoExpressionFlow ();
		return newDNA;
	}
	
	public void DoExpressionFlow ()
	{
		makeDNA ();
		StartExpress ();
		expressGenes ();		
	}
	
	public void StartExpress ()
	{
		for (int i = 0; i < actual.genes.Length; i++) {
			if (actual.genes[i].T1 == actual.genes[i].T2) {
				express[i] = (actual.genes[i].trait1 + actual.genes[i].trait2) / 2f;
			}
			if (actual.genes[i].T1 && !actual.genes[i].T2) {
				express[i] = actual.genes[i].trait1;
			}
			if (!actual.genes[i].T1 && actual.genes[i].T2) {
				express[i] = actual.genes[i].trait2;
			}
		}
	}
	
	public void makeDNA ()
	{
		if (P1 != null || P2 != null) {
			for (int i = 0; i<20; i++) {
				if (Random.Range (0f, 1f) > .5f) {
					actual.genes [i].T1 = P1.genes[i].T1;
					actual.genes [i].T2 = P2.genes[i].T2;
					actual.genes [i].trait1 = P1.genes [i].trait1;
					actual.genes [i].trait2 = P2.genes [i].trait2;
				} else {
					actual.genes [i].T1 = P2.genes [i].T1;
					actual.genes [i].T2 = P1.genes [i].T2;
					actual.genes [i].trait1 = P2.genes [i].trait1;
					actual.genes [i].trait2 = P1.genes [i].trait2;				
				}
			}
		} else {
			print ("no parents for " + name);
			for (int i=0; i<20; i++) {
				actual.genes [i].T1 = basis.genes [i].T1;
				actual.genes [i].T2 = basis.genes [i].T2;
				actual.genes [i].trait1 = basis.genes [i].trait1;
				actual.genes [i].trait2 = basis.genes [i].trait2;
			}
		}
	}
	
	public void expressGenes ()
	{
		print ("EXPRESSIN GENES");
		transform.tag = "wild";
		
		//Add Genetic Appearance 
		Color myColor = new Color (express [4], express [1], express [2], express [3]);
		if (!renderer) {
			gameObject.AddComponent<MeshRenderer>();			
		}
		renderer.material.color = myColor;
		Vector3 scale = new Vector3(express[11],express[12],express[13]);
		transform.localScale = (express[14] + .5f ) * scale * 2;
		
		//create necessary physics structures
		if(!rigidbody){
			myPhysics = gameObject.AddComponent<Rigidbody>();
		}
		myPhysics = gameObject.GetComponent<Rigidbody>();
		myPhysics.freezeRotation = true;
		
		//Genetic Behavior initialization
		bunny_behavior behavior = gameObject.AddComponent<bunny_behavior>();
		behavior.jumpstrength = express[8] * 4f;
		behavior.rotationSpeed = express[9] * 3f;
		behavior.xSpeed = express[10]*3f;
		behavior.zSpeed = express[15]*3f;
		behavior.Sound = gameObject.AddComponent<AudioSource>();
		behavior.changeDirection = express[19];
		
		if(express[16]<.5f){
			behavior.Sound.clip = (AudioClip)Resources.Load("bun1");
		}else{
			behavior.Sound.clip = (AudioClip)Resources.Load("bun2");
		}
		behavior.Sound.volume = express[17];
		behavior.Sound.pitch = express[18];
		
		
		//transform.position = new Vector3 (10f * express [5], 10f * express [6], 10f * express [7]);
	}
}

public class GenesData {
	public const int NUM_BABIES = 0;

}

//WHAT GENES ARE WHAT
/*
 * 0-Number of Babies
 * 1-green
 * 2-blue
 * 3-alpha
 * 4-red
 * 5-x position  UNUSED
 * 6-y psition   UNUSED
 * 7-z position  UNUSED
 * 8-jumpstrength
 * 9-rotation speed
 * 10-xSpeed
 * 11-x proportion
 * 12-y proportion
 * 13-z proportion
 * 14-size
 * 15-zSpeed
 * 16-Which cry (1 lower half 2 upper half)
 * 17-How loud
 * 18-pitch
 * 19-direction change probability
 * */

