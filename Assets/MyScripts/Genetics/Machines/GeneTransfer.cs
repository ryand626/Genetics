using UnityEngine;
using System.Collections;

public class GeneTransfer : MonoBehaviour {

	public geneCrosser machine;
	public testDNA DNA;
	//public bool isChannelOn;

	public buttonPedestal button;


	void Update(){
		if (button.pressed == true) {
			print("button pressed");
			if(DNA != null){
				addToMachine();
			}
			button.pressed = false;
		}
	}

	public void addToMachine(){
		if (machine.P1 == null) {
			machine.P1 = DNA;
		} else if (machine.P2 == null) {
			machine.P2 = DNA;
		}
	}
}
