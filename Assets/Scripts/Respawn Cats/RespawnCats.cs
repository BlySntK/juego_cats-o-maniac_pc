using UnityEngine;
using System.Collections;

public class RespawnCats : MonoBehaviour {

	public GameObject cat;
	int maxCats; 
	public int currentCat = 0, descuento = 0; //Variables dependientes de muerte de gato
	public int level; //Variable que aumentara conforme pasemos niveles
	public long contador = 0;
	bool easy, normal, hard, street; //Variables elegidas en la escena de eleccion de nivel y dificultad
	float posicionZ, posicionX;
	
	

	void Update () {

		//Capturamos la dificultad elegida y para saber cuanta cantidad de gatos queremos instanciar
		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		hard = vars.d_hard;
		easy = vars.d_easy;
		normal = vars.d_normal;
		street = vars.street;
		level = vars.level;

		//Nivel Callejuelas, modo dificil
		if (hard && street) {
			if (level == 5)
				maxCats = 5;
			else if (level == 8)
				maxCats = 13;
			else if (level == 11)
				maxCats = 10;
		}

		//Nivel Callejuelas, modo facil
		if (easy && street) {
			if (level == 4)
				maxCats = 14;
			else if (level == 7)
				maxCats = 6;
			else if (level == 10)
				maxCats = 5;
		}

		//Nivel Callejuelas, modo normal
		if (normal && street) {
			if (level == 3)
				maxCats = 8;
			else if (level == 6)
				maxCats = 2;
			else if (level == 9)
				maxCats = 12;
		}
		//**************************************************************************************


		//Si hay Game Over no se instanciaran mas gatitos; si no lo hay, se instanciaran en las
		//coordenadas adecuadas y con el numero de "bichos" adecuado.
		GameOver over = GameObject.Find ("GameOver").GetComponent <GameOver> ();
		if (!over.end) {
			if (level == 3 && normal && street) {
				if (currentCat < maxCats && descuento <= 0) {
					posicionZ = Random.Range (-92.19f, -107.18f);
					Vector3 posCat = new Vector3 (transform.position.x, transform.position.y, posicionZ);
					Instantiate (cat, posCat, transform.rotation);
					currentCat++;
				}else if (currentCat == maxCats && descuento == 0)
					descuento = 6;
			}else if (level == 6 && normal && street) {
				if (currentCat < maxCats && descuento <= 0) {
					posicionZ = Random.Range (-88.99f, -97.82f);
					posicionX = Random.Range (122.34f, 129.323f);
					Vector3 posCat = new Vector3 (posicionX, transform.position.y, posicionZ);
					Instantiate (cat, posCat, transform.rotation);
					currentCat++;
				}else if (currentCat == maxCats && descuento == 0)
					descuento = 2;
			}else if (level == 9 && normal && street) {
				if (currentCat < maxCats && descuento <= 0) {
					posicionZ = Random.Range (-141.67f, -129.44f);
					posicionX = Random.Range (88.71f, 102.56f);
					Vector3 posCat = new Vector3 (posicionX, transform.position.y, posicionZ);
					Instantiate (cat, posCat, transform.rotation);
					currentCat++;
				}else if (currentCat == maxCats && descuento == 0)
					descuento = 12;
			}

			if (level == 5 && hard && street) {
				if (currentCat < maxCats && descuento <= 0) {
					posicionZ = Random.Range (-92.19f, -107.18f);
					Vector3 posCat = new Vector3 (transform.position.x, transform.position.y, posicionZ);
					Instantiate (cat, posCat, transform.rotation);
					currentCat++;
				}else if (currentCat == maxCats && descuento == 0)
					descuento = 5;
			}else if (level == 8 && hard && street) {
				if (currentCat < maxCats && descuento <= 0) {
					posicionZ = Random.Range (-88.99f, -97.82f);
					posicionX = Random.Range (122.34f, 129.323f);
					Vector3 posCat = new Vector3 (posicionX, transform.position.y, posicionZ);
					Instantiate (cat, posCat, transform.rotation);
					currentCat++;
				}else if (currentCat == maxCats && descuento == 0)
					descuento = 13;
			}else if (level == 11 && hard && street) {
				if (currentCat < maxCats && descuento <= 0) {
					posicionZ = Random.Range (-141.67f, -129.44f);
					posicionX = Random.Range (88.71f, 102.56f);
					Vector3 posCat = new Vector3 (posicionX, transform.position.y, posicionZ);
					Instantiate (cat, posCat, transform.rotation);
					currentCat++;
				}else if (currentCat == maxCats && descuento == 0)
					descuento = 10;
			}

			if (level == 4 && easy && street) {
				if (currentCat < maxCats && descuento <= 0) {
					posicionZ = Random.Range (-92.19f, -107.18f);
					Vector3 posCat = new Vector3 (transform.position.x, transform.position.y, posicionZ);
					Instantiate (cat, posCat, transform.rotation);
					currentCat++;
				}else if (currentCat == maxCats && descuento == 0)
					descuento = 14;
			}else if (level == 7 && easy && street) {
				if (currentCat < maxCats && descuento <= 0) {
					posicionZ = Random.Range (-88.99f, -97.82f);
					posicionX = Random.Range (122.34f, 129.323f);
					Vector3 posCat = new Vector3 (posicionX, transform.position.y, posicionZ);
					Instantiate (cat, posCat, transform.rotation);
					currentCat++;
				}else if (currentCat == maxCats && descuento == 0)
					descuento = 6;
			}else if (level == 10 && easy && street) {
				if (currentCat < maxCats && descuento <= 0) {
					posicionZ = Random.Range (-141.67f, -129.44f);
					posicionX = Random.Range (88.71f, 102.56f);
					Vector3 posCat = new Vector3 (posicionX, transform.position.y, posicionZ);
					Instantiate (cat, posCat, transform.rotation);
					currentCat++;
				}else if (currentCat == maxCats && descuento == 0)
					descuento = 5;
			}
		}
		//**************************************************************************************
	}
}
