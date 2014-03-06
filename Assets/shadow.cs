using UnityEngine;
using System.Collections;

public class shadow : MonoBehaviour {
	public bool eh1;
	public bool eh2;
	// Use this for initialization
	void Start () {
		renderer.useLightProbes = true;
	}
	
	// Update is called once per frame
	void Update () {
		renderer.castShadows = eh1;
		renderer.receiveShadows = eh2;
	}
}
