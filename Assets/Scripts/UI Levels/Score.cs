using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	GameObject text_1;
	VariablesGlobales vars;
	HardLevels nextLevel;
	NormalLevels _nextLevel;
	EasyLevels nextLevel_;


	void Update () {
		
		//Si hay game over en los diferentes niveles de dificultad:
		GameOver over = GameObject.Find ("GameOver").GetComponent<GameOver> ();
		vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		if (vars.d_hard) {
			nextLevel = GameObject.Find ("JuegoGeneral").GetComponent<HardLevels> ();
			Temporizador tempoLevel = GameObject.Find ("Timer").GetComponent<Temporizador> ();
			if (over.end || nextLevel.n_cats >= nextLevel.maxCatsKills && tempoLevel.timeLeft >= 0) {
				//Ocultamos etiquetas y numeros si hay un Game Over
				GameObject labelScore = GameObject.Find ("SCORE");
				Image _labelScore = labelScore.GetComponent<Image> ();
				_labelScore.enabled = false;
				text_1 = GameObject.Find ("Puntos");
				Text text_1_ = text_1.GetComponent<Text>();
				text_1_.enabled = false;
			}
		}else if (vars.d_normal) {
			_nextLevel = GameObject.Find ("JuegoGeneral").GetComponent<NormalLevels> ();
			Temporizador tempoLevel = GameObject.Find ("Timer").GetComponent<Temporizador> ();
			if (over.end || _nextLevel.n_cats >= _nextLevel.maxCatsKills && tempoLevel.timeLeft >= 0) {
				//Ocultamos etiquetas y numeros si hay un Game Over
				GameObject labelScore = GameObject.Find ("SCORE");
				Image _labelScore = labelScore.GetComponent<Image> ();
				_labelScore.enabled = false;
				text_1 = GameObject.Find ("Puntos");
				Text text_1_ = text_1.GetComponent<Text>();
				text_1_.enabled = false;
			}
		}else if (vars.d_easy) {
			nextLevel_ = GameObject.Find ("JuegoGeneral").GetComponent<EasyLevels> ();
			Temporizador tempoLevel = GameObject.Find ("Timer").GetComponent<Temporizador> ();
			if (over.end || nextLevel_.n_cats >= nextLevel_.maxCatsKills && tempoLevel.timeLeft >= 0) {
				//Ocultamos etiquetas y numeros si hay un Game Over
				GameObject labelScore = GameObject.Find ("SCORE");
				Image _labelScore = labelScore.GetComponent<Image> ();
				_labelScore.enabled = false;
				text_1 = GameObject.Find ("Puntos");
				Text text_1_ = text_1.GetComponent<Text>();
				text_1_.enabled = false;
			}
		}
	}

	//Metodo de puntuacion
	public void Puntuar (int p) {

		text_1 = GameObject.Find ("Puntos");
		Text text_1_ = text_1.GetComponent<Text>();
		vars = GameObject.Find ("Lanzador").GetComponent<VariablesGlobales> ();
		vars.puntos = p;
		text_1_.text = p.ToString ();
	}
}
