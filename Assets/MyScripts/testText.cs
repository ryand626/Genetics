using UnityEngine;
using System.Collections;

public class testText : MonoBehaviour {
	public Transform myText;
	public string playerText;
	public Transform myCamera;

	// Update is called once per frame
	void Update () {
		StartCoroutine(lookAtPlayer ());
		if(Input.GetMouseButtonDown(1)){
			myText.GetComponent<TextMesh>().text = playerText;
		}
	}

	IEnumerator lookAtPlayer(){
		myText.position = transform.position;
		myText.LookAt(myCamera.position);
		myText.Rotate(0,230,0);

		yield return null;
	}

}
 