using UnityEngine;
using System.Collections;

public class RespawnGatos_3 : MonoBehaviour {

	public GameObject gatito;
	float tiempoSalida;
	float rotationY = -9.34f;
	Vector3 posicion;
	Quaternion rotacion;
	float posX = 73.59f;
	float posY = -11;
	float posZ = -94.12f;
	float random;


	void Update () {

		if (random == 0) {
			random = Random.Range (8, 14);
			tiempoSalida = random;
		}

		posicion = new Vector3 (posX, posY, posZ);
		rotacion.eulerAngles = new Vector3 (0, rotationY, 0);

		if (tiempoSalida > 0)
			tiempoSalida -= Time.deltaTime;
		else{
			Instantiate (gatito, posicion, rotacion);
			random = 0;
		}
	}
}
