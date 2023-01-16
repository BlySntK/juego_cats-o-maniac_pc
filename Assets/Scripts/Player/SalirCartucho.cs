using UnityEngine;
using System.Collections;

public class SalirCartucho : MonoBehaviour {

	public Rigidbody cartucho;
	public Disparar salirCartucho;
	float speed = 5;
	bool salir;
	public float timeWait = 1;



	void Update () {

		//En cuanto disparemos y retraigamos el cargador, saldra un cartucho mientras dispongamos de municion
		//En caso de hacer pausa o de mostrar las opciones principales o la introduccion, los cartuchos no saldran
		Reloading recargar = GameObject.Find ("Reloading").GetComponent<Reloading> ();
		Opciones hacerParon = GameObject.Find ("JuegoGeneral").GetComponent<Opciones> ();
		VariablesGlobales vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		if (vars.level == 3 || vars.level == 4 || vars.level == 5) {
			if (!hacerParon.ui_intro.enabled) {
				if (!hacerParon.opciones) {
					if (!hacerParon.pausa) {
						if (!recargar.reload && recargar.timeWaitShoot <= 0) {
							if (Input.GetButtonDown ("Fire1") && salirCartucho.contador < 2)
								salir = true;

							//Ejecutamos la instancia y esperamos el tiempo justo para que sea mas realista
							if (salir) {
								if (timeWait > 0)
									timeWait -= Time.deltaTime;
								else{
									Rigidbody fCartucho = (Rigidbody) Instantiate (cartucho, transform.position, transform.rotation);
									fCartucho.velocity = transform.TransformDirection (new Vector3 (-speed, 0, 0));
									timeWait = 1;
									salir = false;
								}
							}
						}
					}
				}
			}
		//Aqui ya no hay intro
		}else if (vars.level > 5 && vars.level < 12) {
			if (!hacerParon.opciones) {
				if (!hacerParon.pausa) {
					if (!recargar.reload && recargar.timeWaitShoot <= 0) {
						if (Input.GetButtonDown ("Fire1") && salirCartucho.contador < 2)
							salir = true;
						
						//Ejecutamos la instancia y esperamos el tiempo justo para que sea mas realista
						if (salir) {
							if (timeWait > 0)
								timeWait -= Time.deltaTime;
							else{
								Rigidbody fCartucho = (Rigidbody) Instantiate (cartucho, transform.position, transform.rotation);
								fCartucho.velocity = transform.TransformDirection (new Vector3 (-speed, 0, 0));
								timeWait = 1;
								salir = false;
							}
						}
					}
				}
			}
		}
	}
}
