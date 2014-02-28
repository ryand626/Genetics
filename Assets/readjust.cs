using UnityEngine;
using System.Collections;

public class readjust : MonoBehaviour {
	Transform background;
	Transform myText;

	float xSize,ySize;

	public int stringLength;
	public float textSize;

	// Where the choice links to
	public int whereTo;


	void Start () {
		background = transform.FindChild("ChoiceBackground");
		myText = transform.FindChild("ChoiceText");
		stringLength = 20;
		textSize = .2f;
	}
	
	// Update is called once per frame
	void Update () {
		xSize = Mathf.Floor(myText.GetComponent<TextMesh>().text.Length /*% stringLength*/);
		ySize = 2 + Mathf.Floor(myText.GetComponent<TextMesh>().text.Length / stringLength);
		print(xSize + " " + ySize);

		background.localScale = new Vector3(xSize * textSize, 
		                                    ySize * textSize,
		                                    background.localScale.z);

	}
}
