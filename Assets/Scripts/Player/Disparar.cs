using UnityEngine;
using System.Collections;

public class Disparar : MonoBehaviour {

	public Rigidbody bala;
	public GameObject agujeroBala;
	float velocity = 30;
	const float TIEMPO_DISPARO = 1.5f;
	float tiempoDisparar = 1.5f;
	public int contador = 0; //Variable dependiente de la recargar y la salida del cartucho disparado
	public int contador_ui; //Variable que se mostrara en la interfaz
	bool disparo_;
	ContadorBalas cont;
	public Animator anim; //Variable dependiente de la recarga
	[HideInInspector]
	public bool disparo; //Variable encargada de instanciar una chispa ademas de disparar una bala
	public AudioClip clip;
	RaycastHit hit;
	NormalLevels __denegarDisparo; //Variable dependiente de NormalLevels
	HardLevels _denegarDisparo; //Variable dependiente de HardLevels
	EasyLevels _denegarDisparo_; //Variable dependiente de EasyLevels
	VariablesGlobales vars;



	void Awake () {

		vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		anim = GameObject.Find ("Shotgun Animated").GetComponent<Animator>();
		if (vars.level == 6 || vars.level == 9 ||
		    vars.level == 7 || vars.level == 10 ||
		    vars.level == 8 || vars.level == 11 && vars.street) {
			contador = vars.n_balas;
			contador_ui = contador;
		}
	}

	void Update () {

		//Una vez pulsamos en el boton disparo y si no estamos recargando
		//En caso de hacer pausa y de mostrar las opciones principales, el jugador se detendra y no disparara
		Reloading recargar = GameObject.Find ("Reloading").GetComponent<Reloading> ();
		Opciones noDisparar = GameObject.Find ("JuegoGeneral").GetComponent<Opciones> ();

		//Dependiendo de la dificultad seleccionada:
		if (vars.d_hard)
			_denegarDisparo = GameObject.Find ("JuegoGeneral").GetComponent<HardLevels> ();
		else if (vars.d_normal)
			__denegarDisparo = GameObject.Find ("JuegoGeneral").GetComponent<NormalLevels> ();
		else if (vars.d_easy)
			_denegarDisparo_ = GameObject.Find ("JuegoGeneral").GetComponent<EasyLevels> ();

		//Ademas, si destruimos al jugador, esta condicion impedira que haya error en el disparo o que
		//se dispare el arma si estamos en la introduccion.
		if (vars.d_hard)
			disparo_ = _denegarDisparo._disparo;
		else if (vars.d_easy)
			disparo_ = _denegarDisparo_._disparo;
		else if (vars.d_normal)
			disparo_ = __denegarDisparo._disparo;

		if (!disparo_) {
			if (vars.level == 3 || vars.level == 4 || vars.level == 5) {
				if (!noDisparar.ui_intro.enabled) {
					if (!noDisparar.opciones) {
						if (!noDisparar.pausa) {
							if (tiempoDisparar >= TIEMPO_DISPARO) {
								if (!recargar.reload && recargar.timeWaitShoot <= 0) {
									if (Input.GetKey (KeyCode.Mouse0) && !disparo) {
										//Mientras haya municion:
										if (contador < 2) {
											disparo = true;

											//Disparamos la bala
											Rigidbody _bala = (Rigidbody)Instantiate (bala, transform.position, transform.rotation);
											_bala.velocity = transform.TransformDirection (new Vector3 (0, 0, velocity));
											Camera camKornRak = GameObject.FindWithTag ("CamKornRak").GetComponent<Camera> ();
											
											//Establecemos un raycast para saber con que colisionamos desde el centro de la camara 
											//hacia delante y guardamos la colision establecida con el objeto al que miramos en hit
											if (Physics.Raycast (camKornRak.transform.position, camKornRak.transform.forward, out hit, 1000)) {
												//Agujereamos paredes
												Vector3 posBullet = hit.point;
												if (hit.collider.name == "Predio_A2")
													Instantiate (agujeroBala, posBullet, Quaternion.FromToRotation (Vector3.up, hit.normal));
											}

											//Ejecutamos la animacion y creamos una fuerza que sea la que impulse a la bala a salir en la direccion correcta
											anim.SetBool ("Fuego", true);

											//Instanciamos el sonido del disparo
											AudioSource _disparo = GetComponent<AudioSource>();
											_disparo.clip = clip;
											_disparo.Play ();

											//Controlamos que la recamara no pase de tres balas
											contador++;
											anim.SetInteger ("Contador", contador);

											//Mostramos las balas que nos quedan en la interfaz
											contador_ui--;
											cont = GameObject.Find ("Bullets").GetComponent<ContadorBalas> ();
											cont.Contar (contador_ui);
										}
									}
								}
							}else if (tiempoDisparar <= 0) {
								tiempoDisparar = TIEMPO_DISPARO;
								disparo = false;
							}
						}

						//Al dejar de pulsar...
						if (!Input.GetKey (KeyCode.Mouse0))
							anim.SetBool ("Fuego", false);

						//Descontamos el tiempo de la animacion para no disparar muy seguido
						if (disparo && tiempoDisparar > 0)
							tiempoDisparar -= Time.deltaTime;
					}
				}
			}else if (vars.level > 5 && vars.level < 12) {
				if (!noDisparar.opciones) {
					if (!noDisparar.pausa) {
						if (tiempoDisparar >= TIEMPO_DISPARO) {
							if (!recargar.reload && recargar.timeWaitShoot <= 0) {
								if (Input.GetKey (KeyCode.Mouse0) && !disparo) {
									//Mientras haya municion:
									if (contador < 2) {
										disparo = true;
										
										//Disparamos la bala
										Rigidbody _bala = (Rigidbody)Instantiate (bala, transform.position, transform.rotation);
										_bala.velocity = transform.TransformDirection (new Vector3 (0, 0, velocity));
										
										//Establecemos un raycast para saber con que colisionamos desde el centro de la camara 
										//hacia delante y guardamos la colision establecida con el objeto al que miramos en hit
										Camera camKornRak = GameObject.FindWithTag ("CamKornRak").GetComponent<Camera> ();
										if (Physics.Raycast (camKornRak.transform.position, camKornRak.transform.forward, out hit, 1000)) {
											//Agujereamos paredes
											Vector3 posBullet = hit.point;
											if (hit.collider.name == "Predio_A2")
												Instantiate (agujeroBala, posBullet, Quaternion.FromToRotation (Vector3.up, hit.normal));
										}
										
										//Ejecutamos la animacion y creamos una fuerza que sea la que impulse a la bala a salir en la direccion correcta
										anim.SetBool ("Fuego", true);
										
										//Instanciamos el sonido del disparo
										AudioSource _disparo = GetComponent<AudioSource>();
										_disparo.clip = clip;
										_disparo.Play ();
										
										//Controlamos que la recamara no pase de tres balas
										contador++;
										anim.SetInteger ("Contador", contador);
										
										//Mostramos las balas que nos quedan en la interfaz
										contador_ui--;
										cont = GameObject.Find ("Bullets").GetComponent<ContadorBalas> ();
										cont.Contar (contador_ui);
									}
								}
							}
						}else if (tiempoDisparar <= 0) {
							tiempoDisparar = TIEMPO_DISPARO;
							disparo = false;
						}
					}
					
					//Al dejar de pulsar...
					if (!Input.GetKey (KeyCode.Mouse0))
						anim.SetBool ("Fuego", false);
					
					//Descontamos el tiempo de la animacion para no disparar muy seguido
					if (disparo && tiempoDisparar > 0)
						tiempoDisparar -= Time.deltaTime;
				}
			}
		}
	}
}
