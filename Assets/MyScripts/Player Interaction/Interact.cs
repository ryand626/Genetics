using UnityEngine;
using System.Collections;

public class Interacts : MonoBehaviour {
	public Transform player;
	bool isMoving = true;
	float sinComponent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Vector3.Distance(player.position, transform.position)<10){
			if(Input.GetKeyDown(KeyCode.Space)){
				isMoving=!isMoving;	
				
			}

		}
		if(isMoving){
			sinComponent = transform.position.x+Mathf.Sin(Time.time)*0.1f;
			//print("a herpa duurrr");	
			transform.position = new Vector3(sinComponent,0,0);
		}
	}
}
