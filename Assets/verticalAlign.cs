using UnityEngine;
using System.Collections;

public class verticalAlign : MonoBehaviour {
	Transform [] choices;
	float total;
	public float buffer;
	int size;

	void Start () {
		size = transform.childCount;
		buffer = 0f;
		updateArray();
		align();
	}
	
	void Update () {
		if(size != transform.childCount){
			size = transform.childCount;
			updateArray();
			align();
		}
	}

	void updateArray(){
		choices = new Transform[transform.childCount];
		for(int i = 0; i < transform.childCount; i++){
			choices[i] = transform.GetChild(i);
		}
	}

	void align(){
		total = 0;
		for(int i = 0; i < choices.Length;i++){
			total += choices[i].FindChild("ChoiceBackground").localScale.y;
			total += buffer;
			print("TOTAL IS: " + total);
		}
		total -= buffer;
		float pos = total / 2f;

		for(int i = 0; i < choices.Length; i++){
			pos -= choices[i].FindChild("ChoiceBackground").localScale.y * .5f;
			choices[i].Translate(new Vector3(0, pos, 0));
			pos -= buffer + choices[i].localScale.y * .5f;
		}
	}
}
