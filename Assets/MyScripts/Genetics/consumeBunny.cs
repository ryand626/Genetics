using UnityEngine;
using System.Collections;

public class consumeBunny : MonoBehaviour {
	public string combo;
	public int traitNumber;
	public int goal;

	private testDNA bunnyDNA;

	private TextMesh text;

	void Start(){
		print ("RECEPTICLE PROBLEMS" + this.gameObject.name);
		this.text = this.transform.FindChild ("Goal").GetComponent<TextMesh> ();
	}

	public void show(){
		if(goal >= 0){
			if(text){
				text.text = goal.ToString();
			}
		}
	}

	public void setObjective(string newCombo, int newTraitNumber, int newGoal){
		combo = newCombo;
		traitNumber = newTraitNumber;
		goal = newGoal;
	}

	void OnTriggerStay(Collider target){

		if (target.tag == "inventory") {
			bunnyDNA = target.gameObject.GetComponent<testDNA>();
			if(goal > 0){
				if(combo == "D"){
					if(bunnyDNA.actual.genes[traitNumber].T1 && bunnyDNA.actual.genes[traitNumber].T2){
						EatBunny(target.gameObject);
					}
				}
				if(combo == "R"){
					if(!bunnyDNA.actual.genes[traitNumber].T1 && !bunnyDNA.actual.genes[traitNumber].T2){
						EatBunny(target.gameObject);
					}
				}
				if(combo == "H"){
					if(bunnyDNA.actual.genes[traitNumber].T1 && !bunnyDNA.actual.genes[traitNumber].T2){
						EatBunny(target.gameObject);
					}else if(!bunnyDNA.actual.genes[traitNumber].T1 && bunnyDNA.actual.genes[traitNumber].T2){
						EatBunny(target.gameObject);
					}

				}
			}
		}
	}

	void EatBunny(GameObject bunny){
		goal--;
		Destroy(bunny);
		show ();
		playerVars.setHolding (false);
	}
}
