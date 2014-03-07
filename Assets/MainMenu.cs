using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	private Ray mouseRay;
	private RaycastHit hit;

	public Camera menuCam;

	void Awake () {
		playerVars.initialize ();
	}

	void Update () {
		mouseRay = menuCam.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(mouseRay, out hit, 50) && Input.GetMouseButtonDown(0)) {
			if (hit.collider.name == "choice1"){
				Application.LoadLevel("Genetics Level 1");
			}
			if (hit.collider.name == "choice2"){
				Application.LoadLevel("Breed Demo");
			}
		}
	}
}
