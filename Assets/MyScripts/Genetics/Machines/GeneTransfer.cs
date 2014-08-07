using UnityEngine;
using System.Collections;


// Transfers the DNA of the bunny in the preview machine to the gene crossing machine
// by pressing the button
public class GeneTransfer : MonoBehaviour {

	public geneCrosser machine;
	public testDNA DNA;

	public bool isInMachine = false;
	public buttonPedestal button;

	void Update(){
		if (DNA == null) {
			machine.P1 = machine.P2 = null;
			renderer.material.color = Color.white;
			isInMachine = false;
			button.pressed = false;
		}

		if (button.pressed == true) {
			// If the button is pressed, there exists a bunny in the previewer and it's
			// DNA isn't in the machine, add it
			if(DNA != null){
				if(!isInMachine){
					addToMachine();
				}
			}
		}else{
			// Turn the cable off if the button isn't pressed
			renderer.material.color = Color.white;
			isInMachine = false;

			// clear data from machine when the transfer cable is off
			if (machine.P1 == DNA){
				machine.P1 = null;
			}
			if (machine.P2 == DNA){
				machine.P2 = null;
			}
		}
	}

	public void addToMachine(){
		if (machine.P1 == null) {
			machine.P1 = DNA;
		} else if (machine.P2 == null) {
			machine.P2 = DNA;
		}
		renderer.material.color = new Color(DNA.express [4], DNA.express [1], DNA.express [2]);
		isInMachine = true;
	}
}
