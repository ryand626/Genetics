using UnityEngine;
using System.Collections;

public class firstNav : MonoBehaviour {
	public Transform target;
	NavMeshAgent agent;
	// Use this for initialization
	void Start () {
		agent = gameObject.GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	public void go () {
		agent.SetDestination(target.position);
	
	}

	public void stop(){

	}

	void Update(){
		if(Vector3.Distance(transform.position,target.position)<.5f){
			playerVars.atDestination();
		}
	}
}
