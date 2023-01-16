using UnityEngine;
using System.Collections;

public class DestruirGato_3 : MonoBehaviour {

	float tiempoDestroy = 40;

	void Update () {

		if (tiempoDestroy > 0)
			tiempoDestroy -= Time.deltaTime;
		else
			Destroy (gameObject);
	}
}
