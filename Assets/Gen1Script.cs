using UnityEngine;
using System.Collections;

public class Gen1Script : MonoBehaviour {
	// Ability to input
	private bool canInput = true;

	// Text variables
	private TextMesh myText;
	string oldMessage; // Previous message in box
	
	// Continue Button Variables
	private MeshRenderer continueButton;
	bool onButton = false; // Check if player is over the button

	//Raycasting for player input
	private Ray mouseRay;
	private RaycastHit hit;

	// Player Input choice buttons
	private GameObject [] playerInputButtons;

	// Text widths
	public int BoxTextWidth;
	public int choiceTextWidth;


	// Dispense
	public Dispenser Dominant;
	public Dispenser Recessive;

	private Vector3 machine;
	public AddtoMachine machineScript;
		
	// Initialization
	void Start () {
		machine = new Vector3(0f,1f,12f);

		playerVars.setIndex(0);
		playerVars.EnableGUI();

		BoxTextWidth = 60;
		choiceTextWidth = 20;

		FillChoice();
		oldMessage = "-";
		
		myText = transform.parent.FindChild("Text").GetComponent<TextMesh>();
		continueButton = transform.parent.FindChild("button").GetComponent<MeshRenderer>();
		togglePlayerInput(false);

		StartCoroutine(talk());
		StartCoroutine(button());
	}

	// Show the cursor if the player can input
	void Update () {
		if (canInput) {
			Screen.showCursor = true;
		}
	}

	//Updates the Face of the person
	void changeFace(string ID){
		transform.parent.FindChild("Face").GetComponent<MeshRenderer>().enabled = (ID != "hide");
		transform.parent.FindChild("Face").GetComponent<MeshRenderer>().material = (Material)Resources.Load(ID);
	}

	// Update the playerInputButtons array by filling it with player choice objects
	void FillChoice(){
		playerInputButtons = new GameObject[transform.parent.FindChild("PlayerChoices").childCount];
		for(int i = 0; i < transform.parent.FindChild("PlayerChoices").childCount; i++){
			playerInputButtons[i] = transform.parent.FindChild("PlayerChoices").GetChild(i).gameObject;
		}
	}

	// Adds a player choice to player choices, then fills playerInputButtons with the new choice
	void addChoice(string choiceString, int whereTo){
		choiceString = addNewLine(choiceTextWidth, choiceString);

		GameObject newChoice = (GameObject)Instantiate(Resources.Load("PlayerChoice"));
		newChoice.transform.parent = transform.parent.FindChild("PlayerChoices");
		newChoice.transform.FindChild("ChoiceText").GetComponent<TextMesh>().text = choiceString;
		newChoice.transform.position = newChoice.transform.parent.position;

		newChoice.GetComponent<readjust>().whereTo = whereTo;
		newChoice.name = "PlayerChoice";

		FillChoice();
	}

	// Detects player input on a player choice.  Moves the textIndex to the point specified by whereTo
	void choose(){
		mouseRay = transform.parent.camera.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(mouseRay, out hit,50) && Input.GetMouseButton(0)){
			if(hit.collider.name == "ChoiceBackground"){
				playerVars.setIndex(hit.collider.transform.parent.GetComponent<readjust>().whereTo);
				removeChoices();
			}
		}		
	}

	// Removes all player choices from PlayerChoices
	void removeChoices(){
		Destroy(transform.parent.FindChild("PlayerChoices").gameObject);
		GameObject newChoices = (GameObject)Instantiate(Resources.Load("PlayerChoices"));

		newChoices.name = "PlayerChoices";
		newChoices.transform.parent = transform.parent;
		newChoices.transform.position = newChoices.transform.parent.position;
		newChoices.transform.Translate(6f,-3.5f,7f);

		FillChoice();
		togglePlayerInput(false);
	}
	
	//Toggles visibility of plyer choice buttons
	void togglePlayerInput(bool enable){
		for(int i = 0; i < playerInputButtons.Length; i++){
			MeshRenderer [] Childrens = playerInputButtons[i].GetComponentsInChildren<MeshRenderer>();
			foreach( MeshRenderer r in Childrens){
				r.enabled = enable;
			}
		}
	}
	
	// Continue button at bottom of screen
	IEnumerator button(){
		while (true) {
			// Dubugging to see ray exists
			mouseRay = transform.parent.camera.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay (mouseRay.origin, mouseRay.direction*50,Color.blue,1);

			// Checking button collision updating the text index accordingly
			if(Physics.Raycast(mouseRay, out hit,50)){
				if(hit.collider.name == "button"){
					// make button glow when selected
					if(continueButton.gameObject.GetComponent<glow>() == null){
						continueButton.gameObject.AddComponent<glow>();
					}
					onButton = true;
				}
			}else{
				// Remove glow when not selected
				if(continueButton.gameObject.GetComponent<glow>() != null){
					continueButton.gameObject.GetComponent<glow>().noMore();
				}
				onButton = false;
			}
			// If you click the button when you're allowed, you may continue
			if(onButton && canInput && Input.GetMouseButtonDown(0)){
				playerVars.proceed();
				canInput = false;
			}

			// Button rotates if it's enabled
			continueButton.enabled = canInput;
			if(continueButton.enabled){
				continueButton.transform.Rotate(0,1,0);
			}

			yield return null;
		}
	}
	string addNewLine(int wrapFactor, string oldString){
		string newString = "";
		bool insertNewline = false;

//		int buffer = 0;
		// Need to add first character manually to avoid text wrapping after first word
		newString += oldString[0];

		for(int i = 1; i < oldString.Length; i++){
			newString += oldString[i];
			if(i % wrapFactor == 0){
				insertNewline = true;
			}
			if(insertNewline && (oldString[i] == ' ')){
				newString += '\n';
				insertNewline = false;
			}
		}
		return newString;
	}


	// Gives a text scrolling effect
	IEnumerator textScroll(string text){
		StopCoroutine ("textScroll");
		if (oldMessage != text) {
			oldMessage = text;
			myText.text = "";
			for (int i = 0; i < text.Length; i++) {
				myText.text += text[i];
				yield return null;
			}
		}
		yield return null;
	}

	IEnumerator tell(string words){

		yield return StartCoroutine(textScroll(addNewLine(BoxTextWidth,words)));
		yield return new WaitForSeconds(2f);
	}

	//ALL THE CONVERSATIONS
	IEnumerator talk(){
		while(true){

			// Return can also advance narative
			if(Input.GetKeyDown(KeyCode.Return) && canInput){
				playerVars.proceed();
			}

			transform.parent.GetComponent<Camera>().enabled = playerVars.ActiveGUI;

			// Conversation Flow
			// The text Index tells you where you are in the narative
			switch(playerVars.textIndex){
			case 0:
				canInput = false;
				changeFace("MossGUI1");
				//StartCoroutine(tell ("You must be the new intern, what was your name?"));
				yield return StartCoroutine(textScroll(addNewLine(BoxTextWidth,/*"Hi there! Sorry about Melissa, she’s just friendly, I swear. \n" +*/
					                                   "You must be the new intern, what was your name?")));
				yield return new WaitForSeconds(2f);
				addChoice("I'd Rather Not Say", 2);
				addChoice("The Name's <PLAYER NAME>", 2);
				addChoice("*smoke bomb*", 2);
				//Recessive.Dispense();
				playerVars.proceed();
				break;
			case 1:
				togglePlayerInput(true);
				changeFace("hide");
				choose();
				break;
			case 2:
				changeFace("MossGUI1");
				yield return StartCoroutine(textScroll(addNewLine(BoxTextWidth, "What? Sorry I zoned out there for a second. " +
				                                       "Anyways, today you’ll be helping me breed some bunnies. " +
				                                       "Did you have any experience with genetics at the " +
				                                       "Belfast University of Technical Technology and Engineering Research?")));
				yield return new WaitForSeconds(2f);
				addChoice("I love punnett squares!", 4);
				addChoice("The only genes I know about are pants", 4);
				addChoice("I spliced a frog, and by spliced " +
						  "I mean that’s the sound it made" , 4);
				playerVars.proceed();
				break;
			case 3:
				togglePlayerInput(true);
				changeFace("hide");
				choose();
				break;
			case 4:
				changeFace("MossGUI1");
				yield return StartCoroutine(textScroll(addNewLine(BoxTextWidth,"Well everything they teach there is wrong anyways. " +
				                                       "You’re lucky. Today we’ll be breeding a special species of bunny, " +
				                                       "they’re actually closer to turnips, but nevermind that. " +
				                                       "Right now I want to show you the difference between a dominant " +
				                                       "trait and a recessive trait")));
				yield return new WaitForSeconds(2f);
				canInput = true;
				//playerVars.proceed();
				break;
			case 5:
				//Dominant.Dispense();
				//canInput = false;
				// Professor and Player walk over to the bunny pens
				playerVars.DisableGUI();
				playerVars.DisableMovement();
				firstNav mossNav = GameObject.Find("Moss").GetComponent<firstNav>();
				firstNav playerNav = GameObject.Find("player").GetComponent<firstNav>();
				mossNav.go();
				playerNav.go();

				Screen.showCursor = false;
				canInput = false;

				playerVars.proceed();
				break;
			case 6:
				print(playerVars.reachedDestination);
				if(playerVars.reachedDestination){
					playerVars.EnableGUI();
					playerVars.proceed();
				}
				break;
			case 7:
				changeFace("MossGUI1");
				yield return StartCoroutine(textScroll(addNewLine(BoxTextWidth,"Now you see, in my breed of bunnies, red fur is a dominant trait, " +
									                   "while white fur is recessive. If a red and white bunny breed, their offspring will be red, " +
									                   "The dominant trait “dominates” the other traits and prevents them from being expressed. " +
									                   "Here watch")));
				yield return new WaitForSeconds(2f);
				//playerVars.proceed();
				canInput = true;
				break;

			// Dispense Bunnies and make them move towards the machine
			case 8:
				Dominant.Dispense();
				Recessive.Dispense();
				playerVars.proceed();
				break;
			case 9:
				Dominant.penPals[0].transform.position = Vector3.Lerp(Dominant.penPals[0].transform.position, machine,Time.deltaTime);
				if(machineScript.P1 != null){
					playerVars.proceed();
				}
				break;
			case 10:
				Recessive.penPals[0].transform.position = Vector3.Lerp(Recessive.penPals[0].transform.position, machine,Time.deltaTime);
				if(machineScript.P2 != null){
					playerVars.proceed();
				}

				break;
			case 11:
				yield return new WaitForSeconds(2f);
				playerVars.proceed();
				break;
			case 12:
				machineScript.babyTime();
				playerVars.proceed();
				break;
			default:
				Screen.showCursor = false;
				canInput = false;
				playerVars.DisableGUI();
				break;
			}
			yield return null;
		}
	}
}
