using UnityEngine;
using System.Collections;

public class glow : MonoBehaviour {
	public Color myColor;
	public Color startColor;

	private Vector3 startScale;
	// Use this for initialization
	void Start () {
		startScale = transform.localScale;

		myColor = transform.GetComponent<MeshRenderer> ().material.color;
		startColor = transform.GetComponent<MeshRenderer> ().material.color;//new Color (myColor.r, myColor.g, myColor.b);
		StartCoroutine (glowin ());
	}

	IEnumerator glowin (){
		float theta = 0;
		while (true) {
			//print("GLOW BITCH");
			transform.GetComponent<MeshRenderer> ().material.color = new Color((startColor.r + 1f) * Mathf.Sin(theta) + startColor.r,
			                                                                   (startColor.g + 1f) * Mathf.Sin(theta) + startColor.g,
			                                                                   startColor.b * Mathf.Sin(theta) + startColor.b);
			transform.localScale = new Vector3(startScale.x * Mathf.Sin(theta) * .2f + startScale.x,
			                                   startScale.y,
			                                   startScale.z * Mathf.Sin(theta) * .2f + startScale.z);
			theta += .03f;
			yield return null;
		}
	}

	public void noMore (){
		//transform.GetComponent<MeshRenderer> ().material.color = myColor;
		//Destroy (this);
	//	yield return null;
		StopAllCoroutines ();
		StartCoroutine (theEnd ());

	}

	IEnumerator theEnd(){
		while (transform.GetComponent<MeshRenderer> ().material.color != startColor) {
			transform.GetComponent<MeshRenderer> ().material.color = Color.Lerp(transform.GetComponent<MeshRenderer> ().material.color,startColor,Time.deltaTime* 10f);
			//print ("bye");

			yield return null;
		}
		while (transform.localScale != startScale) {
			transform.localScale = Vector3.Lerp(transform.localScale, startScale,Time.deltaTime*10f);
			yield return null;
				
		}
		//print ("die");
		Destroy (this);
	}

}
