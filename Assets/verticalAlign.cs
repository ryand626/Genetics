using UnityEngine;
using System.Collections;

public class verticalAlign : MonoBehaviour {
	public Transform [] choices;
	float total;
	public float buffer;
	public float ScaleFactor;
	//int size;

	void Start () {
		ScaleFactor = .7f;
		//size = transform.childCount;
		buffer = 0f;
		updateArray();
		align();
	}
	
	void Update () {
		updateArray();
		align();
	}

	void updateArray(){
		choices = new Transform[transform.childCount];
		for(int i = 0; i < transform.childCount; i++){
			choices[i] = transform.GetChild(i);
		}
	}

	// TODO: FIX THIS
	void align(){
		total = 0;
		for(int i = 0; i < choices.Length;i++){
			total += choices[i].FindChild("ChoiceBackground").lossyScale.y * 2f;
			total += buffer;
		}
		total -= buffer;
		float pos = total * ScaleFactor / 2f;
		//print("POS: " + pos);

		for(int i = 0; i < choices.Length; i++){
			pos -= choices[i].FindChild("ChoiceBackground").lossyScale.y * ScaleFactor;
			choices[i].transform.position = new Vector3(transform.position.x,transform.position.y + pos, transform.position.z);
			pos -= ((choices[i].lossyScale.y) + buffer) * ScaleFactor;
		}
	}
}
