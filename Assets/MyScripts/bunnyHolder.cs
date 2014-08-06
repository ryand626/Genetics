using UnityEngine;
using System.Collections;

public class bunnyHolder : MonoBehaviour {

	public GameObject bunny;

	void Start(){
		bunny = null;
	}

	void OnTriggerStay(Collider target){
		if (target.tag == "inventory") {
			target.tag = "Parent";
			target.transform.position = transform.position;
			bunny = target.gameObject;
		}

	}
}
