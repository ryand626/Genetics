using UnityEngine;
using System.Collections;

public class music : MonoBehaviour {

	// Use this for initialization
	void Start () {
			if(gameObject.GetComponent<AudioSource>() == null){
				AudioSource myMusic = gameObject.AddComponent<AudioSource>();
				myMusic.clip = (AudioClip)Resources.Load("testMusic");
				myMusic.loop = true;
				myMusic.volume = .1f;
				myMusic.Play();
			}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
