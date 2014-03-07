using UnityEngine;
using System.Collections;

public class pickup : MonoBehaviour {
	
	void OnTriggerStay(Collider target){
		print ("c'mere");
		if(Input.GetKey(KeyCode.LeftShift)){
			print("you");
			target.transform.position = transform.position;
		}
	}
}
