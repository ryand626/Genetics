using UnityEngine;
using System.Collections;

public class shimmer : MonoBehaviour {
	public Color shimmerColor;
	float red;
	float green;
	float blue;

	// Use this for initialization
	void Awake () {
		shimmerColor = new Color(.7f,.5f, .7f);
	}
	
	// Update is called once per frame
	void Update () {
		// Have each hue alternate at different rates
		red = shimmerColor.r + Mathf.Sin (Time.time + Mathf.PI / 2f) / 500f;
		green = shimmerColor.g + Mathf.Sin(Time.time) / 500f;
		blue = shimmerColor.b + Mathf.Sin(Time.time - Mathf.PI / 2f) / 500f;
		// Set the color using the new values
		shimmerColor = new Color (red, green, blue);

		gameObject.renderer.material.color = shimmerColor;
	}
}
