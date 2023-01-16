using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Credits_Init : MonoBehaviour {

	float _a, speed = 0.8f;
	float tiempoTransit;
	bool a, b, c, d, e; 
	[HideInInspector]
	public bool arriba, abajoIzquierda, centro, abajoCentro, abajoDerecha;
	Text texto;
	RectTransform texto_;
	float posYlocal;

	void Start () {

		texto = this.GetComponent<Text> ();
		texto_ = this.GetComponent<RectTransform> ();
		_a = texto.color.a;
		_a = 0;
		texto.color = new Color (texto.color.r, texto.color.g, texto.color.b, _a);
		tiempoTransit = 3;
		arriba = false;
	}


	void Update () {

		//Credtitos:
		//Aparece (Arriba)
		if (arriba) {
			float posXlocal = -355;
			posYlocal = 223.27f;
			texto_.localPosition = new Vector3 (posXlocal, posYlocal, texto_.localPosition.z);
			texto.text = "Created By\n\t Bly Snt K";
			if (tiempoTransit > 0 && !a)
				tiempoTransit -= Time.deltaTime;
			else if (tiempoTransit <=0 && !a) {
				_a += speed * Time.deltaTime;
				texto.color = new Color (texto.color.r, texto.color.g, texto.color.b, _a);

				if (_a >= 1) {
					tiempoTransit = 8;
					a = true;
				}
			}

			//Desaparece (Arriba)
			if (tiempoTransit > 0 && a)
				tiempoTransit -= Time.deltaTime;
			else if (tiempoTransit <= 0 && a) {
				_a -= Time.deltaTime;
				texto.color = new Color (texto.color.r, texto.color.g, texto.color.b, _a);

				if (_a <= 0) {
					tiempoTransit = 16;
					a = false;
					arriba = false;
					abajoIzquierda = true;
				}
			}
		}

		//Aparece (Abajo Izquierda)
		if (abajoIzquierda) {
			float posXlocal = -355;
			posYlocal = -260;
			texto_.localPosition = new Vector3 (texto_.localPosition.x, posYlocal, texto_.localPosition.z);
			texto.text = "Based in Original Tale\n\t  'Give Me Those Dead Cats'";
			if (tiempoTransit > 0 && !b)
				tiempoTransit -= Time.deltaTime;
			else if (tiempoTransit <= 0 && !b) {
				_a += speed * Time.deltaTime;
				texto.color = new Color (texto.color.r, texto.color.g, texto.color.b, _a);
				
				if (_a >= 1) {
					tiempoTransit = 8;
					b = true;
				}
			}

			if (tiempoTransit > 0 && b)
				tiempoTransit -= Time.deltaTime;
			else if (tiempoTransit <= 0 && b) {
				_a -= Time.deltaTime;
				texto.color = new Color (texto.color.r, texto.color.g, texto.color.b, _a);
				
				if (_a <= 0) {
					tiempoTransit = 16;
					b = false;
					abajoIzquierda = false;
					abajoCentro = true;
				}
			}
		}

		if (abajoCentro) {
			float posXlocal = 0;
			posYlocal = -249;
			texto_.localPosition = new Vector3 (posXlocal, posYlocal, texto_.localPosition.z);
			texto.text = "A Produced Game By\n\t\t  Blaisantka Project";
			if (tiempoTransit > 0 && !c)
				tiempoTransit -= Time.deltaTime;
			else if (tiempoTransit <= 0 && !c) {
				_a += speed * Time.deltaTime;
				texto.color = new Color (texto.color.r, texto.color.g, texto.color.b, _a);
				
				if (_a >= 1) {
					tiempoTransit = 8;
					c = true;
				}
			}
			
			if (tiempoTransit > 0 && c)
				tiempoTransit -= Time.deltaTime;
			else if (tiempoTransit <= 0 && c) {
				_a -= Time.deltaTime;
				texto.color = new Color (texto.color.r, texto.color.g, texto.color.b, _a);
				
				if (_a <= 0) {
					tiempoTransit = 16;
					c = false;
					abajoCentro = false;
					centro = true;
				}
			}
		}

		if (centro) {
			float posXlocal = -285;
			posYlocal = 0;
			texto_.localPosition = new Vector3 (posXlocal, posYlocal, texto_.localPosition.z);
			texto.text = "Designed & Programmed By\n\t\t  Bly Snt K";
			if (tiempoTransit > 0 && !d)
				tiempoTransit -= Time.deltaTime;
			else if (tiempoTransit <= 0 && !d) {
				_a += speed * Time.deltaTime;
				texto.color = new Color (texto.color.r, texto.color.g, texto.color.b, _a);
				
				if (_a >= 1) {
					tiempoTransit = 8;
					d = true;
				}
			}
			
			if (tiempoTransit > 0 && d)
				tiempoTransit -= Time.deltaTime;
			else if (tiempoTransit <= 0 && d) {
				_a -= Time.deltaTime;
				texto.color = new Color (texto.color.r, texto.color.g, texto.color.b, _a);
				
				if (_a <= 0) {
					tiempoTransit = 16;
					c = false;
					centro = false;
					abajoDerecha = true;
				}
			}
		}

		if (abajoDerecha) {
			float posXlocal = 374.7f;
			posYlocal = -249;
			texto_.localPosition = new Vector3 (posXlocal, posYlocal, texto_.localPosition.z);
			texto.text = "Directed By\n\t\t  Bly Snt K";
			if (tiempoTransit > 0 && !e)
				tiempoTransit -= Time.deltaTime;
			else if (tiempoTransit <= 0 && !e) {
				_a += speed * Time.deltaTime;
				texto.color = new Color (texto.color.r, texto.color.g, texto.color.b, _a);
				
				if (_a >= 1) {
					tiempoTransit = 8;
					e = true;
				}
			}
			
			if (tiempoTransit > 0 && e)
				tiempoTransit -= Time.deltaTime;
			else if (tiempoTransit <= 0 && e) {
				_a -= Time.deltaTime;
				texto.color = new Color (texto.color.r, texto.color.g, texto.color.b, _a);
				
				if (_a <= 0) {
					tiempoTransit = 16;
					e = false;
					centro = false;
					abajoDerecha = false;
				}
			}
		}
	}
}
