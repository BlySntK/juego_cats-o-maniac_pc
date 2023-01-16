using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ContadorBalas : MonoBehaviour {

	GameObject text_1;
	VariablesGlobales vars;
	HardLevels nextLevel_;
	NormalLevels nextLevel;
	EasyLevels _nextLevel;


	void Update () {
		
		vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		GameOver over = GameObject.Find ("GameOver").GetComponent<GameOver> ();
		if (vars.d_normal) {
			nextLevel = GameObject.Find ("JuegoGeneral").GetComponent<NormalLevels> ();
			Temporizador tempoLevel = GameObject.Find ("Timer").GetComponent<Temporizador> ();
			if (over.end || nextLevel.n_cats >= nextLevel.maxCatsKills && tempoLevel.timeLeft >= 0) {
				//Ocultamos etiquetas y numeros si hay un Game Over
				GameObject labelBalas = GameObject.Find ("Bullets");
				GameObject labelBullets = GameObject.Find ("Cartucho");
				Image labelBullets_ = labelBullets.GetComponent<Image> ();
				Text _labelBalas = labelBalas.GetComponent<Text> ();
				_labelBalas.enabled = false;
				labelBullets_.enabled = false;
				text_1 = GameObject.Find ("Munition");
				Text text_1_ = text_1.GetComponent<Text>();
				text_1_.enabled = false;
			}
		}else if (vars.d_hard) {
			nextLevel_ = GameObject.Find ("JuegoGeneral").GetComponent<HardLevels> ();
			Temporizador tempoLevel = GameObject.Find ("Timer").GetComponent<Temporizador> ();
			if (over.end || nextLevel_.n_cats >= nextLevel_.maxCatsKills && tempoLevel.timeLeft >= 0) {
				//Ocultamos etiquetas y numeros si hay un Game Over
				GameObject labelBalas = GameObject.Find ("Bullets");
				GameObject labelBullets = GameObject.Find ("Cartucho");
				Image labelBullets_ = labelBullets.GetComponent<Image> ();
				Text _labelBalas = labelBalas.GetComponent<Text> ();
				_labelBalas.enabled = false;
				labelBullets_.enabled = false;
				text_1 = GameObject.Find ("Munition");
				Text text_1_ = text_1.GetComponent<Text>();
				text_1_.enabled = false;
			}
		}else if (vars.d_easy) {
			_nextLevel = GameObject.Find ("JuegoGeneral").GetComponent<EasyLevels> ();
			Temporizador tempoLevel = GameObject.Find ("Timer").GetComponent<Temporizador> ();
			if (over.end || _nextLevel.n_cats >= _nextLevel.maxCatsKills && tempoLevel.timeLeft >= 0) {
				//Ocultamos etiquetas y numeros si hay un Game Over
				GameObject labelBalas = GameObject.Find ("Bullets");
				GameObject labelBullets = GameObject.Find ("Cartucho");
				Image labelBullets_ = labelBullets.GetComponent<Image> ();
				Text _labelBalas = labelBalas.GetComponent<Text> ();
				_labelBalas.enabled = false;
				labelBullets_.enabled = false;
				text_1 = GameObject.Find ("Munition");
				Text text_1_ = text_1.GetComponent<Text>();
				text_1_.enabled = false;
			}
		}
	}

	public void Contar (int balas) {

		text_1 = GameObject.Find ("Bullets");
		Text texto = GetComponent<Text> ();
		texto.text = balas.ToString ();
		vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		vars.n_balas = balas;
	}
}
