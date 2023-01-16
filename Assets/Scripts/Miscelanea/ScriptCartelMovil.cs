using UnityEngine;
using System.Collections;

public class ScriptCartelMovil : MonoBehaviour {

	float cartel_2 = 1.35f, cartel_1 = 1.02f, cartel_3 = 1.68f;
	float currentCartel = 0;
	float cambio = 6, speed = 0.3f;
	bool cambio_1, cambio_2, cambio_3, regresar;

	void Update () {

		if (currentCartel == 0)
			currentCartel = cartel_2;

		if (cambio > 0)
			cambio -= Time.deltaTime;
		else{
			if (!regresar) {
				if (currentCartel >= cartel_1 && !cambio_1)
					currentCartel -= speed * Time.deltaTime;
				else if (currentCartel <= cartel_1 && !cambio_1) {
					currentCartel = cartel_1;
					cambio_1 = true;
					cambio = 6;
				}
				else if (currentCartel <= cartel_2 && !cambio_2)
					currentCartel += speed * Time.deltaTime;
				else if (currentCartel >= cartel_2 && !cambio_2) {
					currentCartel = cartel_2;
					cambio_2 = true;
					cambio = 6;
				}else if (currentCartel <= cartel_3 && !cambio_3)
					currentCartel += speed * Time.deltaTime;
				else if (currentCartel >= cartel_3 && !cambio_3) {
					currentCartel = cartel_3;
					cambio_3 = true;
					cambio = 6;
				}
			}

			if (cambio_1 && cambio_2 && cambio_3)
				regresar = true;

			if (regresar) {
				if (currentCartel >= cartel_2 && cambio_3)
					currentCartel -= speed * Time.deltaTime;
				else if (currentCartel <= cartel_2 && cambio_3) {
					currentCartel = cartel_2;
					cambio_3 = false;
					cambio = 6;
				}else if (currentCartel >= cartel_1 && cambio_2)
					currentCartel -= speed * Time.deltaTime;
				else if (currentCartel <= cartel_1 && cambio_2) {
					currentCartel = cartel_1;
					cambio = 6;
					cambio_2 = false;
					regresar = false;
				}
			}
		}

		Renderer render = this.GetComponent<Renderer> ();
		render.material.mainTextureOffset = new Vector2 (currentCartel, 0);
	}
}
