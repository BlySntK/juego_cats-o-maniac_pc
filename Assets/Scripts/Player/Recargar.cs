using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Recargar : MonoBehaviour {

	Disparar contador;
	AudioSource audio;
	bool recargando;
	Image pressR;
	bool dispose;
	public bool noPressR;
	AnimatorClipInfo[] infoClip;
	AnimatorStateInfo _infoClipState;
	public AudioClip[] clips;
	float tClip_aux = 0;
	float timeBefore = 0.4f;
	float timeReload = 0.43f;
	float timeAfter = 1.567f;
	float alpha;
	bool turn;


	void Update () {

		contador = GetComponent<Disparar>();
		audio = GetComponent<AudioSource> ();
		Reloading recargar = GameObject.Find ("Reloading").GetComponent<Reloading> ();
		GameOver over = GameObject.Find ("GameOver").GetComponent<GameOver> ();
		Opciones opciones = GameObject.Find ("JuegoGeneral").GetComponent<Opciones> ();
		if (!opciones.opciones) {
			if (!opciones.pausa) {
				if (!noPressR) {
					if (!over.end) {
						if (Input.GetKey (KeyCode.R) && contador.contador_ui <= 0) {
							recargando = true;
							recargar.reload = true;
							pressR = GameObject.Find ("PressR").GetComponent<Image> ();
							pressR.enabled = false;
						}else if (!Input.GetKey (KeyCode.R) && contador.contador_ui <= 0) {
							pressR = GameObject.Find ("PressR").GetComponent<Image> ();
							pressR.enabled = true;

							//Hacer parpadeo
							if (pressR.color.a > 0 && !turn) {
								alpha -= Time.deltaTime;
								pressR.color = new Color (pressR.color.r, pressR.color.g, pressR.color.b, alpha);
							}else if (pressR.color.a <= 0 && !turn)
								turn = true;
							if (pressR.color.a < 1 && turn) {
								alpha += Time.deltaTime;
								pressR.color = new Color (pressR.color.r, pressR.color.g, pressR.color.b, alpha);
							}else if (pressR.color.a >= 1 && turn)
								turn = false;
						}else if (!Input.GetKey (KeyCode.R) && contador.contador_ui > 0) {
							pressR = GameObject.Find ("PressR").GetComponent<Image> ();
							pressR.enabled = false;
						}
					}else
						pressR.enabled = false;
				}else
					pressR.enabled = false;
			
				if (recargando) {
					infoClip = contador.anim.GetCurrentAnimatorClipInfo (0);

					if (infoClip[0].clip.name == "Before Reload") {
						if (timeBefore > 0)
							timeBefore -= Time.deltaTime;
						else{
							contador.anim.SetBool ("Precarga", false);
							contador.anim.SetBool ("Recarga", true);
						}
					}else if (infoClip[0].clip.name == "Reload") {
						if (timeReload > 0) {
							timeReload -= Time.deltaTime;
							Recarga ();
						}else{
							contador.anim.SetBool ("Recarga", false);
							contador.anim.SetBool ("Dispuesto", true);
						}
					}else if (infoClip[0].clip.name == "After Reload") {
						if (timeAfter > 0) {
							timeAfter -= Time.deltaTime;

							if (!dispose) {
								dispose = true;
								Dispuesto ();
							}
						}else{
							contador.anim.SetBool ("Dispuesto", false);
							recargando = false;
							dispose = false;
						}
					}else if (infoClip[0].clip.name == "Idle")
						contador.anim.SetBool ("Precarga", true);
				}else{
					timeAfter = 1.567f;
					timeBefore = 0.4f;
					timeReload = 0.43f;
				}
			}
		}
	}
	
	void Recarga () {


		if (contador.contador > 0) {
			if (timeReload > 0) {
				audio.clip = clips[0];
				audio.pitch = 1.15f; 
				audio.Play ();
				contador.contador--;
				contador.contador_ui++;
				ContadorBalas cont = GameObject.Find ("Bullets").GetComponent<ContadorBalas> ();
				cont.Contar (contador.contador_ui);
				contador.anim.SetInteger ("Contador", contador.contador);
			}
		}
	}

	void Dispuesto () {

		if (contador.contador == 0) {
			if (timeAfter > 0) {
				audio.clip = clips[1];
				audio.Play ();
			}
		}
	}
}
