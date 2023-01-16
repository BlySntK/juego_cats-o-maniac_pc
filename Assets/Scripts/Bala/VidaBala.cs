using UnityEngine;
using System.Collections;

public class VidaBala : MonoBehaviour {

	float time = 3;


	void Update () {

		if (time > 0)
			time -= Time.deltaTime / 3;
		else
			Destroy (gameObject);
	}
}
