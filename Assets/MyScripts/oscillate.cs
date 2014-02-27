using UnityEngine;
using System.Collections;

public class oscillate : MonoBehaviour {
//	private bool up = true;
	private float theta;
	private Vector3 origin;
	// Use this for initialization
	void Start () {
		origin = transform.position;
		theta = 0;
		StartCoroutine(moveUp());
	}
	
	// Update is called once per frame
	void Update () {

		//transform.Translate(new Vector3(0,Mathf.Sin(Time.time)*.01f,0));
	}

	IEnumerator moveUp(){
		while(true){
			transform.position = new Vector3(origin.x,origin.y+ .09f*Mathf.Sin(theta),origin.z);
			theta+=.03f;
			yield return null;
	
		}
	}

	public void noMore(float rate){
		StopAllCoroutines ();
		StartCoroutine (deathWalk (rate));
	}

	IEnumerator deathWalk(float rate){
	
		while(transform.position != origin){
			transform.position = Vector3.Lerp(transform.position, origin, Time.deltaTime * 10f);
			//print ("bye");
	
			yield return null;
		}
		//print ("die");
		Destroy (this);

	}

	void OnDestroy(){

	}
}
