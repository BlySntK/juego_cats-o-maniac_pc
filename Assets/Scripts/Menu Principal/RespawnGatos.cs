using UnityEngine;
using System.Collections;

public class RespawnGatos : MonoBehaviour {

	public GameObject gatito;
	Vector3 posicion;
	Quaternion rotate;
	float tiempoSalida;
	float rotationY = -27.49f;
	float posX = 57.73f;
	float posY = -11.5f;
	float posZ = -82.61f;
	float random;


	void Update () {

		if (random == 0) {
			random = Random.Range (5, 10);
			tiempoSalida = random;
		}

		posicion = new Vector3 (posX, posY, posZ);
		rotate.eulerAngles = new Vector3 (0, rotationY, 0);

		if (tiempoSalida > 0)
			tiempoSalida -= Time.deltaTime;
		else{
			Instantiate (gatito, posicion, rotate);
			random = 0;
		}
	}
}
