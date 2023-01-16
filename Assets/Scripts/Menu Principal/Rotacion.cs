using UnityEngine;
using System.Collections;

public class Rotacion : MonoBehaviour {


	float speedGiro = 65f;

	void Update () {

		transform.Rotate (0, speedGiro * Time.deltaTime, 0);
	}
}
