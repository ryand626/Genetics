using UnityEngine;
using System.Collections;

public class GrowUp : MonoBehaviour {
	Vector3 originalScale;
	public int steps;

	void Start () {
		steps = 0;
		originalScale = transform.localScale;
	}

	void Update () {
		transform.localScale = Vector3.Lerp (originalScale * .5f, originalScale, steps * .001f);
		steps++;

		if (transform.localScale == originalScale) {
			Destroy(this);
		}
	}
}
