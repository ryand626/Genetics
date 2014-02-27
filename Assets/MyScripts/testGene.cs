using UnityEngine;
using System.Collections;

public class testGene : MonoBehaviour {
	public gene[] genes = new gene[20];
	void Awake() {
//		InitGenes();
	}
	public void InitGenes() {
		for(int i = 0; i < genes.Length; i++) {
			genes[i] = new gene();
		}
	}
}

[System.Serializable]
public class gene {
	public bool T1, T2;
	public float trait1, trait2;
	
	public gene() {
		T1 = true;
		T2 = true;
		trait1 = 1;
		trait2 = 1;
	}
	
	public override string ToString() {
		return string.Format("Gene: {0}, {1}, {2}, {3}", T1, T2, trait1, trait2);
	}
}
