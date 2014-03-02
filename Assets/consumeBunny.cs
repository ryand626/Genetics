using UnityEngine;
using System.Collections;

public class consumeBunny : MonoBehaviour {
	public string combo;
	public int traitNumber;

	private testDNA bunnyDNA;

	void Update () {
		combo = playerVars.combo;
		traitNumber = playerVars.traitNumber;
	}

	void OnTriggerStay(Collider target){
		if (target.tag == "inventory") {
			bunnyDNA = target.gameObject.GetComponent<testDNA>();
			if(combo == "D"){
				if(bunnyDNA.actual.genes[traitNumber].T1 && bunnyDNA.actual.genes[traitNumber].T2){
					Destroy(target.gameObject);
				}
			}
			if(combo == "R"){
				if(!bunnyDNA.actual.genes[traitNumber].T1 && !bunnyDNA.actual.genes[traitNumber].T2){
					Destroy(target.gameObject);
				}
			}
			if(combo == "H"){
				if(bunnyDNA.actual.genes[traitNumber].T1 && !bunnyDNA.actual.genes[traitNumber].T2){
					Destroy(target.gameObject);
				}
				if(!bunnyDNA.actual.genes[traitNumber].T1 && bunnyDNA.actual.genes[traitNumber].T2){
					Destroy(target.gameObject);
				}
			}
		}
	}
}
