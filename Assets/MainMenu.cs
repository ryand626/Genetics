using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	private Ray mouseRay;
	private RaycastHit hit;

	public Camera menuCam;

	public GameObject titleBar;
	public GameObject description;
	public GameObject selectScreen;

	public Color menuColor;
	float red;
	float green;
	float blue;


	void Awake () {
		menuColor = new Color(.5f,.5f, .5f);
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

		// Have varied menu colors

		// Have each hue alternate at different rates
		red = menuColor.r + Mathf.Sin (Time.time + Mathf.PI / 2f) / 500f;
		green = menuColor.g + Mathf.Sin(Time.time) / 500f;
		blue = menuColor.b + Mathf.Sin(Time.time - Mathf.PI / 2f) / 500f;
		// Set the color using the new values
		menuColor = new Color (red, green, blue);
		// Apply the color to each menu item
		titleBar.renderer.material.color = menuColor;
		description.renderer.material.color = menuColor;
		selectScreen.renderer.material.color = menuColor;
	}
}
