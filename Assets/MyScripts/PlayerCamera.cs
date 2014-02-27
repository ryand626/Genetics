using UnityEngine;
using System.Collections;

public class PlayerCameras: MonoBehaviour {
	public Transform target;
	
	
	// Use this for initialization
	void Start () {
		camera.enabled=true;
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target);
	}
}
			 