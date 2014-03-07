using UnityEngine;
using System.Collections;

public class readjust : MonoBehaviour {
	// Object references
	Transform background;
	Transform myText;

	// box constraints
	private int stringHeight;
	private int stringLength;

	// Scaling Factors
	public float boxScale;
	public int yScale;

	// Where the choice links to
	public int whereTo;
	
	void Start () {
		yScale = 3;
		background = transform.FindChild("ChoiceBackground");
		myText = transform.FindChild("ChoiceText");
		boxScale = .25f;
	}

	// Scale Choice Background
	void Update () {
		stringLength = transform.parent.parent.FindChild("Text").gameObject.GetComponent<Gen1Script>().choiceTextWidth;
//		print ("STRING LENGTH: " + stringLength);
		stringHeight = yScale * (2 + Mathf.FloorToInt(myText.GetComponent<TextMesh>().text.Length / stringLength));
		background.localScale = new Vector3(stringLength * boxScale, 
		                                    stringHeight * boxScale,
		                                    background.localScale.z);
	}
}
