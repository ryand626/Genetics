﻿using UnityEngine;
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
		agent.Stop ();
	}

	void Update(){
        // Old Way of stopping navigation
//		if(Vector3.Distance(transform.position,target.position)<.86f){
//			playerVars.atDestination();
//		}
//		if (playerVars.reachedDestination) {
//			if(agent != null){
//				agent.Stop();
//			}
//		}

		// Better way of stopping navigation upon destination being reached
		if (agent.remainingDistance == 0) {
			agent.Stop();
		}
	}
}
