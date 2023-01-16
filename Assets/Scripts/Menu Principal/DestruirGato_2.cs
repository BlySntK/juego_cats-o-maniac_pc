using UnityEngine;
using System.Collections;

public class DestruirGato_2 : MonoBehaviour {

	float tiempoDestroy = 6;

	void Update () {

		if (tiempoDestroy > 0)
			tiempoDestroy -= Time.deltaTime;
		else
			Destroy (gameObject);
	}
}
