using UnityEngine;
using System.Collections;

public class consumeBunny : MonoBehaviour {
	public string combo;
	public int traitNumber;
	public int goal;

	private testDNA bunnyDNA;

	public void setObjective(string newCombo, int newTraitNumber, int newGoal){
		combo = newCombo;
		traitNumber = newTraitNumber;
		goal = newGoal;
	}

	void OnTriggerStay(Collider target){
		if (target.tag == "inventory") {
			bunnyDNA = target.gameObject.GetComponent<testDNA>();
			if(combo == "D"){
				if(bunnyDNA.actual.genes[traitNumber].T1 && bunnyDNA.actual.genes[traitNumber].T2){
					goal--;
					Destroy(target.gameObject);
				}
			}
			if(combo == "R"){
				if(!bunnyDNA.actual.genes[traitNumber].T1 && !bunnyDNA.actual.genes[traitNumber].T2){
					goal--;
					Destroy(target.gameObject);
				}
			}
			if(combo == "H"){
				if(bunnyDNA.actual.genes[traitNumber].T1 && !bunnyDNA.actual.genes[traitNumber].T2){
					Destroy(target.gameObject);
					goal--;
				}
				if(!bunnyDNA.actual.genes[traitNumber].T1 && bunnyDNA.actual.genes[traitNumber].T2){
					Destroy(target.gameObject);
					goal--;
				}
			}
		}
	}
}
