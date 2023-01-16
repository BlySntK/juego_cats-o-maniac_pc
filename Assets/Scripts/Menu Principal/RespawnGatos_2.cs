using UnityEngine;
using System.Collections;

public class RespawnGatos_2 : MonoBehaviour {

	public GameObject gatito;
	float tiempoSalida;
	float rotationY = -29.25f;
	Vector3 posicion;
	Quaternion rotacion;
	float posX = 83.42f;
	float posY = -11;
	float posZ = -130.83f;
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
