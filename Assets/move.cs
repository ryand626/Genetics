using UnityEngine;
using System.Collections;

public class move : MonoBehaviour {
	public Transform target;
	public float PlayerSpeed;


	// Use this for initialization
	void Start () {
		PlayerSpeed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W)){
			transform.Translate(Vector3.forward * Time.deltaTime * PlayerSpeed);
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(-Vector3.forward * Time.deltaTime * PlayerSpeed);
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Translate(Vector3.left * Time.deltaTime * PlayerSpeed);
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Translate(-Vector3.left * Time.deltaTime * PlayerSpeed);
		}
	}
}
