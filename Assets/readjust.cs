using UnityEngine;
using System.Collections;

public class readjust : MonoBehaviour {
	Transform background;
	Transform myText;

	int xSize,ySize;

	public int stringLength;
	public float textSize;

	// Where the choice links to
	public int whereTo;


	void Start () {
		background = transform.FindChild("ChoiceBackground");
		myText = transform.FindChild("ChoiceText");
		stringLength = 12;
		textSize = .5f;
	}
	
	// Update is called once per frame
	void Update () {

		xSize = Mathf.FloorToInt(myText.GetComponent<TextMesh>().text.Length % stringLength);
		ySize = 2 + Mathf.FloorToInt(myText.GetComponent<TextMesh>().text.Length / stringLength);

		print("X: " + xSize + " Y: " + ySize);
//		background.localScale = new Vector3(stringLength * textSize, 
//		                                    ySize * textSize,
//		                                    background.localScale.z);
//
	}
}
