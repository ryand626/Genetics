using UnityEngine;
using System.Collections;

public class readjust : MonoBehaviour {
	Transform background;
	Transform myText;

	float xSize,ySize;

	public float scaleFactor;
	public float textSize;

	// Where the choice links to
	public int whereTo;


	void Start () {
		background = transform.FindChild("ChoiceBackground");
		myText = transform.FindChild("ChoiceText");
		scaleFactor = 25f;
		textSize = .25f;
	}
	
	// Update is called once per frame
	void Update () {
		xSize = 1f + myText.GetComponent<TextMesh>().text.Length % scaleFactor;
		ySize = 2f + myText.GetComponent<TextMesh>().text.Length / scaleFactor;
		print(xSize + " " + ySize);

		background.localScale = new Vector3(xSize * textSize, 
		                                    ySize * textSize,
		                                    background.localScale.z);

	}
}
