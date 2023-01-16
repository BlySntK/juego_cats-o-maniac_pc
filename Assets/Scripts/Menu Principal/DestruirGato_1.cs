using UnityEngine;
using System.Collections;

public class DestruirGato_1 : MonoBehaviour {

	float tiempoDestroy = 18;

	void Update () {

		if (tiempoDestroy > 0)
			tiempoDestroy -= Time.deltaTime;
		else
			Destroy (gameObject);
	}
}
