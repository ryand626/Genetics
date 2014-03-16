using UnityEngine;
using System.Collections;

public class look : MonoBehaviour {
	public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.identity;
		//transform.LookAt (target);
	}
}
