using UnityEngine;
using System.Collections;

public class Gen1Script : MonoBehaviour {
	// Player reference and position and ability to input
	public Transform player;
	private float xpos, ypos;
	private bool canInput = true;

	// Text variables
	private TextMesh myText;
	private int textIndex = 0;
	string oldMessage; // Previous message in box


	//Button Variables
	private MeshRenderer continueButton;
	bool onButton = false; // Check if player is over the button

	//Raycasting for player input
	private Ray mouseRay;

		
	// Initialization
	void Start () {
		oldMessage = "-";
		
		myText = transform.parent.FindChild("Text").GetComponent<TextMesh>();
		continueButton = transform.parent.FindChild("button").GetComponent<MeshRenderer>();
		
		StartCoroutine (selector());
		StartCoroutine(talk());
		StartCoroutine(button());
		
	}
	
	// Show the cursor if the player can input
	void Update () {
		if (canInput) {
			Screen.showCursor = true;
		}
	}

	// TODO: DELETE THIS MAYBE
	IEnumerator selector(){
		while (true) {
			yield return null;
		}
	}
	
	
	IEnumerator button(){
		RaycastHit hit;
		while (true) {
			// Dubugging to see ray exists
			mouseRay = transform.parent.camera.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay (mouseRay.origin, mouseRay.direction*50,Color.blue,1);

			// Checking button collision updating the text index accordingly
			if(Physics.Raycast(mouseRay, out hit,50)){
				if(hit.collider.name == "button"){
					if(continueButton.gameObject.GetComponent<glow>() == null){
						continueButton.gameObject.AddComponent<glow>();
					}
					onButton = true;
				}
			}else{
				if(continueButton.gameObject.GetComponent<glow>() != null){
					continueButton.gameObject.GetComponent<glow>().noMore();
				}
				onButton = false;
			}
			if(onButton && canInput){
				if(Input.GetMouseButtonDown(0)){
					textIndex++;
				}
			}

			// Button rotates if it's enabled
			continueButton.enabled = canInput;

			if(continueButton.enabled){
				continueButton.transform.Rotate(0,1,0);
			}
			yield return null;
		}
	}


	// Gives a text scrolling effect
	IEnumerator textScroll(string text){
		StopCoroutine ("textScroll");
		if (oldMessage != text) {
			oldMessage = text;
			myText.text = "";
			for (int i = 0; i < text.Length; i++) {
				myText.text += text [i];
				yield return null;
			}
		}
		//oldMessage = text;
		
		yield return null;
	}

	void changeFace(string ID){
		transform.parent.FindChild("Face").GetComponent<MeshRenderer>().material = (Material)Resources.Load(ID);
	}
	
	//ALL THE CONVERSATIONS
	IEnumerator talk(){
		while(true){
			if(Input.GetKeyDown(KeyCode.Return) && canInput){
				textIndex++;
			}
			switch(textIndex){
			case 0:
				canInput = false;
				changeFace("ProfGUI1");
				yield return StartCoroutine(textScroll("Hi there.  My name is Oak"));
				yield return new WaitForSeconds(2f);
				changeFace("NoFace");
				yield return StartCoroutine(textScroll( "No it's not"));
				yield return new WaitForSeconds(2f);
				changeFace("ProfGUI1");
				yield return StartCoroutine(textScroll("Quiet you"));
				yield return new WaitForSeconds(2f);
				textIndex++;
				break;
			case 1:
				yield return StartCoroutine(textScroll("Sorry about that"));
				canInput = true;
				break;
			case 2:
				yield return StartCoroutine(textScroll("Anyway's it's time you spent some time \nwith professor Moss"));
				break;
			case 3:
				canInput = false;
				changeFace("NoFace");
				yield return StartCoroutine(textScroll("Hold on.....wait"));
				yield return new WaitForSeconds(2f);
				yield return StartCoroutine(textScroll("Almost got the display working"));
				yield return new WaitForSeconds(1f);
				changeFace("MossGUI1");
				yield return StartCoroutine(textScroll("GOT IT!"));
				yield return new WaitForSeconds(1f);
				textIndex++;
				break;
			case 4:
				yield return StartCoroutine(textScroll("Hi. I'm Professor Moss!"));
				canInput = true;
				break;
			case 5:
				yield return StartCoroutine(textScroll("Today we're going to be breeding some\nbunnies!"));
				break;
			case 6:
				yield return StartCoroutine(textScroll("Start by navigating over there to my\nexposition dump! (the wall of text)"));
				break;
			case 7:
				GameObject playerchoice1 = (GameObject)Instantiate((GameObject)Resources.Load("PlayerChoice"));
				GameObject playerchoice2 = (GameObject)Instantiate((GameObject)Resources.Load("PlayerChoice"));
				GameObject playerchoice3 = (GameObject)Instantiate((GameObject)Resources.Load("PlayerChoice"));

				playerchoice2.transform.y = playerchoice1.transform.y-playerchoice1.transform.localScale;
			//	playerchoice.layer = 8;
				//playerchoice.renderer.material.color=Color.red;
				textIndex++;
				break;				                                  
			default:
				Screen.showCursor = false;
				canInput = false;
				//transform.parent.GetComponent<Camera>().enabled = false;
				//player.GetComponent<PlayerMovement>().canMove = true;
				break;
			}
			yield return null;
		}
	}
}
