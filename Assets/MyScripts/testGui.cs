using UnityEngine;
using System.Collections;

public class testGui : MonoBehaviour {
	public Transform player;
	private float xpos, ypos;

	private TextMesh myText;
	private int textIndex = 0;
	private bool canInput = true;
	private MeshRenderer continueButton;

	private Ray mouseRay;

	bool onButton = false;
	string oldMessage;

	// Use this for initialization
	void Start () {
		oldMessage = "-";

		myText = transform.parent.FindChild("Text").GetComponent<TextMesh>();
		continueButton = transform.parent.FindChild("button").GetComponent<MeshRenderer>();

		StartCoroutine (selector());
		StartCoroutine(talk());
		StartCoroutine(button());

	}
	
	// Update is called once per frame
	void Update () {
		if (canInput) {
			Screen.showCursor = true;
		}
	}

	IEnumerator selector(){
		while (true) {
			yield return null;
		}
	}


	IEnumerator button(){
		RaycastHit hit;
		while (true) {
			mouseRay = transform.parent.camera.ScreenPointToRay(Input.mousePosition);
			Debug.DrawRay (mouseRay.origin, mouseRay.direction*50,Color.blue,1);
			
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

			continueButton.enabled = canInput;
			if(continueButton.enabled){
				continueButton.transform.Rotate(0,1,0);
			}
			yield return null;
		}
	}

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

	//ALL THE CONVERSATIONS
	IEnumerator talk(){
		while(true){
			if(Input.GetKeyDown(KeyCode.Return) && canInput){
				textIndex++;
			}
			switch(textIndex){
			case 0:
				canInput = false;
				transform.parent.FindChild("Face").GetComponent<MeshRenderer>().material = (Material)Resources.Load("ProfGUI1");
				yield return StartCoroutine(textScroll("Hi there.  My name is Oak"));
				yield return new WaitForSeconds(2f);
				transform.parent.FindChild("Face").GetComponent<MeshRenderer>().material = (Material)Resources.Load("NoFace");
				yield return StartCoroutine(textScroll( "No it's not"));
				yield return new WaitForSeconds(2f);
				transform.parent.FindChild("Face").GetComponent<MeshRenderer>().material = (Material)Resources.Load("ProfGUI1");
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
				transform.parent.FindChild("Face").GetComponent<MeshRenderer>().material = (Material)Resources.Load("NoFace");
				yield return StartCoroutine(textScroll("Hold on.....wait"));
				yield return new WaitForSeconds(2f);
				yield return StartCoroutine(textScroll("Almost got the display working"));
				yield return new WaitForSeconds(1f);
				transform.parent.FindChild("Face").GetComponent<MeshRenderer>().material = (Material)Resources.Load("MossGUI1");
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
				player.GetComponent<PlayerMovement>().canMove = true;
				break;
			}
			yield return null;
		}
	}
}
