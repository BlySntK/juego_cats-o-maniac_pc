using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	float velocidad = 0.8f;
	Transform objetivo;
	[HideInInspector]
	public Transform seleccion;
	float vel_rotacion = 0.8f;
	int rango;
	VariablesGlobales vars;


	void Start () {

		rango = Random.Range (0, 7);
		
		vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		if (vars.d_easy) {
			if (vars.level == 4) {
				if (rango == 0) objetivo = GameObject.Find ("waypoint_1").transform;
				if (rango == 1) objetivo = GameObject.Find ("waypoint_2").transform;
				if (rango == 2) objetivo = GameObject.Find ("waypoint_3").transform;
				if (rango == 3) objetivo = GameObject.Find ("waypoint_4").transform;
				if (rango == 4) objetivo = GameObject.Find ("waypoint_5").transform;
				if (rango == 5) objetivo = GameObject.Find ("waypoint_6").transform;
				if (rango == 6) objetivo = GameObject.Find ("waypoint_7").transform;
				if (rango == 7) objetivo = GameObject.Find ("waypoint_8").transform;
			}else if (vars.level == 7) {
				if (rango == 0) objetivo = GameObject.Find ("waypoint_1").transform;
				if (rango == 1) objetivo = GameObject.Find ("waypoint_2").transform;
				if (rango == 2) objetivo = GameObject.Find ("waypoint_3").transform;
				if (rango == 3) objetivo = GameObject.Find ("waypoint_4").transform;
				if (rango == 4) objetivo = GameObject.Find ("waypoint_5").transform;
				if (rango == 5) objetivo = GameObject.Find ("waypoint_6").transform;
			}else if (vars.level == 10) {
				if (rango == 0) objetivo = GameObject.Find ("waypoint_7").transform;
				if (rango == 1) objetivo = GameObject.Find ("waypoint_8").transform;
				if (rango == 2) objetivo = GameObject.Find ("waypoint_9").transform;
				if (rango == 3) objetivo = GameObject.Find ("waypoint_10").transform;
				if (rango == 4) objetivo = GameObject.Find ("waypoint_11").transform;
				if (rango == 5) objetivo = GameObject.Find ("waypoint_12").transform;
			}
		}else if (vars.d_normal) {
			if (vars.level == 3) {
				if (rango == 0) objetivo = GameObject.Find ("waypoint_1").transform;
				if (rango == 1) objetivo = GameObject.Find ("waypoint_2").transform;
				if (rango == 2) objetivo = GameObject.Find ("waypoint_3").transform;
				if (rango == 3) objetivo = GameObject.Find ("waypoint_4").transform;
				if (rango == 4) objetivo = GameObject.Find ("waypoint_5").transform;
				if (rango == 5) objetivo = GameObject.Find ("waypoint_6").transform;
				if (rango == 6) objetivo = GameObject.Find ("waypoint_7").transform;
				if (rango == 7) objetivo = GameObject.Find ("waypoint_8").transform;
			}else if (vars.level == 6) {
				if (rango == 0) objetivo = GameObject.Find ("waypoint_1").transform;
				if (rango == 1) objetivo = GameObject.Find ("waypoint_2").transform;
				if (rango == 2) objetivo = GameObject.Find ("waypoint_3").transform;
				if (rango == 3) objetivo = GameObject.Find ("waypoint_4").transform;
				if (rango == 4) objetivo = GameObject.Find ("waypoint_5").transform;
				if (rango == 5) objetivo = GameObject.Find ("waypoint_6").transform;
			}else if (vars.level == 9) {
				if (rango == 0) objetivo = GameObject.Find ("waypoint_7").transform;
				if (rango == 1) objetivo = GameObject.Find ("waypoint_8").transform;
				if (rango == 2) objetivo = GameObject.Find ("waypoint_9").transform;
				if (rango == 3) objetivo = GameObject.Find ("waypoint_10").transform;
				if (rango == 4) objetivo = GameObject.Find ("waypoint_11").transform;
				if (rango == 5) objetivo = GameObject.Find ("waypoint_12").transform;
			}
		}if (vars.d_hard) {
			if (vars.level == 5) {
				if (rango == 0) objetivo = GameObject.Find ("waypoint_1").transform;
				if (rango == 1) objetivo = GameObject.Find ("waypoint_2").transform;
				if (rango == 2) objetivo = GameObject.Find ("waypoint_3").transform;
				if (rango == 3) objetivo = GameObject.Find ("waypoint_4").transform;
				if (rango == 4) objetivo = GameObject.Find ("waypoint_5").transform;
				if (rango == 5) objetivo = GameObject.Find ("waypoint_6").transform;
				if (rango == 6) objetivo = GameObject.Find ("waypoint_7").transform;
				if (rango == 7) objetivo = GameObject.Find ("waypoint_8").transform;
			}else if (vars.level == 8) {
				if (rango == 0) objetivo = GameObject.Find ("waypoint_1").transform;
				if (rango == 1) objetivo = GameObject.Find ("waypoint_2").transform;
				if (rango == 2) objetivo = GameObject.Find ("waypoint_3").transform;
				if (rango == 3) objetivo = GameObject.Find ("waypoint_4").transform;
				if (rango == 4) objetivo = GameObject.Find ("waypoint_5").transform;
				if (rango == 5) objetivo = GameObject.Find ("waypoint_6").transform;
			}else if (vars.level == 11) {
				if (rango == 0) objetivo = GameObject.Find ("waypoint_7").transform;
				if (rango == 1) objetivo = GameObject.Find ("waypoint_8").transform;
				if (rango == 2) objetivo = GameObject.Find ("waypoint_9").transform;
				if (rango == 3) objetivo = GameObject.Find ("waypoint_10").transform;
				if (rango == 4) objetivo = GameObject.Find ("waypoint_11").transform;
				if (rango == 5) objetivo = GameObject.Find ("waypoint_12").transform;
			}
		}
		seleccion = objetivo;
	}

	void Update () {

		RespawnCats respawn = GameObject.Find ("Gatitos").GetComponent<RespawnCats> ();
		Opciones pausar = GameObject.Find ("JuegoGeneral").GetComponent<Opciones> ();
		if (!pausar.pausa) {
			if (vars.d_easy) {
				if (vars.level == 4 && respawn.currentCat > 0 && seleccion != null) {
					transform.Translate (Vector3.forward * Time.deltaTime * velocidad);
					Quaternion rotation = Quaternion.LookRotation (seleccion.transform.position - transform.position);
					transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * vel_rotacion);
				}else if (vars.level == 7 && respawn.currentCat > 0 && seleccion != null) {
					transform.Translate (Vector3.forward * Time.deltaTime * velocidad);
					Quaternion rotation = Quaternion.LookRotation (seleccion.transform.position - transform.position);
					transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * vel_rotacion);
				}else if (vars.level == 10 && respawn.currentCat > 0 && seleccion != null) {
					transform.Translate (Vector3.forward * Time.deltaTime * velocidad);
					Quaternion rotation = Quaternion.LookRotation (seleccion.transform.position - transform.position);
					transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * vel_rotacion);
				}
			}else if (vars.d_normal) {
				if (vars.level == 3 && respawn.currentCat > 0 && seleccion != null) {
					transform.Translate (Vector3.forward * Time.deltaTime * velocidad);
					Quaternion rotation = Quaternion.LookRotation (seleccion.transform.position - transform.position);
					transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * vel_rotacion);
				}else if (vars.level == 6 && respawn.currentCat > 0 && seleccion != null) {
					transform.Translate (Vector3.forward * Time.deltaTime * velocidad);
					Quaternion rotation = Quaternion.LookRotation (seleccion.transform.position - transform.position);
					transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * vel_rotacion);
				}else if (vars.level == 9 && respawn.currentCat > 0 && seleccion != null) {
					transform.Translate (Vector3.forward * Time.deltaTime * velocidad);
					Quaternion rotation = Quaternion.LookRotation (seleccion.transform.position - transform.position);
					transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * vel_rotacion);
				}
			}else if (vars.d_hard) {
				if (vars.level == 5 && respawn.currentCat > 0 && seleccion != null) {
					transform.Translate (Vector3.forward * Time.deltaTime * velocidad);
					Quaternion rotation = Quaternion.LookRotation (seleccion.transform.position - transform.position);
					transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * vel_rotacion);
				}else if (vars.level == 8 && respawn.currentCat > 0 && seleccion != null) {
					transform.Translate (Vector3.forward * Time.deltaTime * velocidad);
					Quaternion rotation = Quaternion.LookRotation (seleccion.transform.position - transform.position);
					transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * vel_rotacion);
				}else if (vars.level == 11 && respawn.currentCat > 0 && seleccion != null) {
					transform.Translate (Vector3.forward * Time.deltaTime * velocidad);
					Quaternion rotation = Quaternion.LookRotation (seleccion.transform.position - transform.position);
					transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * vel_rotacion);
				}
			}
		}
	}
}
