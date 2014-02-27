using UnityEngine;
using System.Collections;

public class mutate : MonoBehaviour {
	public testGene basis;
	
	// Use this for initialization
	void Start () {
		if(basis == null) {
			basis = gameObject.GetComponent<testGene>();
		}
		basis.genes[0].T1=true;	
		basis.genes[0].trait1=.5f;
		basis.genes[0].T2=false;
		basis.genes[0].trait2=.5f;
	}
}
