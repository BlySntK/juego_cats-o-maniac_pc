using UnityEngine;
using System.Collections;

public class MoveCatMenu : MonoBehaviour {

	float speed = 3;

	void Update () {

		transform.Translate (0, 0, speed * Time.deltaTime);
	}
}
