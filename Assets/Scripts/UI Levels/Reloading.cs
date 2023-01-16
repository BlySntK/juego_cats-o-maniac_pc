using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Reloading : MonoBehaviour {

	public bool reload;
	bool bloqueo;
	float _alpha; 
	float speed = 6.5f;
	public float timeWaitShoot;
	float timeHideText;

	void Update () {

		GameObject recargando = this.gameObject;
		Text texto = recargando.GetComponent<Text> ();
		GameOver over = GameObject.Find ("GameOver").GetComponent<GameOver> ();

		if (over.end) {

			//Ocultamos etiquetas y numeros si hay un Game Over
			GameObject labelReload = GameObject.Find ("Reloading");
			Text _labelReload = labelReload.GetComponent<Text> ();
			_labelReload.enabled = false;

		}else{
			if (reload) {
				if (timeWaitShoot == 0)
					timeWaitShoot = 0.8f;

				texto.text = "Reloading...";
				_alpha = texto.color.a;

				if (_alpha > 0 && !bloqueo) {
					_alpha -= speed * Time.deltaTime;
					texto.color = new Color (texto.color.r, texto.color.g, texto.color.b, _alpha);
				}else if (_alpha <= 0 && !bloqueo)
					bloqueo = true;

				if (_alpha < 1 && bloqueo) {
					_alpha += speed * Time.deltaTime;
					texto.color = new Color (texto.color.r, texto.color.g, texto.color.b, _alpha);
				}else if (_alpha >= 1 && bloqueo)
					bloqueo = false;

				if (_alpha < 1)
					_alpha += Time.deltaTime;
				else
					texto.color = new Color (texto.color.r, texto.color.g, texto.color.b, _alpha);

				if (_alpha >= 1) {
					if (reload) {
						if (timeWaitShoot > 0)
							timeWaitShoot -= Time.deltaTime;
						else{
							texto.text = "GO!";
							timeHideText = 1.8f;
							timeWaitShoot = 0;
							reload = false;
						}
					}
				}
			}else{
				if (timeHideText > 0 && !reload)
					timeHideText -= Time.deltaTime;
				else{
					texto.text = "";
					timeHideText = 1.8f;
				}
			}
		}
	}
}
