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

	// Player Input
	private GameObject [] playerInputButtons;

		
	// Initialization
	void Start () {
		FillChoice();
		oldMessage = "-";
		
		myText = transform.parent.FindChild("Text").GetComponent<TextMesh>();
		continueButton = transform.parent.FindChild("button").GetComponent<MeshRenderer>();
//		playerInputButtons = transform.parent.FindChild("PlayerChoices");
		togglePlayerInput(false);

		StartCoroutine (selector());
		StartCoroutine(talk());
		StartCoroutine(button());
		
	}

	void FillChoice(){
		playerInputButtons = new GameObject[transform.parent.FindChild("PlayerChoices").childCount];
		for(int i = 0; i < transform.parent.FindChild("PlayerChoices").childCount;i++){
			playerInputButtons[i] = transform.parent.FindChild("PlayerChoices").GetChild(i).gameObject;
			print("player input buttons: " + playerInputButtons[i].ToString());
		}
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
	//Updates the Face of the person
	void changeFace(string ID){
		transform.parent.FindChild("Face").GetComponent<MeshRenderer>().enabled = (ID != "hide");

		transform.parent.FindChild("Face").GetComponent<MeshRenderer>().material = (Material)Resources.Load(ID);
	}
	//Toggles visibility of input buttons
	void togglePlayerInput(bool enable){
		MeshRenderer [] Childrens = playerInputButtons[0].GetComponentsInChildren<MeshRenderer>();
		foreach( MeshRenderer r in Childrens){
			r.enabled = enable;
		}
	}


	
	//ALL THE CONVERSATIONS
	IEnumerator talk(){
		Debug.Log("AHOSDLKFD" + playerInputButtons[0].ToString());
		TextMesh choice1 = playerInputButtons[0].transform.FindChild("ChoiceText").GetComponent<TextMesh>();

		while(true){
			if(Input.GetKeyDown(KeyCode.Return) && canInput){
				textIndex++;
			}
			RaycastHit hit;
			mouseRay = transform.parent.camera.ScreenPointToRay(Input.mousePosition);

			switch(textIndex){
			case 0:
				canInput = false;
				changeFace("MossGUI1");
				yield return StartCoroutine(textScroll("Hi there! Sorry about Melissa, she’s just friendly, I swear. \n" +
					"You must be the new intern, what was your name?"));
				yield return new WaitForSeconds(2f);
				textIndex++;
				break;
			case 1:
				togglePlayerInput(true);
				changeFace("hide");
				choice1.text = "MY NAME IS MICHAEL WESTON\n....I USED TO BE A SPY";
				if(Physics.Raycast(mouseRay, out hit,50)){
					print(hit.collider.name);
					if(hit.collider.name=="ChoiceBackground"){
						togglePlayerInput(false);
						textIndex++;
						canInput = true;
					}
				}
				break;
				//yield return StartCoroutine(textScroll("Sorry about that"));
				//canInput = true;
				//break;
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
			default:
				Screen.showCursor = false;
				canInput = false;
				transform.parent.GetComponent<Camera>().enabled = false;
				//player.GetComponent<PlayerMovement>().canMove = true;
				break;
			}
			yield return null;
		}
	}
}
