using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	private Ray mouseRay;
	private RaycastHit hit;

	public Camera menuCam;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mouseRay = menuCam.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(mouseRay, out hit, 50) && Input.GetMouseButtonDown(0)) {
			if (hit.collider.name == "choice1"){
				print("choice 1");
				Application.LoadLevel("Genetics Level 1");
			}
			if (hit.collider.name == "choice2"){
				print("choice 2");
				Application.LoadLevel("Breed Demo");
			}
		}
	}
}
