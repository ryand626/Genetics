using UnityEngine;
using System.Collections;

public class bunny_behavior : MonoBehaviour {
	//Genetic Information
	public float jumpstrength;
	public float rotationSpeed;
	public float xSpeed;
	public float zSpeed;
	public AudioSource Sound;
	public float changeDirection;
	//private Quaternion myRotation;
	//Bool for jumping
	bool hoplatch;

	void Start () {
		//jumpstrength = 20f;
		hoplatch = false;
		//myRotation = transform.rotation;

	}
	
	void Update () {
		if(hoplatch){
			if(Random.Range(0, 250) == 0){
				Sound.volume = 5f;
				Sound.Play();
				rigidbody.velocity = Vector3.up*jumpstrength;
				rigidbody.velocity += Vector3.forward*xSpeed;
				rigidbody.velocity += Vector3.right*zSpeed;
				
				if(Random.Range(0f,1f) < changeDirection){
					rotationSpeed = -rotationSpeed;
				}
				
			}else{
				transform.Rotate(0,Random.Range(0,rotationSpeed),0);	
			}
			hoplatch = false;
			
		}	
		//myRotation = new Quaternion(0,transform.rotation.y,0,0);
		//transform.rotation = Quaternion.Slerp(transform.rotation,myRotation, Time.deltaTime * 1f);
	}
	
	void OnCollisionStay(Collision target){
		
		if (target.transform.tag == "jump surface"){
			hoplatch = true;	
		}
	}	
}
