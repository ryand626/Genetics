using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class moodMusic : MonoBehaviour {
	public GameObject bunnyTemplate;
	public testDNA P1;
	public testDNA P2;
	
	public List<testDNA> bunnies = new List<testDNA>();
	private testDNA MyDNA;
	
	public bool babyTime;
	
	void Start () {
		babyTime = false;

	}
	
	void Update(){
		if(!babyTime){
			if(P1 != null && P2 != null){
				babyTime = true;
			}
		}else{
			ActivateBabyProcess();
		}
	}
	
	public void ActivateBabyProcess(){
		MyDNA = new GameObject("MyDNA").AddComponent<testDNA>();
		MyDNA.P1 = P1.actual;
		MyDNA.P2 = P2.actual;
		
		MyDNA.DoExpressionFlow();
		
		for(int i = 0; i < MyDNA.express[0]*5; i++) {
			
			//GameObject bunny = (GameObject)Instantiate(bunnyTemplate);
			//GameObject bunny = (GameObject)Instantiate(Resources.Load("Bunny"));
			testDNA newDNA = bunnyTemplate.AddComponent<testDNA>();
			//newDNA = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<bunny_behavior>();
			newDNA.P1 = P1.actual;
			newDNA.P2 = P2.actual;
			newDNA.basis = P1.basis;
			newDNA.makeDNA();
			newDNA.StartExpress();
			newDNA.expressGenes();
			
			newDNA.transform.position = transform.position ;//+ Vector3.up * 5;
			//newDNA.name = "DNA" + numBunnies;
			
			bunnies.Add(newDNA);	
			//bunnies.Add(testDNA.Create("Bunny " + i, P1.actual, P2.actual));
			bunnies[i].tag = "In Machine";
		}
		
		P1 = null;
		P2 = null;
		
		babyTime = false;

	}
}